using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0809
{
    public class Test0809
    {
        public void Test()
        {
            Interface0809 solution = new Solution0809_2();
            string s; string[] words;
            int result, answer;
            int id = 0;

            // 1. 
            s = "heeelllllooo"; words = new string[] { "hello", "hellllo", "hel", "hi" };
            result = solution.ExpressiveWords(s, words); answer = 2;
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "heeellooo"; words = new string[] { "hello", "hi", "helo" };
            result = solution.ExpressiveWords(s, words); answer = 1;
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "zzzzzyyyyy"; words = new string[] { "zzyy", "zy", "zyy" };
            result = solution.ExpressiveWords(s, words); answer = 3;
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
