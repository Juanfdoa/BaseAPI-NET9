using BaseApi.Application.DTOs.Auth;

namespace BaseApi.Application.Interfaces.Providers
{
    public interface IIdentityService
    {
        Task<UserResponseDto> CreateUserAsync(UserRequestDto request, CancellationToken cancellationToken = default);
        Task<LoginResponseDto> LoginAsync(LoginRequestDto request, CancellationToken cancellationToken);
        Task<string> GeneratePasswordResetTokenAsync(string email,CancellationToken cancellationToken);
        Task ResetPasswordAsync(string email,string token,string password,CancellationToken cancellationToken);
        Task ChangePasswordAsync(Guid userId,string currentPassword,string newPassword,CancellationToken cancellationToken);
    }
}
