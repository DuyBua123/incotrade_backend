using IncotradeBackend.Infrastructure.Database;
using IncotradeBackend.Infrastructure.Database.Enum;
using IncotradeBackend.Infrastructure.Database.Model;
using IncotradeBackend.Infrastructure.Exceptions;
using IncotradeBackend.Infrastructure.Mapper.Authentication;
using IncotradeBackend.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;

namespace IncotradeBackend.Application.Authentication.Me
{
    public class MeUseCase
    {
        private readonly JwtService _jwtService;
        private readonly AppDbContext _context;


        public MeUseCase(
            JwtService jwtService,
            AppDbContext context)
        {
            _jwtService = jwtService;
            _context = context;
        }


        public async Task<MeResult> ExecuteAsync(MeCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.RefreshToken))
            {
                Console.Write("Refresh token trống");
                throw new InvalidRefreshTokenException("Refresh token không hợp lệ.");
            }

            string hashedRefreshToken = _jwtService.HashRefreshToken(command.RefreshToken);

            LoginSession? currentLoginSession = await _context.LoginSessions
                .Include(ls => ls.User)
                .FirstOrDefaultAsync(ls => ls.HashedRefreshToken == hashedRefreshToken);

            if (currentLoginSession == null || currentLoginSession.User == null)
            {
                Console.Write("Login session rỗng");
                throw new InvalidRefreshTokenException("Refresh token không hợp lệ.");
            }

            if (currentLoginSession.RevokedAt != null || currentLoginSession.RevokedReason != null)
            {
                Console.Write("Login session đã revoked");
                throw new InvalidRefreshTokenException("Refresh token không hợp lệ.");
            }

            if (IsExpired(currentLoginSession))
            {
                Console.Write("Login session expired");

                currentLoginSession.RevokedAt = DateTimeOffset.UtcNow;
                currentLoginSession.RevokedReason = RevokedReason.SESSION_EXPIRED;

                await _context.SaveChangesAsync();

                throw new InvalidRefreshTokenException("Phiên đăng nhập đã hết hạn.");
            }


            string accessToken = _jwtService.GenerateAccessToken(
                currentLoginSession.User,
                currentLoginSession.AccessExpiresAt);

                            Console.WriteLine(accessToken);


            return MeMapper.ToResult(accessToken, currentLoginSession.User);
        }



        // PRIVATE METHODS
        private static bool IsExpired(LoginSession loginSession)
        {
            return loginSession.RefreshExpiresAt <= DateTimeOffset.UtcNow;
        }
    }
}
