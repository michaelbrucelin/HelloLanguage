using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0018
{
    public class Solution0018 : Interface0018
    {
        /// <summary>
        /// 与“三数之和”类似，不过要遍历前两个元素，然后再对后两个元素使用双指针
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            if (nums.Length <= 3) return new List<IList<int>>();

            List<IList<int>> result = new List<IList<int>>();
            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 3; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue;          // 如果与上一个值相同，那么找到的看效果也一定在上一轮找到过
                if ((long)nums[i] + nums[i + 1] + nums[i + 2] + nums[i + 3] > target) break;                                   // 防止溢出
                if ((long)nums[i] + nums[nums.Length - 3] + nums[nums.Length - 2] + nums[nums.Length - 1] < target) continue;  // 防止溢出
                for (int j = i + 1; j < nums.Length - 2; j++)
                {
                    if (j > i + 1 && nums[j] == nums[j - 1]) continue;  // 如果与上一个值相同，那么找到的看效果也一定在上一轮找到过
                    if ((long)nums[i] + nums[j] + nums[j + 1] + nums[j + 2] > target) break;                         // 防止溢出
                    if ((long)nums[i] + nums[j] + nums[nums.Length - 2] + nums[nums.Length - 1] < target) continue;  // 防止溢出
                    int left = j + 1, right = nums.Length - 1;
                    while (left < right)
                    {
                        if (left > j + 1 && nums[left] == nums[left - 1]) { left++; continue; }                // 如果与上一个值相同，... ...
                        if (right < nums.Length - 1 && nums[right] == nums[right + 1]) { right--; continue; }  // 如果与上一个值相同，... ...
                        try
                        {
                            checked  // 像上面那样转为long处理就行，这里就是试一下checked关键字的用法
                            {
                                int fourSum = nums[i] + nums[j] + nums[left] + nums[right];
                                if (fourSum == target) { result.Add(new List<int>() { nums[i], nums[j], nums[left], nums[right] }); left++; right--; }
                                else if (fourSum > target) right--; else left++;
                            }
                        }
                        catch { right--; }  // 溢出了
                    }
                }
            }

            return result;
        }
    }
}
