using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1441
{
    public class Solution1441_2 : Interface1441
    {
        public IList<string> BuildArray(int[] target, int n)
        {
            IList<string> result = new List<string>();

            int ptr = 1;
            for (int i = 0; i < target.Length; i++)
            {
                for (int j = ptr; j < target[i]; j++)
                {
                    result.Add("Push");
                    result.Add("Pop");
                }
                result.Add("Push");
                ptr = target[i] + 1;
            }

            return result;
        }
    }
}
