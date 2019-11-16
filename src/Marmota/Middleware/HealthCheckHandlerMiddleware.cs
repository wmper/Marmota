using Marmota.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Marmota.Middleware
{
    public class HealthCheckHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public HealthCheckHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IOptions<MarmotaOptions> options)
        {
            var path = context.Request.Path.Value.ToLower();
            if (options.Value.HealthCheck.ToLower() == path)
            {
                await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes($"OK.{DateTime.UtcNow}"));
            }
            else
            {
                await _next(context);
            }
        }
    }
}
