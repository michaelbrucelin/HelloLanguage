using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0013
{
    public class Solution0013_2 : Interface0013
    {
        private readonly Dictionary<char, int> helper = new Dictionary<char, int>() {
            {'I', 1}, {'V', 5}, {'X', 10}, {'L', 50}, {'C', 100}, {'D', 500}, {'M', 1000}
        };

        public int RomanToInt(string s)
        {
            int result = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int value = helper[s[i]];
                if ((i + 1) < s.Length && helper[s[i + 1]] > value)
                {
                    result = result + helper[s[i + 1]] - value;
                    i++;
                }
                else
                    result += value;
            }

            return result;
        }
    }
}
