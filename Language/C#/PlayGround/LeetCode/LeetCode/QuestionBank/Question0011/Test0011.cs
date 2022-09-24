using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0011
{
    public class Test0011
    {
        public void Test()
        {
            Interface0011 solution = new Solution0011();
            int[] height;
            int result, answer;
            int id = 0;

            height = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }; answer = 49;
            result = solution.MaxArea(height);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            height = new int[] { 1, 1 }; answer = 1;
            result = solution.MaxArea(height);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            height = new int[] { 1, 3, 523, 5634, 7, 12, 7, 8, 545, 53, 643, 745, 6, 2, 5, 4, 1234, 5234, 8, 3, 7 }; answer = 73276;
            result = solution.MaxArea(height);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");
        }
    }
}
