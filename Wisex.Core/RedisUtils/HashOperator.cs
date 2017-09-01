using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Text;
namespace Wisex.Core.RedisUtils
{
    public class HashOperator : RedisOperatorBase
    {
        public HashOperator() : base() { }
        public bool Exist<T>(string hashId, string key)
        {
            return Redis.HashContainsEntry(hashId, key);
        }

        public bool Set<T>(string hashId, string key, T t)
        {
            var value = JsonSerializer.SerializeToString<T>(t);
            return Redis.SetEntryInHash(hashId, key, value);
        }

        public bool Remove(string hashId, string key)
        {
            return Redis.RemoveEntryFromHash(hashId, key);
        }

        public bool Remove(string key)
        {
            return Redis.Remove(key);
        }

        public T Get<T>(string hashId, string key)
        {
            string value = Redis.GetValueFromHash(hashId, key);
            return JsonSerializer.DeserializeFromString<T>(value);
        }

        public List<T> GetAll<T>(string hashId)
        {
            var result = new List<T>();
            var list = Redis.GetHashValues(hashId);
            if (list != null && list.Count > 0)
            {
                list.ForEach(x =>
                 {
                     var value = JsonSerializer.DeserializeFromString<T>(x);
                     result.Add(value);
                 });
            }
            return result;
        }

        public void SetExpire(string key, DateTime datetime)
        {
            Redis.ExpireEntryAt(key, datetime);
        }
    }
}
