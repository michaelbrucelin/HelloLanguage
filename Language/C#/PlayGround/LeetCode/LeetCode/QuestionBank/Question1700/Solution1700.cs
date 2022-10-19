using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1700
{
    public class Solution1700 : Interface1700
    {
        /// <summary>
        /// 用栈和队列模拟
        /// </summary>
        /// <param name="students"></param>
        /// <param name="sandwiches"></param>
        /// <returns></returns>
        public int CountStudents2(int[] students, int[] sandwiches)
        {
            Stack<int> stack = new Stack<int>(sandwiches.Reverse());
            Queue<int> queue = new Queue<int>();
            int cnt0 = 0, cnt1;                        // cnt0与cnt1分别表示喜欢圆形三明治与喜欢方形三明治的学生数量
            for (int i = 0; i < students.Length; i++)
            {
                queue.Enqueue(students[i]);
                if (students[i] == 0) cnt0++;
            }
            cnt1 = students.Length - cnt0;

            while (stack.Count > 0)
            {
                int sandwich = stack.Peek();
                if (sandwich == 0)
                    if (cnt0 == 0) break; else cnt0--;
                else
                    if (cnt1 == 0) break; else cnt1--;
                stack.Pop();
                while (queue.Peek() != sandwich) queue.Enqueue(queue.Dequeue());
                queue.Dequeue();
            }

            return queue.Count;
        }

        /// <summary>
        /// 不用栈和队列模拟，直接用数组
        /// </summary>
        /// <param name="students"></param>
        /// <param name="sandwiches"></param>
        /// <returns></returns>
        public int CountStudents(int[] students, int[] sandwiches)
        {
            int result = students.Length;
            int ptr = 0;                                 // 指向学生的指针
            for (int i = 0; i < sandwiches.Length; i++)
            {
                if (students[ptr] != sandwiches[i])
                {
                    int ptr0 = ptr;
                    ptr = (ptr + 1) % students.Length;
                    while (ptr != ptr0 && students[ptr] != sandwiches[i]) ptr = (ptr + 1) % students.Length;
                    if (ptr == ptr0) break;
                }

                students[ptr] = -1;
                ptr = (ptr + 1) % students.Length;
                result--;
            }

            return result;
        }
    }
}
