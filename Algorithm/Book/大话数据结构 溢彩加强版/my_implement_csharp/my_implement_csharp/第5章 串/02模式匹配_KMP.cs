using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace my_implement_csharp.第5章_串
{
    public class _02模式匹配_KMP
    {
        /// <summary>
        /// 由于C#中字符串与书中C定义的字符串结构不同，这里实现的是C#中字符串的next数组
        /// 索引：  012345678    012345678
        /// 字符串：ababaaaba    ababaaxba
        /// next：  -00123112    -001231--
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int[] GetNext(string s)
        {
            if (s.Length == 1) return new int[] { -1 };
            if (s.Length == 2) return new int[] { -1, 0 };

            int[] next = new int[s.Length]; next[0] = -1; next[1] = 0;
            int i = 2, j = 0;
            while (i < s.Length)
            {
                while (j >= 0 && s[i - 1] != s[j]) j = next[j];
                next[i] = j == -1 ? -1 : next[j] + 1;
                i++; j++;
            }

            return next;
        }
    }
}
