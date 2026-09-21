namespace IncotradeBackend.Presentation.Staff.Request
{
    public record GetStaffRequest
    {
        public string StaffId { get; init; } = string.Empty;
    }
}
