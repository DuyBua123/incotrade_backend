namespace IncotradeBackend.Application.Booking.ConfirmBooking
{
    public record ConfirmBookingCommand
    {
        public int BookingId { get; init; }
    }
}
