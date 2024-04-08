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
});

app.MapGet("/api/animals/{id:int}", ([FromRoute] int id) =>
{
    var animal = DataBase.Animals.FirstOrDefault(an => an.Id == id);
    return animal is null ? Results.NotFound($"Animal with id {id} not found") : Results.Ok(animal);
});

app.MapPost("/api/animals", ([FromBody] Animal data) =>
{
    var animal = DataBase.Animals.Exists(an => an.Id == data.Id);
    if (animal) return Results.Conflict($"Animal with id {data.Id} already exists");
    return Results.Created($"/api/animals/{data.Id}", data);
});

app.UseHttpsRedirection();

app.Run();