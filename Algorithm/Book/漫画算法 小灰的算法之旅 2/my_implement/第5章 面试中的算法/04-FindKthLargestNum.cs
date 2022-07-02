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
            int[] arr = new int[random.Next(29, 43)];
            Parallel.For(0, arr.Length, i => arr[i] = random.Next(0, 100));
            int[] arr1 = arr.ToArray();
            int[] arr2 = arr.ToArray();
            int[] arr3 = arr.ToArray();
            int[] arr4 = arr.ToArray();

            for (int i = 0; i < arr.Length; i++)
                Console.Write($"{arr[i]}, ");

            Console.WriteLine();
            int k = random.Next(1, arr.Length);
            Console.WriteLine($"Minimal Heap,         {k}th largest element is: {FindKthLargestNum(arr1, k)}");
            Console.WriteLine($"Minimal Heap 2,       {k}th largest element is: {FindKthLargestNum2(arr2, k)}");
            Console.WriteLine($"Divide and conquer,   {k}th largest element is: {FindKthLargestNum3(arr3, k)}");
            Console.WriteLine($"Divide and conquer 2, {k}th largest element is: {FindKthLargestNum4(arr4, k)}");

            var arr_desc = arr.AsEnumerable().OrderByDescending(i => i);
            foreach (int i in arr_desc)
                Console.Write($"{i}, ");
        }

        /// <summary>
        /// 给你一个无序数组，要求你找出数组中的第k大元素。
        /// 
        /// 思路：
        /// 利用最小堆来实现。
        /// 1. 取数组的前K个元素，构建为最小堆
        /// 2. 从数组的第k+1个元素向后遍历每一个数组中的元素
        ///    2.1 如果元素大于堆顶，将元素替换堆顶元素，然后将堆顶元素下沉到合适的位置
        /// 3. 遍历完成后，堆顶就是原数组的第k大元素，同时，堆中的元素就是数组中前k大的元素   
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int FindKthLargestNum(int[] nums, int k)
        {
            if (nums.Length < k) throw new Exception($"array length is less than {k}"); ;

            int[] heap = new int[k];
            for (int i = 0; i < k; i++)
                heap[i] = nums[i];

            HeapBuilder(heap);

            for (int i = k; i < nums.Length; i++)
            {
                if (nums[i] > heap[0])
                {
                    heap[0] = nums[i];
                    DownAdjust(heap, 0);
                }
            }

            return heap[0];
        }

        /// <summary>
        /// 给你一个无序数组，要求你找出数组中的第k大元素。
        /// 
        /// 思路：
        /// 同FindKthLargestNum()，原地更改数组，空间复杂度由O(k)降为O(1)
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int FindKthLargestNum2(int[] nums, int k)
        {
            if (nums.Length < k) throw new Exception($"array length is less than {k}"); ;

            HeapBuilder(nums, k);

            for (int i = k; i < nums.Length; i++)
            {
                if (nums[i] > nums[0])
                {
                    swap(nums, 0, i);
                    DownAdjust(nums, 0, k);
                }
            }

            return nums[0];
        }

        /// <summary>
        /// 给你一个无序数组，要求你找出数组中的第k大元素。
        /// 
        /// 思路：
        /// 采用分治法，类似于快速排序的方法来实现。
        /// 1. 以数组某个元素为轴，以快速排序的方式调整为轴元素左边的元素都小于它，右边的元素都大于它，这时
        ///    1.1. 如果轴的索引为k-1，则轴元素就是第k大的元素
        ///    1.2. 如果轴的索引大于k-1，则左边的元素多了，对左边的元素继续1步骤
        ///    1.3. 如果轴的索引小于k-1，则左边的元素少了，对右边的元素继续1步骤
        /// 2. 直至轴的索引为k-1为止
        /// 3. 返回轴元素的值，同时轴左边的元素就是数组前k大的元素
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int FindKthLargestNum3(int[] nums, int k)
        {
            return int.MinValue;
        }

        /// <summary>
        /// 给你一个无序数组，要求你找出数组中的第k大元素。
        /// 
        /// 思路：
        /// 同FindKthLargestNum3()，改为非递归版本
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int FindKthLargestNum4(int[] nums, int k)
        {
            return int.MinValue;
        }

        /*
        * 这里描述的是最小堆，使用数组来存储堆
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
        private static void UpAdjust(IList<int> list)
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
        private static void DownAdjust(IList<int> list, int index)
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
        /// 下沉调整
        /// 将指定位置的元素下沉
        /// </summary>
        /// <param name="list"></param>
        /// <param name="index"></param>
        /// <param name="len">将数组的前len个元素作为堆</param>
        private static void DownAdjust(IList<int> list, int index, int len)
        {
            if (index > len - 1 || len > list.Count) return;

            int value = list[index];

            int childIndex = index * 2 + 1;  // 需要上浮的孩子，先假定是左孩子
            while (childIndex < len)
            {
                if (childIndex + 1 < len && list[childIndex + 1] < list[childIndex])
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
        private static void HeapBuilder(IList<int> list)
        {
            for (int i = list.Count / 2 - 1; i >= 0; i--)
                DownAdjust(list, i);
        }

        /// <summary>
        /// 构建最小堆
        /// 从最后一个非叶子节点开始，依次做“下沉”调整
        /// </summary>
        /// <param name="list"></param>
        /// <param name="len">将数组的前len个元素作为堆</param>
        private static void HeapBuilder(IList<int> list, int len)
        {
            if (len > list.Count) return;

            for (int i = len / 2 - 1; i >= 0; i--)
                DownAdjust(list, i, len);
        }

        private static void swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
