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

            QuickSort3(arr, 0, arr.Length - 1);

            Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
                Console.Write($"{arr[i]}, ");
        }

        /// <summary>
        /// 快速排序
        ///     快速排序原则上是冒泡排序的升级版，冒泡排序每次将交换的元素移动一个位置，而快速排序则移动更多的位置
        /// 双边循环法，递归版
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        private static void QuickSort(int[] arr, int start, int stop)
        {
            if (start >= stop) return;

            int pivot = arr[start];  // 这里从简，直接使用第一个元素作为基准值，生产环境可以使用更科学的基准值
            int left = start, right = stop;
            while (left < right)
            {
                // 从右向左找比基准值小的元素
                for (; arr[right] >= pivot && right > left; right--) ;

                // 从左向右找比基准值大的元素
                for (; arr[left] <= pivot && left < right; left++) ;

                if (left < right)
                {
                    swap(arr, left, right);
                }
                else  // left == right
                {
                    if (left != start) swap(arr, start, left);
                }
            }

            // 递归
            QuickSort(arr, start, left - 1);
            QuickSort(arr, left + 1, stop);
        }

        /// <summary>
        /// 快速排序
        /// 单边循环法
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        private static void QuickSort2(int[] arr, int start, int stop)
        {
            if (start >= stop) return;

            int pivot = arr[start];  // 这里从简，直接使用第一个元素作为基准值，生产环境可以使用更科学的基准值
            int mask = start;
            for (int i = start + 1; i <= stop; i++)
            {
                if (arr[i] < pivot)
                {
                    mask++;
                    if (i != mask) swap(arr, i, mask);
                }
            }
            if (mask != start) swap(arr, start, mask);

            // 递归
            QuickSort2(arr, start, mask - 1);
            QuickSort2(arr, mask + 1, stop);
        }

        /// <summary>
        /// 快速排序
        /// 双边循环法，非递归版
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        private static void QuickSort3(int[] arr, int start, int stop)
        {
            Stack<(int start, int stop)> stack = new Stack<(int, int)>();  // 这里使用一个栈来代替递归的函数栈
            stack.Push((start, stop));

            while (stack.Count > 0)
            {
                var item = stack.Pop();
                if (item.start >= item.stop) continue;

                int pivot = QuickSortPartition(arr, item.start, item.stop);

                // 递归部分
                if (pivot - 1 > item.start) stack.Push((item.start, pivot - 1));
                if (pivot + 1 < item.stop) stack.Push((pivot + 1, item.stop));
            }
        }

        /// <summary>
        /// 快速排序的分治部分，供非递归版快速排序方法调用
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        /// <returns></returns>
        private static int QuickSortPartition(int[] arr, int start, int stop)
        {
            if (start > stop) return -1;

            int pivot = arr[start];  // 这里从简，直接使用第一个元素作为基准值，生产环境可以使用更科学的基准值
            int left = start, right = stop;
            while (left < right)
            {
                // 从右向左找比基准值小的元素
                for (; arr[right] >= pivot && right > left; right--) ;

                // 从左向右找比基准值大的元素
                for (; arr[left] <= pivot && left < right; left++) ;

                if (left < right)
                {
                    swap(arr, left, right);
                }
                else  // left == right
                {
                    if (left != start) swap(arr, start, left);
                }
            }

            return left;
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
