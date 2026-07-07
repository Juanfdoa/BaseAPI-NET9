using BaseApi.Application.Interfaces.Providers;
using BaseApi.Application.Interfaces.Repositories;
using BaseApi.Application.Interfaces.Services;
using BaseApi.Application.Services;
using BaseApi.Infrastructure.Repositories;
using BaseApi.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BaseApi.Infrastructure.Configurations
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            //Services
            services.AddScoped<IAuthService, AuthService>();


            //Repositories
            services.AddScoped<IClientTypeRepository, ClientTypeRepository>();


            //Providers
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ITokenEncoder, TokenEncoder>();
            services.AddScoped<IClientTypeService, ClientTypeService>();

            return services;
        }
    }
}
