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
            // 检验一下两种插入排序的结果，以及每种插入排序比较与交换的次数
            Random random = new Random();
            List<int> list = new List<int>(32);
            Parallel.For(0, 32, i => list.Add(random.Next(0, 100)));

            List<int> list1 = list.ToList();
            List<int> list2 = list.ToList();

            var r1 = InsertSort(list1);
            var r2 = InsertSort2(list2);

            for (int i = 0; i < list.Count; i++)
                Console.Write($"{list[i]}, ");

            Console.WriteLine($"\n1. compare times: {r1.compcnt}, swap times: {r1.swapcnt};");
            for (int i = 0; i < list1.Count; i++) Console.Write($"{list1[i]}, ");

            Console.WriteLine($"\n1. compare times: {r2.compcnt}, swap times: {r2.swapcnt};");
            for (int i = 0; i < list2.Count; i++) Console.Write($"{list1[i]}, ");
        }

        /// <summary>
        /// 插入排序
        /// </summary>
        /// <param name="list"></param>
        public static (int compcnt, int swapcnt) InsertSort(IList<int> list)
        {
            int compcnt = 0, swapcnt = 0;

            for (int i = 1; i < list.Count; i++)
            {
                int insertValue = list[i], j = i - 1;
                for (; j >= 0 && list[j] > insertValue; j--)
                {
                    compcnt++;
                    swapcnt++;
                    list[j + 1] = list[j];
                }


                if (j + 1 != i)
                {
                    swapcnt++;
                    list[j + 1] = insertValue;
                }
            }

            return (compcnt, swapcnt);
        }

        /// <summary>
        /// 插入排序
        /// 优化，向前找合适的插入位置时，由于前面是有序区，尝试使用类似于二分查找的方式查找插入的位置
        /// 疑问
        ///     不使用二分查找（上面的方式），需要比较n次，赋值n次
        ///     使用二分查找，需要比较log2n次，需要赋值n次，而且多了一次循环（上面比较和赋值是一次循环，而这里比较和赋值是两次循环）
        /// 不确认这个优化到底有没有意义
        /// </summary>
        /// <param name="list"></param>
        public static (int compcnt, int swapcnt) InsertSort2(IList<int> list)
        {
            int compcnt = 0, swapcnt = 0;

            for (int i = 1; i < list.Count; i++)
            {
                var r = BinarySearch4InsertSort(list, 0, i - 1, list[i]);

                int index = r.index;
                compcnt += r.compcnt;
                if (list[index] == list[i])
                    for (; index <= i && list[index] == list[i]; index++, compcnt++) ;
                else if (list[index] < list[i])  // list[index+1]一定大于list[i]，插入的位置是index+1
                    index += 1;
                //else                           // list[index-1]一定小于list[i]，插入的位置是index
                //    index = index;

                if (index < i)
                {
                    int insertValue = list[i];
                    for (int j = i; j > index; j--)
                    {
                        swapcnt++;
                        list[j] = list[j - 1];
                    }

                    swapcnt++;
                    list[index] = insertValue;
                }
            }

            return (compcnt, swapcnt);
        }

        /// <summary>
        /// 二分查找
        /// 为插叙排序写的，即使没有找到要查找的值，也返回最后的结果，因为那里是最接近要查找值的位置，假定为i
        /// 如果位置i的值，就是要查找的值，那么i-1与i+1的值，也有可能是要查找的值
        /// 如果位置i的值比要查找的值小，那么i+1位置的值，一定比要查找的值大（想想为什么？可以用反证法）
        /// 如果位置i的值比要查找的值大，那么i-1位置的值，一定比要查找的值小（想想为什么？可以用反证法）
        /// </summary>
        /// <param name="list"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static (int index, int compcnt) BinarySearch4InsertSort(IList<int> list, int low, int high, int value)
        {
            int compcnt = 0;

            if (low == high) return (low, compcnt);

            int mid = (low + high) / 2;
            while (low <= high)
            {
                mid = (low + high) / 2;


                if (list[mid] == value)
                {
                    compcnt++;
                    return (mid, compcnt);
                }
                else if (list[mid] > value)
                {
                    compcnt++;
                    high = mid - 1;
                }
                else  // (list[mid] < value)
                    low = mid + 1;
            }

            if (low == mid + 1)
                return (high, compcnt);
            else
                return (low, compcnt);
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
43, 63, 53, 14, 3, 90, 81, 61, 46, 68, 66, 67, 57, 39, 26, 3, 33, 60, 26, 67, 38, 37, 40, 18, 11, 29, 98, 95, 29, 77, 50, 64,
1. compare times: 255, swap times: 283;
3, 3, 11, 14, 18, 26, 26, 29, 29, 33, 37, 38, 39, 40, 43, 46, 50, 53, 57, 60, 61, 63, 64, 66, 67, 67, 68, 77, 81, 90, 95, 98,
1. compare times:  60, swap times: 283;
3, 3, 11, 14, 18, 26, 26, 29, 29, 33, 37, 38, 39, 40, 43, 46, 50, 53, 57, 60, 61, 63, 64, 66, 67, 67, 68, 77, 81, 90, 95, 98,

第2次测试
52, 4, 30, 98, 25, 14, 93, 64, 3, 80, 38, 29, 84, 99, 70, 63, 42, 30, 48, 25, 25, 35, 62, 46, 99, 19, 92, 95, 16, 19, 57, 22,
1. compare times: 253, swap times: 281;
3, 4, 14, 16, 19, 19, 22, 25, 25, 25, 29, 30, 30, 35, 38, 42, 46, 48, 52, 57, 62, 63, 64, 70, 80, 84, 92, 93, 95, 98, 99, 99,
1. compare times:  63, swap times: 281;
3, 4, 14, 16, 19, 19, 22, 25, 25, 25, 29, 30, 30, 35, 38, 42, 46, 48, 52, 57, 62, 63, 64, 70, 80, 84, 92, 93, 95, 98, 99, 99,

第3次测试
96, 5, 40, 40, 34, 18, 48, 48, 60, 60, 58, 58, 93, 10, 81, 6, 25, 44, 3, 67, 53, 16, 64, 61, 75, 37, 36, 85, 13, 40, 72, 40,
1. compare times: 227, swap times: 258;
3, 5, 6, 10, 13, 16, 18, 25, 34, 36, 37, 40, 40, 40, 40, 44, 48, 48, 53, 58, 58, 60, 60, 61, 64, 67, 72, 75, 81, 85, 93, 96,
1. compare times:  61, swap times: 258;
3, 5, 6, 10, 13, 16, 18, 25, 34, 36, 37, 40, 40, 40, 40, 44, 48, 48, 53, 58, 58, 60, 60, 61, 64, 67, 72, 75, 81, 85, 93, 96,
*/
