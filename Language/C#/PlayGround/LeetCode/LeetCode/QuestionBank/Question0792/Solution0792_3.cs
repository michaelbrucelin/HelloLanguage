using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0792
{
    public class Solution0792_3 : Interface0792
    {
        /// <summary>
        /// 多指针
        /// 遍历s的每一个字符，同时检查每一个words中对应指针指向的字符
        /// 本地测试逻辑没问题，提交会超时
        /// </summary>
        /// <param name="s"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public int NumMatchingSubseq(string s, string[] words)
        {
            int len = words.Length;
            bool[] flags = new bool[len];  // 记录对应字符串是否已经检查完毕
            int[] ptrs = new int[len];     // 记录每一个word的指针
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                for (int j = 0; j < len; j++)
                {
                    if (!flags[j] && words[j][ptrs[j]] == c)
                    {
                        ptrs[j]++;
                        if (ptrs[j] == words[j].Length) flags[j] = true;
                    }
                }
            }

            return flags.Count(b => b);
        }
    }
}
