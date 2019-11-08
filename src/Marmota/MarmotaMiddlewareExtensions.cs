using Marmota.Abstractions;
using Microsoft.AspNetCore.Builder;

namespace Marmota
{
    public static class MarmotaMiddlewareExtensions
    {
        public static IMarmotaPipelineBuilder UseMarmota(this IApplicationBuilder builder)
        {
            return new MarmotaPipelineBuilder(builder).Build();
        }
    }
}
