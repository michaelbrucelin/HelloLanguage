using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0004
{
    public class Test0004
    {
        public void Test()
        {
            Interface0004 solution = new Solution0004();
            int[] nums1, nums2;
            double answer, result;
            int id = 0;

            // 1. 
            nums1 = new int[] { 1, 3 }; nums2 = new int[] { 2 };
            answer = 2d; result = solution.FindMedianSortedArrays(nums1, nums2);
            Console.WriteLine($"{++id,2}: {result == answer}, answer={answer}, result={result}");

            // 2. 
            nums1 = new int[] { 1, 2 }; nums2 = new int[] { 3, 4 };
            answer = 2.5d; result = solution.FindMedianSortedArrays(nums1, nums2);
            Console.WriteLine($"{++id,2}: {result == answer}, answer={answer}, result={result}");

            // 3. 
            nums1 = new int[] { 1, 2, 3 }; nums2 = new int[0];
            answer = 2d; result = solution.FindMedianSortedArrays(nums1, nums2);
            Console.WriteLine($"{++id,2}: {result == answer}, answer={answer}, result={result}");

            // 4.
            nums1 = new int[] { 1, 2 }; nums2 = new int[0];
            answer = 1.5d; result = solution.FindMedianSortedArrays(nums1, nums2);
            Console.WriteLine($"{++id,2}: {result == answer}, answer={answer}, result={result}");

            // 5. 
            nums1 = new int[0]; nums2 = new int[] { 1, 2, 3 };
            answer = 2d; result = solution.FindMedianSortedArrays(nums1, nums2);
            Console.WriteLine($"{++id,2}: {result == answer}, answer={answer}, result={result}");

            // 6. 
            nums1 = new int[0]; nums2 = new int[] { 1, 2 };
            answer = 1.5d; result = solution.FindMedianSortedArrays(nums1, nums2);
            Console.WriteLine($"{++id,2}: {result == answer}, answer={answer}, result={result}");

            // 7. 
            nums1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }; nums2 = new int[] { 1, 2, 3 };
            answer = 3.5d; result = solution.FindMedianSortedArrays(nums1, nums2);
            Console.WriteLine($"{++id,2}: {result == answer}, answer={answer}, result={result}");

            // 8. 
            nums1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }; nums2 = new int[] { -3, -2, -1 };
            answer = 3.5d; result = solution.FindMedianSortedArrays(nums1, nums2);
            Console.WriteLine($"{++id,2}: {result == answer}, answer={answer}, result={result}");

            // 9. 
            nums1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }; nums2 = new int[] { -3, -2, -1, 0 };
            answer = 3d; result = solution.FindMedianSortedArrays(nums1, nums2);
            Console.WriteLine($"{++id,2}: {result == answer}, answer={answer}, result={result}");

            // 10. 
            nums1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }; nums2 = new int[] { 10, 20, 30 };
            answer = 6.5d; result = solution.FindMedianSortedArrays(nums1, nums2);
            Console.WriteLine($"{++id,2}: {result == answer}, answer={answer}, result={result}");

            // 11. 
            nums1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }; nums2 = new int[] { 10, 20, 30, 100 };
            answer = 7d; result = solution.FindMedianSortedArrays(nums1, nums2);
            Console.WriteLine($"{++id,2}: {result == answer}, answer={answer}, result={result}");
        }
    }
}
