using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0768
{
    public class Solution0768 : Interface0768
    {
        /// <summary>
        /// 思路
        /// 假定一个范围不可分割，且其中最大元素为MAX
        ///     如果后面的元素的全部大于等于MAX，那个该范围就是一个分区
        ///     如果后面存在元素小于MAX，那么那个不可分割的范围需要扩大到第一个小于MAX的元素，并成为一个新的不可分割的范围，然后重复上面的分析
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int MaxChunksToSorted(int[] arr)
        {
            int result = 0;

            int anchor = 0, anchor_max = 0, anchor_max_temp = 0;
            while (anchor < arr.Length)
            {
                int p = anchor + 1;
                for (; p < arr.Length; p++)
                {
                    if (arr[p] > arr[anchor_max_temp])
                    {
                        anchor_max_temp = p;
                        continue;
                    }

                    if (arr[p] < arr[anchor_max]) break;
                }

                if (p < arr.Length)
                {
                    anchor = p;
                    anchor_max = anchor_max_temp;
                }
                else
                {
                    result++;
                    anchor++;
                    anchor_max_temp = anchor_max = anchor;
                }
            }

            return result;
        }
    }
}
