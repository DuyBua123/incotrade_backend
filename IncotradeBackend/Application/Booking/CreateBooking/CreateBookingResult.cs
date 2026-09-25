using IncotradeBackend.Infrastructure.Database.Enum;

namespace IncotradeBackend.Application.Booking.CreateBooking
{
    public record CreateBookingResult
    {
        public int Id { get; init; }
        public string BookingCode { get; init; } = string.Empty;
        public int CustomerId { get; init; }
        public int ServiceId { get; init; }
        public int StaffId { get; init; }
        public DateOnly ServedDate { get; init; }
        public TimeOnly StartTime { get; init; }
        public TimeOnly EndTime { get; init; }
        public BookingStatus Status { get; init; }
        public string? CustomerNote { get; init; }
        public DateTimeOffset CreatedAt { get; init; }
        public DateTimeOffset UpdatedAt { get; init; }
    }
}
