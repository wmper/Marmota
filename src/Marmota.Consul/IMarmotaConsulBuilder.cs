using Marmota.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Marmota.Consul
{
    public interface IMarmotaConsulBuilder
    {
        IHostApplicationLifetime HostApplicationLifetime { get; }
        IMarmotaPipelineBuilder Builder { get; }

        IMarmotaConsulBuilder Buid();
    }
}
