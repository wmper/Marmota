using System.Collections.Generic;

namespace Marmota.Abstractions
{
    public class MarmotaOptions
    {
        public IEnumerable<Routes> Routes { get; set; }
    }

    public class Routes
    {
        public string Service { get; set; }
        public Path Path { get; set; }
    }

    public class Path
    {
        public string Up { get; set; }
        public string Down { get; set; }
    }
}
