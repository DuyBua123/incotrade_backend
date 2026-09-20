using FluentValidation;
using IncotradeBackend.Application.Service.GetService;
using IncotradeBackend.Application.Service.GetServices;
using IncotradeBackend.Presentation.Service.Request;
using IncotradeBackend.Presentation.Service.Validator;

namespace IncotradeBackend.Infrastructure.Dependencies
{
    public static class ServiceDependency
    {
        public static IServiceCollection AddServiceDependencies(
            this IServiceCollection services)
        {
            services.AddScoped<IValidator<GetServicesRequest>, GetServicesRequestValidator>();
            services.AddScoped<IValidator<GetServiceRequest>, GetServiceRequestValidator>();
            services.AddScoped<GetServicesUseCase>();
            services.AddScoped<GetServiceUseCase>();

            return services;
        }
    }
}
