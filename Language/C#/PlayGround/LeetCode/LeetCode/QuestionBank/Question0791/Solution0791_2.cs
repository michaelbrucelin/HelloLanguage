using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0791
{
    public class Solution0791_2 : Interface0791
    {
        /// <summary>
        /// 将order转为Dictionary<char, int>分析
        /// </summary>
        /// <param name="order"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public string CustomSortString(string order, string s)
        {
            Dictionary<char, int> ordermap = order.Select((c, i) => (c, i)).ToDictionary(item => item.c, item => item.i);
            return new string(s.OrderBy(c => ordermap.ContainsKey(c) ? ordermap[c] : 100).ToArray());
        }
    }
}
