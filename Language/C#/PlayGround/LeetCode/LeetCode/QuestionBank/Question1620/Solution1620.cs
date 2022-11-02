using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1620
{
    public class Solution1620 : Interface1620
    {
        /// <summary>
        /// 暴力解
        /// 很没有营养的一道题
        /// </summary>
        /// <param name="towers"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        public int[] BestCoordinate(int[][] towers, int radius)
        {
            if (towers.Length == 1)
            {
                if (towers[0][2] > 0) return new int[] { towers[0][0], towers[0][1] }; else return new int[] { 0, 0 };
            }

            int xmin = towers[0][0], xmax = towers[0][0], ymin = towers[0][1], ymax = towers[0][1];
            for (int i = 1; i < towers.Length; i++)
            {
                if (towers[i][0] < xmin) xmin = towers[i][0]; else if (towers[i][0] > xmax) xmax = towers[i][0];
                if (towers[i][1] < ymin) ymin = towers[i][1]; else if (towers[i][1] > ymax) ymax = towers[i][1];
            }

            int[] result = new int[2];
            int signal_max = 0, radius2 = radius * radius;
            // 暴力枚举
            for (int x = xmin; x <= xmax; x++) for (int y = ymin; y <= ymax; y++)
                {
                    int signal_temp = 0;
                    for (int i = 0; i < towers.Length; i++)
                    {
                        int distance2 = (towers[i][0] - x) * (towers[i][0] - x) + (towers[i][1] - y) * (towers[i][1] - y);
                        if (distance2 <= radius2)
                            signal_temp += (int)Math.Floor(towers[i][2] / (1d + Math.Sqrt(distance2)));
                    }

                    if (signal_temp > signal_max) { signal_max = signal_temp; result[0] = x; result[1] = y; }
                    else if (signal_temp == signal_max)
                    {
                        if (x < result[0] || (x == result[0] && y < result[1])) { result[0] = x; result[1] = y; }
                    }
                }
            if (signal_max == 0) { result[0] = 0; result[1] = 0; }

            return result;
        }
    }
}
