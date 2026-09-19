using IncotradeBackend.Infrastructure.Database;
using IncotradeBackend.Infrastructure.Database.Model;
using IncotradeBackend.Infrastructure.Database.Seed;
using IncotradeBackend.Infrastructure.Dependencies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Register PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("Dev")
    )
);

// Register Password Haasher
builder.Services.AddSingleton<PasswordHasher<User>>();

// Register Dependencies
builder.Services.AddSecurityDependency();

// Register Swagger/OpenAPI
builder.Services.AddOpenApi();

// Register Controller
builder.Services.AddControllers();

// Register Auto-run on Startup Service
builder.Services.AddHostedService<PasswordGenerationService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
