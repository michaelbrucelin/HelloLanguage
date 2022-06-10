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
            List<int> list = new List<int>(32);
            Parallel.For(0, 32, i => list.Add(random.Next(0, 100)));

            List<int> list1 = list.ToList();
            List<int> list2 = list.ToList();
            List<int> list3 = list.ToList();

            var r1 = CocktailSort(list1);
            var r2 = CocktailSort2(list2);
            var r3 = BubbleSort(list3);

            for (int i = 0; i < list.Count; i++)
                Console.Write($"{list[i]}, ");

            Console.WriteLine($"\n1. compare times: {r1.compcnt}, swap times: {r1.swapcnt};");
            for (int i = 0; i < list1.Count; i++) Console.Write($"{list1[i]}, ");

            Console.WriteLine($"\n2. compare times: {r2.compcnt}, swap times: {r2.swapcnt};");
            for (int i = 0; i < list2.Count; i++) Console.Write($"{list2[i]}, ");

            Console.WriteLine($"\n3. compare times: {r3.compcnt}, swap times: {r3.swapcnt};");
            for (int i = 0; i < list3.Count; i++) Console.Write($"{list3[i]}, ");
        }

        /// <summary>
        /// 鸡尾酒排序
        /// 鸡尾酒排序原则上就是冒泡排序的优化
        ///     冒泡排序每一轮次都是从前向后遍历，这样导致即使如果前面有一个排序后的区间，仍然每一轮次还需要参与比较
        ///     鸡尾酒排序奇数轮次从前向后遍历，偶数轮次从后向前遍历，这样如果前面有一个排序后的区间，那么就可以像冒泡排序后面有一个排序后的区间一样，优化掉
        /// 这里先只实现奇数轮次从前向后遍历，偶数轮次从后向前遍历，先不涉及有序区间的优化
        /// </summary>
        /// <param name="list"></param>
        private static (int compcnt, int swapcnt) CocktailSort(IList<int> list)
        {
            int compcnt = 0, swapcnt = 0;

            bool direction = true;  // true 从前向后 false 从后向前
            for (int i = 0; i < list.Count - 1; i++)
            {
                if (direction)
                {
                    for (int j = i / 2; j < list.Count - 1 - (i + 1) / 2; j++)
                    {
                        compcnt++;
                        if (list[j] > list[j + 1])
                        {
                            swapcnt++;
                            swap(list, j, j + 1);
                        }
                    }
                }
                else
                {
                    for (int j = list.Count - 1 - (i + 1) / 2; j > i / 2; j--)
                    {
                        compcnt++;
                        if (list[j] < list[j - 1])
                        {
                            swapcnt++;
                            swap(list, j, j - 1);
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
        /// <param name="list"></param>
        private static (int compcnt, int swapcnt) CocktailSort2(IList<int> list)
        {
            int compcnt = 0, swapcnt = 0;

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
                        compcnt++;
                        if (list[j] > list[j + 1])
                        {
                            swapcnt++;
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
                        compcnt++;
                        if (list[j] < list[j - 1])
                        {
                            swapcnt++;
                            swap(list, j, j - 1);
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
        /// <param name="list"></param>
        private static (int compcnt, int swapcnt) BubbleSort(IList<int> list)
        {
            int compcnt = 0, swapcnt = 0;

            int border = list.Count - 1;
            for (int i = 0; i < list.Count - 1; i++)
            {
                int tempborder = 0;
                for (int j = 0; j < border; j++)
                {
                    compcnt++;
                    if (list[j] > list[j + 1])
                    {
                        swapcnt++;
                        swap(list, j, j + 1);
                        tempborder = j;
                    }
                }
                border = tempborder;

                if (border <= 0) break;
            }

            return (compcnt, swapcnt);
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

/*
第1次测试
20, 5, 60, 34, 8, 79, 76, 48, 31, 23, 63, 73, 59, 79, 98, 4, 73, 90, 92, 93, 75, 49, 6, 49, 48, 18, 52, 88, 93, 28, 70, 14,
1. compare times: 496, swap times: 219;
4, 5, 6, 8, 14, 18, 20, 23, 28, 31, 34, 48, 48, 49, 49, 52, 59, 60, 63, 70, 73, 73, 75, 76, 79, 79, 88, 90, 92, 93, 93, 98,
2. compare times: 325, swap times: 219;
4, 5, 6, 8, 14, 18, 20, 23, 28, 31, 34, 48, 48, 49, 49, 52, 59, 60, 63, 70, 73, 73, 75, 76, 79, 79, 88, 90, 92, 93, 93, 98,
3. compare times: 490, swap times: 219;
4, 5, 6, 8, 14, 18, 20, 23, 28, 31, 34, 48, 48, 49, 49, 52, 59, 60, 63, 70, 73, 73, 75, 76, 79, 79, 88, 90, 92, 93, 93, 98,

第2次测试
50, 72, 31, 77, 24, 64, 66, 59, 50, 17, 39, 65, 80, 19, 32, 57, 28, 71, 75, 70, 13, 34, 20, 92, 76, 79, 87, 85, 66, 21, 67, 82,
1. compare times: 496, swap times: 201;
13, 17, 19, 20, 21, 24, 28, 31, 32, 34, 39, 50, 50, 57, 59, 64, 65, 66, 66, 67, 70, 71, 72, 75, 76, 77, 79, 80, 82, 85, 87, 92,
2. compare times: 297, swap times: 201;
13, 17, 19, 20, 21, 24, 28, 31, 32, 34, 39, 50, 50, 57, 59, 64, 65, 66, 66, 67, 70, 71, 72, 75, 76, 77, 79, 80, 82, 85, 87, 92,
3. compare times: 445, swap times: 201;
13, 17, 19, 20, 21, 24, 28, 31, 32, 34, 39, 50, 50, 57, 59, 64, 65, 66, 66, 67, 70, 71, 72, 75, 76, 77, 79, 80, 82, 85, 87, 92,

第3次测试
54, 79, 10, 51, 84, 28, 57, 37, 11, 83, 86, 83, 43, 60, 21, 64, 84, 60, 92, 5, 91, 57, 25, 59, 30, 84, 58, 7, 80, 80, 50, 14,
1. compare times: 496, swap times: 246;
5, 7, 10, 11, 14, 21, 25, 28, 30, 37, 43, 50, 51, 54, 57, 57, 58, 59, 60, 60, 64, 79, 80, 80, 83, 83, 84, 84, 84, 86, 91, 92,
2. compare times: 359, swap times: 246;
5, 7, 10, 11, 14, 21, 25, 28, 30, 37, 43, 50, 51, 54, 57, 57, 58, 59, 60, 60, 64, 79, 80, 80, 83, 83, 84, 84, 84, 86, 91, 92,
3. compare times: 490, swap times: 246;
5, 7, 10, 11, 14, 21, 25, 28, 30, 37, 43, 50, 51, 54, 57, 57, 58, 59, 60, 60, 64, 79, 80, 80, 83, 83, 84, 84, 84, 86, 91, 92,
*/
