using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Marmota.Middleware
{
    public class MapUrlHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public MapUrlHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await _next(context);
        }
    }
}
