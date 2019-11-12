using Marmota.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Marmota
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// A simple, cross-platform of api gateway building by .net core.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IMarmotaBuilder AddMarmota(this IServiceCollection services)
        {
            var service = services.First(x => x.ServiceType == typeof(IConfiguration));
            var configuration = (IConfiguration)service.ImplementationInstance;

            return services.AddMarmota(configuration);
        }

        /// <summary>
        /// A simple, cross-platform of api gateway building by .net core.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IMarmotaBuilder AddMarmota(this IServiceCollection services, IConfiguration configuration)
        {
            return new MarmotaBuilder(services, configuration).Build();
        }
    }
}
