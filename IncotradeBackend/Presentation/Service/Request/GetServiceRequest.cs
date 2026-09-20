namespace IncotradeBackend.Presentation.Service.Request
{
    public record GetServiceRequest
    {
        public string ServiceId { get; init; } = string.Empty;
    }
}
