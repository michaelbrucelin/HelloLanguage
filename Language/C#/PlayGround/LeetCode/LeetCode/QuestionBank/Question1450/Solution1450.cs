using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1450
{
    public class Solution1450
    {
        public int BusyStudent(int[] startTime, int[] endTime, int queryTime)
        {
            int result = 0;

            for (int i = 0; i < startTime.Length; i++)
            {
                if (startTime[i] <= queryTime && queryTime <= endTime[i])
                    result++;
            }

            return result;
        }
    }
}
