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

            int count = random.Next(1024, 2048);
            double[] arr = new double[count];

            int mean = random.Next(128, 1024);
            int stddev = random.Next(1, 16);
            Parallel.For(0, arr.Length, i => arr[i] = NormalDistribution(random, mean, stddev));

            Console.WriteLine($"Data   Count:  {count}.");
            Console.WriteLine($"Target Mean:   {mean}.");
            Console.WriteLine($"Target StdDev: {stddev}.");

            Console.WriteLine();
            Console.WriteLine($"Cal Mean:   {arr.Average()}");
            Console.WriteLine($"Cal StdDev: {StandardDeviation(arr)}");
        }

        /// <summary>
        /// 正态分布的实现
        /// </summary>
        /// <param name="random"></param>
        /// <param name="mean"></param>
        /// <param name="stddev"></param>
        /// <returns></returns>
        public static double NormalDistribution(Random random, double mean, double stddev)
        {
            // The method requires sampling from a uniform random of (0, 1], but Random.NextDouble() returns a sample of [0, 1).
            double u1 = 1.0 - random.NextDouble();  // uniform(0,1] random doubles
            double u2 = 1.0 - random.NextDouble();

            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);  // random normal(0, 1)

            return mean + stddev * randStdNormal;                                                  // random normal(mean, stddev^2)
        }

        /// <summary>
        /// 计算标准差
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static double StandardDeviation(IEnumerable<double> list)
        {
            double avg = list.Average();

            return Math.Sqrt(list.Average(v => Math.Pow(v - avg, 2)));
        }
    }
}
