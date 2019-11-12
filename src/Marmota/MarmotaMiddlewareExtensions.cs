using Marmota.Abstractions;
using Microsoft.AspNetCore.Builder;

namespace Marmota
{
    public static class MarmotaMiddlewareExtensions
    {
        /// <summary>
        /// A simple, cross-platform of api gateway building by .net core.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IMarmotaPipelineBuilder UseMarmota(this IApplicationBuilder builder)
        {
            return new MarmotaPipelineBuilder(builder).Build();
        }
    }
}
