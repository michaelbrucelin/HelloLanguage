using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0011
{
    public class Solution0011 : Interface0011
    {
        /// <summary>
        /// 使用两个指针指向数组的两端，每次将更矮的板向中间移动，如果两边的板同样高，两边一起向中间移动
        /// 仔细想一下，这个方案是一定可以得到最优解的
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int MaxArea(int[] height)
        {
            int left = 0, right = height.Length - 1;
            int result = Math.Min(height[0], height[right]) * right;

            while (left < right)
            {
                int anchor;
                if (height[left] < height[right])
                {
                    anchor = height[left];
                    while (++left < right && height[left] <= anchor) ;
                }
                else if (height[right] < height[left])
                {
                    anchor = height[right];
                    while (--right > left && height[right] <= anchor) ;
                }
                else
                {
                    anchor = height[left];
                    while (++left < right && height[left] <= anchor) ;
                    anchor = height[right];
                    while (--right > left && height[right] <= anchor) ;
                }
                result = Math.Max(result, Math.Min(height[left], height[right]) * (right - left));
            }

            return result;
        }
    }
}
