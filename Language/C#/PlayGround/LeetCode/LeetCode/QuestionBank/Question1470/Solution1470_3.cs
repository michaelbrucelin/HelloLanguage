using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1470
{
    public class Solution1470_3
    {
        public int[] Shuffle(int[] nums, int n)
        {
            for (int i = 1; i < n * 2 - 1; i++)
            {
                int j = i;
                while (nums[i] > 0)
                {
                    j = j < n ? j << 1 : ((j - n) << 1) + 1;
                    Swap(nums, i, j);
                    nums[j] *= -1;
                }
            }

            for (int i = 1; i < n * 2 - 1; i++)
                nums[i] *= -1;

            return nums;
        }

        private void Swap(int[] nums, int i, int j)
        {
            if (i == j) return;

            nums[i] = nums[i] ^ nums[j];
            nums[j] = nums[j] ^ nums[i];
            nums[i] = nums[i] ^ nums[j];
        }
    }
}
