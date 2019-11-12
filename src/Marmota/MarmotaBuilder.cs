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
            var config = Configuration.Get<MarmotaOptions>();

            Services.Configure<MarmotaOptions>(optinos =>
            {
                optinos.Routes = config.Routes;
            });
            Services.AddHttpClient();

            return this;
        }
    }
}
