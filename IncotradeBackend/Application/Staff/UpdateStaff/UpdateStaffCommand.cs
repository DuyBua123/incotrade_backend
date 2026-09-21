namespace IncotradeBackend.Application.Staff.UpdateStaff
{
    public record UpdateStaffCommand
    {
        public int StaffId { get; init; }
        public string FullName { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public bool? IsLock { get; init; }
    }
}
