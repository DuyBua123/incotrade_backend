namespace IncotradeBackend.Presentation.Staff.Response
{
    public record CreateStaffScheduleResponse
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
