
using Memcached.ClientLibrary;

namespace Wisex.Core.Memcached
{
    /// <summary>
    /// MemcachedClient单利模式
    /// </summary>
    public class MemcachedClientSingleton : Singleton<MemcachedClient>
    {
        private MemcachedClientSingleton()
        {
            
        }
    }
}
