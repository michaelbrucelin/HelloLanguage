using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1684
{
    public class Solution1684_2 : Interface1684
    {
        public int CountConsistentStrings(string allowed, string[] words)
        {
            int result = 0;
            int mask = 0;
            for (int i = 0; i < allowed.Length; i++) mask |= (1 << (allowed[i] - 'a'));
            for (int i = 0; i < words.Length; i++)
            {
                int mask_i = 0;
                for (int j = 0; j < words[i].Length; j++) mask_i |= (1 << (words[i][j] - 'a'));
                if ((mask_i | mask) == mask) result++;
            }

            return result;
        }

        /// <summary>
        /// 引入中间变量试试（foreach自动就引入中间变量了），看看会不会变快
        /// </summary>
        /// <param name="allowed"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public int CountConsistentStrings2(string allowed, string[] words)
        {
            int result = 0;
            int mask = 0;
            foreach (char c in allowed) mask |= (1 << (c - 'a'));
            foreach (string word in words)
            {
                int mask_i = 0;
                foreach (char c in word) mask_i |= (1 << (c - 'a'));
                if ((mask_i | mask) == mask) result++;
            }

            return result;
        }
    }
}
