using Microsoft.AspNetCore.Builder;

namespace Marmota.Middleware.Extensions
{
    public static class HttpRequestHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseHttpRequestHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HttpRequestHandlerMiddleware>();
        }
    }
}
