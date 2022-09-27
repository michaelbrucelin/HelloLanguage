using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0014
{
    public class Solution0014 : Interface0014
    {
        /// <summary>
        /// 先找出长度最小的那个字符串，然后逐个比对
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 1) return strs[0];

            int minid = 0;
            for (int i = 1; i < strs.Length; i++)
                if (strs[i].Length < strs[minid].Length) minid = i;

            string result = strs[minid];
            for (int i = 0; i < strs.Length; i++)
            {
                int j = 0;
                while (j < result.Length && result[j] == strs[i][j]) j++;

                if (j == 0) return "";
                if (j < result.Length) result = result.Substring(0, j);
            }

            return result;
        }
    }
}
