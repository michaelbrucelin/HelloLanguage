using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0805
{
    public class Test0805
    {
        public void Test()
        {
            Interface0805 solution = new Solution0805_2_2();
            int[] nums;
            bool result, answer;
            Stopwatch stopwatch = new Stopwatch();
            int id = 0;

            // 1.
            nums = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            answer = true; stopwatch.Restart(); result = solution.SplitArraySameAverage(nums); stopwatch.Stop();
            Console.WriteLine($"{++id,2}: In {stopwatch.Elapsed}, {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = new int[] { 3, 1 };
            answer = false; stopwatch.Restart(); result = solution.SplitArraySameAverage(nums); stopwatch.Stop();
            Console.WriteLine($"{++id,2}: In {stopwatch.Elapsed}, {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3.
            nums = new int[] { 5, 3, 11, 19, 2 };
            answer = true; stopwatch.Restart(); result = solution.SplitArraySameAverage(nums); stopwatch.Stop();
            Console.WriteLine($"{++id,2}: In {stopwatch.Elapsed}, {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4.
            nums = new int[] { 17, 3, 7, 12, 1 };
            answer = false; stopwatch.Restart(); result = solution.SplitArraySameAverage(nums); stopwatch.Stop();
            Console.WriteLine($"{++id,2}: In {stopwatch.Elapsed}, {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            nums = new int[] { 1, 99, 20, 30, 100 };
            answer = true; stopwatch.Restart(); result = solution.SplitArraySameAverage(nums); stopwatch.Stop();
            Console.WriteLine($"{++id,2}: In {stopwatch.Elapsed}, {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            nums = new int[] { 3, 3, 4, 1, 1, 8 };
            answer = true; stopwatch.Restart(); result = solution.SplitArraySameAverage(nums); stopwatch.Stop();
            Console.WriteLine($"{++id,2}: In {stopwatch.Elapsed}, {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 7. 
            nums = new int[] { 732, 3905, 7767, 4089, 6458, 4708, 838, 2261, 9498, 9922, 5340, 2546, 3080, 3792, 6734, 5866, 6242, 6330, 94, 3760, 6061, 5474, 9188, 7127, 7258, 1061, 1270, 3630, 830, 6517 };
            answer = true; stopwatch.Restart(); result = solution.SplitArraySameAverage(nums); stopwatch.Stop();
            Console.WriteLine($"{++id,2}: In {stopwatch.Elapsed}, {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 8. 
            nums = new int[] { 4317, 552, 1918, 3436, 215, 9723, 9866, 9579, 5799, 9191 };
            answer = false; stopwatch.Restart(); result = solution.SplitArraySameAverage(nums); stopwatch.Stop();
            Console.WriteLine($"{++id,2}: In {stopwatch.Elapsed}, {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 9. 
            nums = new int[] { 1369, 9957, 4234, 7728, 8402, 9775, 3214, 7899, 4449, 2517, 2244, 9317, 5325, 9462, 6026, 3271, 774, 7258, 328, 6105, 4569, 995, 5819, 691, 2603, 3599, 3612, 8207, 4109, 9795 };
            answer = false; stopwatch.Restart(); result = solution.SplitArraySameAverage(nums); stopwatch.Stop();
            Console.WriteLine($"{++id,2}: In {stopwatch.Elapsed}, {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 10. 
            nums = new int[] { 5265, 8963, 3934, 3651, 9458, 7169, 4062, 9159, 8464, 9195, 945, 9013, 4241, 4964, 6300, 9004, 2360, 8681, 6518, 370, 5447, 7180, 4288, 1945, 7452, 2114, 341, 1983, 7114, 702, 7716, 7129 };
            answer = false; stopwatch.Restart(); result = solution.SplitArraySameAverage(nums); stopwatch.Stop();
            Console.WriteLine($"{++id,2}: In {stopwatch.Elapsed}, {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
