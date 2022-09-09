using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1262
{
    public class Test1262
    {
        public void Test()
        {
            Interface1262 solution = new Solution1262_4();
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 3, 6, 5, 1, 8 }; answer = 18;
            result = solution.MaxSumDivThree(nums);
            Console.WriteLine($"{++id,2}: {result == answer}, {result}");

            // 2. 
            nums = new int[] { 4 }; answer = 0;
            result = solution.MaxSumDivThree(nums);
            Console.WriteLine($"{++id,2}: {result == answer}, {result}");

            // 3. 
            nums = new int[] { 1, 2, 3, 4, 4 }; answer = 12;
            result = solution.MaxSumDivThree(nums);
            Console.WriteLine($"{++id,2}: {result == answer}, {result}");

            // 4. 
            nums = new int[] { 3 }; answer = 3;
            result = solution.MaxSumDivThree(nums);
            Console.WriteLine($"{++id,2}: {result == answer}, {result}");

            // 5.
            nums = new int[] { 972, 944, 817, 475, 436, 623, 900, 268, 25, 263, 627, 799, 38, 943, 968, 17, 813, 139, 772, 333, 498, 593, 567, 556, 550, 40, 4, 862, 915, 935, 366, 253, 994, 893, 47, 211, 332, 854, 73, 694, 37, 63, 789, 785, 419, 129, 170, 404, 854, 424, 712, 784, 539, 697, 478, 978, 509, 76, 528, 65, 194, 352, 986, 713, 730, 223, 858, 366, 71, 18, 60, 8, 835, 70, 349, 905, 446, 593, 909, 592, 95, 280, 900, 887, 303, 245, 612, 708, 7, 58, 564, 577, 718, 410, 512, 637, 535, 432, 332, 770 };
            answer = 49701;
            result = solution.MaxSumDivThree(nums);
            Console.WriteLine($"{++id,2}: {result == answer}, {result}");

            // 6. 
            nums = new int[] { 1, 1, 3 }; answer = 3;
            result = solution.MaxSumDivThree(nums);
            Console.WriteLine($"{++id,2}: {result == answer}, {result}");
        }
    }
}
