using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0904
{
    public class Test0904
    {
        public void Test()
        {
            Interface0904 solution = new Solution0904();
            int[] fruits;
            int result, answer;
            int id = 0;

            // 1.
            fruits = new int[] { 0 }; answer = 1;
            result = solution.TotalFruit(fruits);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 2.
            fruits = new int[] { 1, 2, 1 }; answer = 3;
            result = solution.TotalFruit(fruits);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 3.
            fruits = new int[] { 0, 1, 2, 2 }; answer = 3;
            result = solution.TotalFruit(fruits);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 4.
            fruits = new int[] { 1, 2, 3, 2, 2 }; answer = 4;
            result = solution.TotalFruit(fruits);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 5.
            fruits = new int[] { 3, 3, 3, 1, 2, 1, 1, 2, 3, 3, 4 }; answer = 5;
            result = solution.TotalFruit(fruits);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 6.
            fruits = new int[] { 3, 3, 3, 1, 2, 1, 1, 2, 3, 3, 4, 3, 4, 3, 4, 3, 4 }; answer = 9;
            result = solution.TotalFruit(fruits);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 7.
            fruits = new int[] { 0, 1, 0, 2 }; answer = 3;
            result = solution.TotalFruit(fruits);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");
        }
    }
}
