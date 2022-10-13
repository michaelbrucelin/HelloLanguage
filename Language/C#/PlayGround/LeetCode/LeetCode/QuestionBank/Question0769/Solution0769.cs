using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0769
{
    public class Solution0769 : Interface0769
    {
        /// <summary>
        /// 由题目定义不用排序也知道数组排序后的结果
        /// 块需要满足一下两点
        ///     1. 块中任意元素都大于左侧的任意元素
        ///     2. 块中任意元素都小于右侧的任意元素
        /// 即块中的元素集合与排序后对应位置的元素集合一致
        /// 最多的块，即全部取最小的块
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int MaxChunksToSorted(int[] arr)
        {
            int result = 0;

            HashSet<int> helper = new HashSet<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == i)
                {
                    if (helper.Count == 0) result++;
                }
                else  // arr[i] != i
                {
                    if (helper.Contains(i)) helper.Remove(i); else helper.Add(i);
                    if (helper.Contains(arr[i])) helper.Remove(arr[i]); else helper.Add(arr[i]);

                    if (helper.Count == 0) result++;
                }
            }

            return result;
        }
    }
}
