using IncotradeBackend.Infrastructure.Database.Enum;

namespace IncotradeBackend.Application.Booking.GetMyBookings
{
    public record GetMyBookingsCommand
    {
        public int CustomerId { get; init; }
        public DateOnly? ServedDate { get; init; }
        public BookingStatus? Status { get; init; }
        public int Page { get; init; } = 1;
        public int Size { get; init; } = 7;
    }
}
