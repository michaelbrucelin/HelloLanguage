using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1422
{
    public class Solution1422
    {
        public int MaxScore(string s)
        {
            int[] cnt0arr = new int[s.Length - 1];
            int[] cnt1arr = new int[s.Length - 1];

            int cnt0 = 0;
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] == '0') cnt0++;
                cnt0arr[i] = cnt0;
            }

            int cnt1 = 0;
            for (int j = s.Length - 1; j > 0; j--)
            {
                if (s[j] == '1') cnt1++;
                cnt1arr[j - 1] = cnt1;
            }

            int result = 0;
            for (int i = 0; i < s.Length - 1; i++)
            {
                result = Math.Max(result, cnt0arr[i] + cnt1arr[i]);
            }

            return result;
        }
    }
}