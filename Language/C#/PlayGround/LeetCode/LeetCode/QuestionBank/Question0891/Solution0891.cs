using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0891
{
    public class Solution0891 : Interface0891
    {
        public int SumSubseqWidths(int[] nums)
        {
            if (nums.Length <= 1) return 0;
            if (nums.Length == 2) return Math.Abs(nums[0] - nums[1]);

            long result = 0;
            const int MOD = 1000000007;
            Array.Sort(nums);
            long x = nums[0], y = 2;
            for (int j = 1; j < nums.Length; j++)
            {
                result = (result + nums[j] * (y - 1) - x) % MOD;
                x = (x * 2 + nums[j]) % MOD;
                y = y * 2 % MOD;
            }
            return (int)((result + MOD) % MOD);
        }
    }
}
