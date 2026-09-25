using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IncotradeBackend.Infrastructure.Database;
using IncotradeBackend.Infrastructure.Database.Model;
using IncotradeBackend.Infrastructure.Exceptions;
using IncotradeBackend.Infrastructure.Mapper.Authentication;
using IncotradeBackend.Infrastructure.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IncotradeBackend.Application.Authentication.Login
{
    public class LoginUseCase
    {
        private readonly PasswordHasher<User> _passwordHasher;
        private readonly JwtService _jwtService;
        private readonly AppDbContext _context;


        public LoginUseCase(
            PasswordHasher<User> passwordHasher,
            JwtService jwtService, 
            AppDbContext context)
        {
            _passwordHasher = passwordHasher;
            _jwtService = jwtService;
            _context = context;
        }


        public async Task<LoginResult> ExecuteAsync(LoginCommand command)
        {

            User? user = _context.Users
                .FirstOrDefault(u => u.Email == command.Email);

            if (user == null)
            {
                throw new InvalidCredentialException("Email hoặc mật khẩu không hợp lệ.");
            }

            if (
                _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, command.Password) == 
                PasswordVerificationResult.Failed
            )
            {
                throw new InvalidCredentialException("Email hoặc mật khẩu không hợp lệ.");
            }

            DateTimeOffset accessTokenExpiresAt = _jwtService.GenerateAccessTokenExpiresAt();
            DateTimeOffset refreshTokenExpiresAt = _jwtService.GenerateRefreshTokenExpiresAt();

            string accessToken = _jwtService.GenerateAccessToken(user, accessTokenExpiresAt);
            string refreshToken = _jwtService.GenerateRefreshToken();

            // Create Login Session
            await CreateLoginSession(
                user, 
                _jwtService.HashRefreshToken(refreshToken), 
                accessTokenExpiresAt, 
                refreshTokenExpiresAt);

            // Return Result
            return LoginMapper.ToResult(
                accessToken,
                refreshToken,
                refreshTokenExpiresAt,
                user);
        }



        // PRIVATE METHODS
        private async Task CreateLoginSession(
            User user, 
            string hashedRefreshToken,
            DateTimeOffset accessTokenExpiresAt,
            DateTimeOffset refreshTokenExpiresAt)
        {
            LoginSession? loginSession = await _context.LoginSessions
                .Where(ls => ls.UserId == user.Id && ls.RevokedReason == null)
                .FirstOrDefaultAsync();

            if (loginSession != null)
            {
                loginSession.HashedRefreshToken = hashedRefreshToken;
                loginSession.AccessExpiresAt = accessTokenExpiresAt;
                loginSession.RefreshExpiresAt = refreshTokenExpiresAt;
            }
            else
            {
                loginSession = new LoginSession
                {
                    User = user,
                    HashedRefreshToken = hashedRefreshToken,
                    AccessExpiresAt = accessTokenExpiresAt,
                    RefreshExpiresAt = refreshTokenExpiresAt,
                    RevokedReason = null,
                    RevokedAt = null
                };

                await _context.LoginSessions.AddAsync(loginSession);
            }
            
            await _context.SaveChangesAsync();
        }
    }
}
