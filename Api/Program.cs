using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Repositories;
using Api.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddScoped<MedicationRepository>();
builder.Services.AddScoped<ClassificationRepository>();
builder.Services.AddScoped<MedicationActiveIngredientsRepository>();
builder.Services.AddScoped<PharmaceuticalFormRepository>();
builder.Services.AddScoped<TherapeuticClassRepository>();

builder.Services.AddScoped<MedicationService>();
builder.Services.AddScoped<ClassificationService>();
builder.Services.AddScoped<MedicationActiveIngredientsService>();
builder.Services.AddScoped<PharmaceuticalFormService>();
builder.Services.AddScoped<TherapeuticClassService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();