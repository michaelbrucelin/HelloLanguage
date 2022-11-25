using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0809
{
    public class Solution0809_3 : Interface0809
    {
        /// <summary>
        /// 预处理 + 双指针
        /// 即将Solution0809与Solution0809_2结合起来
        /// </summary>
        /// <param name="s"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public int ExpressiveWords(string s, string[] words)
        {
            List<(char c, int cnt)> sinfo = GetExpressiveInfo(s);

            int result = 0;
            for (int i = 0; i < words.Length; i++)
                if (IsExpressiveWord(sinfo, words[i])) result++;  // 进一步优化，在调用IsExpressiveWord()之前，先判断s与word[i]的长度，这里就不写了

            return result;
        }

        private List<(char c, int cnt)> GetExpressiveInfo(string s)
        {
            List<(char c, int cnt)> result = new List<(char c, int cnt)>();
            int len = s.Length, ptr = 0, cnt = 1;
            while (ptr < len)
            {
                if (ptr + 1 < len && s[ptr + 1] == s[ptr]) cnt++;
                else
                {
                    result.Add((s[ptr], cnt)); cnt = 1;
                }
                ptr++;
            }

            return result;
        }

        private bool IsExpressiveWord(List<(char c, int cnt)> s, string word)
        {
            int ptr_s = 0, ptr_w = 0, len_s = s.Count, len_w = word.Length;
            while (ptr_s < len_s && ptr_w < len_w)
            {
                if (s[ptr_s].c != word[ptr_w]) return false;
                int cnt_s = s[ptr_s].cnt, cnt_w = 1;
                while (ptr_w + 1 < len_w && word[ptr_w + 1] == word[ptr_w]) { cnt_w++; ptr_w++; }
                if (!(cnt_s == cnt_w || cnt_s >= Math.Max(cnt_w, 3))) return false;
                ptr_s++; ptr_w++;
            }

            return ptr_s == len_s && ptr_w == len_w;
        }
    }
}
