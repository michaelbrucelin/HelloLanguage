using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0014
{
    public class Solution0014_2 : Interface0014
    {
        /// <summary>
        /// 先排序，后比较头尾即可
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 1) return strs[0];

            Array.Sort(strs);

            string s1 = strs[0];
            string s2 = strs[strs.Length - 1];
            if (s1.Length > s2.Length) (s1, s2) = (s2, s1);
            int i = 0;
            while (i < s1.Length && s1[i] == s2[i]) i++;

            return s1.Substring(0, i);
        }
    }
}
