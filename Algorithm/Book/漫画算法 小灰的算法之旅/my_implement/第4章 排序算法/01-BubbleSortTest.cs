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
            // 检验一下每种冒泡排序的结果，以及每种冒泡排序比较与交换的次数
            Random random = new Random();
            int[] arr = new int[random.Next(29, 43)];
            Parallel.For(0, arr.Length, i => arr[i] = random.Next(0, 100));

            int[] arr1 = arr.ToArray();
            int[] arr2 = arr.ToArray();
            int[] arr3 = arr.ToArray();
            int[] arr4 = arr.ToArray();

            var r1 = BubbleSort(arr1);
            var r2 = BubbleSort2(arr2);
            var r3 = BubbleSort3(arr3);
            var r4 = BubbleSort4(arr4);

            for (int i = 0; i < arr.Length; i++)
                Console.Write($"{arr[i]}, ");

            Console.WriteLine($"\n1. compare times: {r1.compcnt}, swap times: {r1.swapcnt};");
            for (int i = 0; i < arr1.Length; i++) Console.Write($"{arr1[i]}, ");

            Console.WriteLine($"\n2. compare times: {r2.compcnt}, swap times: {r2.swapcnt};");
            for (int i = 0; i < arr2.Length; i++) Console.Write($"{arr2[i]}, ");

            Console.WriteLine($"\n3. compare times: {r3.compcnt}, swap times: {r3.swapcnt};");
            for (int i = 0; i < arr3.Length; i++) Console.Write($"{arr3[i]}, ");

            Console.WriteLine($"\n4. compare times: {r4.compcnt}, swap times: {r4.swapcnt};");
            for (int i = 0; i < arr4.Length; i++) Console.Write($"{arr4[i]}, ");
        }

        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        private static (int compcnt, int swapcnt) BubbleSort(int[] arr)
        {
            int compcnt = 0, swapcnt = 0;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    compcnt++;
                    if (arr[j] > arr[j + 1])
                    {
                        swapcnt++;
                        swap(arr, j, j + 1);
                    }
                }
            }

            return (compcnt, swapcnt);
        }

        /// <summary>
        /// 冒泡排序2
        /// 优化：如果某一轮没有发生任何比较，则取消后面所有轮次的比较
        /// </summary>
        /// <param name="arr"></param>
        private static (int compcnt, int swapcnt) BubbleSort2(int[] arr)
        {
            int compcnt = 0, swapcnt = 0;

            bool flag;  // 如果上一轮没有发生任何比较，flag为true，表示不需要下一轮比较
            for (int i = 0; i < arr.Length - 1; i++)
            {
                flag = true;
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    compcnt++;
                    if (arr[j] > arr[j + 1])
                    {
                        swapcnt++;
                        swap(arr, j, j + 1);
                        flag = false;
                    }
                }

                if (flag) break;
            }

            return (compcnt, swapcnt);
        }

        /// <summary>
        /// 冒泡排序3
        /// 优化：如果在border往后的元素，没有发生过交换，则border往后的元素是排序好的，
        ///       则下一轮只要比较到border即可（border可能比 list.Length-1-i 要小）
        /// </summary>
        /// <param name="arr"></param>
        private static (int compcnt, int swapcnt) BubbleSort3(int[] arr)
        {
            int compcnt = 0, swapcnt = 0;

            bool flag;  // 如果上一轮没有发生任何比较，flag为true，表示不需要下一轮比较
            int border = arr.Length - 1;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                flag = true;
                int tempborder = 0;
                for (int j = 0; j < border; j++)
                {
                    compcnt++;
                    if (arr[j] > arr[j + 1])
                    {
                        swapcnt++;
                        swap(arr, j, j + 1);
                        tempborder = j;
                        flag = false;
                    }
                }
                border = tempborder;

                if (flag) break;
            }

            return (compcnt, swapcnt);
        }

        /// <summary>
        /// 冒泡排序4
        /// 优化：与BubbleSort3逻辑一致，取消flag（记录上一轮是否发生交换），
        ///       当已排序的边界到达数组的起始位置，就意味着可以取消以后所有轮次的比较
        /// </summary>
        /// <param name="arr"></param>
        private static (int compcnt, int swapcnt) BubbleSort4(int[] arr)
        {
            int compcnt = 0, swapcnt = 0;

            int border = arr.Length - 1;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int tempborder = 0;
                for (int j = 0; j < border; j++)
                {
                    compcnt++;
                    if (arr[j] > arr[j + 1])
                    {
                        swapcnt++;
                        swap(arr, j, j + 1);
                        tempborder = j;
                    }
                }
                border = tempborder;

                if (border <= 0) break;
            }

            return (compcnt, swapcnt);
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

