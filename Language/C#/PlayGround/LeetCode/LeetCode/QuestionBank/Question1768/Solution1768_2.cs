using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1768
{
    public class Solution1768_2 : Interface1768
    {
        public string MergeAlternately(string word1, string word2)
        {
            StringBuilder sb = new StringBuilder();
            int i = 0, j = 0;
            while (i < word1.Length || j < word2.Length)
            {
                if (i < word1.Length) sb.Append(word1[i++]);
                if (j < word2.Length) sb.Append(word2[j++]);
            }

            return sb.ToString();
        }

        public string MergeAlternately2(string word1, string word2)
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            for (; i < word1.Length && i < word2.Length; i++)
            {
                sb.Append(word1[i]);
                sb.Append(word2[i]);
            }

            if (i < word1.Length)
                return sb.ToString() + word1.Substring(i);
            else if (i < word2.Length)
                return sb.ToString() + word2.Substring(i);
            else
                return sb.ToString();
        }

        public string MergeAlternately3(string word1, string word2)
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            for (; i < word1.Length && i < word2.Length; i++)
            {
                sb.Append(word1[i]);
                sb.Append(word2[i]);
            }

            if (i < word1.Length)
                sb.Append(word1.Substring(i));
            else if (i < word2.Length)
                sb.Append(word2.Substring(i));

            return sb.ToString();
        }
    }
}
