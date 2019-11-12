using Marmota.Middleware;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Marmota.Extensions
{
    public static class MapUrlHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseMapUrlHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MapUrlHandlerMiddleware>();
        }
    }
}
