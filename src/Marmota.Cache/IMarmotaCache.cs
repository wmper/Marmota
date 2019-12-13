using System;
using System.Collections.Generic;
using System.Text;

namespace Marmota.Cache
{
    public interface IMarmotaCache
    {
        T Get<T>(string key);

        void Set<T>(string key, T value);
    }
}
