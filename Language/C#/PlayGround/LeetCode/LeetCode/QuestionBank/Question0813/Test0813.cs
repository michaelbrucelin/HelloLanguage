using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0813
{
    public class Test0813
    {
        public void Test()
        {
            Interface0813 solution = new Solution0813_2();
            int[] nums; int k;
            double result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 9, 1, 2, 3, 9 }; k = 3;
            answer = 20; result = solution.LargestSumOfAverages(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = new int[] { 1, 2, 3, 4, 5, 6, 7 }; k = 4;
            answer = 20.5; result = solution.LargestSumOfAverages(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = new int[] { 5805, 4386, 9127, 845, 1288, 3683, 9712, 480, 5733, 7109, 5227, 4757, 3199, 1680, 8512, 1423, 7233, 3408, 9736, 3284, 3153, 4707, 587, 2000, 6560, 1055, 3041, 2505, 2035, 2792, 6023, 8796, 3747, 2821, 5481, 9839, 9381, 8158, 7070, 7991, 1177, 796, 993, 4509, 7751, 9280, 4548, 151, 6331, 4819, 5363, 4747, 6773, 8212, 4516, 1106, 1245, 3890, 50, 4765, 1585, 1188, 7166, 3957, 1181, 3284, 3435, 532, 1757, 161, 1039, 9065, 2279, 9122, 6273, 7743, 3685, 4461, 2918, 2042, 6029, 2600, 2983, 6017, 1377, 3293, 4331, 9561, 5959, 42, 7979, 8689, 7881, 7756, 3926, 3807, 7222, 6430, 3477, 4004 };
            k = 5; answer = 36111.09908;
            result = solution.LargestSumOfAverages(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums = new int[] { 5805, 4386, 9127, 845, 1288, 3683, 9712, 480, 5733, 7109, 5227, 4757, 3199, 1680, 8512, 1423, 7233, 3408, 9736, 3284, 3153, 4707, 587, 2000, 6560, 1055, 3041, 2505, 2035, 2792, 6023, 8796, 3747, 2821, 5481, 9839, 9381, 8158, 7070, 7991, 1177, 796, 993, 4509, 7751, 9280, 4548, 151, 6331, 4819, 5363, 4747, 6773, 8212, 4516, 1106, 1245, 3890, 50, 4765, 1585, 1188, 7166, 3957, 1181, 3284, 3435, 532, 1757, 161, 1039, 9065, 2279, 9122, 6273, 7743, 3685, 4461, 2918, 2042, 6029, 2600, 2983, 6017, 1377, 3293, 4331, 9561, 5959, 42, 7979, 8689, 7881, 7756, 3926, 3807, 7222, 6430, 3477, 4004 };
            k = 6; answer = 43536.99048;
            result = solution.LargestSumOfAverages(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
