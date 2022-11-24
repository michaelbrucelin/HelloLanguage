using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0795
{
    public class Solution0795 : Interface0795
    {
        /// <summary>
        /// 计算贡献值
        /// 向左找小于left的值，向右找大于right的值
        /// nums = [2,9,2,5,1,6,7], left = 2, right = 8
        /// 2的贡献值：左0右0，(0+1)*(0+1)=1，[2]
        /// 9的贡献值：
        /// 2的贡献值：左0右4，(0+1)*(4+1)=5，[2], [2,5], [2,5,1], [2,5,1,6], [2,5,1,6,7]
        /// 5的贡献值：左0右3，(0+1)*(3+1)=4，[5], [5,1], [5,1,6], [5,1,6,7]
        /// 1的贡献值：
        /// 6的贡献值：左1右1，(1+1)*(1+1)=4，[1,6], [1,6,7], [6], [6, 7]
        /// 7的贡献值：左0右0，(0+1)*(0+1)=1，[7]
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public int NumSubarrayBoundedMax(int[] nums, int left, int right)
        {
            int result = 0, left_cnt = 0, right_border = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < left) left_cnt++;
                else if (nums[i] > right) left_cnt = 0;
                else
                {
                    if (right_border <= i)
                    {
                        for (int j = i + 1; j < nums.Length; j++)
                        {
                            if (nums[j] > right) { right_border = j; goto EndRightBorder; }
                        }
                        right_border = nums.Length;   // if (right_border <= i) right_border = nums.Length;
                    }
                    EndRightBorder:

                    result += ((left_cnt + 1) * (right_border - i));
                    left_cnt = 0;
                }
            }

            return result;
        }
    }
}
