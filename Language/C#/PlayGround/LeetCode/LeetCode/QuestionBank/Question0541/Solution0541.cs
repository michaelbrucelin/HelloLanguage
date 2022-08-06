using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0541
{
    public class Solution0541
    {
        public string ReverseStr(string s, int k)
        {
            char[] arr = s.ToCharArray();

            int p = 0;
            for (; p + k + k < arr.Length; p = p + k + k)
                ReverseSubStr(arr, p, p + k - 1);
            ReverseSubStr(arr, p, Math.Min(p + k - 1, arr.Length - 1));

            return new string(arr);
        }

        private void ReverseSubStr(char[] arr, int left, int right)
        {
            if (left >= right) return;

            for (; left < right; left++, right--)
                Swap(arr, left, right);
        }

        private void Swap(char[] arr, int i, int j)
        {
            char temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
