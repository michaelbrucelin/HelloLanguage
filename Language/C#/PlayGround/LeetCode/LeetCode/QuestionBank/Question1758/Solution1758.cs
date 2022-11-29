using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1758
{
    public class Solution1758 : Interface1758
    {
        /// <summary>
        /// 最终结果只有两种可能，0开头或1开头，所以原字符串与中两种结果比较一下，取较小的结果就可以
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MinOperations(string s)
        {
            if (s.Length == 1) return 0;
            if (s.Length == 2) return (s == "01" || s == "10") ? 0 : 1;

            int r0 = 0, r1 = 0;
            for (int i = 0; i < s.Length; i += 2) if (s[i] == '0') r0++;
            for (int i = 1; i < s.Length; i += 2) if (s[i] == '1') r0++;
            for (int i = 0; i < s.Length; i += 2) if (s[i] == '1') r1++;
            for (int i = 1; i < s.Length; i += 2) if (s[i] == '0') r1++;

            return r0 <= r1 ? r0 : r1;
        }
    }
}
