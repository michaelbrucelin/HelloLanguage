using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0005
{
    public class Solution0005 : Interface0005
    {
        /// <summary>
        /// 假定字符串的长度为len
        /// 先验证长度为len的子串，共1个
        /// 再验证长度为len-1的子串，共2个
        /// 再验证长度为len-2的子串，共3个
        /// ... ...
        /// 直至找到一个回文子串为止
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string LongestPalindrome(string s)
        {
            int len = s.Length;
            while (len > 0)
            {
                for (int i = 0; i < s.Length - len + 1; i++)
                    if (IsPalindrome(s, i, i + len - 1)) return s.Substring(i, len);

                len--;
            }

            return s.Substring(0, 1);
        }

        private bool IsPalindrome(string s, int start, int end)
        {
            while (start < end)
            {
                if (s[start] != s[end])
                    return false;
                start++;
                end--;
            }

            return true;
        }
    }
}
