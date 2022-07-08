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

            int count = random.Next(32768, 65535);
            double[] arr = new double[count];

            Parallel.For(0, arr.Length, i => arr[i] = random.NextDouble() * random.Next(0, 1024));

            Console.WriteLine($"Data Count:   {count}.");
            Console.WriteLine($"AVG Built-in: {arr.Average()}.");
            Console.WriteLine($"AVG Classic:  {Average(arr)}.");
            Console.WriteLine($"AVG Iterate:  {Average2(arr)}.");
        }

        /// <summary>
        /// 使用传统方式实现求平均数
        /// 这种先累加再除法，计算更准确，但是累加的过程可能会溢出
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static double Average(IList<double> list)
        {
            double sum = 0.0;

            for (int i = 0; i < list.Count; i++)
                sum += list[i];

            return sum / list.Count;
        }

        /// <summary>
        /// 使用迭代的方式实现求平均数
        /// 这个算法简单、快速，只需处理每个值一次，并且变量永远不会大于集合中的最大值，因此不会出现溢出
        /// 但是这样会导致结果的精度不够
        /// 
        /// 思路：
        /// 假设前n-1个元素的平均值是avg，那么前n个元素的平均值就是：(avg*(n-1)+arr[n])/n，即avg += (arr[n] - avg)/n
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static double Average2(IList<double> list)
        {
            double avg = 0.0;

            for (int i = 0; i < list.Count; i++)
                avg += (list[i] - avg) / (i + 1);

            return avg;
        }
    }
}
