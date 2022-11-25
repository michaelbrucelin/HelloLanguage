using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0809
{
    public class Solution0809 : Interface0809
    {
        /// <summary>
        /// 预处理
        /// 测试知"helllllo"是"hellllo"的扩张结果，所以可以使用将两个字符串整理成下面两个数组
        /// "helllllo"：[(h,1), (e,1), (l,5), (o,1)]  即字符出现的顺序及数量
        /// "hellllo":  [(h,1), (e,1), (l,4), (o,1)]
        /// 只要保证字符出现的顺序一样，数量要么与原字符串中字符的数量一样，要么比原字符串中字符的数量大，且至少为3
        /// </summary>
        /// <param name="s"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public int ExpressiveWords(string s, string[] words)
        {
            List<(char c, int cnt)> sinfo = GetExpressiveInfo(s);

            int result = 0;
            for (int i = 0; i < words.Length; i++)
                if (IsExpressiveWord(sinfo, words[i])) result++;

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

        private bool IsExpressiveWord(List<(char c, int cnt)> sinfo, string word)
        {
            List<(char c, int cnt)> winfo = GetExpressiveInfo(word);

            if (sinfo.Count != winfo.Count) return false;
            for (int i = 0; i < winfo.Count; i++)
            {
                if (sinfo[i].c != winfo[i].c) return false;
                if (!(sinfo[i].cnt == winfo[i].cnt || sinfo[i].cnt >= Math.Max(winfo[i].cnt, 3))) return false;
            }
            return true;
        }
    }
}
