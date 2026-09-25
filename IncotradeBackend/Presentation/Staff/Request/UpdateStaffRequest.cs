namespace IncotradeBackend.Presentation.Staff.Request
{
    public record UpdateStaffRequest
    {
        public string StaffId { get; init; } = string.Empty;
        public string FullName { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string? IsLock { get; init; }
    }
}
