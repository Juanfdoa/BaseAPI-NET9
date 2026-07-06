using BaseApi.Api.Middlewares;

namespace BaseApi.Api.Configurations
{
    public static class MiddlewareConfiguration
    {
        public static IApplicationBuilder UseApplicationMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();

            return app;
        }
    }
}
