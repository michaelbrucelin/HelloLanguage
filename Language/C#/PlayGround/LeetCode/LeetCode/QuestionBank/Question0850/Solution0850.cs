using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0850
{
    public class Solution0850 : Interface0850
    {
        /// <summary>
        /// 如果是3个矩形，则
        /// 矩形1 + 矩形2 + 矩形3 - (矩形1 ∩ 矩形2) - (矩形1 ∩ 矩形3) - (矩形2 ∩ 矩形3) + (矩形1 ∩ 矩形2 ∩ 矩形3)
        /// 但是如果矩形太多，用上面的方式解就不一定好用了
        /// </summary>
        /// <param name="rectangles"></param>
        /// <returns></returns>
        public int RectangleArea(int[][] rectangles)
        {
            throw new NotImplementedException();
        }

        private int GetLineOverlap(int ax1, int ax2, int bx1, int bx2)
        {
            int x1 = Math.Max(ax1, bx1);
            int x2 = Math.Min(ax2, bx2);

            return x2 > x1 ? x2 - x1 : 0;
        }
    }
}
