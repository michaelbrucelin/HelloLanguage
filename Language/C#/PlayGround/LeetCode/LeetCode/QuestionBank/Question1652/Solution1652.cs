using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1652
{
    public class Solution1652 : Interface1652
    {
        public int[] Decrypt(int[] code, int k)
        {
            int[] result = new int[code.Length];

            int window = 0;
            if (k > 0)
            {
                for (int i = 1; i <= k; i++) window += GetValueAtIndex(code, i);
                result[0] = window;
                for (int i = 1; i < result.Length; i++)
                {
                    window = window - GetValueAtIndex(code, i) + GetValueAtIndex(code, i + k);
                    result[i] = window;
                }
            }
            else if (k < 0)
            {
                for (int i = -1; i >= k; i--) window += GetValueAtIndex(code, i);
                result[0] = window;
                for (int i = 1; i < result.Length; i++)
                {
                    window = window - GetValueAtIndex(code, i + k - 1) + GetValueAtIndex(code, i - 1);
                    result[i] = window;
                }
            }

            return result;
        }

        private int GetValueAtIndex(int[] arr, int i)
        {
            int len = arr.Length;
            while (i < 0) i += len;
            while (i >= len) i -= len;

            return arr[i];
        }
    }
}
