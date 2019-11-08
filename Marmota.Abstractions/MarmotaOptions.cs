using System.Collections.Generic;

namespace Marmota.Abstractions
{
    public class MarmotaOptions
    {
        public IList<MarmotaTemplate> Template { get; set; }
    }

    public class MarmotaTemplate
    {
        public string Service { get; set; }
        public string Up { get; set; }
        public string Down { get; set; }
    }
}
