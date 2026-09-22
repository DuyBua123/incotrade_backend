namespace IncotradeBackend.Presentation.Booking.Response
{
    public record GetMyBookingsResponse
    {
        public int Id { get; init; }
        public string BookingCode { get; init; } = string.Empty;
        public int CustomerId { get; init; }
        public int ServiceId { get; init; }
        public int StaffId { get; init; }
        public DateOnly ServedDate { get; init; }
        public TimeOnly StartTime { get; init; }
        public TimeOnly EndTime { get; init; }
        public string Status { get; init; } = string.Empty;
        public string? CustomerNote { get; init; }
        public string? CancellationReason { get; init; }
        public DateTimeOffset CreatedAt { get; init; }
        public DateTimeOffset UpdatedAt { get; init; }
    }
}
