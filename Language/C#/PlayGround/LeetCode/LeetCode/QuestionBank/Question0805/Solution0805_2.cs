using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0805
{
    public class Solution0805_2 : Interface0805
    {
        /// <summary>
        /// 本质上与Solution0805是一样的，不过由于分成了两部分分别查找，将时间复杂度由pow(2,n)降为n*pow(2,n/2)
        /// 将数组分为两等份，每一份做全排列，然后两部分互相查找一下
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool SplitArraySameAverage(int[] nums)
        {
            if (nums.Length == 1) return false;
            if (nums.Length == 2) return nums[0] == nums[1];

            int len = nums.Length, mid = nums.Length >> 1;
            for (int i = 0; i < len; i++) nums[i] *= len;
            int avg = (int)nums.Average();
            for (int i = 0; i < len; i++) nums[i] -= avg;

            // 左
            if (nums[0] == 0) return true;
            HashSet<int> left = new HashSet<int>() { nums[0] };
            for (int i = 1; i < mid; i++)
            {
                HashSet<int> left_temp = new HashSet<int>(left);
                foreach (int num in left)
                {
                    int sum = num + nums[i];
                    if (nums[i] == 0 || sum == 0) return true;
                    left_temp.Add(nums[i]); left_temp.Add(sum);
                }
                left = left_temp;
            }
            // 右
            if (nums[mid] == 0) return true;
            int sum_right = nums.Skip(mid).Sum();  // 右边不能全取，如果全取有结果，则左边必然有部分和为0，代码跑不到这个位置
            HashSet<int> right = new HashSet<int>() { nums[mid] };
            for (int i = mid + 1; i < len; i++)
            {
                HashSet<int> right_temp = new HashSet<int>(right);
                foreach (int num in right)
                {
                    int sum = num + nums[i];
                    if (nums[i] == 0 || sum == 0 || (sum != sum_right && left.Contains(-sum))) return true;
                    right_temp.Add(nums[i]); right_temp.Add(sum);
                }
                right = right_temp;
            }

            return false;
        }
    }
}
