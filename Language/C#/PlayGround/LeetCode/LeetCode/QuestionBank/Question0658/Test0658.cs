using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeetCode.Utilses;

namespace LeetCode.QuestionBank.Question0658
{
    public class Test0658
    {
        public void Test()
        {
            Solution0658_3 solution = new Solution0658_3();
            IList<int> result;

            result = solution.FindClosestElements(new int[] { 1, 2, 3, 4, 5 }, 4, 3);
            Utils.PrintArray(result);

            result = solution.FindClosestElements(new int[] { 1, 2, 3, 4, 5 }, 4, -1);
            Utils.PrintArray(result);

            result = solution.FindClosestElements(new int[] { 0, 0, 0, 1, 3, 5, 6, 7, 8, 8 }, 2, 2);
            Utils.PrintArray(result);
        }
    }
}
