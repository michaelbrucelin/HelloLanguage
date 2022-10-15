using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0020
{
    public class Solution0020 : Interface0020
    {
        public bool IsValid(string s)
        {
            if ((s.Length & 1) == 1) return false;

            Stack<char> helper = new Stack<char>();
            Dictionary<char, char> pairs = new Dictionary<char, char>() { { '(', ')' }, { '[', ']' }, { '{', '}' } };

            for (int i = 0; i < s.Length; i++)
            {
                if (pairs.ContainsKey(s[i])) helper.Push(s[i]);
                else
                {
                    if (helper.Count == 0 || pairs[helper.Pop()] != s[i])
                        return false;
                }
            }

            return helper.Count == 0;
        }
    }
}
