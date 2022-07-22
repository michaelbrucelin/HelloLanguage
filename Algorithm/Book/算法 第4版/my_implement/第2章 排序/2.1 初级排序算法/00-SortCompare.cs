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
        //public static void Main(string[] args)
        //{
        //    SortCompare compare = new SortCompare();
        //    // compare.Test();
        //    compare.Test2();
        //}

        public void Test()
        {
            Random random = new Random();

            string[] algs = new string[] { "Selection", "Insertion", "Shell", "Merge", "Quick", "Heap" };

            int N = random.Next(1024, 2048);
            int T = random.Next(256, 512);

            Compare(algs, N, T);
        }

        public void Test2()
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
        public void Compare(string[] algs, int N, int T)
        {
            algs.ToList().ForEach(s =>
            {
                double t = TimeRandomInput(s, N, T);
                Console.WriteLine($"{s + ":",-12}{t}");
            });
        }

        /// <summary>
        /// 多轮比较，不同算法之间的数组是一致的，尽可能达到测试的准确
        /// </summary>
        /// <param name="algs"></param>
        /// <param name="N">随机生成数组的长度</param>
        /// <param name="T">随机生成数组的数量</param>
        public void Compare2(string[] algs, int N, int T)
        {
            double[] result = TimeRandomInput(algs, N, T);

            for (int i = 0; i < algs.Length; i++)
                Console.WriteLine($"{algs[i] + ":",-12}{result[i]}");
        }

        public double Time<T>(string alg, T[] arr) where T : IComparable
        {
            Stopwatch watch = new Stopwatch();

            SortTemplate sortobj = null;
            if (alg == "Insertion") sortobj = new Insertion();
            else if (alg == "Selection") sortobj = new Selection();
            else if (alg == "Shell") sortobj = new Shell();
            else if (alg == "Merge") sortobj = new Merge();
            else if (alg == "Quick") sortobj = new Quick();
            else if (alg == "Heap") sortobj = new Heap();

            Debug.Assert(sortobj != null);
            watch.Start();
            sortobj.Sort(arr);
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
        public double TimeRandomInput(string alg, int N, int T)
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
        public double[] TimeRandomInput(string[] algs, int N, int T)
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
