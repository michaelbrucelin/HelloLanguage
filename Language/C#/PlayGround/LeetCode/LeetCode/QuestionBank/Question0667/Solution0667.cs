using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0667
{
    public class Solution0667 : Interface0667
    {
        /// <summary>
        /// k个不同的值，如果可以的话，就是1, 2 ... k这k个值，其中最大的为k，所以序列至少是1~k+1
        /// 下面尝试构建这样的序列，构建方法：
        /// k+1, k+2...顺序排序即可，下面从k+1向前依次排1~k这k个值，使其相邻元素的绝对差依次是k, k-1, k-2 ... 1即可
        /// k=5,  3, 4, 2, 5, 1, 6, 7, 8, 9, 10
        /// 解释一下k=5，k+1为6，所以6以后的元素顺序排即可
        /// 6, 7, 8, 9, 10, ...
        /// 下面开始依次向前排
        ///             1, 6, 7, 8, 9, 10, ...  首先构造差值为k，  即5的元素，只能为1
        ///          5, 1, 6, 7, 8, 9, 10, ...  然后构造差值为k-1，即4的元素，只能为5
        ///       2, 5, 1, 6, 7, 8, 9, 10, ...  然后构造差值为k-2，即3的元素，只能为2
        ///    4, 2, 5, 1, 6, 7, 8, 9, 10, ...  然后构造差值为k-3，即2的元素，只能为4
        /// 3, 4, 2, 5, 1, 6, 7, 8, 9, 10, ...  然后构造差值为k-4，即1的元素，只能为3
        /// 
        /// 下面列举了k从1到9，用上面方式构造的解
        /// k=1,  1, 2, 3, 4, 5, 6, 7, 8, 9, 10
        /// k=2,  2, 1, 3, 4, 5, 6, 7, 8, 9, 10
        /// k=3,  2, 3, 1, 4, 5, 6, 7, 8, 9, 10
        /// k=4,  3, 2, 4, 1, 5, 6, 7, 8, 9, 10
        /// k=5,  3, 4, 2, 5, 1, 6, 7, 8, 9, 10
        /// k=6,  4, 3, 5, 2, 6, 1, 7, 8, 9, 10
        /// k=7,  4, 5, 3, 6, 2, 7, 1, 8, 9, 10
        /// k=8,  5, 4, 6, 3, 7, 2, 8, 1, 9, 10
        /// k=9,  5, 6, 4, 7, 3, 8, 2, 9, 1, 10
        /// 从上面的解中可以找出规律，即
        /// 令x=k/2+1，则序列为k/2+1 ... 4, k-2, 3, k-1, 2, k, 1, k+1
        /// 或者这样总结更容易编写代码：
        /// 令x=k/2+1
        /// 如果k为奇数：x, x+1, x-1, x+2, x-2, x+3, x-3 ... k-1, 2, k, 1, k+1
        /// 如果k为偶数：x, x-1, x+1, x-2, x+2, x-3, x+3 ... k-1, 2, k, 1, k+1
        /// </summary>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[] ConstructArray(int n, int k)
        {
            int[] nums = new int[n];

            for (int i = k; i < n; i++) nums[i] = i + 1;  // 题目保证了k < n

            int start = k / 2 + 1;
            if ((k & 1) == 1)
            {
                for (int i = 0; i < k; i += 2) nums[i] = start - (i >> 1);
                for (int i = 1; i < k; i += 2) nums[i] = start + ((i + 1) >> 1);
            }
            else
            {
                for (int i = 0; i < k; i += 2) nums[i] = start + (i >> 1);
                for (int i = 1; i < k; i += 2) nums[i] = start - ((i + 1) >> 1);
            }

            return nums;
        }
    }
}
