

using IncotradeBackend.Application.Authentication.Login;
using IncotradeBackend.Presentation.Authentication.Request;
using IncotradeBackend.Presentation.Authentication.Response;

namespace IncotradeBackend.Infrastructure.Mapper.Authentication
{
    public static class LoginMapper
    {
        public static LoginCommand ToCommand(LoginRequest request)
        {
            return new LoginCommand
            {
                Email = request.Email,
                Password = request.Password
            };
        }

        public static LoginResult ToResult(
            string accessToken,
            string refreshToken,
            DateTimeOffset refreshTokenExpiresAt)
        {
            return new LoginResult
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                RefreshTokenExpiresAt = refreshTokenExpiresAt
            };
        }

        public static LoginResponse ToResponse(LoginResult result)
        {
            return new LoginResponse
            {
                AccessToken = result.AccessToken
            };
        }
    }
}