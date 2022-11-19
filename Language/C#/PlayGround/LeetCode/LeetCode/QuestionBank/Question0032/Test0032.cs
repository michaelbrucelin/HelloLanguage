using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0032
{
    public class Test0032
    {
        public void Test()
        {
            Interface0032 solution = new Solution0032_5();
            string s;
            int result, answer;
            int id = 0;

            // 1.
            s = "(()"; answer = 2;
            result = solution.LongestValidParentheses(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2.
            s = ")()())"; answer = 4;
            result = solution.LongestValidParentheses(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3.
            s = ""; answer = 0;
            result = solution.LongestValidParentheses(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4.
            s = ")()((())))"; answer = 8;
            result = solution.LongestValidParentheses(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5.
            s = "())()))())(((())(()))()(())())()))())()()(()(())())(()))))(()))((()(()))((())))((((()(())())(((())()))))()()()))(()()()())()()(()(()))))((()())))(()()((())((((()((()()()()))()))(()())()())(()(())()((())()()))))(()())()((()))(((())()((()(()()(((()()()((((()(()())()(()))()())()()(((()((()((()))())(()(())()()(())(())(())()((((()((()()()())((()))(((()(()))(((()))()(((()()()())))((()(()()((()()(()))())(())()))(((())(()(()((((())()()(()))))(((()())()))(()(()))())))()((()(((()(())(()(()(((()()()(()))))(())(((((())))(((()))))(())))())(())())())()(())))))))))(((())()(()())()()()))()(((()(()(((()(())))()((()))))))()()())))))))(((()()(())()()(((((()()))())(((()()))(())()(((()(()()))(()()(()()))()))((()))))()((()()(())))()))))((())))))))((()(()))()())((())(((((()))()())))))())((()())()((())))(()(())(()(((())())))))(())())))))))(()(()()(((())((()(()))))()(())()))))((())()()((((())(()(()(()()())()))((())))())))(()))())))(()))()())))()))()()))))))()(())))(()())(()))())())(((()()(()()((())())((()())(((((())())()(()())))))((())(())()(()((()()((())(((((((((()((()))()()()))()()())((()())(())))))(())))(((()(()()(()()((()((((()((()((())((()((()()(()()(((())))()))(()((()()))(()(()()(()((()((()()))())(((((()())())((()()(((((((((()(((((()";
            answer = 718;
            result = solution.LongestValidParentheses(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
