using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0667
{
    public class Test0667
    {
        public void Test()
        {
            Interface0667 solution = new Solution0667();
            int n, k;
            int[] nums;
            int id = 0;

            // 1. 
            n = 3; k = 1; nums = solution.ConstructArray(n, k);
            Console.Write($"{++id,2}, {Verify(nums) == k}, ");
            Utils.PrintArray(nums);

            // 2. 
            n = 3; k = 2; nums = solution.ConstructArray(n, k);
            Console.Write($"{++id,2}, {Verify(nums) == k}, ");
            Utils.PrintArray(nums);

            // 3. 
            n = 32; k = 16; nums = solution.ConstructArray(n, k);
            Console.Write($"{++id,2}, {Verify(nums) == k}, ");
            Utils.PrintArray(nums);
        }

        private int Verify(int[] nums)
        {
            HashSet<int> buffer = new HashSet<int>();

            for (int i = 0; i < nums.Length - 1; i++)
                buffer.Add(Math.Abs(nums[i] - nums[i + 1]));

            return buffer.Count;
        }
    }
}
