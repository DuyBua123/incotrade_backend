namespace IncotradeBackend.Application.Service.GetAvailableServices
{
    public record GetAvailableServicesCommand
    {
        public int Page { get; init; } = 1;
        public int Size { get; init; } = 7;
        public string? SearchName { get; init; }
    }
}
