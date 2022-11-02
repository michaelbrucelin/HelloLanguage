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
        /// 输出二维数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static void PrintArray<T>(IList<IList<T>> list, bool multiline)
        {
            Console.WriteLine(ArrayToString(list, multiline));
        }

        /// <summary>
        /// 比较两个一维数组是否相等
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public static bool CompareArray<T>(IList<T> list1, IList<T> list2, bool ignoreOrder = false) where T : IComparable
        {
            if (list1.Count != list2.Count) return false;

            if (ignoreOrder)
            {
                list1 = list1.OrderBy(t => t).ToList();
                list2 = list2.OrderBy(t => t).ToList();
            }

            for (int i = 0; i < list1.Count; i++)
                if (list1[i].CompareTo(list2[i]) != 0) return false;

            return true;
        }

        /// <summary>
        /// 比较两个二维数组是否相等
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public static bool CompareArray<T>(IList<IList<T>> list1, IList<IList<T>> list2, bool ignoreOrder = false) where T : IComparable
        {
            if (list1.Count != list2.Count) return false;

            if (ignoreOrder)
            {
                for (int i = 0; i < list1.Count; i++)
                {
                    list1[i] = list1[i].OrderBy(t => t).ToList();
                    list2[i] = list2[i].OrderBy(t => t).ToList();
                }
            }

            bool[] mask = new bool[list2.Count];
            for (int i = 0; i < list1.Count; i++)
            {
                bool flag = true;
                for (int j = 0; j < list2.Count; j++)
                {
                    if (!mask[j] && list1[i].Count == list2[j].Count)
                    {
                        for (int k = 0; k > list1[i].Count; k++)
                            if (list1[i][k].CompareTo(list2[j][k]) != 0) { flag = false; break; }
                        mask[j] = true;
                    }
                }
                if (!flag) return false;
            }

            return true;
        }

        public static string ArrayToString<T>(IEnumerable<T> list)
        {
            return ArrayToString<T>(new List<T>(list));
        }

        public static string ArrayToString<T>(IEnumerable<T> list, int start, int len)
        {
            return ArrayToString<T>(new List<T>(list), start, len);
        }

        /// <summary>
        /// 将一维数组转为字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
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
        /// 将一维数组转为字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string ArrayToString<T>(IList<T> list, int start, int len)
        {
            if (list == null) return "null";
            if (len == 0) return "[ ]";
            if (len == 1) return $"[ {list[start]} ]";

            StringBuilder sb = new StringBuilder();

            sb.Append("[ ");
            sb.Append(list[start].ToString());
            for (int i = start + 1; i < len; i++)
                sb.Append($", {list[i]}");
            sb.Append(" ]");

            return sb.ToString();
        }

        /// <summary>
        /// 将二维数组转为字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string ArrayToString<T>(IList<IList<T>> list, bool multiline)
        {
            if (list == null) return "null";
            if (list.Count == 0) return "[ ]";
            if (list.Count == 1) return $"[ {ArrayToString<T>(list[0])} ]";

            StringBuilder sb = new StringBuilder();

            sb.Append("[ ");
            sb.Append($"{ArrayToString<T>(list[0])}, "); if (multiline) sb.Append(Environment.NewLine);
            for (int i = 1; i < list.Count - 1; i++)
            { if (multiline) sb.Append("  "); sb.Append($"{ArrayToString<T>(list[i])}, "); if (multiline) sb.Append(Environment.NewLine); }
            if (multiline) sb.Append("  "); sb.Append($"{ArrayToString<T>(list[list.Count - 1])}");
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

        /// <summary>
        /// 乱序数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static T[] ShuffleArray<T>(IList<T> list)
        {
            return list.OrderBy(i => random.Next()).ToArray();
        }

        /// <summary>
        /// 乱序字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ShuffleString(string str)
        {
            return new string(str.OrderBy(i => random.Next()).ToArray());
        }

        ///// <summary>
        ///// Question0025里面有写，稍后统一
        ///// </summary>
        ///// <param name="arrayString"></param>
        ///// <returns></returns>
        //public static SinglyListNode GetTreeNodeFromArray(string arrayString)
        //{

        //}
    }
}
