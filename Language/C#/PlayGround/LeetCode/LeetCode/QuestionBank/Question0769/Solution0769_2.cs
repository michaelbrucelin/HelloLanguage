using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0769
{
    public class Solution0769_2 : Interface0769
    {
        /// <summary>
        /// 本质上就是对Solution0769.MaxChunksToSorted2()的数学上的优化
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int MaxChunksToSorted(int[] arr)
        {
            int result = 0;
            int max = -1;
            for (int i = 0; i < arr.Length; i++)
            {
                max = Math.Max(max, arr[i]);
                if (max == i) result++;
            }

            return result;
        }
    }
}
