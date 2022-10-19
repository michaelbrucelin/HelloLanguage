using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1700
{
    public class Solution1700_2 : Interface1700
    {
        public int CountStudents(int[] students, int[] sandwiches)
        {
            int[] cnts = new int[2];
            cnts[1] = students.Sum(); cnts[0] = students.Length - cnts[1];

            for (int i = 0; i < sandwiches.Length; i++)
            {
                if (cnts[sandwiches[i]] == 0) return sandwiches.Length - i;
                cnts[sandwiches[i]]--;
            }

            return 0;
        }
    }
}
