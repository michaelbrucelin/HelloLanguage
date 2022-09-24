using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0012
{
    public class Solution0012_2 : Interface0012
    {
        private readonly (int value, string symbol)[] helper = {
            (1000, "M"),
            (900, "CM"), (500, "D"), (400, "CD"), (100, "C"),
            (90, "XC"),  (50, "L"),  (40, "XL"),  (10, "X"),
            (9, "IX"),   (5, "V"),   (4, "IV"),   (1, "I")
        };

        public string IntToRoman(int num)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < helper.Length; i++)
            {
                int value = helper[i].value;
                string symbol = helper[i].symbol;
                while (num >= value)
                {
                    num -= value;
                    sb.Append(symbol);
                }
                if (num == 0) break;
            }

            return sb.ToString();
        }
    }
}
