using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0481
{
    public class Test0481
    {
        public void Test()
        {
            Interface0481 solution = new Solution0481();
            int n;
            int result, answer;
            int id = 0;

            // 1.
            n = 6; answer = 3;
            result = solution.MagicalString(n);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 2.
            n = 1; answer = 1;
            result = solution.MagicalString(n);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 3.
            n = 100; answer = 49;
            result = solution.MagicalString(n);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 4.
            n = 9999; answer = 4995;
            result = solution.MagicalString(n);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 5.
            n = 100000; answer = 49972;
            result = solution.MagicalString(n);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");
        }
    }
}
