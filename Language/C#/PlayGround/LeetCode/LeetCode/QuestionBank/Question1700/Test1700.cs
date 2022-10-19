using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1700
{
    public class Test1700
    {
        public void Test()
        {
            Interface1700 solution = new Solution1700_2();
            int[] students, sandwiches;
            int result, answer;
            int id = 0;

            // 1.
            students = new int[] { 1, 1, 0, 0 }; sandwiches = new int[] { 0, 1, 0, 1 }; answer = 0;
            result = solution.CountStudents(students, sandwiches);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 2.
            students = new int[] { 1, 1, 1, 0, 0, 1 }; sandwiches = new int[] { 1, 0, 0, 0, 1, 1 }; answer = 3;
            result = solution.CountStudents(students, sandwiches);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");
        }
    }
}
