using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1710
{
    public class Test1710
    {
        public void Test()
        {
            Interface1710 solution = new Solution1710_3();
            int[][] boxTypes; int truckSize;
            int result, answer;
            int id = 0;

            // 1. 
            boxTypes = new int[][] { new int[] { 1, 3 }, new int[] { 2, 2 }, new int[] { 3, 1 } }; truckSize = 4;
            answer = 8; result = solution.MaximumUnits(boxTypes, truckSize);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            boxTypes = new int[][] { new int[] { 5, 10 }, new int[] { 2, 5 }, new int[] { 4, 7 }, new int[] { 3, 9 } }; truckSize = 10;
            answer = 91; result = solution.MaximumUnits(boxTypes, truckSize);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            boxTypes = new int[][] { new int[] { 1, 3 }, new int[] { 5, 5 }, new int[] { 2, 5 }, new int[] { 4, 2 }, new int[] { 4, 1 }, new int[] { 3, 1 }, new int[] { 2, 2 }, new int[] { 1, 3 }, new int[] { 2, 5 }, new int[] { 3, 2 } };
            truckSize = 35;
            answer = 76; result = solution.MaximumUnits(boxTypes, truckSize);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
