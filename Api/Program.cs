using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Repositories;
using Api.Services;
using Api.Interfaces;
using Api.Validations;
using FluentValidation;
using FluentValidation.AspNetCore;
using Api.DTOs;
using Api.Middleware;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddScoped<IMedicationRepository, MedicationRepository>();
builder.Services.AddScoped<IClassificationRepository, ClassificationRepository>();
builder.Services.AddScoped<IMedicationActiveIngredientsRepository, MedicationActiveIngredientsRepository>();
builder.Services.AddScoped<IPharmaceuticalFormRepository, PharmaceuticalFormRepository>();
builder.Services.AddScoped<ITherapeuticClassRepository, TherapeuticClassRepository>();
builder.Services.AddScoped<IATCCodepository, ATCCodepository>();
builder.Services.AddScoped<IActiveIngredientRepository, ActiveIngredientRepository>();

builder.Services.AddScoped<MedicationService>();
builder.Services.AddScoped<ClassificationService>();
builder.Services.AddScoped<MedicationActiveIngredientsService>();
builder.Services.AddScoped<PharmaceuticalFormService>();
builder.Services.AddScoped<TherapeuticClassService>();
builder.Services.AddScoped<ATCCodeService>();
builder.Services.AddScoped<ActiveIngredientService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();