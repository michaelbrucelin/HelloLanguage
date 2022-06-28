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
            // 检验一下鸡尾酒排序与冒泡的结果，以及每种排序比较与交换的次数
            Random random = new Random();
            int[] arr = new int[random.Next(29, 43)];
            Parallel.For(0, arr.Length, i => arr[i] = random.Next(0, 100));

            int[] arr1 = arr.ToArray();
            int[] arr2 = arr.ToArray();
            int[] arr3 = arr.ToArray();

            var r1 = CocktailSort(arr1);
            var r2 = CocktailSort2(arr2);
            var r3 = BubbleSort(arr3);

            for (int i = 0; i < arr.Length; i++)
                Console.Write($"{arr[i]}, ");

            Console.WriteLine($"\n1. compare times: {r1.compcnt}, swap times: {r1.swapcnt};");
            for (int i = 0; i < arr1.Length; i++) Console.Write($"{arr1[i]}, ");

            Console.WriteLine($"\n2. compare times: {r2.compcnt}, swap times: {r2.swapcnt};");
            for (int i = 0; i < arr2.Length; i++) Console.Write($"{arr2[i]}, ");

            Console.WriteLine($"\n3. compare times: {r3.compcnt}, swap times: {r3.swapcnt};");
            for (int i = 0; i < arr3.Length; i++) Console.Write($"{arr3[i]}, ");
        }

        /// <summary>
        /// 鸡尾酒排序
        /// 鸡尾酒排序原则上就是冒泡排序的优化
        ///     冒泡排序每一轮次都是从前向后遍历，这样导致即使如果前面有一个排序后的区间，仍然每一轮次还需要参与比较
        ///     鸡尾酒排序奇数轮次从前向后遍历，偶数轮次从后向前遍历，这样如果前面有一个排序后的区间，那么就可以像冒泡排序后面有一个排序后的区间一样，优化掉
        /// 这里先只实现奇数轮次从前向后遍历，偶数轮次从后向前遍历，先不涉及有序区间的优化
        /// </summary>
        /// <param name="arr"></param>
        private static (int compcnt, int swapcnt) CocktailSort(int[] arr)
        {
            int compcnt = 0, swapcnt = 0;

            bool direction = true;  // true 从前向后 false 从后向前
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (direction)
                {
                    for (int j = i / 2; j < arr.Length - 1 - (i + 1) / 2; j++)
                    {
                        compcnt++;
                        if (arr[j] > arr[j + 1])
                        {
                            swapcnt++;
                            swap(arr, j, j + 1);
                        }
                    }
                }
                else
                {
                    for (int j = arr.Length - 1 - (i + 1) / 2; j > i / 2; j--)
                    {
                        compcnt++;
                        if (arr[j] < arr[j - 1])
                        {
                            swapcnt++;
                            swap(arr, j, j - 1);
                        }
                    }
                }

                direction = !direction;
            }

            return (compcnt, swapcnt);
        }

        /// <summary>
        /// 鸡尾酒排序
        /// 实现有序区间的优化
        /// </summary>
        /// <param name="arr"></param>
        private static (int compcnt, int swapcnt) CocktailSort2(int[] arr)
        {
            int compcnt = 0, swapcnt = 0;

            bool direction = true;  // true 从前向后 false 从后向前
            int borderLeft = 0, borderRight = arr.Length - 1;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int tempborder;
                if (direction)
                {
                    tempborder = borderLeft;
                    for (int j = borderLeft; j < borderRight; j++)
                    {
                        compcnt++;
                        if (arr[j] > arr[j + 1])
                        {
                            swapcnt++;
                            swap(arr, j, j + 1);
                            tempborder = j;
                        }
                    }
                    borderRight = tempborder;
                }
                else
                {
                    tempborder = borderRight;
                    for (int j = borderRight; j > borderLeft; j--)
                    {
                        compcnt++;
                        if (arr[j] < arr[j - 1])
                        {
                            swapcnt++;
                            swap(arr, j, j - 1);
                            tempborder = j;
                        }
                    }
                    borderLeft = tempborder;
                }

                direction = !direction;
            }

            return (compcnt, swapcnt);
        }

        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <param name="arr"></param>
        private static (int compcnt, int swapcnt) BubbleSort(int[] arr)
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
74, 28, 25, 71, 99, 58, 25, 42, 66, 71, 38, 62, 56, 71, 70, 78, 78, 11, 78, 93, 55, 50, 41, 56, 2, 69, 24, 45, 46,
1. compare times: 406, swap times: 221;
2, 11, 24, 25, 25, 28, 38, 41, 42, 45, 46, 50, 55, 56, 56, 58, 62, 66, 69, 70, 71, 71, 71, 74, 78, 78, 78, 93, 99,
2. compare times: 317, swap times: 221;
2, 11, 24, 25, 25, 28, 38, 41, 42, 45, 46, 50, 55, 56, 56, 58, 62, 66, 69, 70, 71, 71, 71, 74, 78, 78, 78, 93, 99,
3. compare times: 388, swap times: 221;
2, 11, 24, 25, 25, 28, 38, 41, 42, 45, 46, 50, 55, 56, 56, 58, 62, 66, 69, 70, 71, 71, 71, 74, 78, 78, 78, 93, 99,

