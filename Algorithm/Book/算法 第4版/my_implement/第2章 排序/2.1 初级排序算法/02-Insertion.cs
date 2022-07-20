using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{
    public class Insertion
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
        }

        /// <summary>
        /// 插入排序
        /// 通常人们整理桥牌的方法是一张一张的来，将每一张牌插入到其他已经有序的牌中的适当位置。
        /// 在计算机的实现中，为了给要插入的元素腾出空间，我们需要将其余所有元素在插入之前都向右移动一位。这种算法叫做插入排序。
        /// </summary>
        /// <param name="arr"></param>
        public static void Sort(IComparable[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = i; j > 0 && Less(arr[j], arr[j - 1]); j--)
                    Exch(arr, j, j - 1);
            }
        }

        /// <summary>
        /// 插入排序  泛型版本
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        public static void Sort<T>(T[] arr) where T : IComparable
        {
            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = i; j > 0 && Less<T>(arr[j], arr[j - 1]); j--)
                    Exch<T>(arr, j, j - 1);
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
    }
}
