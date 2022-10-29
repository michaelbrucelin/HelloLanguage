using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0027
{
    public class Solution0027 : Interface0027
    {
        public int RemoveElement(int[] nums, int val)
        {
            int result = nums.Length;
            if (result == 0) return 0;
            if (result == 1) return nums[0] == val ? 0 : 1;

            int left = 0, right = result - 1;
            while (left < right)
            {
                for (; left < right; left++) if (nums[left] == val) { result--; break; }     // 从左向右找第一个等于val的位置
                if (left == right && nums[left] == val) { result--; break; }                 // 如果到头了，需要单独判断一下

                for (; right > left; right--) if (nums[right] == val) result--; else break;  // 从右向左找第一个不等于val的位置
                if (right == left) { break; }                                                // 如果到头了，需要单独判断一下

                nums[left++] = nums[right--];
                if (left == right && nums[left] == val) { result--; break; }                 // 如果变更后左右指针重合，需要单独判断一下
            }

            return result;
        }
    }
}
