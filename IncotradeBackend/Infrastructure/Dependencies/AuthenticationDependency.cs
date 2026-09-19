using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using IncotradeBackend.Application.Authentication.Login;
using IncotradeBackend.Application.Authentication.Me;
using IncotradeBackend.Application.Authentication.RefreshToken;
using IncotradeBackend.Presentation.Authentication.Validator;

namespace IncotradeBackend.Infrastructure.Dependencies
{
    public static class AuthenticationDependency
    {
        public static IServiceCollection AddAuthenticationDependencies(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // Register authentication services
            services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
            services.AddScoped<LoginUseCase>();
            services.AddScoped<MeUseCase>();
            services.AddScoped<RefreshTokenUseCase>();


            return services;
        }
    }
}
