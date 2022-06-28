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
            int[] arr = new int[random.Next(29, 43)];
            Parallel.For(0, arr.Length, i => arr[i] = random.Next(0, 100));
            Array.Sort(arr);

            for (int i = 0; i < arr.Length; i++)
                Console.Write($"{i}-{arr[i]}, ");

            int target = random.Next(0, 100);

            Console.WriteLine();
            Console.WriteLine($"[{target}]'s index is: {BinarySearch2(arr, target)}.");
        }

        /// <summary>
        /// 二分查找
        /// 非递归实现
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int BinarySearch(int[] arr, int target)
        {
            int low = 0, high = arr.Length - 1;
            int mid;
            while (low <= high)
            {
                // mid = (low + high) / 2;  // low+high有可能会溢出
                mid = low + (high - low) / 2;
                if (arr[mid] == target)
                    return mid;
                else if (arr[mid] > target)
                    high = mid - 1;
                else
                    low = mid + 1;
            }

            return -1;
        }

        /// <summary>
        /// 二分查找
        /// 递归实现
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int BinarySearch2(int[] arr, int target)
        {
            return BinarySearch2_(arr, target, 0, arr.Length - 1);
        }

        public static int BinarySearch2_(int[] arr, int target, int start, int end)
        {
            int mid;
            if (start <= end)
            {
                mid = start + (end - start) / 2;
                if (arr[mid] == target)
                    return mid;
                else if (arr[mid] > target)
                    return BinarySearch2_(arr, target, start, mid - 1);
                else
                    return BinarySearch2_(arr, target, mid + 1, end);
            }

            return -1;
        }
    }
}
