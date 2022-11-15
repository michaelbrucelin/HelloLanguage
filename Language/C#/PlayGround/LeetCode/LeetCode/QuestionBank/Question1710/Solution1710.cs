using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1710
{
    public class Solution1710 : Interface1710
    {
        /// <summary>
        /// 排序 + 贪心
        /// </summary>
        /// <param name="boxTypes"></param>
        /// <param name="truckSize"></param>
        /// <returns></returns>
        public int MaximumUnits(int[][] boxTypes, int truckSize)
        {
            int result = 0;
            Array.Sort(boxTypes, (arr1, arr2) => arr2[1] - arr1[1]);
            int trunks = 0;
            for (int i = 0; i < boxTypes.Length; i++)
            {
                if (trunks == truckSize) break;
                if (trunks + boxTypes[i][0] <= truckSize)
                {
                    result += boxTypes[i][1] * boxTypes[i][0];
                    trunks += boxTypes[i][0];
                }
                else  // else if (trunks <= truckSize)
                {
                    result += boxTypes[i][1] * (truckSize - trunks);
                    break;
                }
            }

            return result;
        }
    }
}
