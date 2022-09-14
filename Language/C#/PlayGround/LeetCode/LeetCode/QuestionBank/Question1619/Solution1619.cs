using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1619
{
    public class Solution1619 : Interface1619
    {
        /// <summary>
        /// .Net Core 5.0中没有PriorityQueue，这里使用数组代替，就不实现最大堆与最小堆了
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public double TrimMean(int[] arr)
        {
            int sum = 0;
            int len = arr.Length;
            int removeCnt = len / 20;

            int[] minarr = new int[removeCnt], maxarr = new int[removeCnt], buffer = new int[removeCnt * 2];
            Array.Copy(arr, buffer, buffer.Length);
            Array.Sort(buffer);
            Array.Copy(buffer, minarr, removeCnt);
            Array.Copy(buffer, removeCnt, maxarr, 0, removeCnt);

            for (int i = removeCnt * 2; i < arr.Length; i++)
            {
                if (arr[i] < minarr[minarr.Length - 1])
                {
                    sum += minarr[minarr.Length - 1];
                    minarr[minarr.Length - 1] = arr[i]; Array.Sort(minarr);
                }
                else if (arr[i] > maxarr[0])
                {
                    sum += maxarr[0];
                    maxarr[0] = arr[i]; Array.Sort(maxarr);
                }
                else sum += arr[i];
            }

            return sum * 1d / (len - removeCnt - removeCnt);
        }
    }
}
