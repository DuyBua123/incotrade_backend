namespace IncotradeBackend.Application.Authentication.RefreshToken
{
    public record RefreshTokenCommand
    {
        public string? RefreshToken { get; init; }
    }
}
