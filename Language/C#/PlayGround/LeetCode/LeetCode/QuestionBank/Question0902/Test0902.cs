using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0902
{
    public class Test0902
    {
        public void Test()
        {
            Interface0902 solution = new Solution0902();
            string[] digits; int n;
            int result, answer;
            int id = 0;

            // 1.
            digits = new string[] { "7" }; n = 8; answer = 1;
            result = solution.AtMostNGivenDigitSet(digits, n);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 2.
            digits = new string[] { "3", "4", "8" }; n = 4; answer = 2;
            result = solution.AtMostNGivenDigitSet(digits, n);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 3.
            digits = new string[] { "1", "3", "5", "7" }; n = 100; answer = 20;
            result = solution.AtMostNGivenDigitSet(digits, n);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 4.
            digits = new string[] { "1", "4", "9" }; n = 1000000000; answer = 29523;
            result = solution.AtMostNGivenDigitSet(digits, n);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 5.
            digits = new string[] { "1", "4", "7", "9" }; n = 865132198; answer = 283988;
            result = solution.AtMostNGivenDigitSet(digits, n);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 6.
            digits = new string[] { "1", "2", "3", "4", "5", "6", "7", "9" }; n = 1; answer = 1;
            result = solution.AtMostNGivenDigitSet(digits, n);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");
        }
    }
}
