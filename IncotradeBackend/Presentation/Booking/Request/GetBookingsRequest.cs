namespace IncotradeBackend.Presentation.Booking.Request
{
    public record GetBookingsRequest
    {
        public string Page { get; init; } = "1";
        public string Size { get; init; } = "7";
        public string? ServedDate { get; init; }
        public string? Status { get; init; }
    }
}
