using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{
    public class SortCompare
    {
        public static void Main(string[] args)
        {
            Random random = new Random();

            string[] algs = new string[] { "Selection", "Insertion", "Shell", "Merge", "Quick", "Heap" };

            int N = random.Next(1024, 2048);
            int T = random.Next(256, 512);

            Compare2(algs, N, T);
        }

        /// <summary>
        /// 多轮比较，缺点是不同算法之间的数组是不一致的，可能会有失公允
        /// </summary>
        /// <param name="algs"></param>
        /// <param name="N">随机生成数组的长度</param>
        /// <param name="T">随机生成数组的数量</param>
        public static void Compare(string[] algs, int N, int T)
        {
            algs.ToList().ForEach(s =>
            {
                double t = TimeRandomInput(s, N, T);
                Console.WriteLine($"{s}:\t{t}");
            });
        }

        /// <summary>
        /// 多轮比较，不同算法之间的数组是一致的，尽可能达到测试的准确
        /// </summary>
        /// <param name="algs"></param>
        /// <param name="N">随机生成数组的长度</param>
        /// <param name="T">随机生成数组的数量</param>
        public static void Compare2(string[] algs, int N, int T)
        {
            double[] result = TimeRandomInput(algs, N, T);

            for (int i = 0; i < algs.Length; i++)
                Console.WriteLine($"{algs[i]}:\t{result[i]}");
        }

        public static double Time(string alg, IComparable[] arr)
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();
            if (alg == "Insertion") Insertion.Sort(arr);
            else if (alg == "Selection") Selection.Sort(arr);
            else if (alg == "Shell") Shell.Sort(arr);
            else if (alg == "Merge") Merge.Sort(arr);
            else if (alg == "Quick") Quick.Sort(arr);
            else if (alg == "Heap") Heap.Sort(arr);
            watch.Stop();

            return watch.ElapsedMilliseconds * 1.0D / 1000;
        }

        public static double Time<T>(string alg, T[] arr) where T : IComparable
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();
            if (alg == "Insertion") Insertion.Sort<T>(arr);
            else if (alg == "Selection") Selection.Sort<T>(arr);
            else if (alg == "Shell") Shell.Sort<T>(arr);
            else if (alg == "Merge") Merge.Sort<T>(arr);
            else if (alg == "Quick") Quick.Sort<T>(arr);
            else if (alg == "Heap") Heap.Sort<T>(arr);
            watch.Stop();

            return watch.ElapsedMilliseconds * 1.0D / 1000;
        }

        /// <summary>
        /// 单一算法多轮测试
        /// </summary>
        /// <param name="alg"></param>
        /// <param name="N">随机生成数组的长度</param>
        /// <param name="T">随机生成数组的数量</param>
        /// <returns></returns>
        public static double TimeRandomInput(string alg, int N, int T)
        {
            double total = 0.0;

            Random random = new Random();
            double[] arr = new double[N];
            for (int t = 0; t < T; t++)
            {
                Parallel.For(0, N, i => arr[i] = random.NextDouble());
                total += Time(alg, arr);
            }

            return total;
        }

        /// <summary>
        /// 多个算法多轮测试
        /// </summary>
        /// <param name="algs"></param>
        /// <param name="N">随机生成数组的长度</param>
        /// <param name="T">随机生成数组的数量</param>
        /// <returns></returns>
        public static double[] TimeRandomInput(string[] algs, int N, int T)
        {
            double[] total = new double[algs.Length];

            Random random = new Random();
            double[] arr = new double[N];

            for (int t = 0; t < T; t++)
            {
                Parallel.For(0, N, i => arr[i] = random.NextDouble());

                for (int i = 0; i < algs.Length; i++)
                {
                    double[] arrtmp = arr.ToArray();
                    total[i] += Time(algs[i], arrtmp);
                }
            }

            return total;
        }
    }
}
