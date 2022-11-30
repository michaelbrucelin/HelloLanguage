using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0895
{
    public class Solution0895
    {
    }

    /// <summary>
    /// 偷个懒，借助内置的PriorityQueue来构建
    /// </summary>
    public class FreqStack : Interface0895
    {

        public FreqStack()
        {
            queue = new PriorityQueue<(int val, int distance), (int frequency, int distance)>(
                Comparer<(int frequency, int distance)>.Create((x, y) => x.frequency != y.frequency ? y.frequency - x.frequency : y.distance - x.distance));
            frequency = new Dictionary<int, int>();
            distance = -1;
        }

        private PriorityQueue<(int val, int distance), (int frequency, int distance)> queue;
        private Dictionary<int, int> frequency;
        private int distance;

        public void Push(int val)
        {
            if (frequency.ContainsKey(val)) frequency[val]++; else frequency.Add(val, 1);
            distance++;
            queue.Enqueue((val, distance), (frequency[val], distance));
        }

        public int Pop()
        {
            var item = queue.Dequeue();
            if (frequency[item.val] > 1) frequency[item.val]--; else frequency.Remove(item.val);
            if (item.distance == distance) distance--;

            return item.val;
        }
    }
}
