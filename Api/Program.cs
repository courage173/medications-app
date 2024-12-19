using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Repositories;
using Api.Services;
using Api.Interfaces;
using FluentValidation.AspNetCore;
using Api.DTOs;
using Api.Middleware;
using FluentValidation;
using Api.Validations;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<CreateUpdateMedicationValidator>();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddScoped<IMedicationRepository, MedicationRepository>();
builder.Services.AddScoped<IMedicationActiveIngredientsRepository, MedicationActiveIngredientsRepository>();
builder.Services.AddScoped<IPharmaceuticalFormRepository, PharmaceuticalFormRepository>();
builder.Services.AddScoped<ITherapeuticClassRepository, TherapeuticClassRepository>();
builder.Services.AddScoped<IATCCodepository, ATCCodepository>();
builder.Services.AddScoped<IActiveIngredientRepository, ActiveIngredientRepository>();

builder.Services.AddScoped<MedicationService>();
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

app.UseCors(builder => builder
     .AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader());

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();