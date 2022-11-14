using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0805
{
    public class Solution0805_2_2 : Interface0805
    {
        /// <summary>
        /// 与Solution0805_2一样，将BFS改为位图遍历
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool SplitArraySameAverage(int[] nums)
        {
            if (nums.Length == 1) return false;
            if (nums.Length == 2) return nums[0] == nums[1];

            int len = nums.Length;
            for (int i = 0; i < len; i++) nums[i] *= len;
            int avg = (int)nums.Average();
            for (int i = 0; i < len; i++) nums[i] -= avg;

            // 左
            int mid = len >> 1; int leftcnt = 1 << mid;
            HashSet<int> left = new HashSet<int>();
            for (int i = 1; i < leftcnt; i++)      // i为左半部分每一种组合的位图，不能取空，所以从1开始
            {
                int sum = 0;
                for (int j = 0; j < mid; j++) if ((i & (1 << j)) != 0) sum += nums[j];
                if (sum == 0) return true;
                left.Add(sum);
            }
            // 右
            int sum_right = nums.Skip(mid).Sum();  // 右边不能全取，如果全取有结果，则左边必然有部分和为0，代码跑不到这个位置
            int rightcnt = 1 << (len - mid);
            HashSet<int> right = new HashSet<int>();
            for (int i = 1; i < rightcnt; i++)     // i为右半部分每一种组合的位图，不能取空，所以从1开始
            {
                int sum = 0;
                for (int j = mid; j < len; j++) if ((i & (1 << (j - mid))) != 0) sum += nums[j];
                if (sum == 0 || (sum != sum_right && left.Contains(-sum))) return true;
                right.Add(sum);
            }

            return false;
        }
    }
}
