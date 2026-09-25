using System.Text;
using FluentValidation.AspNetCore;
using Hangfire;
using Hangfire.PostgreSql;
using IncotradeBackend.Infrastructure.Api;
using IncotradeBackend.Infrastructure.CronJob;
using IncotradeBackend.Infrastructure.Database;
using IncotradeBackend.Infrastructure.Database.Model;
using IncotradeBackend.Infrastructure.Database.Seed;
using IncotradeBackend.Infrastructure.Dependencies;
using IncotradeBackend.Infrastructure.Exceptions;
using IncotradeBackend.Infrastructure.WebSocket;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
builder.Services.AddStaffDependencies();
builder.Services.AddBookingDependencies();

// Register Swagger/OpenAPI
builder.Services.AddOpenApi();

// Register Api Behavior
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

// Register Hangfire
builder.Services.AddHangfire(config => config
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UsePostgreSqlStorage(options =>
    {
        options.UseNpgsqlConnection(builder.Configuration.GetConnectionString("Dev"));
    }));
builder.Services.AddHangfireServer();
builder.Services.AddScoped<CleanupOverdueBooking>();


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
            // Handling authentication error:
            // Missing Access Token in Authorization: Bearer
            // Access Token expired
            // Access Token with invalid signature, tempreed, issuer, audience
            OnChallenge = async context =>
            {
                context.HandleResponse();

                context.Response.StatusCode = StatusCodes.Status401Unauthorized;

                context.Response.Headers.WWWAuthenticate = "Bearer";

                await context.Response.WriteAsJsonAsync(
                    FailureResponse<string>.Failure(
                        "Chưa được xác thực.",
                        ErrorCodes.UNAUTHENTICATED_ERROR,
                        "Chưa được xác thực."
                    )
                );
            },

            // OnForbidden = async context =>
            // {
            //     context.Response.StatusCode = StatusCodes.Status403Forbidden;
            //     context.Response.ContentType = "application/json";

            //     await context.Response.WriteAsJsonAsync(
            //         FailureResponse<object>.FailureMessage(
            //             "API Forbidden",
            //             ErrorCodes.API_FORBIDDEN_ERROR));
            // }
            OnMessageReceived = context =>
            {
                var accessToken = context.Request.Query["access_token"];
                var path = context.HttpContext.Request.Path;

                if (!string.IsNullOrEmpty(accessToken) &&
                    path.StartsWithSegments("/hubs/update-booking-status"))
                {
                    context.Token = accessToken;
                }

                return Task.CompletedTask;
            },
        };
    });
builder.Services.AddAuthorization();

// Register Controller
builder.Services.AddControllers(options =>
{
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
});


// Add SignalR
builder.Services.AddSignalR();

builder.Services.AddSingleton<IUserIdProvider, SignalrUserIdProvider>();

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

app.MapHub<UpdateBookingStatusNotificationHub>("/hubs/update-booking-status/notification");

// Cron jobs
using (var scope = app.Services.CreateScope())
{
    var recurringJobManager =
        scope.ServiceProvider.GetRequiredService<IRecurringJobManager>();

    recurringJobManager.AddOrUpdate<CleanupOverdueBooking>(
        "database-backup",
        job => job.ExecuteAsync(),
        Cron.Minutely,
        new RecurringJobOptions
        {
            TimeZone = TimeZoneInfo.FindSystemTimeZoneById(
                OperatingSystem.IsWindows()
                    ? "SE Asia Standard Time"
                    : "Asia/Ho_Chi_Minh"
            )
        }
    );
}

app.Run();
