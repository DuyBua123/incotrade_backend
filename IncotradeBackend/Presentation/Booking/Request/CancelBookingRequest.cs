namespace IncotradeBackend.Presentation.Booking.Request
{
    public record CancelBookingRequest
    {
        public string BookingId { get; init; } = string.Empty;
        public string CancellationReason { get; init; } = string.Empty;
    }
}
