using Marmota.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Marmota.Extensions
{
    public static class HealthCheckHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseHealthCheckHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HealthCheckHandlerMiddleware>();
        }
    }
}
