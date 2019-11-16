using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using System.Text;

namespace Marmota.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;

                await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes(ex.Message));
            }
        }
    }
}
