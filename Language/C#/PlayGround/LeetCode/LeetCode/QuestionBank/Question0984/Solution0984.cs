using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0984
{
    public class Solution0984
    {
        public string StrWithout3a3b(int a, int b)
        {
            if (a == b) return Enumerable.Repeat("ab", a).ToArray().Aggregate((s1, s2) => $"{s1}{s2}");

            StringBuilder sb = new StringBuilder();

            int cnt_less, cnt_more; char less, more;
            if (a < b)
                (cnt_less, cnt_more, less, more) = (a, b, 'a', 'b');
            else
                (cnt_less, cnt_more, less, more) = (b, a, 'b', 'a');

            if (cnt_more >= (cnt_less << 1))
            {
                for (int i = 0; i < cnt_less; i++)
                    sb.Append($"{more}{more}{less}");
                for (int i = 0; i < cnt_more - cnt_less - cnt_less; i++)
                    sb.Append(more);
            }
            else  // cnt_more > cnr_less && cnt_more < cnt_less * 2
            {
                for (int i = 0; i < cnt_more - cnt_less; i++)
                    sb.Append($"{more}{more}{less}");
                for (int i = 0; i < cnt_less + cnt_less - cnt_more; i++)
                    sb.Append($"{more}{less}");
            }

            return sb.ToString();
        }
    }
}
