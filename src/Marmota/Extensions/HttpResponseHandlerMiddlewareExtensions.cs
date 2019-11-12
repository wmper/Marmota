using Marmota.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Marmota.Extensions
{
    public static class HttpResponseHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseHttpResponseHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HttpResponseHandlerMiddleware>();
        }
    }
}
