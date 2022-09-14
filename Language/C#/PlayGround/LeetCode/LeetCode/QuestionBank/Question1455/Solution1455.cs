using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1455
{
    public class Solution1455 : Interface1455
    {
        public int IsPrefixOfWord(string sentence, string searchWord)
        {
            string[] words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].StartsWith(searchWord))
                    return i + 1;
            }
            return -1;
        }
    }
}
