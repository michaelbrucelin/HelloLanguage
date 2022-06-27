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
            decimal[] arr = new decimal[random.Next(29, 43)];
            Parallel.For(0, arr.Length, i => arr[i] = random.Next(0, 100) * 1.0m / random.Next(1, 100));

            for (int i = 0; i < arr.Length; i++)
                Console.Write($"{arr[i].ToString("0.00")}, ");

            BucketSort(arr);

            Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
                Console.Write($"{arr[i].ToString("0.00")}, ");
        }

        /// <summary>
        /// 桶排序
        /// 这里采用有多少个元素，就创建多少个桶
        /// 桶的跨度 = (最大值-最小值)/(桶数-1)，其中最后一个桶只存最大值，为[ ]，其余所有桶均为[ )
        /// 之所以这么设计桶，因为代码更统一，更容易找到每个元素属于那个桶
        /// </summary>
        /// <param name="arr"></param>
        public static void BucketSort(decimal[] arr)
        {
            if (arr.Length == 1) return;

            decimal min = arr[0], max = arr[0];
            foreach (decimal i in arr)
            {
                if (i < min)
                    min = i;
                else if (i > max)
                    max = i;
            }
            if (min == max) return;

            // 初始化桶并将每一个元素分配到对应的桶中
            decimal span = (max - min) / (arr.Length - 1);
            List<decimal>[] buckets = new List<decimal>[arr.Length];
            for (int i = 0; i < buckets.Length; i++)
                buckets[i] = new List<decimal>();

            // 将每一个元素放到对应的桶中
            for (int i = 0; i < arr.Length; i++)
                buckets[(int)Math.Floor(arr[i] / span)].Add(arr[i]);

            for (int i = 0; i < buckets.Length; i++)
                buckets[i].Sort();  // 每一个桶内部排序，这里直接使用API来实现
                                    // 从这里可以看出，如果数组的元素分布不均，导致元素全部分到一个桶中，那么桶排序就退化为每个桶内部的排序

            // 输出全部元素
            int index = 0;
            for (int i = 0; i < buckets.Length; i++)
            {
                for (int j = 0; j < buckets[i].Count; j++)
                {
                    arr[index++] = buckets[i][j];
                }
            }
        }
    }
}
