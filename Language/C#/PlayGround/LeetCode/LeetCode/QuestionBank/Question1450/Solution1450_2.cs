using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1450
{
    public class Solution1450_2
    {
        /// <summary>
        /// 利用差分数组法求解
        /// 在当前场景下，差分数组并不是最优解，遍历一次这个朴素的方法才是最优解
        /// 但是想到了t-sql中用过这种思想，而且想要找出哪个时间并发值最大需要这样解，这里就实现一下
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="queryTime"></param>
        /// <returns></returns>
        public int BusyStudent(int[] startTime, int[] endTime, int queryTime)
        {
            int min = startTime.Min();
            int max = endTime.Max();

            int[] buffer = new int[max - min + 2];
            for (int i = 0; i < startTime.Length; i++)
            {
                buffer[startTime[i] - min]++;
                buffer[endTime[i] - min + 1]--;
            }

            return buffer.Where((i, index) => index <= (queryTime - min)).Sum();
        }
    }
}
