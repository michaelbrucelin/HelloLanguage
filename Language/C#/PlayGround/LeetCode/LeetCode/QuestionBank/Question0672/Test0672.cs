using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0672
{
    public class Test0672
    {
        public void Test()
        {
            Interface0672 solution = new Solution0672_2();
            int n, presses;
            int answer, result;
            int id = 0;

            // 1. 
            n = 1; presses = 1; answer = 2;
            result = solution.FlipLights(n, presses);
            Console.WriteLine($"{++id,2}: {result == answer}, answer={answer}, result={result}");

            // 2. 
            n = 2; presses = 1; answer = 3;
            result = solution.FlipLights(n, presses);
            Console.WriteLine($"{++id,2}: {result == answer}, answer={answer}, result={result}");

            // 3. 
            n = 3; presses = 1; answer = 4;
            result = solution.FlipLights(n, presses);
            Console.WriteLine($"{++id,2}: {result == answer}, answer={answer}, result={result}");

            // 4. 
            n = 1; presses = 0; answer = 1;
            result = solution.FlipLights(n, presses);
            Console.WriteLine($"{++id,2}: {result == answer}, answer={answer}, result={result}");

            // 5. 
            n = 2; presses = 2; answer = 4;
            result = solution.FlipLights(n, presses);
            Console.WriteLine($"{++id,2}: {result == answer}, answer={answer}, result={result}");

            // 6. 
            n = 1000; presses = 10; answer = 8;
            result = solution.FlipLights(n, presses);
            Console.WriteLine($"{++id,2}: {result == answer}, answer={answer}, result={result}");

            // 7. 
            n = 1000; presses = 100; answer = 8;
            result = solution.FlipLights(n, presses);
            Console.WriteLine($"{++id,2}: {result == answer}, answer={answer}, result={result}");
        }
    }
}
