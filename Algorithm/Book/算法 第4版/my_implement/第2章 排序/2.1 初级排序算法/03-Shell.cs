using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{
    public class Shell : SortTemplate
    {
        /// <summary>
        /// 希尔排序
        /// 这里增量排序使用3k+1，即1, 4, 13, 40, 121, 364, 1093, ...
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        public override void Sort<T>(T[] arr)
        {
            int h = 1;
            while (h < arr.Length / 3) h = 3 * h + 1;  // 1, 4, 13, 40, 121, 364, 1093, ...

            while (h >= 1)
            {
                for (int i = h; i < arr.Length; i++)
                {
                    for (int j = i; j >= h && Less<T>(arr[j], arr[j - h]); j -= h)
                        Exch<T>(arr, j, j - h);
                }
                h /= 3;
            }
        }
    }
}
