using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1624
{
    public class Solution1624 : Interface1624
    {
        /// <summary>
        /// 用一个长度为26的数组记录每一个字母第一次出现的位置即可
        /// 用字典也可以，这里就使用数组实现了
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MaxLengthBetweenEqualCharacters(string s)
        {
            int result = -1;
            int[] helper = new int[26];
            Array.Fill(helper, -1);

            for (int i = 0; i < s.Length; i++)
            {
                int id = s[i] - 'a';
                if (helper[id] == -1)
                    helper[id] = i;
                else
                    result = Math.Max(i - helper[id] - 1, result);
            }

            return result;
        }
    }
}
