namespace IncotradeBackend.Application.Staff.CreateStaff
{
    public record CreateStaffCommand
    {
        public string FullName { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public bool IsLock { get; init; } = true;
    }
}
