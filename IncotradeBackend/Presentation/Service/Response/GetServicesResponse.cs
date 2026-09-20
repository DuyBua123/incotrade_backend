namespace IncotradeBackend.Presentation.Service.Response
{
    public record GetServicesResponse
    {
        public int Id { get; init; }
        public string Name { get; init; } = string.Empty;
        public string? Description { get; init; }
        public int DurationMinutes { get; init; }
        public long Price { get; init; }
        public bool IsLocked { get; init; }
        public DateTimeOffset CreatedAt { get; init; }
        public DateTimeOffset UpdatedAt { get; init; }
    }
}
