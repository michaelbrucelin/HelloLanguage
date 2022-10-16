using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0886
{
    public class Test0886
    {
        public void Test()
        {
            Interface0886 solution = new Solution0886();
            int n; int[][] dislikes;
            bool result, answer;
            int id = 0;

            // 1.
            n = 1; dislikes = new int[][] { };
            answer = true;
            result = solution.PossibleBipartition(n, dislikes);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 2. 
            n = 4; dislikes = new int[][] { new int[] { 1, 2 }, new int[] { 1, 3 }, new int[] { 2, 4 } };
            answer = true;
            result = solution.PossibleBipartition(n, dislikes);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 3. 
            n = 3; dislikes = new int[][] { new int[] { 1, 2 }, new int[] { 1, 3 }, new int[] { 2, 3 } };
            answer = false;
            result = solution.PossibleBipartition(n, dislikes);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 4. 
            n = 5; dislikes = new int[][] { new int[] { 1, 2 }, new int[] { 2, 3 }, new int[] { 3, 4 }, new int[] { 4, 5 }, new int[] { 1, 5 } };
            answer = false;
            result = solution.PossibleBipartition(n, dislikes);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 5. 
            n = 50; dislikes = new int[][] { new int[] { 9, 26 }, new int[] { 1, 34 }, new int[] { 14, 17 }, new int[] { 29, 31 }, new int[] { 10, 17 }, new int[] { 25, 31 }, new int[] { 22, 44 }, new int[] { 36, 44 }, new int[] { 26, 28 }, new int[] { 17, 20 }, new int[] { 16, 28 }, new int[] { 18, 19 }, new int[] { 11, 47 }, new int[] { 34, 46 }, new int[] { 17, 46 }, new int[] { 15, 47 }, new int[] { 19, 29 }, new int[] { 44, 45 }, new int[] { 14, 18 }, new int[] { 1, 6 }, new int[] { 28, 35 }, new int[] { 16, 22 }, new int[] { 10, 41 }, new int[] { 13, 20 }, new int[] { 2, 27 }, new int[] { 18, 20 }, new int[] { 8, 15 }, new int[] { 37, 41 }, new int[] { 2, 6 }, new int[] { 24, 39 }, new int[] { 13, 35 }, new int[] { 10, 13 }, new int[] { 18, 46 }, new int[] { 8, 21 }, new int[] { 1, 17 }, new int[] { 2, 32 }, new int[] { 14, 15 }, new int[] { 5, 21 }, new int[] { 27, 40 }, new int[] { 8, 38 }, new int[] { 5, 34 }, new int[] { 29, 37 }, new int[] { 20, 36 }, new int[] { 9, 39 }, new int[] { 31, 38 }, new int[] { 8, 12 }, new int[] { 7, 44 }, new int[] { 14, 36 }, new int[] { 4, 15 }, new int[] { 17, 39 }, new int[] { 2, 11 }, new int[] { 25, 44 }, new int[] { 15, 33 }, new int[] { 20, 42 }, new int[] { 25, 33 }, new int[] { 19, 23 }, new int[] { 48, 50 }, new int[] { 28, 37 }, new int[] { 1, 21 }, new int[] { 23, 37 }, new int[] { 40, 45 }, new int[] { 10, 42 }, new int[] { 2, 34 }, new int[] { 13, 26 }, new int[] { 11, 35 }, new int[] { 1, 15 }, new int[] { 42, 47 }, new int[] { 24, 46 }, new int[] { 4, 12 }, new int[] { 8, 28 }, new int[] { 15, 26 }, new int[] { 14, 22 }, new int[] { 21, 46 }, new int[] { 4, 42 }, new int[] { 8, 45 }, new int[] { 12, 50 }, new int[] { 16, 29 }, new int[] { 2, 23 }, new int[] { 16, 32 }, new int[] { 11, 46 }, new int[] { 5, 17 }, new int[] { 15, 46 }, new int[] { 20, 49 }, new int[] { 43, 45 }, new int[] { 17, 50 }, new int[] { 7, 20 }, new int[] { 2, 25 }, new int[] { 21, 33 }, new int[] { 8, 42 }, new int[] { 16, 23 }, new int[] { 29, 33 }, new int[] { 11, 26 }, new int[] { 29, 39 }, new int[] { 32, 39 }, new int[] { 13, 19 }, new int[] { 27, 31 }, new int[] { 8, 48 }, new int[] { 12, 35 }, new int[] { 3, 5 }, new int[] { 16, 48 }, new int[] { 4, 6 }, new int[] { 19, 38 }, new int[] { 8, 22 }, new int[] { 14, 25 }, new int[] { 5, 7 }, new int[] { 10, 25 }, new int[] { 26, 30 }, new int[] { 23, 33 }, new int[] { 22, 43 }, new int[] { 1, 30 }, new int[] { 7, 31 }, new int[] { 16, 42 }, new int[] { 5, 9 }, new int[] { 1, 48 }, new int[] { 4, 27 }, new int[] { 44, 48 }, new int[] { 15, 19 }, new int[] { 21, 39 }, new int[] { 49, 50 }, new int[] { 30, 33 }, new int[] { 12, 20 }, new int[] { 7, 19 }, new int[] { 31, 36 }, new int[] { 36, 47 }, new int[] { 34, 43 }, new int[] { 42, 44 }, new int[] { 24, 47 }, new int[] { 31, 49 }, new int[] { 38, 43 }, new int[] { 8, 29 }, new int[] { 15, 39 }, new int[] { 4, 18 }, new int[] { 19, 32 }, new int[] { 14, 23 }, new int[] { 20, 27 }, new int[] { 30, 47 }, new int[] { 4, 38 }, new int[] { 28, 43 }, new int[] { 1, 23 }, new int[] { 23, 43 }, new int[] { 6, 33 }, new int[] { 4, 49 }, new int[] { 11, 33 }, new int[] { 2, 3 }, new int[] { 18, 43 }, new int[] { 14, 29 }, new int[] { 12, 46 }, new int[] { 3, 47 }, new int[] { 6, 8 }, new int[] { 15, 43 }, new int[] { 27, 47 }, new int[] { 22, 47 }, new int[] { 12, 19 }, new int[] { 28, 40 }, new int[] { 35, 38 }, new int[] { 1, 7 }, new int[] { 8, 49 }, new int[] { 7, 43 }, new int[] { 14, 41 }, new int[] { 30, 50 }, new int[] { 17, 47 }, new int[] { 20, 28 }, new int[] { 13, 33 }, new int[] { 19, 41 }, new int[] { 18, 44 }, new int[] { 8, 23 }, new int[] { 13, 46 }, new int[] { 20, 34 }, new int[] { 29, 35 }, new int[] { 15, 31 }, new int[] { 20, 29 }, new int[] { 2, 45 }, new int[] { 7, 16 }, new int[] { 23, 35 }, new int[] { 30, 37 }, new int[] { 12, 16 }, new int[] { 5, 42 }, new int[] { 16, 24 }, new int[] { 3, 14 }, new int[] { 17, 37 }, new int[] { 6, 50 }, new int[] { 25, 50 }, new int[] { 15, 35 }, new int[] { 5, 12 }, new int[] { 12, 44 }, new int[] { 10, 12 }, new int[] { 5, 25 }, new int[] { 19, 25 }, new int[] { 24, 31 }, new int[] { 39, 41 }, new int[] { 31, 42 }, new int[] { 1, 13 }, new int[] { 9, 10 }, new int[] { 8, 30 }, new int[] { 24, 35 }, new int[] { 3, 31 }, new int[] { 3, 19 }, new int[] { 20, 32 }, new int[] { 27, 35 }, new int[] { 6, 19 }, new int[] { 1, 22 }, new int[] { 32, 47 }, new int[] { 5, 38 }, new int[] { 10, 45 }, new int[] { 3, 8 }, new int[] { 42, 46 }, new int[] { 35, 48 }, new int[] { 26, 48 } };
            answer = true;
            result = solution.PossibleBipartition(n, dislikes);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");
        }
    }
}
