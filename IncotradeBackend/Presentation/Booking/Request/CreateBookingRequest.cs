namespace IncotradeBackend.Presentation.Booking.Request
{
    public record CreateBookingRequest
    {
        public string ServiceId { get; init; } = string.Empty;
        public string StaffScheduleId { get; init; } = string.Empty;
        public string StartTime { get; init; } = string.Empty;
        public string? CustomerNote { get; init; }
    }
}
