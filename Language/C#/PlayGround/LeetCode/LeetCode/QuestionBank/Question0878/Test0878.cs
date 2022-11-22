using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0878
{
    public class Test0878
    {
        public void Test()
        {
            Interface0878 solution = new Solution0878();
            int n, a, b;
            int result, answer;
            int id = 0;

            // 1.
            n = 1; a = 2; b = 3; answer = 2;
            result = solution.NthMagicalNumber(n, a, b);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2.
            n = 4; a = 2; b = 3; answer = 6;
            result = solution.NthMagicalNumber(n, a, b);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3.
            n = 1000000000; a = 19999; b = 39999; answer = 999903342;
            result = solution.NthMagicalNumber(n, a, b);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4.
            n = 206117388; a = 938; b = 24479; answer = 254370162;
            result = solution.NthMagicalNumber(n, a, b);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
