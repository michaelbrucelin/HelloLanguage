using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1784
{
    public class Solution1784 : Interface1784
    {
        /// <summary>
        /// 又是一道读不懂题的题目。
        /// 解释一下题目：一个或多个1是一个连续字段，比如1、1111。如果字符串s含有的连续字段数目≤1，则返回true，否则为false。
        /// 这个题就是判断字符串是否由左边连续的1和右边连续的0两部分组成，其他的构成都不合法。所以我们只需要找出两个端点然后判断位置就可以了。
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool CheckOnesSegment(string s)
        {
            int left = 0, right = s.Length - 1;
            while (left < s.Length && s[left] == '0') left++;  // 找出s中第一个1，由题意知必是0
            while (right >= 0 && s[right] == '0') right--;     // 找出s中最后一个1

            for (; left <= right; left++)
                if (s[left] == '0') return false;

            return true;
        }
    }
}
