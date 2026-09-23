using FluentValidation;
using IncotradeBackend.Application.Booking.CompleteBooking;
using IncotradeBackend.Application.Booking.ConfirmBooking;
using IncotradeBackend.Application.Booking.CreateBooking;
using IncotradeBackend.Application.Booking.GetBookings;
using IncotradeBackend.Application.Booking.GetMyBookings;
using IncotradeBackend.Presentation.Booking.Request;
using IncotradeBackend.Presentation.Booking.Validator;

namespace IncotradeBackend.Infrastructure.Dependencies
{
    public static class BookingDependency
    {
        public static IServiceCollection AddBookingDependencies(
            this IServiceCollection services)
        {
            services.AddScoped<IValidator<CompleteBookingRequest>, CompleteBookingRequestValidator>();
            services.AddScoped<IValidator<ConfirmBookingRequest>, ConfirmBookingRequestValidator>();
            services.AddScoped<IValidator<CreateBookingRequest>, CreateBookingRequestValidator>();
            services.AddScoped<IValidator<GetBookingsRequest>, GetBookingsRequestValidator>();
            services.AddScoped<IValidator<GetMyBookingsRequest>, GetMyBookingsRequestValidator>();
            services.AddScoped<CompleteBookingUseCase>();
            services.AddScoped<ConfirmBookingUseCase>();
            services.AddScoped<CreateBookingUseCase>();
            services.AddScoped<GetBookingsUseCase>();
            services.AddScoped<GetMyBookingsUseCase>();

            return services;
        }
    }
}
