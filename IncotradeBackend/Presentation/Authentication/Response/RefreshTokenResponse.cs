namespace IncotradeBackend.Presentation.Authentication.Response
{
    public record RefreshTokenResponse
    {
        public string AccessToken { get; init; } = string.Empty;
    }
}
