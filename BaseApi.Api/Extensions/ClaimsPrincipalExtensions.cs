using System.Security.Claims;

namespace BaseApi.Api.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid GetUserId(this ClaimsPrincipal user)
        {
            var value = user.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrWhiteSpace(value))
                throw new UnauthorizedAccessException();

            return Guid.Parse(value);
        }
    }
}
