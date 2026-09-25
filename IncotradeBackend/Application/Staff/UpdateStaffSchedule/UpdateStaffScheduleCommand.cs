namespace IncotradeBackend.Application.Staff.UpdateStaffSchedule
{
    public record UpdateStaffScheduleCommand
    {
        public int StaffScheduleId { get; init; }
        public int StaffId { get; init; }
        public DateOnly WorkDate { get; init; }
        public TimeOnly StartTime { get; init; }
        public TimeOnly EndTime { get; init; }
    }
}
