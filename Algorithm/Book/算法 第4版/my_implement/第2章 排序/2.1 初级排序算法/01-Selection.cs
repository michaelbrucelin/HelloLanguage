using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{
    public class Selection : SortTemplate
    {
        /// <summary>
        /// 选择排序
        /// 首先，找到数组中最小的那个元素，其次，将它和数组的第一个元素交换位置（如果第一个元素就是最小元素那么它就和自己交换）。
        /// 再次，在剩下的元素中找到最小的元素，将它与数组的第二个元素交换位置。
        /// 如此往复，直到将整个数组排序。这种方法叫做选择排序，因为它在不断地选择剩余元素之中的最小者。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        public override void Sort<T>(T[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int minId = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (Less<T>(arr[j], arr[minId]))
                        minId = j;
                }
                if (minId != i)
                    Exch<T>(arr, i, minId);
            }
        }
    }
}
