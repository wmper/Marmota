using Marmota.Abstractions;
using Microsoft.Extensions.Hosting;

namespace Marmota.Consul
{
    public class MarmotaConsulBuilder : IMarmotaConsulBuilder
    {
        public IHostApplicationLifetime HostApplicationLifetime { get; }
        public IMarmotaPipelineBuilder Builder { get; }

        private IMarmotaConsul Service { get; set; }

        public MarmotaConsulBuilder(IMarmotaPipelineBuilder builder)
        {
            Builder = builder;

            HostApplicationLifetime = (IHostApplicationLifetime)builder.Builder.ApplicationServices.GetService(typeof(IHostApplicationLifetime));
            Service = (IMarmotaConsul)Builder.Builder.ApplicationServices.GetService(typeof(IMarmotaConsul));
        }

        public IMarmotaConsulBuilder Buid()
        {
            HostApplicationLifetime.ApplicationStarted.Register(() =>
            {
                Service.ServiceRegister();
            });

            HostApplicationLifetime.ApplicationStopping.Register(() =>
            {
                Service.ServiceDeregister();
            });

            return this;
        }
    }
}
