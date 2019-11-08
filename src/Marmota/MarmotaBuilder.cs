using Marmota.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Marmota
{
    public class MarmotaBuilder : IMarmotaBuilder
    {
        public IServiceCollection Services { get; }

        public IConfiguration Configuration { get; }

        public MarmotaBuilder(IServiceCollection services, IConfiguration configuration)
        {
            Services = services;
            Configuration = configuration;
        }

        public IMarmotaBuilder Build()
        {
            // TODO Service
            // services.AddSingleton<Ttest, Test>();

            return this;
        }
    }
}
