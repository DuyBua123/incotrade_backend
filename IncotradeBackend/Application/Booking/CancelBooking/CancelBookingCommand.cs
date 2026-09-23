namespace IncotradeBackend.Application.Booking.CancelBooking
{
    public record CancelBookingCommand
    {
        public int BookingId { get; init; }
        public int CustomerId { get; init; }
        public string CancellationReason { get; init; } = string.Empty;
    }
}
