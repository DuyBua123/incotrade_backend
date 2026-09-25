namespace IncotradeBackend.Application.Staff.UpdateStaff
{
    public record UpdateStaffResult
    {
        public int Id { get; init; }
        public string FullName { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public bool IsLocked { get; init; }
        public DateTimeOffset CreatedAt { get; init; }
        public DateTimeOffset UpdatedAt { get; init; }
    }
}
