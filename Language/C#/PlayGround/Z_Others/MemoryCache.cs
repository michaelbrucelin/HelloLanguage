using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Caching;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestCSharp
{
    public class Program
    {
        private static readonly MemoryCache cache = MemoryCache.Default;
        private static readonly CacheItemPolicy cachePolicy = new CacheItemPolicy() { SlidingExpiration = TimeSpan.FromSeconds(5) };         // 5秒内没有被使用，移除缓存
        private static readonly HttpClient httpClient = new HttpClient();

        /// <summary>
        /// 观察输出结果
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            Console.WriteLine($"{DateTime.Now} MemoryCache Test Start");
            for (int i = 0; i < 16; i++)
            {
                string result = GetValue("");
                Console.WriteLine($"{DateTime.Now} {i,-2} {result}");
                Thread.Sleep(1000);
            }
            Console.WriteLine($"{DateTime.Now} MemoryCache Test End");
        }

        /// <summary>
        /// 模拟前端获取数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static string GetValue(string key)
        {
            if (cache.Contains(key))
                return cache.Get(key).ToString();

            string value = GetValueFromIO(key);
            // cache.Set(key, value, cachePolicy);
            cache.Set(key, value, DateTimeOffset.Now.AddSeconds(5));  // 5秒后过期
            return value;
        }

        /// <summary>
        /// 模拟网络、磁盘、数据库等获取数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static string GetValueFromIO(string key)
        {
            Thread.Sleep(3000);
            return "hello world.";
        }
    }
}
