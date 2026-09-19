

using IncotradeBackend.Application.Authentication.Login;
using IncotradeBackend.Infrastructure.Database.Model;
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
            DateTimeOffset refreshTokenExpiresAt,
            User user)
        {
            return new LoginResult
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                RefreshTokenExpiresAt = refreshTokenExpiresAt,
                User = new LoginUserResult
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Email = user.Email,
                    Role = user.Role.ToString()
                }
            };
        }

        public static LoginResponse ToResponse(LoginResult result)
        {
            return new LoginResponse
            {
                AccessToken = result.AccessToken,
                User = new LoginUserResponse
                {
                    Id = result.User.Id,
                    FullName = result.User.FullName,
                    Email = result.User.Email,
                    Role = result.User.Role
                }
            };
        }
    }
}
