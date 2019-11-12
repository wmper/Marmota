using Microsoft.AspNetCore.Builder;

namespace Marmota.Abstractions
{
    public interface IMarmotaPipelineBuilder
    {
        IApplicationBuilder Builder { get; }

        IMarmotaPipelineBuilder Build();
    }
}
