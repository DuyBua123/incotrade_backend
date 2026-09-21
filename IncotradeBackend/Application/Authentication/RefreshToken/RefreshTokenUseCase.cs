using IncotradeBackend.Infrastructure.Database;
using IncotradeBackend.Infrastructure.Database.Enum;
using IncotradeBackend.Infrastructure.Database.Model;
using IncotradeBackend.Infrastructure.Exceptions;
using IncotradeBackend.Infrastructure.Mapper.Authentication;
using IncotradeBackend.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;

namespace IncotradeBackend.Application.Authentication.RefreshToken
{
    public class RefreshTokenUseCase
    {
        private readonly JwtService _jwtService;
        private readonly AppDbContext _context;


        public RefreshTokenUseCase(
            JwtService jwtService,
            AppDbContext context)
        {
            _jwtService = jwtService;
            _context = context;
        }


        public async Task<RefreshTokenResult> ExecuteAsync(RefreshTokenCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.RefreshToken))
            {
                throw new InvalidRefreshTokenException("Refresh token không tồn tại.");
            }

            string hashedRefreshToken = _jwtService.HashRefreshToken(command.RefreshToken);

            LoginSession? currentLoginSession = await _context.LoginSessions
                .Include(ls => ls.User)
                .FirstOrDefaultAsync(ls => ls.HashedRefreshToken == hashedRefreshToken);

            if (currentLoginSession == null || currentLoginSession.User == null)
            {
                throw new InvalidRefreshTokenException("Refresh token không hợp lệ.");
            }

            if (currentLoginSession.RevokedAt != null || currentLoginSession.RevokedReason != null)
            {
                throw new InvalidRefreshTokenException("Refresh token không hợp lệ.");
            }

            if (IsExpired(currentLoginSession))
            {
                currentLoginSession.RevokedAt = DateTimeOffset.UtcNow;
                currentLoginSession.RevokedReason = RevokedReason.SESSION_EXPIRED;

                await _context.SaveChangesAsync();

                throw new InvalidRefreshTokenException("Phiên đăng nhập đã hết hạn.");
            }

            string accessToken = _jwtService.GenerateAccessToken(
                currentLoginSession.User,
                _jwtService.GenerateAccessTokenExpiresAt());

            return RefreshTokenMapper.ToResult(accessToken);
        }



        // PRIVATE METHODS
        private static bool IsExpired(LoginSession loginSession)
        {
            return loginSession.RefreshExpiresAt <= DateTimeOffset.UtcNow;
        }
    }
}
