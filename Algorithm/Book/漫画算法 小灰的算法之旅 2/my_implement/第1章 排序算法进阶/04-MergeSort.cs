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
            List<int> list = new List<int>(new int[random.Next(29, 43)]);
            Parallel.For(0, list.Count, i => list[i] = random.Next(0, 100));

            for (int i = 0; i < list.Count; i++)
                Console.Write($"{list[i]}, ");

            MergeSort2(list);

            Console.WriteLine();
            for (int i = 0; i < list.Count; i++)
                Console.Write($"{list[i]}, ");
        }

        /// <summary>
        /// 归并排序
        /// 
        /// 递归版，从中间开始逐步折半
        /// </summary>
        /// <param name="list"></param>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public static void MergeSort(IList<int> list)
        {
            MergeSort_(list, 0, list.Count - 1);
        }

        private static void MergeSort_(IList<int> list, int start, int stop)
        {
            if (start >= stop) return;

            int mid = (start + stop) / 2;
            MergeSort_(list, start, mid);
            MergeSort_(list, mid + 1, stop);

            IList<int> buffer = new List<int>(stop - start + 1);
            int i = start, j = mid + 1;
            while (i <= mid && j <= stop)
            {
                if (list[i] <= list[j])
                    buffer.Add(list[i++]);
                else
                    buffer.Add(list[j++]);
            }
            while (i <= mid)
                buffer.Add(list[i++]);
            while (j <= stop)
                buffer.Add(list[j++]);

            for (i = start, j = 0; i <= stop; i++, j++)
                list[i] = buffer[j];
        }

        /// <summary>
        /// 归并排序
        /// 
        /// 非递归版，从前向后两两分组进行归并
        /// span 0  1  2  3  4  5  6  7  8  9  10  11  12  13  14  15  16  17  18
        ///   2  ----  ----  ----  ----  ----  ------  ------  ------  ------  --
        ///   4  ----------  ----------  ------------  --------------  ----------
        ///   8  ----------------------------------------------------  ----------
        ///  16  ----------------------------------------------------------------
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static void MergeSort2(IList<int> list)
        {
            int span = 1;
            while ((span <<= 1) <= list.Count)
            {
                for (int step = 0; step < list.Count; step += span)
                {
                    int mid = step + (span >> 1);      // span中第2个有序序列的第1个元素的索引
                    int border;                        // span中第2个有序序列的最后1个元素的索引
                    if (step + span - 1 < list.Count)  // 最后1个span是完整的
                        border = step + span - 1;
                    else if (mid < list.Count)         // 最后1个span虽然不是完整的，但仍然需要合并
                        border = list.Count - 1;
                    else
                        break;

                    List<int> buffer = new List<int>(span);
                    int i = step, j = mid;
                    while (i < mid && j <= border)
                    {
                        if (list[i] <= list[j])
                            buffer.Add(list[i++]);
                        else
                            buffer.Add(list[j++]);
                    }
                    while (i < mid)
                        buffer.Add(list[i++]);

                    while (j <= border)
                        buffer.Add(list[j++]);

                    for (i = step, j = 0; i <= border; i++, j++)
                        list[i] = buffer[j];
                }
            }

            List<int> buffer_ = new List<int>(list.Count);
            int mid_ = span >> 1, i_ = 0, j_ = mid_;
            while (i_ < mid_ && j_ < list.Count)
            {
                if (list[i_] <= list[j_])
                    buffer_.Add(list[i_++]);
                else
                    buffer_.Add(list[j_++]);
            }
            while (i_ < mid_)
                buffer_.Add(list[i_++]);

            while (j_ < list.Count)
                buffer_.Add(list[j_++]);

            for (i_ = 0; i_ < list.Count; i_++)
                list[i_] = buffer_[i_];
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
