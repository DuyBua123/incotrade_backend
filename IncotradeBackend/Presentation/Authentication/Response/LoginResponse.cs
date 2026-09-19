

namespace IncotradeBackend.Presentation.Authentication.Response
{
    public record LoginUserResponse
    {
        public int Id { get; init; }
        public string FullName { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string Role { get; init; } = string.Empty;
    }

    public record LoginResponse
    {
        public string AccessToken { get; init; } = string.Empty;
        public LoginUserResponse User { get; init; } = new();
    }
}
