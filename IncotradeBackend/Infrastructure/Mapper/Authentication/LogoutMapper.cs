using IncotradeBackend.Application.Authentication.Logout;

namespace IncotradeBackend.Infrastructure.Mapper.Authentication
{
    public static class LogoutMapper
    {
        public static LogoutCommand ToCommand(string? refreshToken)
        {
            return new LogoutCommand
            {
                RefreshToken = refreshToken
            };
        }
    }
}
