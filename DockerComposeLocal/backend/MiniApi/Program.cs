using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    // Deze CORS policy bekijkt enkel de host, niet poort en http(s) scheme.
    // Je hebt veel vrijheid om de policy te configureren.
    options.AddDefaultPolicy(
        policy =>
        {
            policy.SetIsOriginAllowed(origin =>
                new Uri(origin).Host == "localhost"); 
        });
    // AllowAnyOrigin() is een eenvoudige manier om alle hosts toe te staan, maar dat gebruik je niet in productie!
});

var app = builder.Build();

app.MapGet("/", (IConfiguration config) =>
{
    using var dbConnection = new MySqlConnection(config["MYSQL_CONNECTION_STRING"]);
    var results = dbConnection.Query<DemoItem>("SELECT Id, Title, Description FROM composedemo.DemoItems").ToArray();
    var randomPick = results[Random.Shared.Next(results.Length)];
    return randomPick.Title + " - " + randomPick.Description;
});

app.UseCors();

app.Run();

public record DemoItem(int Id, string Title, string Description);