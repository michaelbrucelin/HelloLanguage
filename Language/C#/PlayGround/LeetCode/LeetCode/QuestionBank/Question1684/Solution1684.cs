using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1684
{
    public class Solution1684 : Interface1684
    {
        public int CountConsistentStrings(string allowed, string[] words)
        {
            int result = 0;
            HashSet<char> chars = new HashSet<char>(allowed);
            for (int i = 0; i < words.Length; i++)
            {
                int j = 0;
                for (; j < words[i].Length && chars.Contains(words[i][j]); j++) ;
                if (j == words[i].Length) result++;
            }

            return result;
        }

        public int CountConsistentStrings2(string allowed, string[] words)
        {
            HashSet<char> chars = new HashSet<char>(allowed);
            return words.Count(str => str.All(c => chars.Contains(c)));
        }
    }
}
