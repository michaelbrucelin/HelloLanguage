using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1608
{
    public class Solution1608 : Interface1608
    {
        /// <summary>
        /// 排序+二分查找
        /// 假定数组长度为length，那个在索引为index位置元素的右侧（含此元素），有length-index个元素
        /// 如果nums[index] >= length-index && nums[index-1] < length-index，则length-index就是结果
        /// 如果nums[index] < length-index，index需要向右移动
        /// 如果nums[index-1] >= length-index，index需要向左移动
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SpecialArray(int[] nums)
        {
            Array.Sort(nums);
            int low = 0, high = nums.Length - 1;
            while (high >= low)
            {
                int mid = low + ((high - low) >> 1);

                if (mid == 0)
                    if (nums[0] >= nums.Length) return nums.Length;
                    else break;

                if (nums[mid - 1] >= nums.Length - mid)
                    high = mid - 1;
                else if (nums[mid] < nums.Length - mid)
                    low = mid + 1;
                else
                    return nums.Length - mid;
            }

            return -1;
        }
    }
}
