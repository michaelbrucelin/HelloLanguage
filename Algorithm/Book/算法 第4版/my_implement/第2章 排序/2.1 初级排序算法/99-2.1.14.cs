using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{
    public class Program_2_1_14
    {
        //public static void Main(string[] args)
        //{
        //    Program_2_1_14 p2_1_14 = new Program_2_1_14();

        //    p2_1_14.Test();
        //}

        public void Test()
        {
            Random random = new Random();
            int[] arr = new int[random.Next(29, 43)];
            Parallel.For(0, arr.Length, i => arr[i] = random.Next(0, 100));
            DS<int> ds = new DS<int>(arr);

            Show(ds);
            Sort(ds);

            Debug.Assert(IsSorted2(ds));  // Trace.Assert(IsSorted2(arr));
            Show(ds);

            // Verify();
        }

        public void Sort<T>(DS<T> ds) where T : IComparable
        {
            for (int r = 1; r < ds.Length; r++)  // r rounds，第r轮
            {
                for (int i = 0; i < ds.Length - r; i++)
                {
                    if (Less(ds[1], ds[0]))
                        ds.SwapFirstAndSecond();
                    ds.MoveFirstToLast();
                }

                for (int i = 0; i < r; i++)
                {
                    ds.MoveFirstToLast();
                }
            }
        }

        private bool Less<T>(T v, T w) where T : IComparable
        {
            return v.CompareTo(w) < 0;
        }

        private void Show<T>(DS<T> ds) where T : IComparable
        {
            T[] arr = ds.Arr;

            for (int i = 0; i < arr.Length; i++)
                Console.Write($"{arr[i]} ");
            Console.WriteLine();
        }

        private void Show<T>(T[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write($"{arr[i]} ");
            Console.WriteLine();
        }

        /// <summary>
        /// 检验数组是否有序，并检验数组的元素是否与原数组一致
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <returns></returns>
        private bool IsSorted2<T>(DS<T> ds) where T : IComparable
        {
            T[] arr = ds.Arr;
            T[] arrcopy = arr.ToArray();
            Array.Sort<T>(arrcopy);       // 这里相信API的排序是正确的

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].CompareTo(arrcopy[i]) != 0)
                    return false;
            }

            return true;
        }

        public void Verify()
        {
            int total = 0, yes = 0;

            Random random = new Random();
            int T = random.Next(256, 512);

            List<double[]> errs = new List<double[]>();
            for (int t = 0; t < T; t++)
            {
                int N = random.Next(1024, 2048);
                double[] arr = new double[N];
                Parallel.For(0, N, i => arr[i] = random.NextDouble());

                DS<double> dstest = new DS<double>(arr.ToArray());
                Sort<double>(dstest);
                if (IsSorted2<double>(dstest))
                    yes++;
                else
                    errs.Add(arr);

                total++;
            }

            if (yes == total)
                Console.WriteLine($"共测试{total}次，每次数组长度为1024~2048之间随机，排序全部成功。");
            else
            {
                Console.WriteLine($"共测试{total}次，每次数组长度为1024~2048之间随机，排序成功{yes}次，发生错误的数组如下：");
                errs.ForEach(arr => Show(arr));
            }
        }
    }

    /// <summary>
    /// 构建一个特定的线性表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DS<T> where T : IComparable
    {
        public DS(T[] arr)
        {
            this.arr = arr;
        }

        private T[] arr;  // 使用数组模拟线性表

        public T[] Arr { get { return arr; } }
        public int Length { get { return arr.Length; } }

        /// <summary>
        /// 使用索引器限制只能访问线性表的前两个元素
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get
            {
                if (index == 0 || index == 1)
                    return arr[index];
                else
                    throw new Exception("只能访问此线性表的前两个元素");
            }
        }

        /// <summary>
        /// 交换线性表的前两个元素
        /// </summary>
        public void SwapFirstAndSecond()
        {
            T first = arr[0];
            arr[0] = arr[1];
            arr[1] = first;
        }

        /// <summary>
        /// 将线性表的第一个元素放到线性表的末尾
        /// </summary>
        public void MoveFirstToLast()
        {
            T first = arr[0];

            for (int i = 0; i < arr.Length - 1; i++)
                arr[i] = arr[i + 1];

            arr[arr.Length - 1] = first;
        }
    }
}
