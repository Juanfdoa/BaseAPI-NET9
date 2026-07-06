using BaseApi.Application.Exceptions;
using System.Net;
using System.Text.Json;

namespace BaseApi.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ApiException ex)
            {
                context.Response.StatusCode = (int)ex.StatusCode;
                context.Response.ContentType = "application/json";

                var response = new
                {
                    success = false,
                    statusCode = (int)ex.StatusCode,
                    message = ex.Message,
                    errors = ex.Errors,
                    traceId = context.TraceIdentifier,
                    timestamp = DateTime.UtcNow
                };

                await context.Response.WriteAsync(
                    JsonSerializer.Serialize(response));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";

                var response = new
                {
                    success = false,
                    statusCode = 500,
                    message = "An unexpected error occurred.",
                    traceId = context.TraceIdentifier,
                    timestamp = DateTime.UtcNow
                };

                await context.Response.WriteAsync(
                    JsonSerializer.Serialize(response));
            }
        }
    }
}
