namespace IncotradeBackend.Application.Staff.GetAvailableStaffs
{
    public record GetAvailableStaffsResult
    {
        public int Id { get; init; }
        public string FullName { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public bool IsLocked { get; init; }
        public List<GetAvailableStaffsWorkScheduleResult> WorkSchedules { get; init; } = [];
        public DateTimeOffset CreatedAt { get; init; }
        public DateTimeOffset UpdatedAt { get; init; }
    }

    public record GetAvailableStaffsWorkScheduleResult
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
