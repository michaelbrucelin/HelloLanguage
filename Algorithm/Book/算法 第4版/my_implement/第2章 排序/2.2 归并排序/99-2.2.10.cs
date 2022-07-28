using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{
    public class Program_2_2_10 : SortTemplate
    {
        //public static void Main(string[] args)
        //{
        //    Program_2_2_10 merge = new Program_2_2_10();

        //    // merge.Test();
        //    // merge.Verify();
        //    merge.Test2();

        //    /*
        //    Sort_Normal:     0.05500000000000001
        //    Sort_Quick:      0.005

        //    Sort_Normal:     0.002
        //    Sort_Quick:      0.004

        //    Sort_Normal:     0.018000000000000002
        //    Sort_Quick:      0.003

        //    Sort_Normal:     0.025000000000000012
        //    Sort_Quick:      0.017000000000000008

        //    Sort_Normal:     0.029000000000000012
        //    Sort_Quick:      0.016000000000000007

        //    Sort_Normal:     0.003
        //    Sort_Quick:      0.002

        //    Sort_Normal:     0.04800000000000002
        //    Sort_Quick:      0.033000000000000015

        //    Sort_Normal:     0.001
        //    Sort_Quick:      0.002

        //    Sort_Normal:     0.009
        //    Sort_Quick:      0.001

        //    Sort_Normal:     0.018000000000000002
        //    Sort_Quick:      0.004
        //    */
        //}

        public override void Sort<T>(T[] arr)
        {
            Sort_Quick<T>(arr);
        }

        /// <summary>
        /// 归并排序
        /// 自顶向下的归并排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        public void Sort_Normal<T>(T[] arr) where T : IComparable
        {
            T[] buffer = new T[arr.Length];
            Sort_Normal<T>(arr, 0, arr.Length - 1, ref buffer);
        }

        public void Sort_Normal<T>(T[] arr, int low, int high, ref T[] buffer) where T : IComparable
        {
            if (low >= high) return;

            int mid = low + (high - low) / 2;
            Sort_Normal<T>(arr, low, mid, ref buffer);
            Sort_Normal<T>(arr, mid + 1, high, ref buffer);
            if (arr[mid].CompareTo(arr[mid + 1]) > 0)  // 如果arr[mid]小于等于arr[mid+1]，我们就认为数组有序并可以跳过merge()方法了
                Merge_Normal(arr, low, mid, high, ref buffer);
        }

        /// <summary>
        /// 将arr[low..mid]和arr[mid+1..high]归并
        /// 在Sort方法内部创建buffer[]数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="low"></param>
        /// <param name="mid"></param>
        /// <param name="high"></param>
        /// <param name="buffer"></param>
        public void Merge_Normal<T>(T[] arr, int low, int mid, int high, ref T[] buffer) where T : IComparable
        {
            if (high <= low) return;

            int id = low, i = low, j = mid + 1;
            while (i <= mid && j <= high)
            {
                if (arr[i].CompareTo(arr[j]) <= 0)
                    buffer[id++] = arr[i++];
                else
                    buffer[id++] = arr[j++];
            }

            while (i <= mid) buffer[id++] = arr[i++];
            while (j <= high) buffer[id++] = arr[j++];

            id = low;
            for (; id <= high; id++) arr[id] = buffer[id];
        }

        /// <summary>
        /// 归并排序
        /// 实现一个merge()方法，按降序将a[] 的后半部分复制到aux[]，然后将其归并回a[] 中。这样就可以去掉内循环中检测某半边是否用尽的代码。
        /// 注意：这样的排序产生的结果是不稳定的。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        public void Sort_Quick<T>(T[] arr) where T : IComparable
        {
            T[] buffer = new T[arr.Length];
            Sort_Quick<T>(arr, 0, arr.Length - 1, ref buffer);
        }

        public void Sort_Quick<T>(T[] arr, int low, int high, ref T[] buffer) where T : IComparable
        {
            if (low >= high) return;

            int mid = low + (high - low) / 2;
            Sort_Quick<T>(arr, low, mid, ref buffer);
            Sort_Quick<T>(arr, mid + 1, high, ref buffer);
            if (arr[mid].CompareTo(arr[mid + 1]) > 0)
                Merge_Quick<T>(arr, low, mid, high, ref buffer);
        }

        /// <summary>
        /// 将arr[low..mid]和arr[mid+1..high]归并
        /// 在Sort方法内部创建buffer[]数组
        /// 实现一个merge()方法，按降序将a[]的后半部分复制到aux[]，然后将其归并回a[]中。这样就可以去掉内循环中检测某半边是否用尽的代码。
        /// 注意：这样的排序产生的结果是不稳定的。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="low"></param>
        /// <param name="mid"></param>
        /// <param name="high"></param>
        /// <param name="buffer"></param>
        public void Merge_Quick<T>(T[] arr, int low, int mid, int high, ref T[] buffer) where T : IComparable
        {
            if (high <= low) return;

            for (int i = low; i <= mid; i++)
                buffer[i] = arr[i];
            for (int i = mid + 1; i <= high; i++)
                buffer[i] = arr[high + mid + 1 - i];

            int lo = low, hi = high;
            for (int i = low; i <= high; i++)
            {
                if (buffer[lo].CompareTo(buffer[hi]) <= 0)
                    arr[i] = buffer[lo++];
                else
                    arr[i] = buffer[hi--];
            }
        }

        public void Test2()
        {
            Random random = new Random();

            string[] algs = new string[] { "Sort_Normal", "Sort_Quick" };

            int N = random.Next(1024, 2048);
            int T = random.Next(256, 512);

            Compare2(algs, N, T);
        }

        /// <summary>
        /// 多轮比较，不同算法之间的数组是一致的，尽可能达到测试的准确
        /// </summary>
        /// <param name="algs"></param>
        /// <param name="N">随机生成数组的长度</param>
        /// <param name="T">随机生成数组的数量</param>
        public void Compare2(string[] algs, int N, int T)
        {
            double[] result = TimeRandomInput(algs, N, T);

            for (int i = 0; i < algs.Length; i++)
                Console.WriteLine($"{algs[i] + ":",-17}{result[i]}");
        }

        /// <summary>
        /// 多个算法多轮测试
        /// </summary>
        /// <param name="algs"></param>
        /// <param name="N">随机生成数组的长度</param>
        /// <param name="T">随机生成数组的数量</param>
        /// <returns></returns>
        public double[] TimeRandomInput(string[] algs, int N, int T)
        {
            double[] total = new double[algs.Length];

            Random random = new Random();
            double[] arr = new double[N];

            for (int t = 0; t < T; t++)
            {
                Parallel.For(0, N, i => arr[i] = random.NextDouble());

                for (int i = 0; i < algs.Length; i++)
                {
                    double[] arrtmp = arr.ToArray();
                    total[i] += Time(algs[i], arrtmp);
                }
            }

            return total;
        }

        public double Time<T>(string alg, T[] arr) where T : IComparable
        {
            Stopwatch watch = new Stopwatch();

            Action<T[]> sortfunc = null;
            if (alg == "Sort_Normal") sortfunc = Sort_Normal;
            else if (alg == "Sort_Quick") sortfunc = Sort_Quick;

            Debug.Assert(sortfunc != null);
            watch.Start();
            sortfunc(arr);
            watch.Stop();

            return watch.ElapsedMilliseconds * 1.0D / 1000;
        }
    }
}
