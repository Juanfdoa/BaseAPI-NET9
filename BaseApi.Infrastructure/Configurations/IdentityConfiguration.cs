using BaseApi.Infrastructure.Context;
using BaseApi.Infrastructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace BaseApi.Infrastructure.Configurations
{
    public static class IdentityConfiguration
    {
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services)
        {
            services.AddIdentityCore<ApplicationUser>(ConfigureIdentity)
                     .AddRoles<ApplicationRole>()
                     .AddEntityFrameworkStores<ApplicationDbContext>()
                     .AddDefaultTokenProviders();

            return services;

        }

        private static void ConfigureIdentity(IdentityOptions options)
        {
            // Password
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 8;
            options.Password.RequireUppercase = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequiredUniqueChars = 1;

            // User
            options.User.RequireUniqueEmail = true;

            // Lockout
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);

            // SignIn
            options.SignIn.RequireConfirmedEmail = false;
        }
    }
}
