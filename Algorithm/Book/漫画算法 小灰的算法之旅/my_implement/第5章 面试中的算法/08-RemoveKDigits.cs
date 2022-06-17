using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestCSharp
{
    class Program
    {
        public static void Main(string[] args)
        {
            string s;
            int k;

            s = "1593212"; k = 3;
            Console.WriteLine($"({s}, {k}):\t{RemoveKDigits3(s, k)}");

            s = "30200"; k = 1;
            Console.WriteLine($"({s}, {k}):\t{RemoveKDigits3(s, k)}");

            s = "10"; k = 2;
            Console.WriteLine($"({s}, {k}):\t{RemoveKDigits3(s, k)}");

            s = "541270936"; k = 3;
            Console.WriteLine($"({s}, {k}):\t{RemoveKDigits3(s, k)}");

            s = "1593212"; k = 4;
            Console.WriteLine($"({s}, {k}):\t{RemoveKDigits3(s, k)}");

            s = "1000020000000010"; k = 2;
            Console.WriteLine($"({s}, {k}):\t{RemoveKDigits3(s, k)}");
        }

        /// <summary>
        /// 题目
        /// 给出一个整数，从该整数中去掉k个数字，要求剩下的数字形成的新整数尽可能小。应该如何选取被去掉的数字？
        /// 其中整数的长度大于或等于k，给出的整数的大小可以超过long类型的数字范围。
        /// 1 593 212，删去3个数字，新整数最小的情况是1212
        /// 30 200，   删去1个数字，新整数最小的情况是200
        /// 10，       删去2个数字，新整数最小的情况是0
        /// 
        /// 这里使用贪心算法，每次移除1位数字，总共移除k次即可。
        /// 
        /// 原理：
        /// 从左至右遍历每一位数字，如果这个数字大于右边的数字，删除这个数字即可，
        /// 如果到了最后一位，仍然没有符合上述条件的数字，那么删除最后一位数字即可。
        /// 
        /// 使用List<char>实现，因为涉及从中间位置删除元素，理论上性能低于双向链表
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>

        public static string RemoveKDigits(string s, int k)
        {
            if (!Regex.IsMatch(s, @"^\d+$")) return null;
            if (k < 0 || k > s.Length) return null;
            if (k == s.Length) return "0";

            List<char> buffer = s.ToList();

            int index = 0;
            while (k > 0 && index < buffer.Count - 1)
            {
                if (buffer[index] > buffer[index + 1])  // 移除元素，指针后退一步
                {
                    k--;
                    buffer.RemoveAt(index);
                    if (index > 0) index--;
                }
                else                                    // 指针前进一步
                    index++;
            }
            while (k-- > 0)
                buffer.RemoveAt(buffer.Count - 1);

            // 移除开头的0
            int border = 0;
            for (; border < buffer.Count - 1 && buffer[border] == '0'; border++) ;  // 最后一位即使是0，也需要保留

            return new string(buffer.ToArray(), border, buffer.Count - border);
        }

        /// <summary>
        /// 使用LinkedList<char>实现
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static string RemoveKDigits2(string s, int k)
        {
            if (!Regex.IsMatch(s, @"^\d+$")) return null;
            if (k < 0 || k > s.Length) return null;
            if (k == s.Length) return "0";

            LinkedList<char> buffer = new LinkedList<char>(s);

            LinkedListNode<char> pointer = buffer.First;
            for (; k > 0 && pointer.Next != null && pointer.Next.Next != null;)
            {
                if (pointer.Value > pointer.Next.Value)  // 移除元素，指针后退一步
                {
                    k--;
                    LinkedListNode<char> temp = pointer;
                    if (pointer.Previous != null)
                        pointer = pointer.Previous;
                    else
                        pointer = pointer.Next;
                    buffer.Remove(temp);
                }
                else                                     // 指针前进一步
                    pointer = pointer.Next;
            }
            while (k-- > 0)
                buffer.RemoveLast();

            // 移除开头的0
            pointer = buffer.First;
            while (pointer.Value == '0' && pointer.Next != null)  // 最后一位即使是0，也需要保留
            {
                pointer = pointer.Next;
                buffer.RemoveFirst();
            }

            return new string(buffer.ToArray());
        }

        /// <summary>
        /// 使用缓冲数组实现
        /// </summary>
        /// <param name="s"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static string RemoveKDigits3(string s, int k)
        {
            if (!Regex.IsMatch(s, @"^\d+$")) return null;
            if (k < 0 || k > s.Length) return null;
            if (k == s.Length) return "0";

            char[] buffer = new char[s.Length - k];  // 缓冲数组

            int sid = 0, bufferid = 0;
            while (k > 0 && sid < s.Length - 1 && bufferid < buffer.Length)
            {
                if (bufferid == 0 || s[sid] >= buffer[bufferid - 1])
                    buffer[bufferid++] = s[sid++];
                else
                {
                    bufferid--;
                    k--;
                }
            }
            // 执行到此处，如果bufferid < buffer.Length-1，即buffer没有装满
            //                说明s没有走到最后，就成功删除了k个整数，需要将s剩余的部分写入buffer
            //            否则即使sid没有走到尽头，也说明s后面的部分应该删除
            while (bufferid < buffer.Length)
                buffer[bufferid++] = s[sid++];

            // 移除开头的0
            int border = 0;
            for (; border < buffer.Length - 1 && buffer[border] == '0'; border++) ;  // 最后一位即使是0，也需要保留

            return new string(buffer, border, buffer.Length - border);
        }
    }
}
