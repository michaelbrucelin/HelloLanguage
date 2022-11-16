using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0775
{
    public class Solution0775 : Interface0775
    {
        /// <summary>
        /// 由题目知，全局倒置一定是局部倒置，所以存在非局部倒置的全局倒置（j>i+1 && nums[j]<nums[i]）结果为false，否则为true
        /// 证明见Solution0775.md
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool IsIdealPermutation(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
                if (Math.Abs(nums[i] - i) > 1) return false;
            return true;
        }
    }
}
