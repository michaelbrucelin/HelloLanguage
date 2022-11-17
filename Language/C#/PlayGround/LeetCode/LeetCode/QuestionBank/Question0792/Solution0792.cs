using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0792
{
    public class Solution0792 : Interface0792
    {
        /// <summary>
        /// 字典 + 二分查找
        /// 首先从前向后迭代s，记录下s中每个字符的位置
        ///     例如"caeabcde"生成Dictionary<char,List<int>>{{'a',[1,3]}, {'b',[4]}, {'c',[0,5]}, {'d',6}, {'e',[2,7]}}
        /// 检查word是否是s的子序列时，借助字典+二分查找即可
        ///     例如"ace"，字典中存在'a'，取第一个'a'的索引1
        ///                字典中存在'c'，取1后面第一个'c'的索引5
        ///                字典中存在'e'，取5后面第一个'e'的索引7
        /// </summary>
        /// <param name="s"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public int NumMatchingSubseq(string s, string[] words)
        {
            Dictionary<char, List<int>> helper = new Dictionary<char, List<int>>();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (helper.ContainsKey(c))
                    helper[c].Add(i);
                else
                    helper.Add(c, new List<int>() { i });
            }

            int result = 0, len = s.Length;
            for (int i = 0; i < words.Length; i++)
                if (words[i].Length <= len && IsSubSequence(helper, words[i])) result++;

            return result;
        }

        private bool IsSubSequence(Dictionary<char, List<int>> dic, string word)
        {
            int border = -1;
            for (int i = 0; i < word.Length; i++)
            {
                char c = word[i];
                if (!dic.ContainsKey(c)) return false;
                int index = BinarySearch(dic[c], border);
                if (index == dic[c].Count) return false;
                border = dic[c][index];
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
