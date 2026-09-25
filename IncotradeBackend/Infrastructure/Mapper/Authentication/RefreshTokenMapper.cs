using IncotradeBackend.Application.Authentication.RefreshToken;
using IncotradeBackend.Presentation.Authentication.Response;

namespace IncotradeBackend.Infrastructure.Mapper.Authentication
{
    public static class RefreshTokenMapper
    {
        public static RefreshTokenCommand ToCommand(string? refreshToken)
        {
            return new RefreshTokenCommand
            {
                RefreshToken = refreshToken
            };
        }

        public static RefreshTokenResult ToResult(string accessToken)
        {
            return new RefreshTokenResult
            {
                AccessToken = accessToken
            };
        }

        public static RefreshTokenResponse ToResponse(RefreshTokenResult result)
        {
            return new RefreshTokenResponse
            {
                AccessToken = result.AccessToken
            };
        }
    }
}
