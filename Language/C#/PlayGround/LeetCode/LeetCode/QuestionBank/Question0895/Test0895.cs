using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0895
{
    public class Test0895
    {
        public void Test()
        {
            Interface0895 solution = new FreqStack_3();
            int result, answer;
            int id = 0;

            solution.Push(5);                     // 堆栈为 [5]
            solution.Push(7);                     // 堆栈是 [5,7]
            solution.Push(5);                     // 堆栈是 [5,7,5]
            solution.Push(7);                     // 堆栈是 [5,7,5,7]
            solution.Push(4);                     // 堆栈是 [5,7,5,7,4]
            solution.Push(5);                     // 堆栈是 [5,7,5,7,4,5]
            answer = 5; result = solution.Pop();  // 返回 5 ，因为 5 出现频率最高。堆栈变成 [5,7,5,7,4]。
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            answer = 7; result = solution.Pop();  // 返回 7 ，因为 5 和 7 出现频率最高，但7最接近顶部。堆栈变成 [5,7,5,4]。
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            answer = 5; result = solution.Pop();  // 返回 5 ，因为 5 出现频率最高。堆栈变成 [5,7,4]。
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            answer = 4; result = solution.Pop();  // 返回 4 ，因为 4, 5 和 7 出现频率最高，但 4 是最接近顶部的。堆栈变成 [5,7]。
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
