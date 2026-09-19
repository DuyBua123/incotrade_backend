namespace IncotradeBackend.Presentation.Authentication.Response
{
    public record MeUserResponse
    {
        public int Id { get; init; }
        public string FullName { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string Role { get; init; } = string.Empty;
    }

    public record MeResponse
    {
        public string AccessToken { get; init; } = string.Empty;
        public MeUserResponse User { get; init; } = new();
    }
}
