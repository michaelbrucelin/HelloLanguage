using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0870
{
    /// <summary>
    /// 未完成
    /// </summary>
    public class Solution0870_2 : Interface0870
    {
        /// <summary>
        /// 对Solution0870进行优化
        /// Solution0870用二分法，这里使用归并排序
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int[] AdvantageCount(int[] nums1, int[] nums2)
        {
            int[] result = new int[nums1.Length];
            Array.Sort(nums1);
            Array.Sort(nums2);

            int id1 = 0, id2 = 0;
            bool[] mask = new bool[nums1.Length];
            while (id2 < nums2.Length)
            {
                while (id1 < nums1.Length && nums1[id1] <= nums2[id2]) id1++;
                if (id1 >= nums1.Length) break;
                result[id2] = nums1[id1];
                mask[id1] = true;
                id2++;
            }

            for (int i = 0; i < nums1.Length; i++)
                if (!mask[i]) result[id2++] = nums1[i];

            return result;
        }
    }
}
