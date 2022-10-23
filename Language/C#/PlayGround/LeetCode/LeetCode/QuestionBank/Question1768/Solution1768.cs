using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1768
{
    public class Solution1768 : Interface1768
    {
        public string MergeAlternately(string word1, string word2)
        {
            char[] result = new char[word1.Length + word2.Length];
            int i = 0;
            for (; i < word1.Length && i < word2.Length; i++)
            {
                result[i * 2] = word1[i];
                result[i * 2 + 1] = word2[i];
            }
            int k = i * 2;
            while (i < word1.Length) { result[k] = word1[i]; k++; i++; }
            while (i < word2.Length) { result[k] = word2[i]; k++; i++; }

            return new string(result);
        }
    }
}
