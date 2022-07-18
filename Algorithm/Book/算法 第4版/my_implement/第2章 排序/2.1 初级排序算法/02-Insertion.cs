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
        /// <param name="a"></param>
        public static void Sort(IComparable[] a)
        {
            for (int i = 1; i < a.Length; i++)
            {
                for (int j = i; j > 0 && Less(a[j], a[j - 1]); j--)
                    Exch(a, j, j - 1);
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
