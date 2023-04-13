using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCSharp.Algorithm.Utilses
{
    public static class Utils
    {
        public static string ArrayToString<T>(IEnumerable<T> list)
        {
            return ArrayToString<T>(new List<T>(list));
        }

        public static string ArrayToString<T>(IEnumerable<T> list, int start, int length)
        {
            return ArrayToString<T>(new List<T>(list), start, length);
        }

        /// <summary>
        /// 将一维数组转为字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string ArrayToString<T>(IList<T> list)
        {
            return ArrayToString<T>(list, 0, list.Count);
        }

        /// <summary>
        /// 将一维数组转为字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string ArrayToString<T>(IList<T> list, int start, int length)
        {
            if (list == null) return "null";
            if (length == 0) return "[ ]";
            if (length == 1) return $"[ {list[start]} ]";

            StringBuilder sb = new StringBuilder();
            sb.Append("[ ");
            sb.Append(list[start].ToString());
            for (int i = start + 1; i < length; i++) sb.Append($", {list[i]}");
            sb.Append(" ]");

            return sb.ToString();
        }
    }
}
