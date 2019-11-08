using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Marmota.Abstractions
{
    public interface IMarmotaBuilder
    {
        IServiceCollection Services { get; }

        IConfiguration Configuration { get; }

        IMarmotaBuilder Build();
    }
}
