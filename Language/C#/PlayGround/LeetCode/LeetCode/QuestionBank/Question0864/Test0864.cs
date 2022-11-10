using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0864
{
    public class Test0864
    {
        public void Test()
        {
            Interface0864 solution = new Solution0864();
            string[] grid;
            int result, answer;
            int id = 0;

            // 1.
            grid = new string[] { "@.a.#", "###.#", "b.A.B" };
            answer = 8; result = solution.ShortestPathAllKeys(grid);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 2.
            grid = new string[] { "@..aA", "..B#.", "....b" };
            answer = 6; result = solution.ShortestPathAllKeys(grid);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 3.
            grid = new string[] { "@Aa" };
            answer = -1; result = solution.ShortestPathAllKeys(grid);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 4.
            grid = new string[] { "@aA" };
            answer = 1; result = solution.ShortestPathAllKeys(grid);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 5.
            grid = new string[] { "@..Aa", "...##", "....." };
            answer = -1; result = solution.ShortestPathAllKeys(grid);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 6.
            grid = new string[] { "@...a", ".###A", "b.BCc" };
            answer = 10; result = solution.ShortestPathAllKeys(grid);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");
        }
    }
}
