namespace IncotradeBackend.Presentation.Service.Request
{
    public record UpdateServiceRequest
    {
        public string ServiceId { get; init; } = string.Empty;
        public string ServiceName { get; init; } = string.Empty;
        public string? Description { get; init; }
        public string DurationMinutes { get; init; } = string.Empty;
        public string Price { get; init; } = string.Empty;
        public string? IsLock { get; init; }
    }
}
