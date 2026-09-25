namespace IncotradeBackend.Application.Authentication.Me
{
    public record MeCommand
    {
        public string? RefreshToken { get; init; }
    }
}
