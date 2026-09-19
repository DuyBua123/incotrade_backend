using IncotradeBackend.Infrastructure.Database;
using IncotradeBackend.Infrastructure.Database.Enum;
using IncotradeBackend.Infrastructure.Database.Model;
using IncotradeBackend.Infrastructure.Exceptions;
using IncotradeBackend.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;

namespace IncotradeBackend.Application.Authentication.Logout
{
    public class LogoutUseCase
    {
        private readonly JwtService _jwtService;
        private readonly AppDbContext _context;


        public LogoutUseCase(
            JwtService jwtService,
            AppDbContext context)
        {
            _jwtService = jwtService;
            _context = context;
        }


        public async Task ExecuteAsync(LogoutCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.RefreshToken))
            {
                throw new InvalidRefreshTokenException("Refresh token không tồn tại.");
            }

            string hashedRefreshToken = _jwtService.HashRefreshToken(command.RefreshToken);

            LoginSession? currentLoginSession = await _context.LoginSessions
                .FirstOrDefaultAsync(ls => ls.HashedRefreshToken == hashedRefreshToken);

            if (currentLoginSession == null)
            {
                throw new InvalidRefreshTokenException("Refresh token không hợp lệ.");
            }

            if (currentLoginSession.RevokedAt != null || currentLoginSession.RevokedReason != null)
            {
                throw new InvalidRefreshTokenException("Refresh token không hợp lệ.");
            }

            currentLoginSession.RevokedAt = DateTimeOffset.UtcNow;
            currentLoginSession.RevokedReason = RevokedReason.LOGOUT;

            await _context.SaveChangesAsync();
        }
    }
}
