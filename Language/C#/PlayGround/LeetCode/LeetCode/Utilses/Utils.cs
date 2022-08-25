using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Utilses
{
    public static class Utils
    {
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
    }
}
