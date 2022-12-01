using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1779
{
    public class Solution1779 : Interface1779
    {
        public int NearestValidPoint(int x, int y, int[][] points)
        {
            int result = -1, distance = int.MaxValue;
            for (int i = 0; i < points.Length; i++)
            {
                if (points[i][0] == x || points[i][1] == y)
                {
                    int _distance = Math.Abs(points[i][0] - x) + Math.Abs(points[i][1] - y);
                    if (_distance < distance)
                    {
                        result = i;
                        distance = _distance;
                    }
                }
            }

            return result;
        }

        public int NearestValidPoint2(int x, int y, int[][] points)
        {
            int result = -1, distance = int.MaxValue;
            for (int i = 0; i < points.Length; i++)
            {
                if (points[i][0] == x)
                {
                    int _distance = Math.Abs(points[i][1] - y);
                    if (_distance < distance)
                    {
                        result = i;
                        distance = _distance;
                    }
                }
                else if (points[i][1] == y)
                {
                    int _distance = Math.Abs(points[i][0] - x);
                    if (_distance < distance)
                    {
                        result = i;
                        distance = _distance;
                    }
                }
            }

            return result;
        }
    }
}
