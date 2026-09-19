namespace IncotradeBackend.Application.Authentication.Logout
{
    public record LogoutCommand
    {
        public string? RefreshToken { get; init; }
    }
}
