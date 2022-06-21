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

            InsertSort2(list);

            Console.WriteLine();
            for (int i = 0; i < list.Count; i++)
                Console.Write($"{list[i]}, ");
        }

        /// <summary>
        /// 插入排序
        /// </summary>
        /// <param name="list"></param>
        public static void InsertSort(IList<int> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                int insertValue = list[i], j = i - 1;
                for (; j >= 0 && list[j] > insertValue; j--)
                    list[j + 1] = list[j];

                if (j + 1 != i)
                    list[j + 1] = insertValue;
            }
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
        public static void InsertSort2(IList<int> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                int index = BinarySearch4InsertSort(list, 0, i - 1, list[i]);
                if (list[index] == list[i])
                    for (; index <= i && list[index] == list[i]; index++) ;
                else if (list[index] < list[i])  // list[index+1]一定大于list[i]，插入的位置是index+1
                    index += 1;
                //else                           // list[index-1]一定小于list[i]，插入的位置是index
                //    index = index;

                if (index < i)
                {
                    int insertValue = list[i];
                    for (int j = i; j > index; j--)
                        list[j] = list[j - 1];

                    list[index] = insertValue;
                }
            }
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
        private static int BinarySearch4InsertSort(IList<int> list, int low, int high, int value)
        {
            if (low == high) return low;

            int mid = (low + high) / 2;
            while (low <= high)
            {
                mid = (low + high) / 2;

                if (list[mid] == value)
                    return mid;
                else if (list[mid] > value)
                    high = mid - 1;
                else  // (list[mid] < value)
                    low = mid + 1;
            }

            if (low == mid + 1)
                return high;
            else
                return low;
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
