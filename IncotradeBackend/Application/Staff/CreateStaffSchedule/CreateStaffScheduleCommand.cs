namespace IncotradeBackend.Application.Staff.CreateStaffSchedule
{
    public record CreateStaffScheduleCommand
    {
        public int StaffId { get; init; }
        public DateOnly WorkDate { get; init; }
        public TimeOnly StartTime { get; init; }
        public TimeOnly EndTime { get; init; }
    }
}
