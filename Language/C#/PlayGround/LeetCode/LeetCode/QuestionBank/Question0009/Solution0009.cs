using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0009
{
    public class Solution0009
    {
        public bool IsPalindrome(int x)
        {
            if (x < 0) return false;

            return x.ToString() == new string(x.ToString().Reverse().ToArray());
        }

        public bool IsPalindrome2(int x)
        {
            if (x < 0) return false;

            string str_x = x.ToString();
            int left = 0;
            int right = str_x.Length - 1;
            while (left < right)
            {
                if (str_x[left++] != str_x[right--])
                    return false;
            }

            return true;
        }
    }
}
