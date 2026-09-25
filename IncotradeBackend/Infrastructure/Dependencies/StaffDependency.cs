using FluentValidation;
using IncotradeBackend.Application.Staff.CreateStaff;
using IncotradeBackend.Application.Staff.CreateStaffSchedule;
using IncotradeBackend.Application.Staff.GetAvailableStaffs;
using IncotradeBackend.Application.Staff.GetStaff;
using IncotradeBackend.Application.Staff.GetStaffSchedule;
using IncotradeBackend.Application.Staff.GetStaffSchedules;
using IncotradeBackend.Application.Staff.GetStaffs;
using IncotradeBackend.Application.Staff.UpdateStaff;
using IncotradeBackend.Application.Staff.UpdateStaffSchedule;
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
            services.AddScoped<IValidator<CreateStaffScheduleRequest>, CreateStaffScheduleRequestValidator>();
            services.AddScoped<IValidator<GetStaffRequest>, GetStaffRequestValidator>();
            services.AddScoped<IValidator<GetStaffScheduleRequest>, GetStaffScheduleRequestValidator>();
            services.AddScoped<IValidator<GetStaffSchedulesRequest>, GetStaffSchedulesRequestValidator>();
            services.AddScoped<IValidator<GetStaffsRequest>, GetStaffsRequestValidator>();
            services.AddScoped<IValidator<GetAvailableStaffsRequest>, GetAvailableStaffsRequestValidator>();
            services.AddScoped<IValidator<UpdateStaffRequest>, UpdateStaffRequestValidator>();
            services.AddScoped<IValidator<UpdateStaffScheduleRequest>, UpdateStaffScheduleRequestValidator>();
            services.AddScoped<CreateStaffUseCase>();
            services.AddScoped<CreateStaffScheduleUseCase>();
            services.AddScoped<GetAvailableStaffsUseCase>();
            services.AddScoped<GetStaffUseCase>();
            services.AddScoped<GetStaffScheduleUseCase>();
            services.AddScoped<GetStaffSchedulesUseCase>();
            services.AddScoped<GetStaffsUseCase>();
            services.AddScoped<UpdateStaffUseCase>();
            services.AddScoped<UpdateStaffScheduleUseCase>();

            return services;
        }
    }
}
