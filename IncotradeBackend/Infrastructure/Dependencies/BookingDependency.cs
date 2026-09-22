using FluentValidation;
using IncotradeBackend.Application.Booking.CreateBooking;
using IncotradeBackend.Presentation.Booking.Request;
using IncotradeBackend.Presentation.Booking.Validator;

namespace IncotradeBackend.Infrastructure.Dependencies
{
    public static class BookingDependency
    {
        public static IServiceCollection AddBookingDependencies(
            this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateBookingRequest>, CreateBookingRequestValidator>();
            services.AddScoped<CreateBookingUseCase>();

            return services;
        }
    }
}
