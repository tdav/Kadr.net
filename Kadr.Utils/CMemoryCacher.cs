using System;
using System.Collections.Generic;
using System.Runtime.Caching;

namespace Apteka.Utils
{
    public static class CMemoryCacher
    {
        public static object GetValue(string key)
        {
            var memoryCache = MemoryCache.Default;
            return memoryCache.Get(key);
        }
        
        public static bool Add(string key, object value,int min)
        {
            var memoryCache = MemoryCache.Default;
            return memoryCache.Add(key, value, DateTimeOffset.UtcNow.AddMinutes(min));
        }

        public static void Delete(string key)
        {
            var memoryCache = MemoryCache.Default;
            if (memoryCache.Contains(key))
            {
                memoryCache.Remove(key);
            }
        }

        public static bool Get<T>(string key, out T value)
        {
            var memoryCache = MemoryCache.Default;
            var obj = memoryCache.Get(key);
            if (obj !=null)
            {
                value = (T)obj;
                return true;
            }
            value = default(T);
            return false;
        }

        public static void Clear()
        {
            var memoryCache = MemoryCache.Default;
            foreach (KeyValuePair<string, object> item in memoryCache)
            {
                memoryCache.Remove(item.Key);
            }
        }
    }
}
        //memCacher.Add(token, userId, DateTimeOffset.UtcNow.AddHours(1));
        //var result = memCacher.GetValue(token);
        //    if (result == null)
        //{
        //    // for example get token from database and put grabbed token
        //    // again in memCacher Cache
        //}
