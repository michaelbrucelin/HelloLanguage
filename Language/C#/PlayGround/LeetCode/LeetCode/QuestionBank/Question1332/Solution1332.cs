using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1332
{
    public class Solution1332
    {
        public int RemovePalindromeSub(string s)
        {
            int left = 0, right = s.Length - 1;
            while (left < right)
            {
                if (s[left++] != s[right--])
                    return 2;
            }

            return 1;
        }
    }
}
