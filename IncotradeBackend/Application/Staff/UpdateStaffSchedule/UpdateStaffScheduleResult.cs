namespace IncotradeBackend.Application.Staff.UpdateStaffSchedule
{
    public record UpdateStaffScheduleResult
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
