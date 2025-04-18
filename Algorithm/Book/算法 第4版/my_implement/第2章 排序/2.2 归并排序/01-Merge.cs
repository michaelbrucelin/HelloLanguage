using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{
    public class Merge : SortTemplate
    {
        //public static void Main(string[] args)
        //{
        //    Merge sortobj = new Merge();

        //    sortobj.Test();
        //    // sortobj.Verify();
        //}

        /// <summary>
        /// 归并排序
        /// 自顶向下的归并排序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        public override void Sort<T>(T[] arr)
        {
            T[] buffer = new T[arr.Length];
            Sort<T>(arr, 0, arr.Length - 1, ref buffer);
        }

        public void Sort<T>(T[] arr, int low, int high, ref T[] buffer) where T : IComparable
        {
            if (low >= high) return;

            int mid = low + (high - low) / 2;
            Sort<T>(arr, low, mid, ref buffer);
            Sort<T>(arr, mid + 1, high, ref buffer);
            if (arr[mid].CompareTo(arr[mid + 1]) > 0)  // 如果arr[mid]小于等于arr[mid+1]，我们就认为数组有序并可以跳过merge()方法了
                Merge_(arr, low, mid, high, ref buffer);
        }

        /// <summary>
        /// 将arr[low..mid]和arr[mid+1..high]归并
        /// 在Merge方法内部创建buffer[]数组，这样做代码更简单，但是有下面两个缺点
        /// 1. 频繁的创建数组，代码在创建数组上面消耗了很多时间
        /// 2. 如果是C语言这样可以直接操作内存的语言还好，如果是使用GC技术的语言，内存管控的并不好
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <param name="low"></param>
        /// <param name="mid"></param>
        /// <param name="high"></param>
        public void Merge_<T>(T[] arr, int low, int mid, int high) where T : IComparable
        {
            if (high <= low) return;

            T[] buffer = new T[high - low + 1];

            int id = 0, i = low, j = mid + 1;
            while (i <= mid && j <= high)
            {
                if (arr[i].CompareTo(arr[j]) <= 0)
                    buffer[id++] = arr[i++];
                else
                    buffer[id++] = arr[j++];
            }

            while (i <= mid) buffer[id++] = arr[i++];
            while (j <= high) buffer[id++] = arr[j++];

            id = 0;
            for (; id < buffer.Length; id++) arr[low + id] = buffer[id];
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
        public void Merge_<T>(T[] arr, int low, int mid, int high, ref T[] buffer) where T : IComparable
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
    }
}
