using Marmota.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Marmota.Consul
{
    public static class ServiceCollectionExtensions
    {
        public static IMarmotaBuilder AddConsul(this IMarmotaBuilder builder)
        {
            builder.Services.AddSingleton<IMarmotaConsul, MarmotaConsulService>();

            return builder;
        }
    }
}
