using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0032
{
    public class Solution0032_5 : Interface0032
    {
        public int LongestValidParentheses(string s)
        {
            int result = 0;
            int left = 0, right = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(') left++;
                else
                {
                    right++;
                    if (left == right) result = Math.Max(result, (left << 1));
                    else if (left < right) left = right = 0;
                }
            }

            left = 0; right = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == ')') right++;
                else
                {
                    left++;
                    if (right == left) result = Math.Max(result, (right << 1));
                    else if (right < left) right = left = 0;
                }
            }

            return result;
        }
    }
}
