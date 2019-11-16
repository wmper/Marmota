using Marmota.Abstractions;

namespace Marmota.Consul
{
    public static class MarmotaConsulMiddlewareExtensions
    {
        public static IMarmotaPipelineBuilder UseConsul(this IMarmotaPipelineBuilder builder)
        {
            new MarmotaConsulBuilder(builder).Buid();

            return builder;
        }
    }
}
