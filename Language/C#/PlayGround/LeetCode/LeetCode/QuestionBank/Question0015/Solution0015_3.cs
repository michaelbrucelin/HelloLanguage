using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0015
{
    public class Solution0015_3 : Interface0015
    {
        /// <summary>
        /// 排序 + 双指针
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();

            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 2; i++)           // i, j, k分别遍历的是3个值中的第1个，第2个与第3个
            {
                if (nums[i] > 0) break;
                if (i > 0 && nums[i] == nums[i - 1]) continue;  // 如果第1个值与前一轮第1个值相等，那么这次找到的解必读与前一轮找到的解重复

                int j = i + 1, k = nums.Length - 1;
                while (j < k)
                {
                    if (nums[i] + nums[j] > 0) break;
                    if (j - 1 > i && nums[j] == nums[j - 1]) { j++; continue; }  // 如果第2个值与前一轮第2个值相等，那么这次找到的解必读与前一轮找到的解重复

                    int v = nums[i] + nums[j] + nums[k];
                    if (v == 0) { result.Add(new List<int>() { nums[i], nums[j], nums[k] }); j++; k--; }
                    else if (v < 0) j++; else k--;
                }
            }

            return result;
        }
    }
}
