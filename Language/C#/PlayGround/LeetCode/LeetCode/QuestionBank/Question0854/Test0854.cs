using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0854
{
    public class Test0854
    {
        public void Test()
        {
            Interface0854 solution = new Solution0854();
            string s1, s2;
            int result, answer;
            int id = 0;

            s1 = "ab"; s2 = "ba"; answer = 1;
            result = solution.KSimilarity(s1, s2);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            s1 = "abc"; s2 = "bca"; answer = 2;
            result = solution.KSimilarity(s1, s2);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            s1 = "cbfdaccfdaacafbdadcc"; s2 = "cdadaccbccfaaffdabdc"; answer = 5;
            result = solution.KSimilarity(s1, s2);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            s1 = "aeeeecedfcebe"; s2 = "eeceaeebecfed"; answer = 5;
            result = solution.KSimilarity(s1, s2);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            s1 = "aabbccddee"; s2 = "cbeddebaac"; answer = 6;
            result = solution.KSimilarity(s1, s2);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            s1 = "cbeddebaac"; s2 = "aabbccddee"; answer = 6;
            result = solution.KSimilarity(s1, s2);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");
        }
    }
}
