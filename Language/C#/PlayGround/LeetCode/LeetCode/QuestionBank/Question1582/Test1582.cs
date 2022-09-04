using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1582
{
    public class Test1582
    {
        public void Test()
        {
            Solution1582_3 solution = new Solution1582_3();
            int[][] mat;

            // [[1,0,0],[0,0,1],[1,0,0]]
            mat = new int[][] { new int[] { 1, 0, 0 }, new int[] { 0, 0, 1 }, new int[] { 1, 0, 0 } };
            Console.WriteLine($"1: {solution.NumSpecial(mat)}");

            // [[1,0,0],[0,1,0],[0,0,1]]
            mat = new int[][] { new int[] { 1, 0, 0 }, new int[] { 0, 1, 0 }, new int[] { 0, 0, 1 } };
            Console.WriteLine($"3: {solution.NumSpecial(mat)}");

            // [[0,0,0,1],[1,0,0,0],[0,1,1,0],[0,0,0,0]]
            mat = new int[][] { new int[] { 0, 0, 0, 1 }, new int[] { 1, 0, 0, 0 }, new int[] { 0, 1, 1, 0 }, new int[] { 0, 0, 0, 0 } };
            Console.WriteLine($"2: {solution.NumSpecial(mat)}");

            // [[0,0,0,0,0],[1,0,0,0,0],[0,1,0,0,0],[0,0,1,0,0],[0,0,0,1,1]]
            mat = new int[][] { new int[] { 0, 0, 0, 0, 0 }, new int[] { 1, 0, 0, 0, 0 }, new int[] { 0, 1, 0, 0, 0 }, new int[] { 0, 0, 1, 0, 0 }, new int[] { 0, 0, 0, 1, 1 } };
            Console.WriteLine($"3: {solution.NumSpecial(mat)}");

            // [[0]]
            mat = new int[][] { new int[] { 0 } };
            Console.WriteLine($"0: {solution.NumSpecial(mat)}");

            // [[1]]
            mat = new int[][] { new int[] { 1 } };
            Console.WriteLine($"1: {solution.NumSpecial(mat)}");

            // [[0,0],[0,0],[1,0]]
            mat = new int[][] { new int[] { 0, 0 }, new int[] { 0, 0 }, new int[] { 1, 0 } };
            Console.WriteLine($"1: {solution.NumSpecial(mat)}");

            // [[0,0,0,0,0,1,0,0],[0,0,0,0,1,0,0,1],[0,0,0,0,1,0,0,0],[1,0,0,0,1,0,0,0],[0,0,1,1,0,0,0,0]]
            mat = new int[][] { new int[] { 0, 0, 0, 0, 0, 1, 0, 0 }, new int[] { 0, 0, 0, 0, 1, 0, 0, 1 }, new int[] { 0, 0, 0, 0, 1, 0, 0, 0 }, new int[] { 1, 0, 0, 0, 1, 0, 0, 0 }, new int[] { 0, 0, 1, 1, 0, 0, 0, 0 } };
            Console.WriteLine($"1: {solution.NumSpecial(mat)}");
        }
    }
}
