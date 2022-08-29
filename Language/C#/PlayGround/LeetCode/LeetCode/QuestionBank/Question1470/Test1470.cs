using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1470
{
    public class Test1470
    {
        public void Test()
        {
            Test01();
        }

        private void Test01()
        {
            int[] nums = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            Solution1470_3 solution = new Solution1470_3();
            solution.Shuffle(nums, 4);

            Utils.PrintArray(nums);
        }
    }
}
