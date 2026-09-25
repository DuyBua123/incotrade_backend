namespace IncotradeBackend.Application.Staff.GetStaffSchedules
{
    public record GetStaffSchedulesCommand
    {
        public int StaffId { get; init; }
        public int Page { get; init; } = 1;
        public int Size { get; init; } = 7;
    }
}
