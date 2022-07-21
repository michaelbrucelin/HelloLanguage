using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{
    public class Selection
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
        /// 选择排序
        /// 首先，找到数组中最小的那个元素，其次，将它和数组的第一个元素交换位置（如果第一个元素就是最小元素那么它就和自己交换）。
        /// 再次，在剩下的元素中找到最小的元素，将它与数组的第二个元素交换位置。
        /// 如此往复，直到将整个数组排序。这种方法叫做选择排序，因为它在不断地选择剩余元素之中的最小者。
        /// </summary>
        /// <param name="arr"></param>
        public static void Sort(IComparable[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int minId = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (Less(arr[j], arr[minId]))
                        minId = j;
                }
                if (minId != i)
                    Exch(arr, i, minId);
            }
        }

        /// <summary>
        /// 选择排序  泛型版本
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        public static void Sort<T>(T[] arr) where T : IComparable
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int minId = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (Less<T>(arr[j], arr[minId]))
                        minId = j;
                }
                if (minId != i)
                    Exch<T>(arr, i, minId);
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
