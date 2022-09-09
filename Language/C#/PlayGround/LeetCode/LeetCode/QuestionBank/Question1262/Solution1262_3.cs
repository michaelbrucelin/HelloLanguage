using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1262
{
    public class Solution1262_3 : Interface1262
    {
        /// <summary>
        /// 在Solution1262_2上继续优化
        /// 如果sum能被3整除，返回，如果不能，则sum%3只有1与2两种可能，
        ///     如果sum%3==1，则需要一个除3余1的项或两个除3余2的项
        ///     如果sum%3==2，则需要一个除3余2的项或两个除3余1的项
        /// 所以只要遍历一次，并记录下最小的两个除3余1的项，与最小的两个除3余2的项即可
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSumDivThree(int[] nums)
        {
            int sum = 0;
            (int first, int second) yushu1 = (int.MaxValue, int.MaxValue);
            (int first, int second) yushu2 = (int.MaxValue, int.MaxValue);

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] % 3 == 1)
                {
                    if (nums[i] < yushu1.first) yushu1 = (nums[i], yushu1.first);
                    else if (nums[i] < yushu1.second) yushu1 = (yushu1.first, nums[i]);
                }
                else if (nums[i] % 3 == 2)
                {
                    if (nums[i] < yushu2.first) yushu2 = (nums[i], yushu2.first);
                    else if (nums[i] < yushu2.second) yushu2 = (yushu2.first, nums[i]);
                }

                sum += nums[i];
            }

            if (sum % 3 == 0) return sum;
            if (sum % 3 == 1)
            {
                if (yushu1.first != int.MaxValue && yushu2.second != int.MaxValue)
                    return Math.Max(sum - yushu1.first, sum - yushu2.first - yushu2.second);
                if (yushu1.first != int.MaxValue && yushu2.second == int.MaxValue) return sum - yushu1.first;
                if (yushu1.first == int.MaxValue && yushu2.second != int.MaxValue) return sum - yushu2.first - yushu2.second;
            }
            else
            {
                if (yushu2.first != int.MaxValue && yushu1.second != int.MaxValue)
                    return Math.Max(sum - yushu2.first, sum - yushu1.first - yushu1.second);
                if (yushu2.first != int.MaxValue && yushu1.second == int.MaxValue) return sum - yushu2.first;
                if (yushu2.first == int.MaxValue && yushu1.second != int.MaxValue) return sum - yushu1.first - yushu1.second;
            }

            return 0;
        }
    }
}
