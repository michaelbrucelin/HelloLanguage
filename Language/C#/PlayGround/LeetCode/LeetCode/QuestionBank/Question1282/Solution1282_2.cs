using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1282
{
    public class Solution1282_2
    {
        public IList<IList<int>> GroupThePeople(int[] groupSizes)
        {
            Dictionary<int, Queue<int>> buffer = new Dictionary<int, Queue<int>>();
            for (int i = 0; i < groupSizes.Length; i++)
            {
                buffer.TryAdd(groupSizes[i], new Queue<int>());
                buffer[groupSizes[i]].Enqueue(i);
            }

            IList<IList<int>> result = new List<IList<int>>();
            foreach (KeyValuePair<int, Queue<int>> kv in buffer)
            {
                int groupcnt = kv.Value.Count / kv.Key;
                for (int i = 0; i < groupcnt; i++)
                {
                    List<int> group = new List<int>();
                    for (int j = 0; j < kv.Key; j++)
                        group.Add(kv.Value.Dequeue());

                    result.Add(group);
                }
            }

            return result;
        }
    }
}
