using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1668
{
    public class Solution1668_2 : Interface1668
    {
        /// <summary>
        /// 二分法
        /// </summary>
        /// <param name="sequence"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public int MaxRepeating(string sequence, string word)
        {
            if (word.Length > sequence.Length) return 0;
            if (!sequence.Contains(word)) return 0;

            int result = 0, left = 1, right = sequence.Length / word.Length;
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (sequence.Contains(new string('X', mid).Replace("X", word)))
                {
                    result = mid;
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return result;
        }
    }
}
