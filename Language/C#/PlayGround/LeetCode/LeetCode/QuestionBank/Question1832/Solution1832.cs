using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1832
{
    public class Solution1832
    {
        public bool CheckIfPangram(string sentence)
        {
            HashSet<char> buffer = new HashSet<char>();

            for (int i = 0; i < sentence.Length; i++)
            {
                if (!buffer.Contains(sentence[i]))
                {
                    buffer.Add(sentence[i]);
                    if (buffer.Count == 26)
                        return true;
                }
            }

            return false;
        }

        public bool CheckIfPangram2(string sentence)
        {
            return new HashSet<char>(sentence).Count == 26;
        }
    }
}
