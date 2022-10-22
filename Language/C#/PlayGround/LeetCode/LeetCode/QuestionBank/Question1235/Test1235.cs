using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1235
{
    public class Test1235
    {
        public void Test()
        {
            Interface1235 solution = new Solution1235();
            int[] startTime, endTime, profit;
            int result, answer;
            int id = 0;

            // 1.
            startTime = new int[] { 1, 2, 3, 3 }; endTime = new int[] { 3, 4, 5, 6 }; profit = new int[] { 50, 10, 40, 70 };
            answer = 120;
            result = solution.JobScheduling(startTime, endTime, profit);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 2.
            startTime = new int[] { 1, 2, 3, 4, 6 }; endTime = new int[] { 3, 5, 10, 6, 9 }; profit = new int[] { 20, 20, 100, 70, 60 };
            answer = 150;
            result = solution.JobScheduling(startTime, endTime, profit);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 3.
            startTime = new int[] { 1, 1, 1 }; endTime = new int[] { 2, 3, 4 }; profit = new int[] { 5, 6, 4 };
            answer = 6;
            result = solution.JobScheduling(startTime, endTime, profit);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 4.
            startTime = new int[] { 1 }; endTime = new int[] { 2 }; profit = new int[] { 100 };
            answer = 100;
            result = solution.JobScheduling(startTime, endTime, profit);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");
        }
    }
}
