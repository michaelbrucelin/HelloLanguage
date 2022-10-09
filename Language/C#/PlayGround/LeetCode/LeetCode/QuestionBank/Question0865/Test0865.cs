using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0865
{
    public class Test0865
    {
        public void Test()
        {
            Interface0865 solution = new Solution0865();
            string s;
            int result, answer;
            int id = 0;

            s = "()"; answer = 1;
            result = solution.ScoreOfParentheses(s);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            s = "(())"; answer = 2;
            result = solution.ScoreOfParentheses(s);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            s = "()()"; answer = 2;
            result = solution.ScoreOfParentheses(s);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            s = "(()(()))"; answer = 6;
            result = solution.ScoreOfParentheses(s);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            s = "((())()()((()))())"; answer = 18;
            result = solution.ScoreOfParentheses(s);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            s = "((())()()((()))(()))()()(()(()(()(()))))"; answer = 52;
            result = solution.ScoreOfParentheses(s);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            s = "((((((((((((((((((((((((()))))))))))))))))))))))))"; answer = 16777216;
            result = solution.ScoreOfParentheses(s);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");
        }
    }
}
