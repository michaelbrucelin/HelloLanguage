using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0438
{
    public class Solution0438 : Interface0438
    {
        /// <summary>
        /// 滑动窗口
        /// 1. 用一个长度为26的数组记录p中每一个小写字母的数量
        /// 2. 遍历s中与p相同的字串，减去数组中对应字母的数量，如果数组中全部数据都为0.则是p的一个异位词
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public IList<int> FindAnagrams(string s, string p)
        {
            List<int> result = new List<int>();
            if (s.Length < p.Length) return result;

            int len_s = s.Length, len_p = p.Length;
            int[] helper = new int[26];
            for (int i = 0; i < len_p; i++) { helper[p[i] - 'a']++; helper[s[i] - 'a']--; }
            if (helper.All(i => i == 0)) result.Add(0);
            for (int i = 1; i <= len_s - len_p; i++)
            {
                helper[s[i - 1] - 'a']++; helper[s[i + len_p - 1] - 'a']--;
                if (helper.All(i => i == 0)) result.Add(i);
            }

            return result;
        }
    }
}
