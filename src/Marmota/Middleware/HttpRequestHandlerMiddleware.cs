using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Marmota.Middleware
{
    public class HttpRequestHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public HttpRequestHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context);
        }
    }
}
