using BaseApi.Application.DTOs.Auth;
using BaseApi.Application.Exceptions;
using BaseApi.Application.Interfaces.Providers;
using BaseApi.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace BaseApi.Infrastructure.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtService _jwtService;

        public IdentityService(UserManager<ApplicationUser> userManager, IJwtService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }

        public async Task<UserResponseDto> CreateUserAsync(UserRequestDto request, CancellationToken cancellationToken = default)
        {
            var exists = await _userManager.FindByEmailAsync(request.Email);

            if (exists != null)
                throw new ConflictException("The email is already registered.");

            var user = new ApplicationUser
            {
                Id = Guid.NewGuid(),
                UserName = request.Email,
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                EmailConfirmed = true,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                throw new BadRequestException(string.Join(Environment.NewLine, result.Errors.Select(x => x.Description)));
            }

            return new UserResponseDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email!
            };
        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email) 
                ?? throw new UnauthorizedException("Invalid email or password.");

            var validPassword = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!validPassword)
                throw new UnauthorizedException("Invalid email or password.");

            var roles = await _userManager.GetRolesAsync(user);

            var jwtUser = new JwtUserResponseDto
            {
                Id = user.Id,
                Email = user.Email!,
                UserName = user.UserName!,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            var token = _jwtService.GenerateToken(jwtUser, roles);

            return new LoginResponseDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email!,
                AccessToken = token.Token,
                ExpiresAt = token.ExpiresAt
            };
        }
        public async Task<string> GeneratePasswordResetTokenAsync(string email, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var user = await _userManager.FindByEmailAsync(email);

            if (user is null)
            {
                return null!;
            }

            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task ResetPasswordAsync(string email, string token, string password, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var user = await _userManager.FindByEmailAsync(email) 
                ?? throw new NotFoundException("User not found.");

            var result = await _userManager.ResetPasswordAsync(user,token,password);

            if (!result.Succeeded)
            {
                throw new BadRequestException(string.Join(Environment.NewLine, result.Errors.Select(x => x.Description)));
            }
        }

        public async Task ChangePasswordAsync(Guid userId, string currentPassword, string newPassword, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString()) 
                ?? throw new NotFoundException("User not found.");

            var result = await _userManager.ChangePasswordAsync(
                user,
                currentPassword,
                newPassword
            );

            if (!result.Succeeded)
                throw new BadRequestException(string.Join(Environment.NewLine, result.Errors.Select(x => x.Description)));
        }
    }
}
