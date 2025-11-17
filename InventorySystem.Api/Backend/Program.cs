using Backend.Data;
using Backend.Endpoints;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// ✅ Enable CORS for Blazor Dev
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorDev", policy =>
    {
        policy.WithOrigins( "http://localhost:5109",
            "https://localhost:7016",
            "http://192.168.10.20:5109",
            "https://192.168.10.20:5109",
            "http://192.168.10.20")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
var connString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseMySql(connString, ServerVersion.AutoDetect(connString)));


var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.UseCors("AllowBlazorDev");

app.UseAuthorization();
app.MapControllers();

app.MapUserEndpoints();

app.Run();