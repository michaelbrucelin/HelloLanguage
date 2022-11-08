using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0029
{
    public class Test0029
    {
        public void Test()
        {
            Interface0029 solution = new Solution0029_3();
            int dividend, divisor;
            int result, answer;
            int id = 0;

            // 1.
            dividend = 10; divisor = 3; answer = 3;
            result = solution.Divide(dividend, divisor);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 2.
            dividend = 7; divisor = -3; answer = -2;
            result = solution.Divide(dividend, divisor);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 3.
            dividend = -2147483648; divisor = -1; answer = 2147483647;
            result = solution.Divide(dividend, divisor);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 4.
            dividend = -99; divisor = 3; answer = -33;
            result = solution.Divide(dividend, divisor);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 5.
            dividend = 2048; divisor = -2; answer = -1024;
            result = solution.Divide(dividend, divisor);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");
        }

        public void TestMulti()
        {
            Type type = typeof(Solution0029_2_2);
            MethodInfo method = type.GetMethod("Multi", BindingFlags.NonPublic | BindingFlags.Instance);
            object obj = Activator.CreateInstance(type);

            Console.WriteLine(method.Invoke(obj, new object[] { 33, 66 }));
        }
    }
}
