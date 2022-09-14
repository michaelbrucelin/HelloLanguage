using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1910
{
    public class Solution1910_2 : Interface1910
    {
        /// <summary>
        /// 暴力破解法，应该调用API或使用KMP，这里只是试着用一下双向链表
        /// </summary>
        /// <param name="s"></param>
        /// <param name="part"></param>
        /// <returns></returns>
        public string RemoveOccurrences(string s, string part)
        {
            LinkedList<char> link = new LinkedList<char>(s);

            LinkedListNode<char> p1 = link.First;
            while (p1 != null)
            {
                LinkedListNode<char> p2 = p1;
                int i = 0;
                for (; i < part.Length; i++)
                {
                    if (p2 == null || p2.Value != part[i])
                        break;
                    else
                        p2 = p2.Next;
                }

                if (i < part.Length)
                    p1 = p1.Next;
                else
                {
                    // LinkedListNode<char> pz = p2;
                    // for (int k = 0; k < part.Length; k++)
                    //     p2 = p2.Previous;
                    // LinkedListNode<char> pa = p2.Previous;
                    // pa.Next = pz;
                    // pz.Previous = pa;

                    if (p2 != null)
                    {
                        for (int k = 0; k < part.Length; k++)
                            link.Remove(p2.Previous);

                        for (int k = 0; k < part.Length - 1 && p2.Previous != null; k++)
                            p2 = p2.Previous;

                        p1 = p2;
                    }
                    else
                    {
                        for (int k = 0; k < part.Length; k++)
                            link.RemoveLast();
                        break;
                    }
                }
            }

            return new string(link.ToArray());
        }
    }
}
