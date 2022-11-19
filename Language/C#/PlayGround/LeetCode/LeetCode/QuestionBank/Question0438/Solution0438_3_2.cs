using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0438
{
    public class Solution0438_3_2 : Interface0438
    {
        /// <summary>
        /// 与Solution0438_3一样，添加了判断“出窗口”与“入窗口”的字符是否一样
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public IList<int> FindAnagrams(string s, string p)
        {
            List<int> result = new List<int>();
            if (s.Length < p.Length) return result;

            int len_s = s.Length, len_p = p.Length;
            int diff = 0; int[] helper = new int[26];
            for (int i = 0; i < len_p; i++) { helper[p[i] - 'a']++; helper[s[i] - 'a']--; }
            diff = helper.Count(i => i != 0);
            bool last_status = false;
            if (diff == 0) { result.Add(0); last_status = true; }
            for (int i = 1; i <= len_s - len_p; i++)
            {
                if (s[i - 1] == s[i + len_p - 1])
                {
                    if (last_status) result.Add(i);
                    continue;
                }

                int id_out = s[i - 1] - 'a', id_in = s[i + len_p - 1] - 'a';
                if (++helper[id_out] == 0) diff--; else if (helper[id_out] == 1) diff++;
                if (--helper[id_in] == 0) diff--; else if (helper[id_in] == -1) diff++;

                if (diff == 0) { result.Add(i); last_status = true; } else last_status = false;
            }

            return result;
        }
    }
}
