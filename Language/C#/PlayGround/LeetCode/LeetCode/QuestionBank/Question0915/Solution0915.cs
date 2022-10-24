using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0915
{
    public class Solution0915 : Interface0915
    {
        /// <summary>
        /// 即分割位置左侧的最大值小于等于分割位置右侧的最小值
        /// 
        /// 先找出数组第一个最小值的索引(i)与第一个最大值对应的索引(j)，由于题目必有解，所以i<=j，而且解就在i与j之间  O(n)
        /// 先找出数组0-i之间的最大值，并记录，暂定结果为i+1                                                          O(n)
        /// 从i至j之间逐位判断，假定索引为k                                                                           O(n)
        ///     如果nums[k]大于等于左侧的最大值，继续
        ///     如果nums[k]小于左侧最大值，更新左侧的最大值为0-k之间的最大值，并更新结果为k+1
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int PartitionDisjoint(int[] nums)
        {
            int minid = 0, maxid = 0, maxid_left = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] < nums[minid])
                {
                    minid = i;
                    maxid_left = maxid;
                }
                else if (nums[i] > nums[maxid])
                {
                    maxid = i;
                }
            }

            int result = minid + 1, tempmaxid = maxid_left;
            for (int i = minid + 1; i < maxid; i++)
            {
                if (nums[i] > nums[tempmaxid]) tempmaxid = i;
                else if (nums[i] < nums[maxid_left])
                {
                    result = i + 1;
                    maxid_left = tempmaxid;
                }
            }

            return result;
        }
    }
}
