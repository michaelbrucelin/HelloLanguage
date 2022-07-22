using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp
{
    public class Insertion : SortTemplate
    {
        /// <summary>
        /// 插入排序
        /// 通常人们整理桥牌的方法是一张一张的来，将每一张牌插入到其他已经有序的牌中的适当位置。
        /// 在计算机的实现中，为了给要插入的元素腾出空间，我们需要将其余所有元素在插入之前都向右移动一位。这种算法叫做插入排序。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        public override void Sort<T>(T[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = i; j > 0 && Less<T>(arr[j], arr[j - 1]); j--)
                    Exch<T>(arr, j, j - 1);
            }
        }
    }
}
