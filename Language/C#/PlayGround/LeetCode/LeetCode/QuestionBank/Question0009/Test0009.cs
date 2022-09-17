using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0009
{
    public class Test0009
    {
        public void Test()
        {
            Interface0009 solution = new Solution0009_3();
            int x;
            bool result, answer;
            int id = 0;

            x = 123; answer = false;
            result = solution.IsPalindrome(x);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            x = 121; answer = true;
            result = solution.IsPalindrome(x);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            x = int.MaxValue; answer = false;
            result = solution.IsPalindrome(x);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");
        }
    }
}
