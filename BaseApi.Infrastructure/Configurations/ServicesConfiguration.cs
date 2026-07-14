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
            services.AddScoped<IClientTypeService, ClientTypeService>();
            services.AddScoped<IClientService, ClientService>();

            //Repositories
            services.AddScoped<IClientTypeRepository, ClientTypeRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Providers
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ITokenEncoder, TokenEncoder>();
            

            return services;
        }
    }
}
