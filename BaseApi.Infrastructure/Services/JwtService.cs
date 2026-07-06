using BaseApi.Application.DTOs.Auth;
using BaseApi.Application.Interfaces.Providers;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BaseApi.Infrastructure.Services
{
    public class JwtService : IJwtService
    {
        public JwtTokenResponseDto GenerateToken(JwtUserResponseDto user, IList<string> roles)
        {
            var secret = Environment.GetEnvironmentVariable("JWT_SECRET")
                ?? throw new InvalidOperationException("JWT_SECRET is not configured.");

            var issuer = Environment.GetEnvironmentVariable("JWT_ISSUER")
                ?? throw new InvalidOperationException("JWT_ISSUER is not configured.");

            var audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE")
                ?? throw new InvalidOperationException("JWT_AUDIENCE is not configured.");

            var expiresMinutes = int.Parse(
                Environment.GetEnvironmentVariable("JWT_EXPIRES_MINUTES") ?? "60");

            var expiresAt = DateTime.UtcNow.AddMinutes(expiresMinutes);

            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new(JwtRegisteredClaimNames.Email, user.Email!),
                new(JwtRegisteredClaimNames.UniqueName, user.UserName!),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

                new("first_name", user.FirstName),
                new("last_name", user.LastName)
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

            var credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer,
                audience,
                claims,
                expires: expiresAt,
                signingCredentials: credentials
            );

            return new JwtTokenResponseDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpiresAt = expiresAt
            };
        }
    }
}
