using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1422
{
    public class Solution1422_2
    {
        public int MaxScore(string s)
        {
            int score = s[0] == '0' ? 1 : 0;  // score是从第一个字符后拆分的结果
            for (int i = 1; i < s.Length; i++)
                if (s[i] == '1') score++;

            int result = score;
            for (int i = 1; i < s.Length - 1; i++)
            {
                if (s[i] == '0') score++;
                else score--;

                result = Math.Max(result, score);
            }

            return result;
        }
    }
}