namespace IncotradeBackend.Presentation.Staff.Request
{
    public record GetStaffScheduleRequest
    {
        public string StaffScheduleId { get; init; } = string.Empty;
    }
}
