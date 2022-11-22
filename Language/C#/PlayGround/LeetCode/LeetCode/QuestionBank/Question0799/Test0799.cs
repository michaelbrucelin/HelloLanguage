using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0799
{
    public class Test0799
    {
        public void Test()
        {
            Interface0799 solution = new Solution0799_2();
            int poured, query_row, query_glass;
            double result, answer;
            int id = 0;

            // 1.
            poured = 1; query_glass = 1; query_row = 1; answer = 0;
            result = solution.ChampagneTower(poured, query_row, query_glass);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2.
            poured = 2; query_glass = 1; query_row = 1; answer = 0.5;
            result = solution.ChampagneTower(poured, query_row, query_glass);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3.
            poured = 100000009; query_row = 33; query_glass = 17; answer = 1;
            result = solution.ChampagneTower(poured, query_row, query_glass);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4.
            poured = 100000009; query_row = 81; query_glass = 18; answer = 1;
            result = solution.ChampagneTower(poured, query_row, query_glass);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5.
            poured = 100000009; query_row = 99; query_glass = 49; answer = 1;
            result = solution.ChampagneTower(poured, query_row, query_glass);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6.
            poured = 10000; query_row = 88; query_glass = 31; answer = 0;
            result = solution.ChampagneTower(poured, query_row, query_glass);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 7.
            poured = 8; query_row = 3; query_glass = 1; answer = 0.875;
            result = solution.ChampagneTower(poured, query_row, query_glass);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 8.
            poured = 10; query_row = 4; query_glass = 1; answer = 0.3125;
            result = solution.ChampagneTower(poured, query_row, query_glass);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
