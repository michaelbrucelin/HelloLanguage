using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0791
{
    public class Solution0791 : Interface0791
    {
        /// <summary>
        /// 将s转为Dictionary<char, int>分析
        /// </summary>
        /// <param name="order"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public string CustomSortString(string order, string s)
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
                if (dic.ContainsKey(s[i])) dic[s[i]]++; else dic.Add(s[i], 1);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < order.Length; i++)
            {
                if (dic.ContainsKey(order[i]))
                {
                    for (int j = 0; j < dic[order[i]]; j++) sb.Append(order[i]);
                    dic.Remove(order[i]);
                }
            }
            foreach (char c in dic.Keys)
                for (int i = 0; i < dic[c]; i++) sb.Append(c);

            return sb.ToString();
        }
    }
}
