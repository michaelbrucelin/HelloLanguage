using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1662
{
    public class Solution1662 : Interface1662
    {
        /// <summary>
        /// 使用.Net LINQ API
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public bool ArrayStringsAreEqual(string[] word1, string[] word2)
        {
            return word1.Aggregate((s1, s2) => $"{s1}{s2}") == word2.Aggregate((s1, s2) => $"{s1}{s2}");
        }

        /// <summary>
        /// 使用.Net LINQ API
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public bool ArrayStringsAreEqual2(string[] word1, string[] word2)
        {
            char[] s1 = word1.SelectMany(s => s).ToArray();
            char[] s2 = word2.SelectMany(s => s).ToArray();
            if (s1.Length != s2.Length) return false;

            int len = s1.Length;
            for (int i = 0; i < len; i++)
                if (s1[i] != s2[i]) return false;

            return true;
        }
    }
}
