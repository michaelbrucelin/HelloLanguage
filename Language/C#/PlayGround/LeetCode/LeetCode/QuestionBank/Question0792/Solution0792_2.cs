using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0792
{
    public class Solution0792_2 : Interface0792
    {
        /// <summary>
        /// 与Solution0792一样
        /// 只是将Dictionary换成数组试一下，理论上会省下计算hash值的时间
        /// </summary>
        /// <param name="s"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public int NumMatchingSubseq(string s, string[] words)
        {
            List<int>[] helper = new List<int>[26];
            for (int i = 0; i < 26; i++) helper[i] = new List<int>();
            for (int i = 0; i < s.Length; i++) helper[s[i] - 'a'].Add(i);

            int result = 0, len = s.Length;
            for (int i = 0; i < words.Length; i++)
                if (words[i].Length <= len && IsSubSequence(helper, words[i])) result++;

            return result;
        }

        private bool IsSubSequence(List<int>[] dic, string word)
        {
            int border = -1;
            for (int i = 0; i < word.Length; i++)
            {
                int id = word[i] - 'a';
                if (dic[id].Count == 0) return false;
                int index = BinarySearch(dic[id], border);
                if (index == dic[id].Count) return false;
                border = dic[id][index];
            }

            return true;
        }

        /// <summary>
        /// 返回list中大于border的第一个值的索引
        /// </summary>
        /// <param name="list"></param>
        /// <param name="border"></param>
        /// <returns></returns>
        private int BinarySearch(List<int> list, int border)
        {
            int id = list.Count;
            int left = 0, right = list.Count - 1;
            while (left <= right)
            {
                int mid = left + ((right - left) >> 1);
                if (list[mid] <= border) left = mid + 1;
                else
                {
                    id = mid;
                    right = mid - 1;
                }
            }

            return id;
        }
    }
}
