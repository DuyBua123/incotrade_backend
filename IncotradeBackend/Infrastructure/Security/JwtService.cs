
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using IncotradeBackend.Infrastructure.Database.Model;
using Microsoft.IdentityModel.Tokens;


namespace IncotradeBackend.Infrastructure.Security
{
    public class JwtService
    {

        private readonly IConfiguration _configuration;
        private readonly JwtSecurityTokenHandler _handler = new();


        public JwtService(
            IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateAccessToken(User user, DateTimeOffset expiresAt)
        {
            var jwtConfig = _configuration.GetSection("Jwt");

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtConfig["Key"]!));

            var creds = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtConfig["Issuer"],
                audience: jwtConfig["Audience"],
                claims: claims,
                expires: expiresAt.UtcDateTime,
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            return Base64UrlEncoder.Encode(RandomNumberGenerator.GetBytes(64));
        }
        
    }
}