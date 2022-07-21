using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{
    public class Shell
    {
        public static void Main(string[] args)
        {
            Random random = new Random();
            IComparable[] arr = new IComparable[random.Next(29, 43)];
            Parallel.For(0, arr.Length, i => arr[i] = random.Next(0, 100));

            Show(arr);
            Sort(arr);

            Debug.Assert(IsSorted(arr));  // Trace.Assert(IsSorted(arr));
            Show(arr);

            // Verify();
        }

        /// <summary>
        /// 希尔排序
        /// 这里增量排序使用3k+1，即1, 4, 13, 40, 121, 364, 1093, ...
        /// </summary>
        /// <param name="arr"></param>
        public static void Sort(IComparable[] arr)
        {
            int h = 1;
            while (h < arr.Length / 3) h = 3 * h + 1;  // 1, 4, 13, 40, 121, 364, 1093, ...

            while (h >= 1)
            {
                for (int i = h; i < arr.Length; i++)
                {
                    for (int j = i; j >= h && Less(arr[j], arr[j - h]); j -= h)
                        Exch(arr, j, j - h);
                }
                h /= 3;
            }
        }

        /// <summary>
        /// 希尔排序  泛型版本
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        public static void Sort<T>(T[] arr) where T : IComparable
        {
            int h = 1;
            while (h < arr.Length / 3) h = 3 * h + 1;  // 1, 4, 13, 40, 121, 364, 1093, ...

            while (h >= 1)
            {
                for (int i = h; i < arr.Length; i++)
                {
                    for (int j = i; j >= h && Less<T>(arr[j], arr[j - h]); j -= h)
                        Exch<T>(arr, j, j - h);
                }
                h /= 3;
            }
        }

        private static bool Less(IComparable v, IComparable w)
        {
            return v.CompareTo(w) < 0;
        }

        private static bool Less<T>(T v, T w) where T : IComparable
        {
            return v.CompareTo(w) < 0;
        }

        private static void Exch(IComparable[] arr, int i, int j)
        {
            IComparable t = arr[i];
            arr[i] = arr[j];
            arr[j] = t;
        }

        private static void Exch<T>(T[] arr, int i, int j) where T : IComparable
        {
            T t = arr[i];
            arr[i] = arr[j];
            arr[j] = t;
        }

        public static void Show(IComparable[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write($"{arr[i]} ");
            Console.WriteLine();
        }

        public static void Show<T>(T[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write($"{arr[i]} ");
            Console.WriteLine();
        }

        public static bool IsSorted(IComparable[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
                if (Less(arr[i], arr[i - 1])) return false;
            return true;
        }

        public static bool IsSorted<T>(T[] arr) where T : IComparable
        {
            for (int i = 1; i < arr.Length; i++)
                if (Less<T>(arr[i], arr[i - 1])) return false;
            return true;
        }

        public static void Verify()
        {
            int total = 0, yes = 0;

            Random random = new Random();
            int T = random.Next(256, 512);

            List<double[]> errs = new List<double[]>();
            for (int t = 0; t < T; t++)
            {
                int N = random.Next(1024, 2048);
                double[] arr = new double[N];
                Parallel.For(0, N, i => arr[i] = random.NextDouble());

                double[] arrtest = arr.ToArray();
                Sort(arrtest);
                if (IsSorted<double>(arrtest))
                    yes++;
                else
                    errs.Add(arr);

                total++;
            }

            if (yes == total)
                Console.WriteLine($"共测试{total}次，每次数组长度为1024~2048之间随机，排序全部成功。");
            else
            {
                Console.WriteLine($"共测试{total}次，每次数组长度为1024~2048之间随机，排序成功{yes}次，发生错误的数组如下：");
                errs.ForEach(arr => Show(arr));
            }
        }
    }
}
