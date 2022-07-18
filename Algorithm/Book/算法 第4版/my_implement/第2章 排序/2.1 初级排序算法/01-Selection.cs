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
        }

        /// <summary>
        /// 选择排序
        /// 首先，找到数组中最小的那个元素，其次，将它和数组的第一个元素交换位置（如果第一个元素就是最小元素那么它就和自己交换）。
        /// 再次，在剩下的元素中找到最小的元素，将它与数组的第二个元素交换位置。
        /// 如此往复，直到将整个数组排序。这种方法叫做选择排序，因为它在不断地选择剩余元素之中的最小者。
        /// </summary>
        /// <param name="a"></param>
        public static void Sort(IComparable[] a)
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                int minId = i;
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (Less(a[j], a[minId]))
                        minId = j;
                }
                if (minId != i)
                    Exch(a, i, minId);
            }
        }

        private static bool Less(IComparable v, IComparable w)
        {
            return v.CompareTo(w) < 0;
        }

        private static void Exch(IComparable[] a, int i, int j)
        {
            IComparable t = a[i];
            a[i] = a[j];
            a[j] = t;
        }

        public static void Show(IComparable[] a)
        {
            for (int i = 0; i < a.Length; i++)
                Console.Write($"{a[i]} ");
            Console.WriteLine();
        }

        public static bool IsSorted(IComparable[] a)
        {
            for (int i = 1; i < a.Length; i++)
                if (Less(a[i], a[i - 1])) return false;
            return true;
        }
    }
}
