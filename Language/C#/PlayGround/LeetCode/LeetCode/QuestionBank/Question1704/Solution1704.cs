using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1704
{
    public class Solution1704 : Interface1704
    {
        private static readonly HashSet<char> vowels = new HashSet<char>() { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

        public bool HalvesAreAlike(string s)
        {
            int cnt1 = 0, cnt2 = 0, len = s.Length, mid = (s.Length >> 1);
            for (int i = 0; i < mid; i++) if (vowels.Contains(s[i])) cnt1++;
            for (int i = mid; i < len; i++) if (vowels.Contains(s[i])) cnt2++;

            return cnt1 == cnt2;
        }
    }
}
