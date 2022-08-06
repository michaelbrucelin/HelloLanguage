using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0551
{
    public class Solution0551
    {
        public bool CheckRecord(string s)
        {
            if (s.Length - s.Replace("A", "").Length >= 2)
                return false;

            if (s.Contains("LLL"))
                return false;

            return true;
        }

        public bool CheckRecord2(string s)
        {
            int absents = 0, lates = 0;
            int n = s.Length;
            for (int i = 0; i < n; i++)
            {
                char c = s[i];
                if (c == 'A')
                {
                    absents++;
                    if (absents >= 2)
                    {
                        return false;
                    }
                }
                if (c == 'L')
                {
                    lates++;
                    if (lates >= 3)
                    {
                        return false;
                    }
                }
                else
                {
                    lates = 0;
                }
            }
            return true;
        }
    }
}
