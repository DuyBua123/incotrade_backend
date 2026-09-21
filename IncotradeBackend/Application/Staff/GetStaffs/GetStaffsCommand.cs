namespace IncotradeBackend.Application.Staff.GetStaffs
{
    public record GetStaffsCommand
    {
        public int Page { get; init; } = 1;
        public int Size { get; init; } = 7;
        public string? SearcFullhName { get; init; }
    }
}
