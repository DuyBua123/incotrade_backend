namespace IncotradeBackend.Application.Service.SetServiceLocking
{
    public record SetServiceLockingCommand
    {
        public int ServiceId { get; init; }
        public bool IsLock { get; init; }
    }
}
