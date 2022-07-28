using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{
    public class Program_2_2_11 : SortTemplate
    {
        public override void Sort<T>(T[] arr)
        {
            Sort_Improve<T>(arr);
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
        /// 改进。实现2.2.2节所述的对归并排序的三项改进：加快小数组的排序速度，检测数组是否已经有序以及通过在递归中交换参数来避免数组复制。
        /// 1. 加快小数组的排序速度：当数组长度小于15时，改为插入排序
        /// 2. 检测数组是否已经有序
        /// 3. 通过在递归中交换参数来避免数组复制
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        public void Sort_Improve<T>(T[] arr) where T : IComparable
        {
            if (arr.Length < 15)
            {
                Sort_Insertion<T>(arr, 0, arr.Length - 1);
                return;
            }

            T[] buffer = new T[arr.Length];
            Sort_Improve<T>(arr, 0, arr.Length - 1, ref buffer);
        }

        public void Sort_Improve<T>(T[] arr, int low, int high, ref T[] buffer) where T : IComparable
        {
            if (low >= high) return;

            if (high - low + 1 < 15)
            {
                Sort_Insertion<T>(arr, 0, arr.Length - 1);
                return;
            }

            int mid = low + (high - low) / 2;
            Sort_Improve<T>(arr, low, mid, ref buffer);
            Sort_Improve<T>(arr, mid + 1, high, ref buffer);
            if (arr[mid].CompareTo(arr[mid + 1]) > 0)
                Merge_Improve<T>(arr, low, mid, high, ref buffer);
        }

        /// <summary>
        /// 将arr[low..mid]和arr[mid+1..high]归并
        /// 在Sort方法内部创建buffer[]数组
        /// 改进。实现2.2.2节所述的对归并排序的三项改进：加快小数组的排序速度，检测数组是否已经有序以及通过在递归中交换参数来避免数组复制。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="low"></param>
        /// <param name="mid"></param>
        /// <param name="high"></param>
        /// <param name="buffer"></param>
        public void Merge_Improve<T>(T[] arr, int low, int mid, int high, ref T[] buffer) where T : IComparable
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

        /// <summary>
        /// 供归并排序调用的插入排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        public void Sort_Insertion<T>(T[] arr, int low, int high) where T : IComparable
        {
            for (int i = low + 1; i <= high; i++)
            {
                T t = arr[i];
                int j = i;
                for (; j > low && t.CompareTo(arr[j - 1]) < 0; j--)
                    arr[j] = arr[j - 1];
                if (j != i)
                    arr[j] = t;
            }
        }

        public void Test2()
        {
            Random random = new Random();

            string[] algs = new string[] { "Sort_Normal", "Sort_Improve" };

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
            else if (alg == "Sort_Improve") sortfunc = Sort_Improve;

            Debug.Assert(sortfunc != null);
            watch.Start();
            sortfunc(arr);
            watch.Stop();

            return watch.ElapsedMilliseconds * 1.0D / 1000;
        }
    }
}
