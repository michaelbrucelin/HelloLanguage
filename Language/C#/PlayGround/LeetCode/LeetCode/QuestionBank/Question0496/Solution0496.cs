using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0496
{
    public class Solution0496 : Interface0496
    {
        /// <summary>
        /// 纯暴力解法
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int[] NextGreaterElement(int[] nums1, int[] nums2)
        {
            int[] result = new int[nums1.Length];

            for (int i = 0; i < nums1.Length; i++)
            {
                result[i] = -1;
                bool flag = false;
                for (int j = 0; j < nums2.Length; j++)
                {
                    if (!flag)
                    {
                        if (nums2[j] == nums1[i]) flag = true;
                        continue;
                    }
                    else if (nums2[j] > nums1[i])
                    {
                        result[i] = nums2[j];
                        break;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 先将nums2转为字典，这样可以剩下大量的查找时间
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int[] NextGreaterElement2(int[] nums1, int[] nums2)
        {
            int[] result = new int[nums1.Length];

            Dictionary<int, int> dic = nums2.Select((i, id) => (i, id)).ToDictionary(key => key.i, value => value.id);
            for (int i = 0; i < nums1.Length; i++)
            {
                result[i] = -1;
                for (int j = dic[nums1[i]] + 1; j < nums2.Length; j++)
                {
                    if (nums2[j] > nums1[i])
                    {
                        result[i] = nums2[j];
                        break;
                    }
                }
            }

            return result;
        }
    }
}
