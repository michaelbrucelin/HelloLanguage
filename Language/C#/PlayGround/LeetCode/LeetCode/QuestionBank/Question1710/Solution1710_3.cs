using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1710
{
    public class Solution1710_3 : Interface1710
    {
        /// <summary>
        /// 排序 + 贪心
        /// 使用基数排序将排序的时间复杂度由nlogn将为n
        /// </summary>
        /// <param name="boxTypes"></param>
        /// <param name="truckSize"></param>
        /// <returns></returns>
        public int MaximumUnits(int[][] boxTypes, int truckSize)
        {
            int[] distrib = new int[1001];
            for (int i = 0; i < boxTypes.Length; i++) distrib[boxTypes[i][1]] += boxTypes[i][0];

            int result = 0;
            int trunks = 0;
            for (int i = 1000; i > 0; i--)
            {
                if (distrib[i] == 0) continue;
                if (trunks == truckSize) break;
                if (trunks + distrib[i] <= truckSize)
                {
                    result += i * distrib[i];
                    trunks += distrib[i];
                }
                else  // else if (trunks < truckSize)
                {
                    result += i * (truckSize - trunks);
                    break;
                }
            }

            return result;
        }
    }
}
