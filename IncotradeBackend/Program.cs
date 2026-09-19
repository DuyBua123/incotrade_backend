using IncotradeBackend.Infrastructure.Database;
using IncotradeBackend.Infrastructure.Database.Model;
using IncotradeBackend.Infrastructure.Database.Seed;
using IncotradeBackend.Infrastructure.Dependencies;
using IncotradeBackend.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
builder.Services.AddAuthenticationDependencies(builder.Configuration);

// Register Swagger/OpenAPI
builder.Services.AddOpenApi();

// Register Api Behavior
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = actionContext =>
    {
        throw new InputValidationException(actionContext.ModelState);
    };
});

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
