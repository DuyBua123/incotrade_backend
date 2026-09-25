namespace IncotradeBackend.Application.Service.UpdateService
{
    public record UpdateServiceCommand
    {
        public int ServiceId { get; init; }
        public string ServiceName { get; init; } = string.Empty;
        public string? Description { get; init; }
        public int DurationMinutes { get; init; }
        public long Price { get; init; }
        public bool? IsLock { get; init; }
    }
}
