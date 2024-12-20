
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Text;
using System.Threading.Tasks;

public class ResponseMiddleware
{
    private readonly RequestDelegate _next;

    public ResponseMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var originalBodyStream = context.Response.Body;

        using (var responseBody = new MemoryStream())
        {
            context.Response.Body = responseBody;

            await _next(context);

            context.Response.Body = originalBodyStream;
            context.Response.Clear();
            context.Response.ContentType = "application/json";

            responseBody.Seek(0, SeekOrigin.Begin);
            var responseBodyText = await new StreamReader(responseBody).ReadToEndAsync();
            responseBody.Seek(0, SeekOrigin.Begin);

            var formattedResponse = new
            {
                data = responseBodyText
            };

            var jsonResponse = System.Text.Json.JsonSerializer.Serialize(formattedResponse);
            await context.Response.WriteAsync(jsonResponse, Encoding.UTF8);
        }
    }
}