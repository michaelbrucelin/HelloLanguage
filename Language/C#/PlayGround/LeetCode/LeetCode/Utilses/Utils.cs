using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Utilses
{
    public static class Utils
    {
        static Utils()
        {
            random = new Random();
        }

        private static readonly Random random;

        /// <summary>
        /// 输出一维数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static void PrintArray<T>(IList<T> list)
        {
            Console.WriteLine(ArrayToString(list));
        }

        /// <summary>
        /// 忽略数组中元素的顺序，比较两个数组是否相等
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public static bool CompareArray<T>(IList<T> list1, IList<T> list2) where T : IComparable
        {
            if (list1.Count != list2.Count) return false;

            list1 = list1.OrderBy(t => t).ToList();
            list2 = list2.OrderBy(t => t).ToList();
            for (int i = 0; i < list1.Count; i++)
                if (list1[i].CompareTo(list2[i]) != 0) return false;

            return true;
        }

        public static string ArrayToString<T>(IList<T> list)
        {
            if (list == null) return "null";
            if (list.Count == 0) return "[ ]";
            if (list.Count == 1) return $"[ {list[0]} ]";

            StringBuilder sb = new StringBuilder();

            sb.Append("[ ");
            sb.Append(list[0].ToString());
            for (int i = 1; i < list.Count; i++)
                sb.Append($", {list[i]}");
            sb.Append(" ]");

            return sb.ToString();
        }

        /// <summary>
        /// 生成随机测试用例，整数数组
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GenerateRandomIntArray(int length, int min, int max)
        {
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
                array[i] = random.Next(min, max + 1);

            return ArrayToString(array);
        }

        /// <summary>
        /// 生成随机字符串
        /// </summary>
        /// <param name="chars"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GetRandomString(string chars, int length)
        {
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string ShuffleString(string str)
        {
            return new string(str.OrderBy(i => random.Next()).ToArray());
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="arrayString"></param>
        ///// <returns></returns>
        //public static TreeNode GetTreeNodeFromArray(string arrayString)
        //{ 

        //}
    }
}
