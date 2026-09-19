using IncotradeBackend.Application.Authentication.Me;
using IncotradeBackend.Infrastructure.Database.Model;
using IncotradeBackend.Presentation.Authentication.Response;

namespace IncotradeBackend.Infrastructure.Mapper.Authentication
{
    public static class MeMapper
    {
        public static MeCommand ToCommand(string? refreshToken)
        {
            return new MeCommand
            {
                RefreshToken = refreshToken
            };
        }

        public static MeResult ToResult(string accessToken, User user)
        {
            return new MeResult
            {
                AccessToken = accessToken,
                User = new MeUserResult
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Email = user.Email,
                    Role = user.Role.ToString()
                }
            };
        }

        public static MeResponse ToResponse(MeResult result)
        {
            return new MeResponse
            {
                AccessToken = result.AccessToken,
                User = new MeUserResponse
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
