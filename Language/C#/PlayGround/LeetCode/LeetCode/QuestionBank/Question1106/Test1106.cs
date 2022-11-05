using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1106
{
    public class Test1106
    {
        public void Test()
        {
            Interface1106 solution = new Solution1106_2();
            string expression;
            bool result, answer;
            int id = 0;

            // 1.
            expression = "&(|(f))";
            answer = false; result = solution.ParseBoolExpr(expression);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 2.
            expression = "|(f,f,f,t)";
            answer = true; result = solution.ParseBoolExpr(expression);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 3.
            expression = "!(&(f,t))";
            answer = true; result = solution.ParseBoolExpr(expression);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 4.
            expression = "|(&(t,f,t),!(t))";
            answer = false; result = solution.ParseBoolExpr(expression);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 5.
            expression = "|(f,t,&(t,f,t),!(t))";
            answer = true; result = solution.ParseBoolExpr(expression);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 6.
            expression = "|(f,f,&(t,f,t),!(t)),f,|(f,f,t,f,t),f,t";
            answer = false; result = solution.ParseBoolExpr(expression);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 7.
            expression = "f,f,f,f,f,f,f";
            answer = false; result = solution.ParseBoolExpr(expression);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 8.
            expression = "f,f,f,f,f,f,t";
            answer = true; result = solution.ParseBoolExpr(expression);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");
        }
    }
}
