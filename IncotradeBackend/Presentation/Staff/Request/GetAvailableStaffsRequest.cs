namespace IncotradeBackend.Presentation.Staff.Request
{
    public record GetAvailableStaffsRequest
    {
        public string Page { get; init; } = "1";
        public string Size { get; init; } = "7";
        public string? SearchFullName { get; init; }
    }
}
