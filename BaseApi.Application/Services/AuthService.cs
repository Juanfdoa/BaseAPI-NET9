using BaseApi.Application.Constants;
using BaseApi.Application.DTOs.Auth;
using BaseApi.Application.Interfaces.Providers;
using BaseApi.Application.Interfaces.Services;

namespace BaseApi.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IIdentityService _identityService;
        private readonly IEmailService _emailService;
        private readonly ITokenEncoder _tokenEncoder;

        public AuthService(IIdentityService identityService, IEmailService emailService, ITokenEncoder tokenEncoder)
        {
            _identityService = identityService;
            _emailService = emailService;
            _tokenEncoder = tokenEncoder;
        }

        public async Task<UserResponseDto> CreateUserAsync(UserRequestDto request, CancellationToken cancellationToken = default)
        {
            return await _identityService.CreateUserAsync(request, cancellationToken);
        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request, CancellationToken cancellationToken)
        {
            return await _identityService.LoginAsync(request, cancellationToken);
        }

        public async Task ForgotPasswordAsync(ForgotPasswordRequestDto request, CancellationToken cancellationToken)
        {
            var token = await _identityService.GeneratePasswordResetTokenAsync(request.Email,cancellationToken);;

            if (token is not null)
            {
                var encodedToken = _tokenEncoder.Encode(token);
                var link = $"https://my-frontend-app/reset-password?email={Uri.EscapeDataString(request.Email)}&token={Uri.EscapeDataString(encodedToken)}";

                await _emailService.SendTemplateAsync(
                request.Email,
                "Reset your password",
                EmailTemplates.ResetPassword,
                new Dictionary<string, object?>
                {
                    ["FirstName"] = request.Email,
                    ["ResetLink"] = link,
                    ["Year"] = DateTime.UtcNow.Year
                });
            }

            return;
        }

        public async Task ResetPasswordAsync(ResetPasswordRequestDto request, CancellationToken cancellationToken)
        {
            var decodedToken = _tokenEncoder.Decode(request.Token);
            await _identityService.ResetPasswordAsync(request.Email,decodedToken,request.Password,cancellationToken);
        }

        public async Task ChangePasswordAsync(Guid userId, ChangePasswordRequestDto request, CancellationToken cancellationToken)
        {
            await _identityService.ChangePasswordAsync(userId,request.CurrentPassword,request.NewPassword,cancellationToken);
        }
    }
}
