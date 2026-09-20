namespace IncotradeBackend.Presentation.Service.Request
{
    public record GetServicesRequest
    {
        public string Page { get; init; } = "1";
        public string Size { get; init; } = "7";
        public string? SearchName { get; init; }
    }
}
