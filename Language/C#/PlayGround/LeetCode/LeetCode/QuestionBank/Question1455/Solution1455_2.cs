using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1455
{
    public class Solution1455_2 : Interface1455
    {
        public int IsPrefixOfWord(string sentence, string searchWord)
        {
            int start = 0, id = 1;
            int position = start;
            while (start < sentence.Length)
            {
                while (position < sentence.Length && sentence[position] != ' ') position++;
                if (position - start >= searchWord.Length)
                    if (_IsPrefix(sentence, start, searchWord))
                        return id;
                start = ++position;
                id++;
            }

            return -1;
        }

        private bool _IsPrefix(string sentence, int start, string searchWord)
        {
            // 专用辅助流程，searchWord长度一定小于等于word的长度
            for (int i = 0; i < searchWord.Length; i++)
            {
                if (sentence[start + i] != searchWord[i])
                    return false;
            }
            return true;
        }
    }
}