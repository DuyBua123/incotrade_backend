namespace IncotradeBackend.Application.Service.CreateService
{
    public record CreateServiceCommand
    {
        public string ServiceName { get; init; } = string.Empty;
        public string? Description { get; init; }
        public int DurationMinutes { get; init; }
        public long Price { get; init; }
        public bool IsLock { get; init; }
    }
}
