using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1710
{
    public class Solution1710_2 : Interface1710
    {
        /// <summary>
        /// 优先级队列，本质上仍然是排序 + 贪心
        /// </summary>
        /// <param name="boxTypes"></param>
        /// <param name="truckSize"></param>
        /// <returns></returns>
        public int MaximumUnits(int[][] boxTypes, int truckSize)
        {
            PriorityQueue<int, int> priority = new PriorityQueue<int, int>(Comparer<int>.Create((i1, i2) => i2 - i1));  // 无法指定堆的容量，否则可以将时间复杂度由nlogn将为nlogk
            for (int i = 0; i < boxTypes.Length; i++) for (int j = 0; j < boxTypes[i][0]; j++)
                    priority.Enqueue(boxTypes[i][1], boxTypes[i][1]);

            int result = 0;
            for (int i = 0; i < truckSize; i++)
            {
                if (priority.Count > 0)
                    result += priority.Dequeue();
                else break;
            }

            return result;
        }
    }
}
