using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

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
            catch (Exception) when (context.RequestAborted.IsCancellationRequested)
            {

            }
        }
    }
}
