

namespace IncotradeBackend.Presentation.Authentication.Response
{
    public record LoginResponse
    {
        public string AccessToken { get; init; } = string.Empty;
    }
}