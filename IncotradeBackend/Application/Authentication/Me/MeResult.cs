namespace IncotradeBackend.Application.Authentication.Me
{
    public record MeUserResult
    {
        public int Id { get; init; }
        public string FullName { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string Role { get; init; } = string.Empty;
    }

    public record MeResult
    {
        public string AccessToken { get; init; } = string.Empty;
        public MeUserResult User { get; init; } = new();
    }
}
