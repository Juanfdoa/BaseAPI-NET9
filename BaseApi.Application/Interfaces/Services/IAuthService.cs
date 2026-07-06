using BaseApi.Application.DTOs.Auth;

namespace BaseApi.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<UserResponseDto> CreateUserAsync(UserRequestDto request, CancellationToken cancellationToken = default);
        Task<LoginResponseDto> LoginAsync(LoginRequestDto request, CancellationToken cancellationToken);
        Task ForgotPasswordAsync(ForgotPasswordRequestDto request,CancellationToken cancellationToken);
        Task ResetPasswordAsync(ResetPasswordRequestDto request,CancellationToken cancellationToken);
        Task ChangePasswordAsync(Guid userId,ChangePasswordRequestDto request,CancellationToken cancellationToken);
    }
}
