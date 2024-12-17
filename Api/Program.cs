using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Repositories;
using Api.Services;
using Api.Interfaces;
using Api.Validations;
using FluentValidation;
using Api.DTOs;

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


builder.Services.AddScoped<IMedicationRepository, MedicationRepository>();
builder.Services.AddScoped<IClassificationRepository, ClassificationRepository>();
builder.Services.AddScoped<IMedicationActiveIngredientsRepository, MedicationActiveIngredientsRepository>();
builder.Services.AddScoped<IPharmaceuticalFormRepository, PharmaceuticalFormRepository>();
builder.Services.AddScoped<ITherapeuticClassRepository, TherapeuticClassRepository>();

builder.Services.AddScoped<MedicationService>();
builder.Services.AddScoped<ClassificationService>();
builder.Services.AddScoped<MedicationActiveIngredientsService>();
builder.Services.AddScoped<PharmaceuticalFormService>();
builder.Services.AddScoped<TherapeuticClassService>();

builder.Services.AddScoped<IValidator<MedicationRecordDTO>, CreateUpdateMedicationValidator>();
builder.Services.AddScoped<IValidator<CreateAndUpdateClassificationDto>, CreateUpdateClassificationValidator>();
builder.Services.AddScoped<IValidator<CreateUpdatePharmaceuticalFormDto>, CreateUpdatePharmaceuticalFormValidator>();
builder.Services.AddScoped<IValidator<CreateUpdateTherapeuticClassDto>, CreateUpdateTherapeuticValidator>();



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