using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0870
{
    public class Solution0870_3 : Interface0870
    {
        public int[] AdvantageCount(int[] nums1, int[] nums2)
        {
            int n = nums1.Length;
            int[] idx1 = new int[n];
            int[] idx2 = new int[n];
            for (int i = 0; i < n; i++)
            {
                idx1[i] = i;
                idx2[i] = i;
            }
            Array.Sort(idx1, (i, j) => nums1[i] - nums1[j]);
            Array.Sort(idx2, (i, j) => nums2[i] - nums2[j]);

            int[] result = new int[n];
            int left = 0, right = n - 1;
            for (int i = 0; i < n; ++i)
            {
                if (nums1[idx1[i]] > nums2[idx2[left]])
                {
                    result[idx2[left]] = nums1[idx1[i]];
                    ++left;
                }
                else
                {
                    result[idx2[right]] = nums1[idx1[i]];
                    --right;
                }
            }

            return result;
        }
    }
}
