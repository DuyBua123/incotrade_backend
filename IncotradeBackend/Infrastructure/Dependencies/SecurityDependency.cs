using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IncotradeBackend.Infrastructure.Security;

namespace IncotradeBackend.Infrastructure.Dependencies
{
    public static class SecurityDependency
    {
        public static IServiceCollection AddSecurityDependency(
            this IServiceCollection services)
        {
            // Register services
            services.AddScoped<JwtService>();


            return services;
        }
    }
}