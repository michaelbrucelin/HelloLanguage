using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1822
{
    public class Solution1822_2 : Interface1822
    {
        public int ArraySign(int[] nums)
        {
            if (nums.Contains(0)) return 0;
            if ((nums.Count(i => i < 0) & 1) == 1) return -1;
            return 1;
        }
    }
}
