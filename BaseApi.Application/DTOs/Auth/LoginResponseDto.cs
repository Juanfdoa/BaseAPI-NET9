namespace BaseApi.Application.DTOs.Auth
{
    public class LoginResponseDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
    }
}
