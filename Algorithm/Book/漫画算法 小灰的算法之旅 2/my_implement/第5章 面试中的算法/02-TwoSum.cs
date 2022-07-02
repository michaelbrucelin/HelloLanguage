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
            List<(int m, int n)> result = TwoSum(nums, 12);

            int i = 1;
            foreach (var item in result)
                Console.WriteLine($"{i++}. ({item.m}, {item.n})");
        }

        /// <summary>
        /// 两数之和
        /// 
        /// 给你一个整型数组，数组中没有重复元素，
        /// 请你从数组中找出所有和为特定值的一对整数，输出它们的下标。
        /// 
        /// 思路：
        /// 空间换时间，借助字典实现O(1)查找
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static List<(int m, int n)> TwoSum(int[] nums, int target)
        {
            List<(int m, int n)> result = new List<(int m, int n)>();

            Dictionary<int, int> dic = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (dic.ContainsKey(target - nums[i]))
                    result.Add((dic[target - nums[i]], i));

                dic.Add(nums[i], i);
            }

            return result;
        }
    }
}
