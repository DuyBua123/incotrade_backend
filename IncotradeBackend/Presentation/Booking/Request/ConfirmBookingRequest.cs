namespace IncotradeBackend.Presentation.Booking.Request
{
    public record ConfirmBookingRequest
    {
        public string BookingId { get; init; } = string.Empty;
    }
}
