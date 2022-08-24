using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCP.LCP0030
{
    public class Solution0030_2
    {
        public int MagicTower(int[] nums)
        {
            // if (nums.Sum() < 0) return -1;
            long sum = 0;
            for (int i = 0; i < nums.Length; i++) sum += nums[i];
            if (sum < 0) return -1;

            int result = 0;

            int current = 1;
            Queue<int> queue = new Queue<int>(nums);
            PriorityQueue buffer = new PriorityQueue();  // .NetFramework没有内建优先队列，这里用最小堆简单模拟
            while (queue.Count > 0)
            {
                int value = queue.Dequeue();
                current += value;
                if (value < 0) buffer.EnQueue(value);

                while (current <= 0)
                {
                    if (buffer.Count == 0) return -1;

                    int recover = buffer.DeQueue();
                    current -= recover;
                    queue.Enqueue(recover);
                    result++;
                }
            }

            return result;
        }

        /// <summary>
        /// 用最小堆实现一个优先队列
        /// </summary>
        class PriorityQueue
        {
            public PriorityQueue() { }

            private List<int> minheap = new List<int>();

            public int Count
            {
                get { return minheap.Count; }
            }

            public void EnQueue(int item)
            {
                minheap.Add(item);
                UpAdjust(minheap);
            }

            public int DeQueue()
            {
                if (minheap.Count == 0) throw new Exception("the queue is empty.");

                int result = minheap[0];
                minheap[0] = minheap[minheap.Count - 1];
                minheap.RemoveAt(minheap.Count - 1);
                DownAdjust(minheap, 0);

                return result;
            }

            private void UpAdjust(IList<int> list)
            {
                int index = list.Count - 1;
                int value = list[index];

                while (index > 0 && value < list[(index - 1) / 2])
                {
                    list[index] = list[(index - 1) / 2];
                    index = (index - 1) / 2;
                }
                list[index] = value;
            }

            private void DownAdjust(IList<int> list, int index)
            {
                if (index > list.Count - 1) return;

                int value = list[index];

                int childIndex = index * 2 + 1;  // 需要上浮的孩子，先假定是左孩子
                while (childIndex < list.Count)
                {
                    if (childIndex + 1 < list.Count && list[childIndex + 1] < list[childIndex])
                        childIndex++;            // 选出左右孩子中较小的那一个

                    if (value > list[childIndex])
                    {
                        list[index] = list[childIndex];
                        index = childIndex;
                        childIndex = childIndex * 2 + 1;
                    }
                    else
                        break;
                }
                list[index] = value;
            }

            private void HeapBuilder(IList<int> list)
            {
                for (int i = list.Count / 2 - 1; i >= 0; i--)
                    DownAdjust(list, i);
            }
        }
    }
}
