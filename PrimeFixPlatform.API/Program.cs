using Microsoft.EntityFrameworkCore;
using PrimeFixPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add DbContext with PostgresSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.MapGet("/test-db", async (AppDbContext db) =>
{
    try
    {
        var canConnect = await db.Database.CanConnectAsync();
        return canConnect
            ? Results.Ok("Conexión exitosa a PostgreSQL!")
            : Results.Problem("No se pudo conectar a PostgreSQL");
    }
    catch (Exception ex)
    {
        return Results.Problem("Error: " + ex.Message);
    }
});

app.Run();