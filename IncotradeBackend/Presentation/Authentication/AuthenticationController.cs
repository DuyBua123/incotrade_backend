
using IncotradeBackend.Application.Authentication.Login;
using IncotradeBackend.Application.Authentication.RefreshToken;
using IncotradeBackend.Infrastructure.Api;
using IncotradeBackend.Infrastructure.Exceptions;
using IncotradeBackend.Infrastructure.Mapper.Authentication;
using IncotradeBackend.Presentation.Authentication.Request;
using IncotradeBackend.Presentation.Authentication.Response;
using Microsoft.AspNetCore.Mvc;

namespace IncotradeBackend.Presentation.Authentication
{
    [ApiController]
    [Route("api/auth")]
    public class AuthenticationController : ControllerBase
    {

        private readonly LoginUseCase _loginUseCase;
        private readonly RefreshTokenUseCase _refreshTokenUseCase;


        public AuthenticationController(
            LoginUseCase loginUseCase,
            RefreshTokenUseCase refreshTokenUseCase
        )
        {
            _loginUseCase = loginUseCase;
            _refreshTokenUseCase = refreshTokenUseCase;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {

            if (!ModelState.IsValid)
            {
                throw new InputValidationException(ModelState);
            }

            var command = LoginMapper.ToCommand(request);
            var result = await _loginUseCase.ExecuteAsync(command);

            var response = LoginMapper.ToResponse(result);

            AppendRefreshTokenCookie(result.RefreshToken, result.RefreshTokenExpiresAt);

            return Ok(SuccessResponse<LoginResponse>
                .Success("Đăng nhập thành công.", 
                response)
            );
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken()
        {
            string? refreshToken = Request.Cookies["refreshToken"];

            var command = RefreshTokenMapper.ToCommand(refreshToken);
            var result = await _refreshTokenUseCase.ExecuteAsync(command);

            var response = RefreshTokenMapper.ToResponse(result);

            return Ok(SuccessResponse<RefreshTokenResponse>
                .Success("Refresh token thành công.",
                response)
            );
        }



        // PRIVATE METHODS
        private void AppendRefreshTokenCookie(
            string refreshToken,
            DateTimeOffset refreshTokenExpiresAt)
        {
            HttpContext.Response.Cookies.Append(
                "refreshToken",
                refreshToken,
                new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true, // HTTPS only
                    SameSite = SameSiteMode.Lax,
                    Path = "/api/auth",
                    Expires = refreshTokenExpiresAt
                }
            );
        }

        private void DeleteRefreshTokenCookie()
        {
            HttpContext.Response.Cookies.Delete("refreshToken");
        }
        
    }
}
