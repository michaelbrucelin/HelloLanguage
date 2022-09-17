using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0010
{
    public class Test0010
    {
        public void Test()
        {
            Interface0010 solution = new Solution0010();
            string s, p;
            bool result, answer;
            int id = 0;

            //s = "a"; p = "a"; answer = true;
            //result = solution.IsMatch(s, p);
            //Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            //s = "aa"; p = "a"; answer = false;
            //result = solution.IsMatch(s, p);
            //Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            //s = "aa"; p = "a*"; answer = true;
            //result = solution.IsMatch(s, p);
            //Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            //s = "ab"; p = ".*"; answer = true;
            //result = solution.IsMatch(s, p);
            //Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            s = "ab"; p = "a*"; answer = false;
            result = solution.IsMatch(s, p);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            s = "bbab"; p = "b*a*"; answer = false;
            result = solution.IsMatch(s, p);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            s = "aabbdccdd"; p = "aa..*d"; answer = true;
            result = solution.IsMatch(s, p);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            s = "aabbdccdd"; p = "aa..*c*ccdd"; answer = true;
            result = solution.IsMatch(s, p);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            s = "aabbdccdd"; p = "aa..*c*cccdd"; answer = false;
            result = solution.IsMatch(s, p);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            s = "aabbdccdd"; p = "aa..*c*c*c*ccdd"; answer = true;
            result = solution.IsMatch(s, p);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            s = "aab"; p = "c*a*b"; answer = true;
            result = solution.IsMatch(s, p);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            s = "mississippi"; p = "mis*is*p*."; answer = false;
            result = solution.IsMatch(s, p);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            //s = ""; p = ""; ansser = false;
            //result = solution.IsMatch(s, p);
            //Console.WriteLine($"{++id,2}: {result == ansser}, result: {result}, answer: {ansser}");
        }
    }
}
