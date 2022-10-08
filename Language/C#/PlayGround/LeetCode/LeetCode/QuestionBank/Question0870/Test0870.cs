using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0870
{
    public class Test0870
    {
        public void Test()
        {
            Interface0870 solution = new Solution0870_2();
            int[] nums1, nums2;
            int[] result_arr, answer_arr;
            int result, answer;
            int id = 0;

            nums1 = new int[] { 2, 7, 11, 15 }; nums2 = new int[] { 1, 10, 4, 11 }; answer_arr = new int[] { 2, 11, 7, 15 };
            result_arr = solution.AdvantageCount(nums1, nums2);
            result = AdvantageCount(result_arr, nums2);
            answer = AdvantageCount(answer_arr, nums2);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            nums1 = new int[] { 12, 24, 8, 32 }; nums2 = new int[] { 13, 25, 32, 11 }; answer_arr = new int[] { 24, 32, 8, 12 };
            result_arr = solution.AdvantageCount(nums1, nums2);
            result = AdvantageCount(result_arr, nums2);
            answer = AdvantageCount(answer_arr, nums2);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            //nums1 = new int[] { 983, 149, 115, 151, 171, 177, 564, 398, 238, 143, 352, 924, 582, 396, 989, 584, 814, 711, 672, 630, 592, 355, 658, 448, 679, 438, 422, 457, 682, 365, 201, 360 };
            //nums2 = new int[] { 605, 345, 323, 592, 755, 608, 523, 206, 693, 81, 254, 558, 374, 612, 141, 470, 64, 133, 243, 325, 641, 745, 957, 723, 671, 555, 349, 522, 715, 917, 425, 268 };
            //answer_arr = new int[] { 672, 398, 365, 658, 457, 679, 584, 238, 924, 143, 355, 630, 438, 682, 151, 564, 115, 149, 352, 396, 711, 201, 177, 989, 814, 592, 422, 582, 983, 171, 448, 360 };
            //result_arr = solution.AdvantageCount(nums1, nums2);
            //result = AdvantageCount(result_arr, nums2);
            //answer = AdvantageCount(answer_arr, nums2);
            //Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            //nums1 = new int[] { 45, 833, 994, 341, 842, 621, 514, 56, 704, 235, 193, 923, 893, 79, 38, 874, 796, 514, 228, 119, 287, 211, 644, 578, 679, 577, 439, 717, 532, 892, 110, 310, 679, 643, 245, 464, 226, 778, 389, 430, 80, 48, 6, 742, 824, 110, 691, 439, 24, 579, 519, 428, 946, 932, 693, 19, 330, 710, 86, 117, 341, 193, 462, 78, 432, 875, 799, 636, 138, 663, 632, 619, 411, 608, 796, 37, 792, 925, 481, 858, 481, 778, 298, 599, 47, 892, 239, 676, 866, 379, 698, 857, 289, 958, 511, 736, 380, 765, 192, 225 };
            //nums2 = new int[] { 510, 923, 952, 132, 262, 444, 774, 547, 77, 564, 493, 216, 629, 734, 132, 415, 788, 269, 843, 299, 143, 369, 479, 674, 314, 819, 130, 829, 749, 156, 400, 820, 514, 637, 867, 170, 712, 909, 203, 582, 210, 654, 758, 287, 407, 315, 749, 19, 854, 473, 643, 846, 465, 779, 131, 18, 719, 99, 146, 743, 507, 400, 818, 137, 179, 789, 174, 132, 606, 777, 537, 850, 509, 639, 597, 231, 250, 955, 947, 124, 199, 151, 16, 874, 536, 180, 389, 786, 265, 767, 508, 335, 941, 56, 860, 21, 456, 10, 76, 419 };
            //answer_arr = new int[] { 643, 119, 117, 225, 411, 577, 842, 679, 80, 679, 619, 379, 704, 792, 211, 519, 874, 430, 925, 439, 228, 481, 608, 765, 439, 892, 192, 923, 799, 245, 514, 893, 644, 710, 110, 287, 778, 86, 341, 691, 341, 742, 824, 432, 514, 462, 796, 38, 958, 599, 736, 932, 579, 858, 193, 37, 778, 110, 235, 796, 621, 511, 892, 226, 298, 875, 289, 193, 698, 857, 676, 946, 636, 717, 693, 380, 389, 56, 48, 138, 330, 239, 24, 47, 663, 310, 481, 866, 428, 833, 632, 464, 6, 78, 994, 45, 578, 19, 79, 532 };
            //result_arr = solution.AdvantageCount(nums1, nums2);
            //result = AdvantageCount(result_arr, nums2);
            //answer = AdvantageCount(answer_arr, nums2);
            //Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");
        }

        private int AdvantageCount(int[] nums1, int[] nums2)
        {
            int result = 0;
            int len = Math.Min(nums1.Length, nums2.Length);
            for (int i = 0; i < len; i++)
                if (nums1[i] > nums2[i]) result++;

            return result;
        }
    }
}
