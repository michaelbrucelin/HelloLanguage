using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0013
{
    public class Solution0013 : Interface0013
    {
        private readonly Dictionary<string, int> helper = new Dictionary<string, int>() {
            {"I", 1}, {"V", 5}, {"X", 10}, {"L", 50}, {"C", 100}, {"D", 500}, {"M", 1000}
            , {"IV", 4}, {"IX", 9}, {"XL", 40}, {"XC", 90}, {"CD", 400}, {"CM", 900}
        };

        public int RomanToInt(string s)
        {
            int result = 0;

            char[] chars = s.ToCharArray();
            int i = 0;
            while (i < chars.Length)
            {
                if ((i + 1) < chars.Length && helper.ContainsKey(new string(chars, i, 2)))
                {
                    result += helper[new string(chars, i, 2)];
                    i += 2;
                }
                else
                {
                    result += helper[chars[i].ToString()];
                    i++;
                }
            }

            return result;
        }
    }
}
