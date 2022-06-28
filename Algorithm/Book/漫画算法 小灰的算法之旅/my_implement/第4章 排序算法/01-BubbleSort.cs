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

            BubbleSort4(arr);

            Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
                Console.Write($"{arr[i]}, ");
        }

        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        private static void BubbleSort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                        swap(arr, j, j + 1);
                }
            }
        }

        /// <summary>
        /// 冒泡排序2
        /// 优化：如果某一轮没有发生任何比较，则取消后面所有轮次的比较
        /// </summary>
        /// <param name="arr"></param>
        private static void BubbleSort2(int[] arr)
        {
            bool flag;  // 如果上一轮没有发生任何比较，flag为true，表示不需要下一轮比较
            for (int i = 0; i < arr.Length - 1; i++)
            {
                flag = true;
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        swap(arr, j, j + 1);
                        flag = false;
                    }
                }

                if (flag) break;
            }
        }

        /// <summary>
        /// 冒泡排序3
        /// 优化：如果在border往后的元素，没有发生过交换，则border往后的元素是排序好的，
        ///       则下一轮只要比较到border即可（border可能比 list.Length-1-i 要小）
        /// </summary>
        /// <param name="arr"></param>
        private static void BubbleSort3(int[] arr)
        {
            bool flag;  // 如果上一轮没有发生任何比较，flag为true，表示不需要下一轮比较
            int border = arr.Length - 1;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                flag = true;
                int tempborder = 0;
                for (int j = 0; j < border; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        swap(arr, j, j + 1);
                        tempborder = j;
                        flag = false;
                    }
                }
                border = tempborder;

                if (flag) break;
            }
        }

        /// <summary>
        /// 冒泡排序4
        /// 优化：与BubbleSort3逻辑一致，取消flag（记录上一轮是否发生交换），
        ///       当已排序的边界到达数组的起始位置，就意味着可以取消以后所有轮次的比较
        /// </summary>
        /// <param name="arr"></param>
        private static void BubbleSort4(int[] arr)
        {
            int border = arr.Length - 1;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int tempborder = 0;
                for (int j = 0; j < border; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        swap(arr, j, j + 1);
                        tempborder = j;
                    }
                }
                border = tempborder;

                if (border <= 0) break;
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
