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

            SelectionSort(arr);

            Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
                Console.Write($"{arr[i]}, ");
        }

        /// <summary>
        /// 选择排序
        /// 选择排序与冒泡排序
        /// 1. 如果数据完全随机，选择排序交换元素的次数要小于冒泡排序，但是如果数据中大部分数据已经有序，冒泡排序的效率更高
        /// 2. 选择排序不稳定，而冒泡排序是稳定的
        /// </summary>
        /// <param name="arr"></param>
        public static void SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int minid = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minid])
                        minid = j;
                }

                if (i != minid)
                    swap(arr, i, minid);
            }
        }

        private static void swap(int[] arr, int i, int j)
        {
            if (i != j)
            {
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }
    }
}
