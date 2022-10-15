using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1441
{
    public class Solution1441 : Interface1441
    {
        public IList<string> BuildArray(int[] target, int n)
        {
            IList<string> result = new List<string>();

            int len = target.Length;
            int ptr = 0;
            for (int i = 1; i <= target[len - 1]; i++)
            {
                result.Add("Push");

                if (target[ptr] == i)
                    ptr++;
                else
                    result.Add("Pop");
            }

            return result;
        }
    }
}
