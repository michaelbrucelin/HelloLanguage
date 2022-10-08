using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0870
{
    public class Solution0870 : Interface0870
    {
        /// <summary>
        /// 田忌赛马
        /// nums1排序
        /// nums2中每一项都匹配nums1中比它大中最小的一项，如果nums1中不存在比它大的项，则匹配nums1中最小的项
        /// 
        /// 提交后测试用例全部通过，但是超时
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int[] AdvantageCount(int[] nums1, int[] nums2)
        {
            int[] result = new int[nums1.Length];

            Array.Sort(nums1);
            List<int> helper = nums1.ToList();
            for (int i = 0; i < nums1.Length; i++)
            {
                int id = SearchRightBorder(helper, nums2[i]);
                if (id == helper.Count) id = 0;
                result[i] = helper[id];
                helper.RemoveAt(id);
            }

            return result;
        }

        /// <summary>
        /// 二分查找目标值的右边界
        /// 即如果大于目标值的值存在，返回第1个对应的索引，如果不存在，返回数组的长度
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private static int SearchRightBorder(List<int> nums, int target)
        {
            int result = nums.Count;

            int left = 0, right = nums.Count - 1;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] > target)
                {
                    right = mid - 1;
                    result = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return result;
        }
    }
}
