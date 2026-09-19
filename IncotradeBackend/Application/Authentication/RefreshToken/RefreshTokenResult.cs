namespace IncotradeBackend.Application.Authentication.RefreshToken
{
    public record RefreshTokenResult
    {
        public string AccessToken { get; init; } = string.Empty;
    }
}
