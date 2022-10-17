using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0904
{
    public class Solution0904 : Interface0904
    {
        public int TotalFruit(int[] fruits)
        {
            if (fruits.Length <= 2) return fruits.Length;
            if (fruits.Distinct().Count() <= 2) return fruits.Length;

            // 优化数组，将fruits[]中连续种类相同的合并为一项
            int[,] kinds = new int[fruits.Length, 2];
            kinds[0, 0] = fruits[0]; kinds[0, 1] = 1; int ptr = 0;
            for (int i = 1; i < fruits.Length; i++)
                if (fruits[i] == kinds[ptr, 0]) kinds[ptr, 1]++; else { kinds[++ptr, 0] = fruits[i]; kinds[ptr, 1] = 1; }
            int kindcnt = ptr + 1;

            int result = 0, temp = kinds[0, 1];
            int[] key = new int[] { kinds[0, 0], -1 };
            ptr = 0;
            while (++ptr < kindcnt)
            {
                int kind = kinds[ptr, 0], cnt = kinds[ptr, 1];
                if (key[1] == -1) { key[1] = kind; temp += cnt; continue; }
                if (kind == key[0] || kind == key[1]) { temp += cnt; continue; }

                result = Math.Max(result, temp);
                temp = kinds[--ptr, 1];
                key[0] = kinds[ptr, 0]; key[1] = -1;
            }
            result = Math.Max(result, temp);

            return result;
        }
    }
}
