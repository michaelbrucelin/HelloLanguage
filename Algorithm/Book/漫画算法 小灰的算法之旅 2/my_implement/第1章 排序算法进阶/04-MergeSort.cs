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

            var list2 = MergeSort2(list, 0, list.Count - 1);

            Console.WriteLine();
            for (int i = 0; i < list2.Count; i++)
                Console.Write($"{list2[i]}, ");
        }

        /// <summary>
        /// 归并排序
        /// 
        /// 递归版，从中间开始逐步折半
        /// </summary>
        /// <param name="list"></param>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public static IList<int> MergeSort(IList<int> list, int start, int stop)
        {
            if (start >= stop)
                return list.Skip(start).Take(stop - start + 1).ToList();

            IList<int> left = MergeSort(list, start, (start + stop) / 2);
            IList<int> right = MergeSort(list, (start + stop) / 2 + 1, stop);

            IList<int> result = new List<int>(stop - start + 1);
            int i = 0, j = 0;
            while (i < left.Count && j < right.Count)
            {
                if (left[i] <= right[j])
                    result.Add(left[i++]);   // result[i + j] = left[i]; i++;
                else                         // left[i] > right[j]
                    result.Add(right[j++]);  // result[i + j] = right[j]; j++;
            }
            while (i < left.Count)
                result.Add(left[i++]);       // result[i + j] = left[i]; i++;
            while (j < right.Count)
                result.Add(right[j++]);      // result[i + j] = right[j]; j++;

            return result;
        }

        /// <summary>
        /// 归并排序
        /// 
        /// 非递归版，从前向后两两分组进行归并
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static IList<int> MergeSort2(IList<int> list)
        {
            int span = 2;
            while (span < list.Count - 1)
            {
                for(int i = 0;i+span<list.Count;)

                span <<= 1;
            }

            return null;
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
