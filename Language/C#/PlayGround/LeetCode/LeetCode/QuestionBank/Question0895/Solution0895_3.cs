using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0895
{
    public class Solution0895_3
    {
    }

    public class FreqStack_3 : Interface0895
    {
        public FreqStack_3()
        {
            queue = new Dictionary<int, Stack<int>>();
            freqs = new Dictionary<int, int>();
            maxFreq = 0;
        }

        private Dictionary<int, Stack<int>> queue;
        private Dictionary<int, int> freqs;
        private int maxFreq;

        public int Pop()
        {
            int val = queue[maxFreq].Pop();
            if (freqs[val] > 1) freqs[val]--; else freqs.Remove(val);
            if (queue[maxFreq].Count == 0)
            {
                queue.Remove(maxFreq);
                maxFreq--;
            }

            return val;
        }

        public void Push(int val)
        {
            if (freqs.ContainsKey(val)) freqs[val]++; else freqs.Add(val, 1);
            if (queue.ContainsKey(freqs[val]))
                queue[freqs[val]].Push(val);
            else
                queue.Add(freqs[val], new Stack<int>(new int[] { val }));

            maxFreq = Math.Max(maxFreq, freqs[val]);
        }
    }
}
