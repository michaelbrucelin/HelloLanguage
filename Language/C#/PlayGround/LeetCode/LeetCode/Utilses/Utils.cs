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
