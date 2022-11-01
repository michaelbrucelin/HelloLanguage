using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1662
{
    public class Solution1662_2 : Interface1662
    {
        /// <summary>
        /// 双指针直接遍历
        /// </summary>
        /// <param name="word1"></param>
        /// <param name="word2"></param>
        /// <returns></returns>
        public bool ArrayStringsAreEqual(string[] word1, string[] word2)
        {
            int i = 0, j = 0, p = 0, q = 0;
            while (i < word1.Length && j < word2.Length)
            {
                if (word1[i][p++] != word2[j][q++]) return false;
                if (p == word1[i].Length) { p = 0; i++; }
                if (q == word2[j].Length) { q = 0; j++; }
            }

            return i == word1.Length && j == word2.Length;
        }
    }
}
