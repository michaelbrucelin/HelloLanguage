using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1282
{
    public class Solution1282 : Interface1282
    {
        public IList<IList<int>> GroupThePeople(int[] groupSizes)
        {
            IList<IList<int>> result = new List<IList<int>>();

            Dictionary<int, List<int>> buffer = new Dictionary<int, List<int>>();
            for (int i = 0; i < groupSizes.Length; i++)
            {
                if (!buffer.ContainsKey(groupSizes[i]))
                    buffer.Add(groupSizes[i], new List<int>() { i });
                else
                    buffer[groupSizes[i]].Add(i);

                if (buffer[groupSizes[i]].Count == groupSizes[i])
                {
                    result.Add(buffer[groupSizes[i]]);
                    buffer.Remove(groupSizes[i]);
                }
            }

            foreach (List<int> item in buffer.Values)
                result.Add(item);

            return result;
        }
    }
}
