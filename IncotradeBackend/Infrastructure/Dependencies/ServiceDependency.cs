using IncotradeBackend.Application.Service.GetServices;

namespace IncotradeBackend.Infrastructure.Dependencies
{
    public static class ServiceDependency
    {
        public static IServiceCollection AddServiceDependencies(
            this IServiceCollection services)
        {
            services.AddScoped<GetServicesUseCase>();

            return services;
        }
    }
}
