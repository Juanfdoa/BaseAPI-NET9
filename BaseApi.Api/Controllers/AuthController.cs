using BaseApi.Api.Extensions;
using BaseApi.Application.DTOs.Auth;
using BaseApi.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BaseApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Registers a new user.
        /// </summary>
        [HttpPost("register")]
        [ProducesResponseType(typeof(UserResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateUser(UserRequestDto request,CancellationToken cancellationToken)
        {
            var user = await _authService.CreateUserAsync(request,cancellationToken);
            return Created(string.Empty, user);
        }

        /// <summary>
        /// Authenticates a user and returns a JWT.
        /// </summary>
        [HttpPost("login")]
        [ProducesResponseType(typeof(LoginResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login(
            LoginRequestDto request,
            CancellationToken cancellationToken)
        {
            var response = await _authService.LoginAsync(request, cancellationToken);
            return Ok(response);
        }

        /// <summary>
        /// Returns the authenticated user.
        /// </summary>
        [Authorize]
        [HttpGet("me")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Me()
        {
            return Ok(new
            {
                UserId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value,
                Email = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value,
                Name = User.Identity?.Name
            });
        }

        /// <summary>
        /// Recover password.
        /// </summary>
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordRequestDto request,CancellationToken cancellationToken)
        {
            await _authService.ForgotPasswordAsync(request, cancellationToken);
            return Ok();
        }

        /// <summary>
        /// Reset password.
        /// </summary>
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequestDto request,CancellationToken cancellationToken)
        {
            await _authService.ResetPasswordAsync(request, cancellationToken);
            return Ok();
        }

        [Authorize]
        [HttpPost("change-password")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequestDto request,CancellationToken cancellationToken)
        {
            var userId = User.GetUserId();
            await _authService.ChangePasswordAsync(userId,request,cancellationToken);
            return NoContent();
        }
    }
}
