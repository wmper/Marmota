using Marmota.Middleware.Extensions;
using Microsoft.AspNetCore.Builder;

namespace Marmota.Extensions
{
    public static class MarmotaPipelineBuilderExtensions
    {
        public static IApplicationBuilder UseMarmotaPipeline(this IApplicationBuilder builder)
        {
            // try catch error
            builder.UseExceptionHandlerMiddleware();

            // http request
            builder.UseHttpRequestHandlerMiddleware();

            return builder;
        }
    }
}
