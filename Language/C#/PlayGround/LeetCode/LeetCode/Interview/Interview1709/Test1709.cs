using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1709
{
    public class Test1709
    {
        public void Test()
        {
            Interface1709 solution = new Solution1709_2();
            int k;
            int result, answer;
            int id = 0;

            k = 1; answer = 1;
            result = solution.GetKthMagicNumber(k);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            k = 2; answer = 3;
            result = solution.GetKthMagicNumber(k);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            k = 5; answer = 9;
            result = solution.GetKthMagicNumber(k);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            k = 100; answer = 33075;
            result = solution.GetKthMagicNumber(k);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            k = 500; answer = 283618125;
            result = solution.GetKthMagicNumber(k);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            //k = 1000; answer = 81716054175;
            //result = solution.GetKthMagicNumber(k);
            //Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");
        }
    }
}
