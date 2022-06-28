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

            CocktailSort2(arr);

            Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
                Console.Write($"{arr[i]}, ");
        }

        /// <summary>
        /// 鸡尾酒排序
        /// 鸡尾酒排序原则上就是冒泡排序的优化
        ///     冒泡排序每一轮次都是从前向后遍历，这样导致即使如果前面有一个排序后的区间，仍然每一轮次还需要参与比较
        ///     鸡尾酒排序奇数轮次从前向后遍历，偶数轮次从后向前遍历，这样如果前面有一个排序后的区间，那么就可以像冒泡排序后面有一个排序后的区间一样，优化掉
        /// 这里先只实现奇数轮次从前向后遍历，偶数轮次从后向前遍历，先不涉及有序区间的优化
        /// </summary>
        /// <param name="arr"></param>
        private static void CocktailSort(int[] arr)
        {
            bool direction = true;  // true 从前向后 false 从后向前
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (direction)
                {
                    for (int j = i / 2; j < arr.Length - 1 - (i + 1) / 2; j++)
                    {
                        if (arr[j] > arr[j + 1])
                        {
                            swap(arr, j, j + 1);
                        }
                    }
                }
                else
                {
                    for (int j = arr.Length - 1 - (i + 1) / 2; j > i / 2; j--)
                    {
                        if (arr[j] < arr[j - 1])
                        {
                            swap(arr, j, j - 1);
                        }
                    }
                }

                direction = !direction;
            }
        }

        /// <summary>
        /// 鸡尾酒排序
        /// 实现有序区间的优化
        /// </summary>
        /// <param name="arr"></param>
        private static void CocktailSort2(int[] arr)
        {
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
                        if (arr[j] > arr[j + 1])
                        {
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
                        if (arr[j] < arr[j - 1])
                        {
                            swap(arr, j, j - 1);
                            tempborder = j;
                        }
                    }
                    borderLeft = tempborder;
                }

                direction = !direction;
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
