namespace IncotradeBackend.Presentation.Staff.Request
{
    public record UpdateStaffScheduleRequest
    {
        public string StaffScheduleId { get; init; } = string.Empty;
        public string StaffId { get; init; } = string.Empty;
        public string WorkDate { get; init; } = string.Empty;
        public string StartTime { get; init; } = string.Empty;
        public string EndTime { get; init; } = string.Empty;
    }
}
