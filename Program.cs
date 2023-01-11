using MedicalTrack.Data;
using MedicalTrack.src.Drug.Service;
using MedicalTrack.src.Patient.Service;
using MedicalTrack.src.Schedule.Service;
using MedicalTrack.src.Test.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MedicalContext>(options =>{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DatabaseConnection"));
});
builder.Services.AddScoped<PatientService>();
builder.Services.AddScoped<DrugService>();
builder.Services.AddScoped<ScheduleService>();
builder.Services.AddScoped<TestService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
