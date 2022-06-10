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

            CocktailSort2(list);

            Console.WriteLine();
            for (int i = 0; i < list.Count; i++)
                Console.Write($"{list[i]}, ");
        }

        /// <summary>
        /// 鸡尾酒排序
        /// 鸡尾酒排序原则上就是冒泡排序的优化
        ///     冒泡排序每一轮次都是从前向后遍历，这样导致即使如果前面有一个排序后的区间，仍然每一轮次还需要参与比较
        ///     鸡尾酒排序奇数轮次从前向后遍历，偶数轮次从后向前遍历，这样如果前面有一个排序后的区间，那么就可以像冒泡排序后面有一个排序后的区间一样，优化掉
        /// 这里先只实现奇数轮次从前向后遍历，偶数轮次从后向前遍历，先不涉及有序区间的优化
        /// </summary>
        /// <param name="list"></param>
        private static void CocktailSort(IList<int> list)
        {
            bool direction = true;  // true 从前向后 false 从后向前
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (direction)
                {
                    for (int j = i / 2; j < list.Count - 1 - (i + 1) / 2; j++)
                    {
                        if (list[j] > list[j + 1])
                        {
                            swap(list, j, j + 1);
                        }
                    }
                }
                else
                {
                    for (int j = list.Count - 1 - (i + 1) / 2; j > i / 2; j--)
                    {
                        if (list[j] < list[j - 1])
                        {
                            swap(list, j, j - 1);
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
        /// <param name="list"></param>
        private static void CocktailSort2(IList<int> list)
        {
            bool direction = true;  // true 从前向后 false 从后向前
            int borderLeft = 0, borderRight = list.Count - 1;
            for (int i = 0; i < list.Count - 1; i++)
            {
                int tempborder;
                if (direction)
                {
                    tempborder = borderLeft;
                    for (int j = borderLeft; j < borderRight; j++)
                    {
                        if (list[j] > list[j + 1])
                        {
                            swap(list, j, j + 1);
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
                        if (list[j] < list[j - 1])
                        {
                            swap(list, j, j - 1);
                            tempborder = j;
                        }
                    }
                    borderLeft = tempborder;
                }

                direction = !direction;
            }
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
