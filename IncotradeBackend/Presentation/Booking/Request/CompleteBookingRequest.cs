namespace IncotradeBackend.Presentation.Booking.Request
{
    public record CompleteBookingRequest
    {
        public string BookingId { get; init; } = string.Empty;
    }
}
