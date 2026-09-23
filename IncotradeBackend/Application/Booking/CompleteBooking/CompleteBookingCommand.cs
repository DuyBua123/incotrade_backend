namespace IncotradeBackend.Application.Booking.CompleteBooking
{
    public record CompleteBookingCommand
    {
        public int BookingId { get; init; }
    }
}
