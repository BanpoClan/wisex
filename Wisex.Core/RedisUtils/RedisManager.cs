using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wisex.Core.RedisUtils
{
    public class RedisManager
    {
        private static readonly RedisConfigInfo RedisConfigInfo = RedisConfigInfo.GetConfig();
        private static PooledRedisClientManager _prcm;
        static RedisManager()
        {
            CreateManager();
        }

        private static void CreateManager()
        {
            var writeServerList = RedisConfigInfo.WriteServerList.Split(',');
            var readServerList = RedisConfigInfo.ReadServerList.Split(',');
            _prcm = new PooledRedisClientManager(writeServerList, readServerList,
                             new RedisClientManagerConfig
                             {
                                 MaxWritePoolSize = RedisConfigInfo.MaxWritePoolSize,
                                 MaxReadPoolSize = RedisConfigInfo.MaxReadPoolSize,
                                 AutoStart = RedisConfigInfo.AutoStart,
                             });
        }

        //private static IEnumerable<string> SplitString(string strSource, string split)
        //{
        //     return strSource.Split(split.ToArray());
        // }

        /// <summary>
        /// 客户端缓存操作对象
        /// </summary>
        public static ServiceStack.Redis.IRedisClient GetClient()
        {
            if (_prcm == null)
            {
                CreateManager();
            }
            return _prcm.GetClient();
        }

    }
}
