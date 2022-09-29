using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0016
{
    public class Solution0016 : Interface0016
    {
        /// <summary>
        /// 3层循环暴力解，没有提交测试，担心超时
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int ThreeSumClosest(int[] nums, int target)
        {
            if (nums.Length == 3) return nums.Sum();

            int result = nums[0] + nums[1] + nums[2];
            if (result == target) return result;
            for (int i = 0; i < nums.Length - 2; i++) for (int j = i + 1; j < nums.Length - 1; j++) for (int k = j + 1; k < nums.Length; k++)
                    {
                        int threeSum = nums[i] + nums[j] + nums[k];
                        if (Math.Abs(threeSum - target) < Math.Abs(result - target))
                        {
                            result = threeSum;
                            if (result == target) goto Found;
                        }
                    }
            Found:
            return result;
        }
    }
}
