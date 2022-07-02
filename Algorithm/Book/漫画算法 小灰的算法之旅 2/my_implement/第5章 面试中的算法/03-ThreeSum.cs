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
            int[] nums = { 5, 12, 6, 3, 9, 2, 1, 7 };
            List<(int o, int p, int q)> result = ThreeSum2(nums, 12);

            int i = 1;
            foreach (var item in result)
                Console.WriteLine($"{i++}. ({item.o}, {item.p}, {item.q})");
        }

        /// <summary>
        /// 三数之和
        /// 
        /// 给你一个整型数组，数组中没有重复元素，
        /// 请你从数组中找出所有和为特定值的3个元素，输出它们的值。
        /// 
        /// 思路：
        /// 1. 将数组升序排序
        /// 2. 使用两个指针从前向后遍历所有可能的组合
        /// 3. 使用二分查找从其余（后面）的元素中，查找有没有目标值
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static List<(int o, int p, int q)> ThreeSum(int[] nums, int target)
        {
            List<(int o, int p, int q)> result = new List<(int, int, int)>();

            Array.Sort(nums);
            int border1 = target / 3;           // 第1层循环的边界，不一定严谨
            int border2 = target - target / 3;  // 第2层循环的边界，不一定严谨
            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (nums[i] > border1) break;
                for (int j = i + 1; j < nums.Length - 1; j++)
                {
                    if (nums[i] + nums[j] > border2) break;

                    int k = BinarySearch(nums, j + 1, nums.Length - 1, (target - nums[i] - nums[j]));
                    if (k != -1)
                        result.Add((nums[i], nums[j], nums[k]));
                }
            }

            return result;
        }

        /// <summary>
        /// 三数之和
        /// 
        /// 给你一个整型数组，数组中没有重复元素，
        /// 请你从数组中找出所有和为特定值的3个元素，输出它们的值。
        /// 
        /// 思路：
        /// 1. 将数组升序排序
        /// 2. 使用1个指针从前向后遍历各个元素
        /// 3. 使用两个指针从后面所有元素的两端逐步向中间靠拢，寻找答案
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static List<(int o, int p, int q)> ThreeSum2(int[] nums, int target)
        {
            List<(int o, int p, int q)> result = new List<(int, int, int)>();

            Array.Sort(nums);
            int border1 = target / 3;           // 第1层循环的边界，不一定严谨
            int border2 = target - target / 3;  // 第2层循环的边界，不一定严谨
            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (nums[i] > border1) break;
                int left = i + 1, right = nums.Length - 1;
                while (left < right)
                {
                    if (nums[left] > border2) break;
                    if (nums[left] + nums[right] == target - nums[i])
                    {
                        result.Add((nums[i], nums[left], nums[right]));
                        left++;
                        right--;
                    }
                    else if (nums[left] + nums[right] < target - nums[i])
                        left++;
                    else
                        right--;
                }
            }

            return result;
        }

        /// <summary>
        /// 二分查找
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private static int BinarySearch(int[] nums, int left, int right, int target)
        {
            if (left > right) return -1;

            int mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (nums[mid] == target)
                    return mid;
                else if (nums[mid] > target)
                    right = mid - 1;
                else
                    left = mid + 1;
            }

            return -1;
        }
    }
}
