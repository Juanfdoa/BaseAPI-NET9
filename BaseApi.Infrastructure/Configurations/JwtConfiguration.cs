using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BaseApi.Infrastructure.Configurations
{
    public static class JwtConfiguration
    {
        public static IServiceCollection AddJwtConfiguration(this IServiceCollection services)
        {
            var secret = Environment.GetEnvironmentVariable("JWT_SECRET")
                ?? throw new InvalidOperationException("JWT_SECRET is not configured.");

            var issuer = Environment.GetEnvironmentVariable("JWT_ISSUER")
                ?? throw new InvalidOperationException("JWT_ISSUER is not configured.");

            var audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE")
                ?? throw new InvalidOperationException("JWT_AUDIENCE is not configured.");

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidateAudience = true,
                    ValidAudience = audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddAuthorization();

            return services;
        }
    }
}
