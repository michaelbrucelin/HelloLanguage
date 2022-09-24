using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0012
{
    public class Solution0012 : Interface0012
    {
        /// <summary>
        /// 一点一点分析即可，利用好 1 <= num <= 3999 这个条件
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string IntToRoman(int num)
        {
            StringBuilder sb = new StringBuilder();

            int thousand = num / 1000;
            for (int i = 0; i < thousand; i++) sb.Append('M');
            num = num % 1000;

            int hundred = num / 100;
            if (hundred == 9) sb.Append("CM");
            else if (hundred >= 5) { sb.Append('D'); for (int i = 0; i < hundred - 5; i++) sb.Append('C'); }
            else if (hundred == 4) sb.Append("CD");
            else for (int i = 0; i < hundred; i++) sb.Append('C');
            num = num % 100;

            int ten = num / 10;
            if (ten == 9) sb.Append("XC");
            else if (ten >= 5) { sb.Append('L'); for (int i = 0; i < ten - 5; i++) sb.Append('X'); }
            else if (ten == 4) sb.Append("XL");
            else for (int i = 0; i < ten; i++) sb.Append('X');
            num = num % 10;

            if (num == 9) sb.Append("IX");
            else if (num >= 5) { sb.Append('V'); for (int i = 0; i < num - 5; i++) sb.Append('I'); }
            else if (num == 4) sb.Append("IV");
            else for (int i = 0; i < num; i++) sb.Append('I');

            return sb.ToString();
        }

        /// <summary>
        /// 对上面方法做一次封装
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public string IntToRoman2(int num)
        {
            StringBuilder sb = new StringBuilder();

            int thousand = num / 1000;
            for (int i = 0; i < thousand; i++) sb.Append('M');
            num = num % 1000;

            int hundred = num / 100;
            ToRoman(sb, hundred, 'M', 'D', 'C');
            num = num % 100;

            int ten = num / 10;
            ToRoman(sb, ten, 'C', 'L', 'X');
            num = num % 10;

            ToRoman(sb, num, 'X', 'V', 'I');

            return sb.ToString();
        }

        private void ToRoman(StringBuilder sb, int n, char c1, char c2, char c3)
        {
            if (n == 9) { sb.Append(c3); sb.Append(c1); }
            else if (n >= 5) { sb.Append(c2); for (int i = 0; i < n - 5; i++) sb.Append(c3); }
            else if (n == 4) { sb.Append(c3); sb.Append(c2); }
            else for (int i = 0; i < n; i++) sb.Append(c3);
        }
    }
}
