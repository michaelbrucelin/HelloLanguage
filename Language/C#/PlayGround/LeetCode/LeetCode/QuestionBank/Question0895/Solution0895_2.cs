using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0895
{
    public class Solution0895_2
    {
    }

    /// <summary>
    /// 从头构建一个最大堆
    /// </summary>
    public class FreqStack_2 : Interface0895
    {
        public FreqStack_2()
        {
            list = new List<(int val, int frequency, int distance)>();
            frequency = new Dictionary<int, int>();
            distance = -1;
        }

        private List<(int val, int frequency, int distance)> list;
        private Dictionary<int, int> frequency;
        private int distance;

        public void Push(int val)
        {
            if (frequency.ContainsKey(val)) frequency[val]++; else frequency.Add(val, 1);
            distance++;
            list.Add((val, frequency[val], distance));
            UpAdjust();
        }

        public int Pop()
        {
            if (list.Count == 0) throw new Exception("the queue is empty.");

            var item = list[0];
            list[0] = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            DownAdjust(0);
            if (frequency[item.val] > 1) frequency[item.val]--; else frequency.Remove(item.val);
            if (item.distance == distance) distance--;

            return item.val;
        }

        private bool IsBiger((int val, int frequency, int distance) x, (int val, int frequency, int distance) y)
        {
            return (x.frequency > y.frequency) || (x.frequency == y.frequency && x.distance > y.distance);
        }

        private void UpAdjust()
        {
            int index = list.Count - 1;
            var item = list[index];

            while (index > 0)
            {
                var item2 = list[(index - 1) >> 1];
                if (IsBiger(item, item2))
                {
                    list[index] = list[(index - 1) >> 1];
                    index = (index - 1) >> 1;
                }
                else break;
            }
            list[index] = item;
        }

        private void DownAdjust(int index)
        {
            if (index >= (list.Count >> 1)) return;

            var item = list[index];

            int childIndex = (index << 1) + 1;  // 需要上浮的孩子，先假定是左孩子
            while (childIndex < list.Count)
            {
                if (childIndex + 1 < list.Count && IsBiger(list[childIndex + 1], list[childIndex]))
                    childIndex++;               // 选出左右孩子中较大的那一个

                if (IsBiger(list[childIndex], item))
                {
                    list[index] = list[childIndex];
                    index = childIndex;
                    childIndex = (childIndex << 1) + 1;
                }
                else
                    break;
            }
            list[index] = item;
        }
    }
}
