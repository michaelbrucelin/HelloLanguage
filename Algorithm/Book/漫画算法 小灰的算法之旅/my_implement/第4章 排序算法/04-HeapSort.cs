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
            Random random = new Random();
            List<int> list = new List<int>(32);
            Parallel.For(0, 32, i => list.Add(random.Next(0, 100)));

            for (int i = 0; i < list.Count; i++)
                Console.Write($"{list[i]}, ");

            HeapSort(list);

            Console.WriteLine();
            for (int i = 0; i < list.Count; i++)
                Console.Write($"{list[i]}, ");
        }

        /// <summary>
        /// 堆排序
        /// 1. 把无序数组调整为二叉堆
        ///        从小到大排序，构建最大堆；从大到小排序，构建最小堆；这里以从小到大为例
        /// 2. 循环“删除”堆顶的元素放到堆的“末尾”
        ///        第一个堆顶放在堆的最后，堆的“有效数量”-1
        ///        第二个堆顶放在堆的倒数第二个位置，堆的“有效数量”-1
        ///        ... ...
        /// 3. 最后，就是从小到大排序
        /// </summary>
        /// <param name="list"></param>
        public static void HeapSort(IList<int> list)
        {
            HeapBuilder(list);                    // 将list构建成最大堆

            for (int i = 1; i < list.Count; i++)  // 这里i表示第几次移动堆顶
            {
                swap(list, 0, list.Count - i);
                DownAdjust(list, 0, list.Count - 1 - i);
            }
        }

        /*
         * 这里描述的是最大堆，使用数组来存储堆
         *               0
         *       1               2
         *   3       4       5       6
         * 7   8   9
         * 从上面可以得出这么几个结论，下面会用到这几个结论
         * 1. 某节点的索引为n，那么如果有左孩子，那么索引为2n+1，如果有右孩子，那么索引为2n+2
         * 2. 某节点的索引为n，父节点（如果有的话）的索引为(n-1)/2，如果n为奇数，那么为父节点的左孩子，如果n为偶数，那么为父节点的右孩子
         * 3. 如果堆中共有N个元素，堆有lnN+1层
         * 4. 如果堆中共有N个元素，即最后一个元素的索引为N-1，那么最后一个非叶子节点的索引为N/2-1，第一个叶子节点的索引为N/2
         */

        /// <summary>
        /// 上浮调整
        /// 将最后一个元素上浮到合适的位置
        /// </summary>
        /// <param name="list"></param>
        public static void UpAdjust(IList<int> list)
        {
            int index = list.Count - 1;
            int value = list[index];

            while (index > 0 && value > list[(index - 1) / 2])
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
        /// <param name="len">有效长度，由于每次把堆顶拿到最后，新的堆顶需要下沉，这时需要保证拿到最后的堆顶永远在这不动，所以使用有效长度限制新堆顶的下沉范围</param>
        public static void DownAdjust(IList<int> list, int index, int len)
        {
            if (index > len) return;

            int value = list[index];

            int childIndex = index * 2 + 1;  // 需要上浮的孩子，先假定是左孩子
            while (childIndex <= len)
            {
                if (childIndex + 1 <= len && list[childIndex + 1] > list[childIndex])
                    childIndex++;            // 选出左右孩子中较大的那一个

                if (value < list[childIndex])
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
        /// 构建最大堆
        /// 从最后一个非叶子节点开始，依次做“下沉”调整
        /// </summary>
        /// <param name="list"></param>
        public static void HeapBuilder(IList<int> list)
        {
            for (int i = list.Count / 2 - 1; i >= 0; i--)
                DownAdjust(list, i, list.Count - 1);
        }

        public static void swap(IList<int> list, int i, int j)
        {
            if (i != j)
            {
                int temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }
    }
}
