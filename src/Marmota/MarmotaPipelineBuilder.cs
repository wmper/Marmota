using Marmota.Abstractions;
using Marmota.Extensions;
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
            Builder.UseMarmotaPipeline();

            return this;
        }
    }
}
