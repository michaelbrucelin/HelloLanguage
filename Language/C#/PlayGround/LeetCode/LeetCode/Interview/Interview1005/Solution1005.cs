using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1005
{
    public class Solution1005 : Interface1005
    {
        /// <summary>
        /// 二分法 + 分治
        /// 测试知题目不允许数组中有重复项
        /// </summary>
        /// <param name="words"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public int FindString(string[] words, string s)
        {
            return FindString(words, s, 0, words.Length - 1);
        }

        private int FindString(string[] words, string s, int left, int right)
        {
            if (left > right) return -1;

            int mid = left + ((right - left) >> 1);
            if (words[mid] == s) return mid;
            if (words[mid] != "")
            {
                if (StringComparer.Ordinal.Compare(words[mid], s) < 0) return FindString(words, s, mid + 1, right);
                if (StringComparer.Ordinal.Compare(words[mid], s) > 0) return FindString(words, s, left, mid - 1);
            }
            else
            {
                int result = FindString(words, s, left, mid - 1);
                if (result > 0) return result;
                return FindString(words, s, mid + 1, right);
            }

            return -2;
        }
    }
}
