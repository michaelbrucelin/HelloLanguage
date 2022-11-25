using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0809
{
    public class Solution0809_2 : Interface0809
    {
        /// <summary>
        /// 双指针
        /// 本质上与Solution0809是一样的，不过这里采用了类似于C的朴素的上指针来解决
        /// 这样内存使用的更少，但是每次都需要遍历s，即没有预处理s
        /// </summary>
        /// <param name="s"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public int ExpressiveWords(string s, string[] words)
        {
            int result = 0;
            for (int i = 0; i < words.Length; i++)
                if (IsExpressiveWord(s, words[i])) result++;

            return result;
        }

        private bool IsExpressiveWord(string s, string word)
        {
            if (s.Length < word.Length) return false;

            int ptr_s = 0, ptr_w = 0, len_s = s.Length, len_w = word.Length;
            while (ptr_s < len_s && ptr_w < len_w)
            {
                if (s[ptr_s] != word[ptr_w]) return false;
                int cnt_s = 1, cnt_w = 1;
                while (ptr_s + 1 < len_s && s[ptr_s + 1] == s[ptr_s]) { cnt_s++; ptr_s++; }
                while (ptr_w + 1 < len_w && word[ptr_w + 1] == word[ptr_w]) { cnt_w++; ptr_w++; }
                if (!(cnt_s == cnt_w || cnt_s >= Math.Max(cnt_w, 3))) return false;
                ptr_s++; ptr_w++;
            }
            if (ptr_s < len_s || ptr_w < len_w) return false;

            return true;

            // return ptr_s == len_s && ptr_w == len_w
        }
    }
}
