using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0438
{
    public class Solution0438_4 : Interface0438
    {
        /// <summary>
        /// 双指针，需要理解
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public IList<int> FindAnagrams(string s, string p)
        {
            List<int> result = new List<int>();
            if (s.Length < p.Length) return result;

            int[] helper = new int[26];
            for (int i = 0; i < p.Length; i++) helper[p[i] - 'a']++;

            int slow = 0, fast = 0;
            while (fast < s.Length)
            {
                if (helper[s[fast] - 'a'] > 0)
                {
                    helper[s[fast++] - 'a']--;
                    if (fast - slow == p.Length) result.Add(slow);
                }
                else
                {
                    helper[s[slow++] - 'a']++;
                }
            }
            return result;
        }

        /// <summary>
        /// 双指针，需要理解
        /// 将数组长度由26扩大到123，节省下计算数组索引的时间
        /// </summary>
        /// <param name="s"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public IList<int> FindAnagrams2(string s, string p)
        {
            List<int> result = new List<int>();
            if (s.Length < p.Length) return result;

            int[] helper = new int[123];  // 更大的数组，理论上可以节省出计算数组id的时间
            for (int i = 0; i < p.Length; i++) helper[p[i]]++;

            int slow = 0, fast = 0;
            while (fast < s.Length)
            {
                if (helper[s[fast]] > 0)
                {
                    helper[s[fast++]]--;
                    if (fast - slow == p.Length) result.Add(slow);
                }
                else
                {
                    helper[s[slow++]]++;
                }
            }
            return result;
        }
    }
}