/*
第1次测试
92, 2, 67, 14, 96, 75, 29, 67, 48, 8, 62, 45, 79, 58, 40, 58, 82, 25, 14, 96, 36, 66, 48, 97, 8, 43, 62, 6, 27, 87, 83,
1. compare times: 465, swap times: 233;
2, 6, 8, 8, 14, 14, 25, 27, 29, 36, 40, 43, 45, 48, 48, 58, 58, 62, 62, 66, 67, 67, 75, 79, 82, 83, 87, 92, 96, 96, 97,
2. compare times: 459, swap times: 233;
2, 6, 8, 8, 14, 14, 25, 27, 29, 36, 40, 43, 45, 48, 48, 58, 58, 62, 62, 66, 67, 67, 75, 79, 82, 83, 87, 92, 96, 96, 97,
3. compare times: 412, swap times: 233;
2, 6, 8, 8, 14, 14, 25, 27, 29, 36, 40, 43, 45, 48, 48, 58, 58, 62, 62, 66, 67, 67, 75, 79, 82, 83, 87, 92, 96, 96, 97,
4. compare times: 412, swap times: 233;
2, 6, 8, 8, 14, 14, 25, 27, 29, 36, 40, 43, 45, 48, 48, 58, 58, 62, 62, 66, 67, 67, 75, 79, 82, 83, 87, 92, 96, 96, 97,

第2次测试
43, 98, 68, 20, 63, 88, 19, 32, 49, 37, 3, 1, 24, 8, 67, 57, 52, 49, 76, 4, 85, 16, 68, 80, 49, 71, 86, 41, 69, 10, 32, 90, 36, 76, 51, 35, 67, 87, 60, 97, 67,
1. compare times: 820, swap times: 335;
1, 3, 4, 8, 10, 16, 19, 20, 24, 32, 32, 35, 36, 37, 41, 43, 49, 49, 49, 51, 52, 57, 60, 63, 67, 67, 67, 68, 68, 69, 71, 76, 76, 80, 85, 86, 87, 88, 90, 97, 98,
2. compare times: 715, swap times: 335;
1, 3, 4, 8, 10, 16, 19, 20, 24, 32, 32, 35, 36, 37, 41, 43, 49, 49, 49, 51, 52, 57, 60, 63, 67, 67, 67, 68, 68, 69, 71, 76, 76, 80, 85, 86, 87, 88, 90, 97, 98,
3. compare times: 660, swap times: 335;
1, 3, 4, 8, 10, 16, 19, 20, 24, 32, 32, 35, 36, 37, 41, 43, 49, 49, 49, 51, 52, 57, 60, 63, 67, 67, 67, 68, 68, 69, 71, 76, 76, 80, 85, 86, 87, 88, 90, 97, 98,
4. compare times: 660, swap times: 335;
1, 3, 4, 8, 10, 16, 19, 20, 24, 32, 32, 35, 36, 37, 41, 43, 49, 49, 49, 51, 52, 57, 60, 63, 67, 67, 67, 68, 68, 69, 71, 76, 76, 80, 85, 86, 87, 88, 90, 97, 98,

第3次测试
33, 66, 65, 71, 42, 71, 27, 44, 78, 23, 9, 21, 11, 94, 31, 14, 25, 91, 2, 90, 39, 83, 41, 7, 41, 71, 38, 49, 53, 22, 96, 83, 61,
1. compare times: 528, swap times: 244;
2, 7, 9, 11, 14, 21, 22, 23, 25, 27, 31, 33, 38, 39, 41, 41, 42, 44, 49, 53, 61, 65, 66, 71, 71, 71, 78, 83, 83, 90, 91, 94, 96,
2. compare times: 492, swap times: 244;
2, 7, 9, 11, 14, 21, 22, 23, 25, 27, 31, 33, 38, 39, 41, 41, 42, 44, 49, 53, 61, 65, 66, 71, 71, 71, 78, 83, 83, 90, 91, 94, 96,
3. compare times: 459, swap times: 244;
2, 7, 9, 11, 14, 21, 22, 23, 25, 27, 31, 33, 38, 39, 41, 41, 42, 44, 49, 53, 61, 65, 66, 71, 71, 71, 78, 83, 83, 90, 91, 94, 96,
4. compare times: 459, swap times: 244;
2, 7, 9, 11, 14, 21, 22, 23, 25, 27, 31, 33, 38, 39, 41, 41, 42, 44, 49, 53, 61, 65, 66, 71, 71, 71, 78, 83, 83, 90, 91, 94, 96,
*/
