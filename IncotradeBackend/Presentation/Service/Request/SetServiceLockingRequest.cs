namespace IncotradeBackend.Presentation.Service.Request
{
    public record SetServiceLockingRequest
    {
        public string ServiceId { get; init; } = string.Empty;
        public string IsLocked { get; init; } = string.Empty;
    }
}
