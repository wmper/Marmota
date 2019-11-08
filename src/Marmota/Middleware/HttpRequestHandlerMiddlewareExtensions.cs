using Microsoft.AspNetCore.Builder;

namespace Marmota.Middleware
{
    public static class HttpRequestHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseHttpRequestHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HttpRequestHandlerMiddleware>();
        }
    }
}
