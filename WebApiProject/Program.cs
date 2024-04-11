using Microsoft.AspNetCore.Mvc;
using WebApiProject.DataBase;
using WebApiProject.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/api/animals", () =>
{
    var animals = DataBase.Animals;
    return Results.Ok(animals);
}).WithName("GetAnimals").WithOpenApi();

app.MapGet("/api/animals/{id:int}", ([FromRoute] int id) =>
{
    var animal = DataBase.Animals.FirstOrDefault(an => an.Id == id);
    return animal is null ? Results.NotFound($"Animal with id {id} not found") : Results.Ok(animal);
}).WithName("GetAnimal").WithOpenApi();

app.MapPost("/api/animals", ([FromBody] Animal data) =>
{
    var exists = DataBase.Animals.Exists(an => an.Id == data.Id);
    if (exists) return Results.Conflict($"Animal with id {data.Id} already exists");
    return Results.Created($"/api/animals/{data.Id}", data);
}).WithName("CreateAnimal").WithOpenApi();

app.MapPost("/api/animals/{id:int}", ([FromRoute] int id, [FromBody] Animal data) =>
{
    var animal = DataBase.Animals.FirstOrDefault(a => a.Id == id);
    if (animal is null) return Results.NotFound($"Animal with id {id} not found");
    DataBase.Animals.Remove(animal);
    DataBase.Animals.Add(data);
    return Results.NoContent();
}).WithName("UpdateAnimal").WithOpenApi();

app.MapDelete("/api/animals/{id:int}", ([FromRoute] int id) =>
{
    var animal = DataBase.Animals.FirstOrDefault(a => a.Id == id);
    if (animal is null) return Results.NotFound($"Animal with id {id} not found");
    DataBase.Animals.Remove(animal);
    return Results.NoContent();
}).WithName("DeleteAnimal").WithOpenApi();

app.MapGet("/api/appointments/{id:int}", ([FromRoute] int id) =>
{
    var appointments = DataBase.Appointments.FindAll((appointment) => appointment.Animal.Id == id).ToList();
    if (appointments.Count == 0) return Results.NotFound($"Appointment for Animal with id {id} not found");
    return Results.Ok(appointments);
}).WithName("GetAppointmentByAnimalID").WithOpenApi();

app.MapPost("/api/appointments", ([FromBody] Appointment data) =>
{
    var exists = DataBase.Appointments.Exists(ap => ap.Date == data.Date);
    if (exists) return Results.Conflict($"Appointment on this date {data.Date} already exists");
    var animal = data.Animal;
    if (!DataBase.Animals.Contains(animal))
        return Results.Conflict($"Animal does not exist in database. First add animal.");
    DataBase.Appointments.Add(data);
    return Results.Created();
}).WithName("CreateAppointment").WithOpenApi();

app.UseHttpsRedirection();
app.Run();