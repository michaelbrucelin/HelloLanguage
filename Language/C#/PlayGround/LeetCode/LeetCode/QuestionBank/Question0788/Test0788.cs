using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0788
{
    public class Test0788
    {
        public void Test()
        {
            Interface0788 solution = new Solution0778();
            int n;
            int result, answer;
            int id = 0;

            n = 10; answer = 4;
            result = solution.RotatedDigits(n);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");
        }
    }
}
