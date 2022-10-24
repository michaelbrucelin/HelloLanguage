using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0915
{
    public class Solution0915_2 : Interface0915
    {
        public int PartitionDisjoint(int[] nums)
        {
            int[] min_r = new int[nums.Length];
            min_r[nums.Length - 1] = nums[nums.Length - 1];
            for (int i = nums.Length - 2; i >= 0; i--)
                min_r[i] = Math.Min(nums[i], min_r[i + 1]);

            int max_l = nums[0], id = 0;
            while (id < nums.Length - 1)
            {
                max_l = Math.Max(max_l, nums[id]);
                if (max_l <= min_r[id + 1]) return id + 1;
                id++;
            }

            return -1;  // 一定有解，所以不会执行到此处
        }
    }
}
