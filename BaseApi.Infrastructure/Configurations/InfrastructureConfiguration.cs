using Microsoft.Extensions.DependencyInjection;

namespace BaseApi.Infrastructure.Configurations
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDatabaseConfiguration();
            services.AddIdentityConfiguration();
            services.AddJwtConfiguration();
            services.AddServices();

            return services;
        }
    }
}
