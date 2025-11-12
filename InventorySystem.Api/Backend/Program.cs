using Backend.Data;
using Backend.Endpoints;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseMySql(connString, ServerVersion.AutoDetect(connString)));


var app = builder.Build();

app.MapGet("/", () => "Hello World!");


app.MapUserEndpoints();

app.Run();
