using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0012
{
    public class Solution0012_3 : Interface0012
    {
        private readonly string[] thousands = { "", "M", "MM", "MMM" };
        private readonly string[] hundreds = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
        private readonly string[] tens = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
        private readonly string[] ones = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

        public string IntToRoman(int num)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(thousands[num / 1000]);
            sb.Append(hundreds[num % 1000 / 100]);
            sb.Append(tens[num % 100 / 10]);
            sb.Append(ones[num % 10]);

            return sb.ToString();
        }
    }
}
