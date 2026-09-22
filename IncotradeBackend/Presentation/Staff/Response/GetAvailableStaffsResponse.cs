namespace IncotradeBackend.Presentation.Staff.Response
{
    public record GetAvailableStaffsResponse
    {
        public int Id { get; init; }
        public string FullName { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public bool IsLocked { get; init; }
        public List<GetAvailableStaffsWorkScheduleResponse> WorkSchedules { get; init; } = [];
        public DateTimeOffset CreatedAt { get; init; }
        public DateTimeOffset UpdatedAt { get; init; }
    }

    public record GetAvailableStaffsWorkScheduleResponse
    {
        public int Id { get; init; }
        public int StaffId { get; init; }
        public DateOnly WorkDate { get; init; }
        public TimeOnly StartTime { get; init; }
        public TimeOnly EndTime { get; init; }
        public DateTimeOffset CreatedAt { get; init; }
        public DateTimeOffset UpdatedAt { get; init; }
    }
}
