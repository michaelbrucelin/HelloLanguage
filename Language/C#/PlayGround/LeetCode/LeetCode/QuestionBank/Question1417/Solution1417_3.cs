using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1417
{
    public class Solution1417_3
    {
        public string Reformat(string s)
        {
            int digitcnt = 0, lettercnt;
            for (int i = 0; i < s.Length; i++)
                if (char.IsDigit(s[i])) digitcnt++;
            lettercnt = s.Length - digitcnt;

            if (digitcnt - lettercnt > 1 || digitcnt - lettercnt < -1)
                return "";

            bool flag;  // true：偶数位digit，奇数位letter；false：偶数位letter，奇数位digit；
            if (digitcnt == lettercnt) flag = char.IsDigit(s[0]);
            else flag = (digitcnt > lettercnt);

            char[] buffer = s.ToCharArray();
            int even = 0, odd = 1;  // even遍历偶数位，odd遍历奇数位
            for (; even < buffer.Length; even += 2)
            {
                if (char.IsDigit(buffer[even]) != flag)
                {
                    for (; odd < buffer.Length; odd += 2)
                    {
                        if (char.IsDigit(buffer[odd]) == flag)
                        {
                            Swap(buffer, even, odd);
                            break;
                        }
                    }
                }
            }

            return new string(buffer);
        }

        private void Swap(char[] arr, int i, int j)
        {
            char temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
