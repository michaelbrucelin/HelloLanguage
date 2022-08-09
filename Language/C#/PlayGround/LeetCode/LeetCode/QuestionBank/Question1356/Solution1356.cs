using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1356
{
    public class Solution1356
    {
        public int[] SortByBits(int[] arr)
        {
            return arr.OrderBy(i => GetBits(i)).ThenBy(i => i).ToArray();
        }

        /// <summary>
        /// 计算整数对应二进制中1的数量
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private int GetBits(int i)
        {
            int result = 0;

            while (i > 0)
            {
                result++;
                i &= (i - 1);
            }

            return result;
        }
    }
}
