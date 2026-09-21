using FluentValidation;
using IncotradeBackend.Application.Staff.CreateStaff;
using IncotradeBackend.Application.Staff.GetStaff;
using IncotradeBackend.Application.Staff.GetStaffs;
using IncotradeBackend.Application.Staff.UpdateStaff;
using IncotradeBackend.Presentation.Staff.Request;
using IncotradeBackend.Presentation.Staff.Validator;

namespace IncotradeBackend.Infrastructure.Dependencies
{
    public static class StaffDependency
    {
        public static IServiceCollection AddStaffDependencies(
            this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateStaffRequest>, CreateStaffRequestValidator>();
            services.AddScoped<IValidator<GetStaffRequest>, GetStaffRequestValidator>();
            services.AddScoped<IValidator<GetStaffsRequest>, GetStaffsRequestValidator>();
            services.AddScoped<IValidator<UpdateStaffRequest>, UpdateStaffRequestValidator>();
            services.AddScoped<CreateStaffUseCase>();
            services.AddScoped<GetStaffUseCase>();
            services.AddScoped<GetStaffsUseCase>();
            services.AddScoped<UpdateStaffUseCase>();

            return services;
        }
    }
}
