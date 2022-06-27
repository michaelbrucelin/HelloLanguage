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

            for (int i = 0; i < arr.Length; i++)
                Console.Write($"{arr[i]}, ");

            MergeSort2(arr);

            Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
                Console.Write($"{arr[i]}, ");
        }

        /// <summary>
        /// 归并排序
        /// 
        /// 递归版，从中间开始逐步折半
        /// </summary>
        /// <param name="arr"></param>
        public static void MergeSort(int[] arr)
        {
            MergeSort_(arr, 0, arr.Length - 1);
        }

        /// <summary>
        /// 归并排序
        /// 
        /// 递归版，从中间开始逐步折半
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        private static void MergeSort_(int[] arr, int start, int end)
        {
            if (start >= end) return;

            int mid = (start + end) / 2;
            MergeSort_(arr, start, mid);
            MergeSort_(arr, mid + 1, end);

            Merge(arr, start, mid, end);
        }

        /// <summary>
        /// 归并排序
        /// 
        /// 非递归版，从前向后两两分组进行归并
        /// span 0  1  2  3  4  5  6  7  8  9  10  11  12  13  14  15  16  17  18
        ///   2  ----  ----  ----  ----  ----  ------  ------  ------  ------  --
        ///   4  ----------  ----------  ------------  --------------  ----------
        ///   8  ----------------------------------------------------  ----------
        ///  16  ----------------------------------------------------------------
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static void MergeSort2(int[] arr)
        {
            int span = 1;
            while ((span <<= 1) <= arr.Length)
            {
                for (int step = 0; step < arr.Length; step += span)
                {
                    int mid = step + (span >> 1);      // span中第2个有序序列的第1个元素的索引
                    int border;                        // span中第2个有序序列的最后1个元素的索引
                    if (step + span - 1 < arr.Length)  // 最后1个span是完整的
                        border = step + span - 1;
                    else if (mid < arr.Length)         // 最后1个span虽然不是完整的，但仍然需要合并
                        border = arr.Length - 1;
                    else
                        break;                         // 最后1个span只有第一个有序序列，没有第2个有序序列，所以不需要合并

                    Merge(arr, step, mid - 1, border);
                }
            }

            Merge(arr, 0, (span >> 1) - 1, arr.Length - 1);
        }

        /// <summary>
        /// 合并两个有序数组，用于归并排序
        /// </summary>
        /// <param name="arr">归并排序的数组</param>
        /// <param name="start">第1个有序区间的起始位置</param>
        /// <param name="mid">第1个有序区间的结束位置</param>
        /// <param name="end">第2个有序区间的结束位置</param>
        private static void Merge(int[] arr, int start, int mid, int end)
        {
            int[] buffer = new int[end - start + 1];

            int p = 0, p1 = start, p2 = mid + 1;
            while (p1 <= mid && p2 <= end)
            {
                if (arr[p1] <= arr[p2])
                    buffer[p++] = arr[p1++];
                else
                    buffer[p++] = arr[p2++];
            }

            while (p1 <= mid)
                buffer[p++] = arr[p1++];


            while (p2 <= end)
                buffer[p++] = arr[p2++];

            for (p = 0; p < buffer.Length; p++)
                arr[start + p] = buffer[p];
        }
    }
}
