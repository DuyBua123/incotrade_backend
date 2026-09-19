using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncotradeBackend.Application.Authentication.Login
{
    public record LoginResult
    {
        public string AccessToken { get; init; } = string.Empty;
        public string RefreshToken { get; init; } = string.Empty;
        public DateTimeOffset RefreshTokenExpiresAt { get; init; }
    }
}