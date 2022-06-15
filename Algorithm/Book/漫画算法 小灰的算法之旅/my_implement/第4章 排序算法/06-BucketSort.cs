using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TestCSharp
{
    class Program
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            List<decimal> list = new List<decimal>(32);
            Parallel.For(0, 32, i => list.Add(random.Next(0, 100) * 1.0m / random.Next(1, 100)));

            for (int i = 0; i < list.Count; i++)
                Console.Write($"{list[i].ToString("0.00")}, ");

            var list2 = BucketSort(list);

            Console.WriteLine();
            for (int i = 0; i < list2.Count; i++)
                Console.Write($"{list2[i].ToString("0.00")}, ");
        }

        /// <summary>
        /// 桶排序
        /// 这里采用有多少个元素，就创建多少个桶
        /// 桶的跨度 = (最大值-最小值)/(桶数-1)，其中最后一个桶只存最大值，为[ ]，其余所有桶均为[ )
        /// 之所以这么设计桶，因为代码更统一，更容易找到每个元素属于那个桶
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IList<decimal> BucketSort(IList<decimal> list)
        {
            if (list.Count == 1) return list;

            decimal min = list[0], max = list[0];
            foreach (decimal i in list)
            {
                if (i < min)
                    min = i;
                else if (i > max)
                    max = i;
            }
            if (min == max) return list;

            // 初始化桶并将每一个元素分配到对应的桶中
            decimal span = (max - min) / (list.Count - 1);
            List<decimal>[] buckets = new List<decimal>[list.Count];
            for (int i = 0; i < buckets.Length; i++) buckets[i] = new List<decimal>();
            for (int i = 0; i < list.Count; i++)
            {
                buckets[(int)Math.Floor(list[i] / span)].Add(list[i]);
            }

            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i].Sort();  // 每一个桶内部排序，这里直接使用API来实现
            }

            IList<decimal> result = new List<decimal>(list.Count);
            for (int i = 0; i < buckets.Length; i++)
            {
                for (int j = 0; j < buckets[i].Count; j++)
                {
                    result.Add(buckets[i][j]);
                }
            }

            return result;
        }
    }
}
