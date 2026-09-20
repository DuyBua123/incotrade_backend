using System.Text;
using FluentValidation.AspNetCore;
using IncotradeBackend.Infrastructure.Database;
using IncotradeBackend.Infrastructure.Database.Model;
using IncotradeBackend.Infrastructure.Database.Seed;
using IncotradeBackend.Infrastructure.Dependencies;
using IncotradeBackend.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Register custom Exception Handler
builder.Services.AddExceptionHandler<ExceptionHandler>();
builder.Services.AddProblemDetails();

// Register PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("Dev")
    )
);

// Register Password Haasher
builder.Services.AddSingleton<PasswordHasher<User>>();

// Register Fluent Validation Auto-Validation
builder.Services.AddFluentValidationAutoValidation();

// Register Dependencies
builder.Services.AddSecurityDependency();
builder.Services.AddAuthenticationDependencies(builder.Configuration);
builder.Services.AddServiceDependencies();

// Register Swagger/OpenAPI
builder.Services.AddOpenApi();

// Register Api Behavior
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

// Register CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: "IncodetradeCorsPolicy",
        policy =>
        {
            policy.WithOrigins("https://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        }
    );
});

// Register JWT Bearer Authentication
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],

            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };

        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                context.HttpContext.Items["AuthException"] =
                    context.Exception;

                return Task.CompletedTask;
            },

            // OnChallenge = async context =>
            // {
            //     context.HandleResponse();

            //     var exception = context.HttpContext.Items["AuthException"] as UnauthenticatedException;


            //     context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            //     context.Response.ContentType = "application/json";

            //     await context.Response.WriteAsJsonAsync(
            //         FailureResponse<object>.FailureMessage(
            //             exception!.Message,
            //             ErrorCodes.UNAUTHENTICATED_ERROR));
            // },

            // OnForbidden = async context =>
            // {
            //     context.Response.StatusCode = StatusCodes.Status403Forbidden;
            //     context.Response.ContentType = "application/json";

            //     await context.Response.WriteAsJsonAsync(
            //         FailureResponse<object>.FailureMessage(
            //             "API Forbidden",
            //             ErrorCodes.API_FORBIDDEN_ERROR));
            // }
        };
    });
builder.Services.AddAuthorization();

// Register Controller
builder.Services.AddControllers(options =>
{
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
});

// Register Auto-run on Startup Service
builder.Services.AddHostedService<PasswordGenerationService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseExceptionHandler();

app.UseCors("IncodetradeCorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
