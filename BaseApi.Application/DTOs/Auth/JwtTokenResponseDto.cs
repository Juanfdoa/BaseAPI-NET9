namespace BaseApi.Application.DTOs.Auth
{
    public class JwtTokenResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
    }
}
