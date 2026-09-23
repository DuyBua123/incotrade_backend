using IncotradeBackend.Infrastructure.Database.Enum;

namespace IncotradeBackend.Application.Booking.GetBookings
{
    public record GetBookingsResult
    {
        public int Id { get; init; }
        public string BookingCode { get; init; } = string.Empty;
        public int CustomerId { get; init; }
        public string CustomerFullName { get; init; } = string.Empty;
        public string ServiceName { get; init; } = string.Empty;
        public string StaffFullName { get; init; } = string.Empty;
        public DateOnly ServedDate { get; init; }
        public TimeOnly StartTime { get; init; }
        public TimeOnly EndTime { get; init; }
        public BookingStatus Status { get; init; }
        public string? CustomerNote { get; init; }
        public string? CancellationReason { get; init; }
        public DateTimeOffset CreatedAt { get; init; }
        public DateTimeOffset UpdatedAt { get; init; }
    }
}
