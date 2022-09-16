using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0223
{
    public class Solution0223 : Interface0223
    {
        /// <summary>
        /// 仔细分析一下，重叠部分的长是(ax1, ax2)与(bx1, bx2)的交集
        ///               重叠部分的宽是(ay1, ay2)与(by1, by2)的交集
        /// 即二维（矩形）的重叠部分就是一维（线段）重叠的乘积，降为分析即可
        /// 
        /// 矩形1的四个顶点为：左上：(ax1, ay2) 右上：(ax2, ay2) 右下：(ax2, ay1) 左下：(ax1, ay1)
        /// 矩形2的四个顶点为：左上：(bx1, by2) 右上：(bx2, by2) 右下：(bx2, by1) 左下：(bx1, by1)
        /// </summary>
        /// <param name="ax1"></param>
        /// <param name="ay1"></param>
        /// <param name="ax2"></param>
        /// <param name="ay2"></param>
        /// <param name="bx1"></param>
        /// <param name="by1"></param>
        /// <param name="bx2"></param>
        /// <param name="by2"></param>
        /// <returns></returns>
        public int ComputeArea(int ax1, int ay1, int ax2, int ay2, int bx1, int by1, int bx2, int by2)
        {
            int area1 = (ax2 - ax1) * (ay2 - ay1);
            int area2 = (bx2 - bx1) * (by2 - by1);

            int x_overlap = GetLineOverlap(ax1, ax2, bx1, bx2);
            if (x_overlap == 0) return area1 + area2;

            int y_overlap = GetLineOverlap(ay1, ay2, by1, by2);
            if (y_overlap == 0) return area1 + area2;

            return area1 - (x_overlap * y_overlap) + area2;
        }

        private int GetLineOverlap(int ax1, int ax2, int bx1, int bx2)
        {
            int x1 = Math.Max(ax1, bx1);
            int x2 = Math.Min(ax2, bx2);

            return x2 > x1 ? x2 - x1 : 0;
        }
    }
}
