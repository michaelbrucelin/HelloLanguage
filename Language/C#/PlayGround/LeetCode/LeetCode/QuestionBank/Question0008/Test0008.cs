using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0008
{
    public class Test0008
    {
        public void Test()
        {
            Interface0008 solution = new Solution0008();
            string s;
            int answer, result;
            int id = 0;

            s = ""; answer = 0;
            result = solution.MyAtoi(s);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            s = "42"; answer = 42;
            result = solution.MyAtoi(s);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            s = "   -42"; answer = -42;
            result = solution.MyAtoi(s);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            s = "4193 with words"; answer = 4193;
            result = solution.MyAtoi(s);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            s = "- 1-2abc42"; answer = 0;
            result = solution.MyAtoi(s);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            s = "-01-2abc42"; answer = -1;
            result = solution.MyAtoi(s);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            s = "0-1-2abc42"; answer = 0;
            result = solution.MyAtoi(s);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            s = "9999999999999999"; answer = 2147483647;
            result = solution.MyAtoi(s);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            s = "-9999999999999999"; answer = -2147483648;
            result = solution.MyAtoi(s);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");
        }
    }
}
