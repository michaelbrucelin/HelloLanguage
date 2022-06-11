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
            List<int> list = new List<int>(32);
            Parallel.For(0, 32, i => list.Add(random.Next(0, 100)));

            for (int i = 0; i < list.Count; i++)
                Console.Write($"{list[i]}, ");

            QuickSort3(list, 0, list.Count - 1);

            Console.WriteLine();
            for (int i = 0; i < list.Count; i++)
                Console.Write($"{list[i]}, ");
        }

        /// <summary>
        /// 快速排序
        ///     快速排序原则上是冒泡排序的升级版，冒泡排序每次将交换的元素移动一个位置，而快速排序则移动更多的位置
        /// 双边循环法，递归版
        /// </summary>
        /// <param name="list"></param>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        private static void QuickSort(IList<int> list, int start, int stop)
        {
            if (start >= stop) return;

            int pivot = list[start];  // 这里从简，直接使用第一个元素作为基准值，生产环境可以使用更科学的基准值
            int left = start, right = stop;
            while (left < right)
            {
                // 从右向左找比基准值小的元素
                for (; list[right] >= pivot && right > left; right--) ;

                // 从左向右找比基准值大的元素
                for (; list[left] <= pivot && left < right; left++) ;

                if (left < right)
                {
                    swap(list, left, right);
                }
                else  // left == right
                {
                    if (left != start) swap(list, start, left);
                }
            }

            // 递归
            QuickSort(list, start, left - 1);
            QuickSort(list, left + 1, stop);
        }

        /// <summary>
        /// 快速排序
        /// 单边循环法
        /// </summary>
        /// <param name="list"></param>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        private static void QuickSort2(IList<int> list, int start, int stop)
        {
            if (start >= stop) return;

            int pivot = list[start];  // 这里从简，直接使用第一个元素作为基准值，生产环境可以使用更科学的基准值
            int mask = start;
            for (int i = start + 1; i <= stop; i++)
            {
                if (list[i] < pivot)
                {
                    mask++;
                    if (i != mask) swap(list, i, mask);
                }
            }
            if (mask != start) swap(list, start, mask);

            // 递归
            QuickSort2(list, start, mask - 1);
            QuickSort2(list, mask + 1, stop);
        }

        /// <summary>
        /// 快速排序
        /// 双边循环法，非递归版
        /// </summary>
        /// <param name="list"></param>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        private static void QuickSort3(IList<int> list, int start, int stop)
        {
            Stack<(int start, int stop)> stack = new Stack<(int, int)>();  // 这里使用一个栈来代替递归的函数栈
            stack.Push((start, stop));

            while (stack.Count > 0)
            {
                var item = stack.Pop();
                if (item.start >= item.stop) continue;

                int pivot = QuickSortPartition(list, item.start, item.stop);

                // 递归部分
                if (pivot - 1 > item.start) stack.Push((item.start, pivot - 1));
                if (pivot + 1 < item.stop) stack.Push((pivot + 1, item.stop));
            }
        }

        /// <summary>
        /// 快速排序的分治部分，供非递归版快速排序方法调用
        /// </summary>
        /// <param name="list"></param>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        /// <returns></returns>
        private static int QuickSortPartition(IList<int> list, int start, int stop)
        {
            if (start > stop) return -1;

            int pivot = list[start];  // 这里从简，直接使用第一个元素作为基准值，生产环境可以使用更科学的基准值
            int left = start, right = stop;
            while (left < right)
            {
                // 从右向左找比基准值小的元素
                for (; list[right] >= pivot && right > left; right--) ;

                // 从左向右找比基准值大的元素
                for (; list[left] <= pivot && left < right; left++) ;

                if (left < right)
                {
                    swap(list, left, right);
                }
                else  // left == right
                {
                    if (left != start) swap(list, start, left);
                }
            }

            return left;
        }

        private static void swap(IList<int> list, int i, int j)
        {
            if (i != j)
            {
                int temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }
    }
}
