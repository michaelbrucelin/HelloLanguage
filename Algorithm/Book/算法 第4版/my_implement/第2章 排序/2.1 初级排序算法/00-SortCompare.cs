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
            Console.WriteLine("ABCDEFGHIJKLMN");
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

        //public static double Time<T>(string alg, T[] arr) where T:IComparable
        //{
        //    Stopwatch watch = new Stopwatch();

        //    watch.Start();
        //    if (alg == "Insertion") Insertion.Sort(arr);
        //    else if (alg == "Selection") Selection.Sort(arr);
        //    else if (alg == "Shell") Shell.Sort(arr);
        //    else if (alg == "Merge") Merge.Sort(arr);
        //    else if (alg == "Quick") Quick.Sort(arr);
        //    else if (alg == "Heap") Heap.Sort(arr);
        //    watch.Stop();

        //    return watch.ElapsedMilliseconds * 1.0D / 1000;
        //}

        /// <summary>
        /// 
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
    }
}
