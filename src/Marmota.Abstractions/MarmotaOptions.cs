using System.Collections.Generic;

namespace Marmota.Abstractions
{
    public class MarmotaOptions
    {
        public string HealthCheck { get; set; } = "/api/healthcheck";
        public IEnumerable<Routes> Routes { get; set; }
    }

    public class Routes
    {
        public string Service { get; set; }
        public string Scheme { get; set; } = "http";
        public string Host { get; set; } = "127.0.0.1";
        public int Port { get; set; } = 5000;
        public Path Path { get; set; }
    }

    public class Path
    {
        public string Up { get; set; }
        public string Down { get; set; }
    }
}
