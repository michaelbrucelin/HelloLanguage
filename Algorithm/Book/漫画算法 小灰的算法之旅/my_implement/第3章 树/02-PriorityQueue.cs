using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TestCSharp
{
    class Program
    {
        public static void Main(string[] args)
        {
            PriorityQueue priorityQueue = new PriorityQueue();
            priorityQueue.EnQueue(3);
            priorityQueue.EnQueue(5);
            priorityQueue.EnQueue(10);
            priorityQueue.EnQueue(2);
            priorityQueue.EnQueue(7);

            while (priorityQueue.Count > 0)
                Console.WriteLine($"出队元素：{priorityQueue.DeQueue()}");
        }
    }

    /// <summary>
    /// 这里使用最小堆来模拟实现一个简单的优先队列
    /// 下面描述的是最小堆，使用数组来存储堆
    ///               0
    ///       1               2
    ///   3       4       5       6
    /// 7   8   9
    /// 从上面可以得出这么几个结论，下面会用到这几个结论
    /// 1. 某节点的索引为n，那么如果有左孩子，那么索引为2n+1，如果有右孩子，那么索引为2n+2
    /// 2. 某节点的索引为n，父节点（如果有的话）的索引为(n-1)/2，如果n为奇数，那么为父节点的左孩子，如果n为偶数，那么为父节点的右孩子
    /// 3. 如果堆中共有N个元素，堆有lnN+1层
    /// 4. 如果堆中共有N个元素，即最后一个元素的索引为N-1，那么最后一个非叶子节点的索引为N/2-1，第一个叶子节点的索引为N/2
    /// </summary>
    class PriorityQueue
    {
        public PriorityQueue() { }

        private List<int> minheap = new List<int>();  // 堆的物理存储

        public int Count
        {
            get { return minheap.Count; }
        }

        /// <summary>
        /// 压栈
        /// 1. 将压入的元素放在堆的最后
        /// 2. 然后将其上浮到合适的位置
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public void EnQueue(int item)
        {
            minheap.Add(item);
            UpAdjust(minheap);
        }

        /// <summary>
        /// 出栈
        /// 1. 将堆顶的元素返回
        /// 2. 然后堆中最后一个元素放到堆顶
        /// 3. 最后将堆顶下沉到合适的位置
        /// </summary>
        /// <returns></returns>
        public int DeQueue()
        {
            if (minheap.Count == 0) throw new Exception("the queue is empty.");

            int result = minheap[0];
            minheap[0] = minheap[minheap.Count - 1];
            minheap.RemoveAt(minheap.Count - 1);
            DownAdjust(minheap, 0);

            return result;
        }

        /// <summary>
        /// 上浮调整
        /// 将最后一个元素上浮到合适的位置
        /// </summary>
        /// <param name="list"></param>
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

        /// <summary>
        /// 下沉调整
        /// 将指定位置的元素下沉
        /// </summary>
        /// <param name="list"></param>
        /// <param name="index"></param>
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

        /// <summary>
        /// 构建最小堆
        /// 从最后一个非叶子节点开始，依次做“下沉”调整
        /// </summary>
        /// <param name="list"></param>
        private void HeapBuilder(IList<int> list)
        {
            for (int i = list.Count / 2 - 1; i >= 0; i--)
                DownAdjust(list, i);
        }
    }
}
