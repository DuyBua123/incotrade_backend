namespace IncotradeBackend.Presentation.Staff.Request
{
    public record GetStaffSchedulesRequest
    {
        public string StaffId { get; init; } = string.Empty;
        public string Page { get; init; } = "1";
        public string Size { get; init; } = "7";
    }
}
