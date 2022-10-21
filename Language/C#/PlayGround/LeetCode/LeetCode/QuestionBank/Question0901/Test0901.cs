using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0901
{
    public class Test0901
    {
        public void Test()
        {
            Interface0901 solution = new StockSpanner_2();
            int price;
            int result, answer;
            int id = 0;

            price = 100; answer = 1; result = solution.Next(price);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");
            price = 80; answer = 1; result = solution.Next(price);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");
            price = 60; answer = 1; result = solution.Next(price);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");
            price = 70; answer = 2; result = solution.Next(price);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");
            price = 60; answer = 1; result = solution.Next(price);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");
            price = 75; answer = 4; result = solution.Next(price);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");
            price = 85; answer = 6; result = solution.Next(price);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");
        }
    }
}
