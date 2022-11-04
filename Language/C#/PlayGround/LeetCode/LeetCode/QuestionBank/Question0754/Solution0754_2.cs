using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0754
{
    public class Solution0754_2 : Interface0754
    {
        /// <summary>
        /// 找规律，数学归纳法证明
        /// 下面是1-10步，可以到达的位置，从第5步起，忽略负位置
        /// 可以发现步数为i时，可到达的位置与能到达的最大值有相同的奇偶性，剩下的用数学归纳法就很容易证明了
        /// 1   [1,-1]
        /// 2   [1,3,-3,-1]
        /// 3   [0,2,4,6,-6,-4,-2]
        /// 4   [0,2,4,6,8,10,-10,-8,-6,-4,-2]
        /// 5   [1,3,5,7,9,11,13,15]
        /// 6   [1,3,5,7,9,11,13,15,17,19,21]
        /// 7   [0,2,4,6,8,10,12,14,16,18,20,22,24,26,28]
        /// 8   [0,2,4,6,8,10,12,14,16,18,20,22,24,26,28,30,32,34,36]
        /// 9   [1,3,5,7,9,11,13,15,17,19,21,23,25,27,29,31,33,35,37,39,41,43,45]
        /// 10  [1,3,5,7,9,11,13,15,17,19,21,23,25,27,29,31,33,35,37,39,41,43,45,47,49,51,53,55]
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public int ReachNumber(int target)
        {
            if (target == 1 || target == -1) return 1;

            target = Math.Abs(target);
            int i = 1, sum = 1;
            for (; sum < target || ((sum & 1) != (target & 1)); i++, sum += i) { }

            return i;
        }
    }
}
