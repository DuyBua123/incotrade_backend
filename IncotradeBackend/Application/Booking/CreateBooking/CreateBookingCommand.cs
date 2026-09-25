namespace IncotradeBackend.Application.Booking.CreateBooking
{
    public record CreateBookingCommand
    {
        public int CustomerId { get; init; }
        public int ServiceId { get; init; }
        public int StaffScheduleId { get; init; }
        public TimeOnly StartTime { get; init; }
        public string? CustomerNote { get; init; }
    }
}
