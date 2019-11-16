using Consul;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace Marmota.Consul
{
    public class MarmotaConsulService : IMarmotaConsul
    {
        private readonly string ip = NetworkInterface.GetAllNetworkInterfaces()
                                     .Select(p => p.GetIPProperties())
                                     .SelectMany(p => p.UnicastAddresses)
                                     .Where(p => p.Address.AddressFamily == AddressFamily.InterNetwork && !IPAddress.IsLoopback(p.Address))
                                     .FirstOrDefault()?.Address.ToString();

        private readonly AgentServiceRegistration serviceRegistration;
        private readonly IConsulClient _client;
        private readonly string path;
        private readonly ConsulOptions config;

        public MarmotaConsulService(IConfiguration configuration)
        {
            config = configuration.Get<ConsulOptions>();

            var consul = config.Consul;
            var host = consul.Service.Host;
            if (string.IsNullOrWhiteSpace(host) || host == "127.0.0.1")
            {
                host = ip;
            }

            serviceRegistration = new AgentServiceRegistration()
            {
                ID = Guid.NewGuid().ToString(),
                Name = consul.Service.Name,
                Address = host,
                Port = consul.Service.Port
            };

            _client = new ConsulClient(x =>
            {
                x.Address = new Uri($"{consul.Address}:{consul.Port}");
            });

            path = config.HealthCheck;
        }

        public void ServiceDeregister()
        {
            _client.Agent.ServiceDeregister(serviceRegistration.ID).Wait();
        }

        public void ServiceRegister()
        {
            var service = config.Consul.Service;
            serviceRegistration.Check = new AgentServiceCheck()
            {
                DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),
                Interval = TimeSpan.FromSeconds(3),
                HTTP = $"{service.Scheme}://{service.Host}:{service.Port}/{path.TrimStart('/')}",
                Timeout = TimeSpan.FromSeconds(5)
            };

            _client.Agent.ServiceRegister(serviceRegistration).Wait();
        }
    }
}
