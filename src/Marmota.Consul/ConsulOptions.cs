using Marmota.Abstractions;

namespace Marmota.Consul
{
    internal class ConsulOptions : MarmotaOptions
    {
        public ConsulService Consul { get; set; }
    }

    internal class ConsulService
    {
        public string Address { get; set; }
        public int Port { get; set; } = 8500;
        public Service Service { get; set; }
    }

    internal class Service
    {
        public string Name { get; set; } = "ApiGateway";
        public string Address { get; set; } = "192.168.137.1";
        public int Port { get; set; } = 59620;
    }
}
