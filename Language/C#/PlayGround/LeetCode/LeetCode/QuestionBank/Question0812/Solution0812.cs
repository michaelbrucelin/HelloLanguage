using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0812
{
    public class Solution0812 : Interface0812
    {
        /// <summary>
        /// 海伦公式：|x1y2+x2y3+x3y1−x1y3−x2y1−x3y2|/2
        /// </summary>
        /// <param name="points"></param>
        /// <returns></returns>
        public double LargestTriangleArea(int[][] points)
        {
            double result = 0;

            for (int i = 0; i < points.Length; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    for (int k = j + 1; k < points.Length; k++)
                    {
                        double area = 0.5D * Math.Abs(points[i][0] * points[j][1] + points[j][0] * points[k][1] + points[k][0] * points[i][1]
                                                    - points[i][0] * points[k][1] - points[j][0] * points[i][1] - points[k][0] * points[j][1]);
                        result = area > result ? area : result;
                    }
                }
            }

            return result;
        }
    }
}
