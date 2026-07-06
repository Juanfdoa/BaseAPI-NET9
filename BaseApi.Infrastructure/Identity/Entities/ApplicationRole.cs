using Microsoft.AspNetCore.Identity;

namespace BaseApi.Infrastructure.Identity.Entities
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
