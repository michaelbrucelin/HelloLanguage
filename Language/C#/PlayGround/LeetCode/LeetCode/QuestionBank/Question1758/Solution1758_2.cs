using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1758
{
    public class Solution1758_2 : Interface1758
    {
        public int MinOperations(string s)
        {
            if (s.Length == 1) return 0;
            if (s.Length == 2) return (s == "01" || s == "10") ? 0 : 1;

            int cnt = 0;
            for (int i = 0; i < s.Length; i += 2) if (s[i] == '0') cnt++;
            for (int i = 1; i < s.Length; i += 2) if (s[i] == '1') cnt++;

            return Math.Min(cnt, s.Length - cnt);
        }
    }
}
