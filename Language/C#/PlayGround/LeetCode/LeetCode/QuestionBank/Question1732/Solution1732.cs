using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1732
{
    public class Solution1732 : Interface1732
    {
        public int LargestAltitude(int[] gain)
        {
            int result = 0, high = 0;
            for (int i = 0; i < gain.Length; i++)
                result = Math.Max(result, high += gain[i]);

            return result;
        }
    }
}
