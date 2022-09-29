using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0015
{
    public class Solution0015_2 : Interface0015
    {
        /// <summary>
        /// 排序，2层循环 + 二分查找
        /// 两层循环遍历所有前两个值的可能性，然后二分查找第三个值是否存在
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            HashSet<(int, int)> buffer = new HashSet<(int, int)>();

            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (nums[i] > 0) break;
                for (int j = i + 1; j < nums.Length - 1; j++)
                {
                    if (buffer.Contains((nums[i], nums[j]))) continue;
                    if (nums[i] + nums[j] > 0) break;
                    if (BinarySearch(nums, j + 1, nums.Length - 1, -nums[i] - nums[j]))
                        buffer.Add((nums[i], nums[j]));
                }
            }

            List<IList<int>> result = new List<IList<int>>();
            foreach (var item in buffer) result.Add(new List<int>() { item.Item1, item.Item2, -item.Item1 - item.Item2 });

            return result;
        }

        private bool BinarySearch(int[] nums, int left, int right, int target)
        {
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (nums[mid] == target) return true;

                if (nums[mid] < target) left = mid + 1;
                else right = mid - 1;
            }

            return false;
        }
    }
}