第2次测试
70, 12, 11, 77, 80, 19, 55, 35, 30, 62, 56, 21, 3, 14, 75, 10, 75, 29, 11, 61, 2, 47, 85, 11, 81, 81, 18, 86, 68, 21, 92, 28, 68, 25, 95, 93, 96, 16, 0,
1. compare times: 741, swap times: 316;
0, 2, 3, 10, 11, 11, 11, 12, 14, 16, 18, 19, 21, 21, 25, 28, 29, 30, 35, 47, 55, 56, 61, 62, 68, 68, 70, 75, 75, 77, 80, 81, 81, 85, 86, 92, 93, 95, 96,
2. compare times: 478, swap times: 316;
0, 2, 3, 10, 11, 11, 11, 12, 14, 16, 18, 19, 21, 21, 25, 28, 29, 30, 35, 47, 55, 56, 61, 62, 68, 68, 70, 75, 75, 77, 80, 81, 81, 85, 86, 92, 93, 95, 96,
3. compare times: 741, swap times: 316;
0, 2, 3, 10, 11, 11, 11, 12, 14, 16, 18, 19, 21, 21, 25, 28, 29, 30, 35, 47, 55, 56, 61, 62, 68, 68, 70, 75, 75, 77, 80, 81, 81, 85, 86, 92, 93, 95, 96,

第3次测试
3, 27, 66, 37, 66, 48, 14, 17, 54, 88, 85, 69, 72, 35, 24, 23, 26, 23, 70, 51, 70, 27, 61, 45, 60, 52, 48, 30, 81, 50, 88, 54, 69, 72,
1. compare times: 561, swap times: 213;
3, 14, 17, 23, 23, 24, 26, 27, 27, 30, 35, 37, 45, 48, 48, 50, 51, 52, 54, 54, 60, 61, 66, 66, 69, 69, 70, 70, 72, 72, 81, 85, 88, 88,
2. compare times: 344, swap times: 213;
3, 14, 17, 23, 23, 24, 26, 27, 27, 30, 35, 37, 45, 48, 48, 50, 51, 52, 54, 54, 60, 61, 66, 66, 69, 69, 70, 70, 72, 72, 81, 85, 88, 88,
3. compare times: 411, swap times: 213;
3, 14, 17, 23, 23, 24, 26, 27, 27, 30, 35, 37, 45, 48, 48, 50, 51, 52, 54, 54, 60, 61, 66, 66, 69, 69, 70, 70, 72, 72, 81, 85, 88, 88,
*/
