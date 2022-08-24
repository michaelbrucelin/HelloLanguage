using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0665
{
    public class Solution0665
    {
        /// <summary>
        /// 当第一次出现两个相邻的元素（k k+1）递减时，有下面几种可能：
        ///     1. k==0或k+1==Length-1，有解
        ///     2. 将arr[k]改成arr[k-1]，如果arr[k-1]<=arr[k+1]，操作成功，如果失败，考虑下一种可能
        ///     3. 将arr[k+1]改成arr[k+2]，如果arr[k]<=arr[k+2]，操作成功，如果失败，无解
        /// 如果出现了第二次两个相邻的元素递减时，无解
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool CheckPossibility(int[] nums)
        {
            bool isdone = false;  // 是否已经做过一次处理了

            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] > nums[i + 1])
                {
                    if (isdone) return false;

                    if (i == 0 || i + 1 == nums.Length - 1 || nums[i - 1] <= nums[i + 1] || nums[i] <= nums[i + 2])
                        isdone = true;
                    else
                        return false;
                }
            }

            return true;
        }
    }
}
