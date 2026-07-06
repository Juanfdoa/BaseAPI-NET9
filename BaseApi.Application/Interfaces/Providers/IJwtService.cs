using BaseApi.Application.DTOs.Auth;

namespace BaseApi.Application.Interfaces.Providers
{
    public interface IJwtService
    {
        JwtTokenResponseDto GenerateToken(JwtUserResponseDto user,IList<string> roles);
    }
}
