namespace IncotradeBackend.Presentation.Staff.Request
{
    public record CreateStaffScheduleRequest
    {
        public string StaffId { get; init; } = string.Empty;
        public string WorkDate { get; init; } = string.Empty;
        public string StartTime { get; init; } = string.Empty;
        public string EndTime { get; init; } = string.Empty;
    }
}
