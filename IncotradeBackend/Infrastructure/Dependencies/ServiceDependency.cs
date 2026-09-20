using FluentValidation;
using IncotradeBackend.Application.Service.CreateService;
using IncotradeBackend.Application.Service.GetService;
using IncotradeBackend.Application.Service.GetServices;
using IncotradeBackend.Application.Service.UpdateService;
using IncotradeBackend.Presentation.Service.Request;
using IncotradeBackend.Presentation.Service.Validator;

namespace IncotradeBackend.Infrastructure.Dependencies
{
    public static class ServiceDependency
    {
        public static IServiceCollection AddServiceDependencies(
            this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateServiceRequest>, CreateServiceRequestValidator>();
            services.AddScoped<IValidator<GetServicesRequest>, GetServicesRequestValidator>();
            services.AddScoped<IValidator<GetServiceRequest>, GetServiceRequestValidator>();
            services.AddScoped<IValidator<UpdateServiceRequest>, UpdateServiceRequestValidator>();
            services.AddScoped<CreateServiceUseCase>();
            services.AddScoped<GetServicesUseCase>();
            services.AddScoped<GetServiceUseCase>();
            services.AddScoped<UpdateServiceUseCase>();

            return services;
        }
    }
}
