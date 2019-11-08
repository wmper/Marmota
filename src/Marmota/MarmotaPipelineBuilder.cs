using Marmota.Abstractions;
using Marmota.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Marmota
{
    public class MarmotaPipelineBuilder : IMarmotaPipelineBuilder
    {
        public IApplicationBuilder Builder { get; }

        public MarmotaPipelineBuilder(IApplicationBuilder builder)
        {
            Builder = builder;
        }

        public IMarmotaPipelineBuilder Build()
        {
            // try catch error
            Builder.UseExceptionHandlerMiddleware();

            // http request
            Builder.UseHttpRequestHandlerMiddleware();

            return this;
        }
    }
}
