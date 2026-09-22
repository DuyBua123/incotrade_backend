namespace IncotradeBackend.Application.Staff.GetAvailableStaffs
{
    public record GetAvailableStaffsCommand
    {
        public int Page { get; init; } = 1;
        public int Size { get; init; } = 7;
        public string? SearchFullName { get; init; }
    }
}
