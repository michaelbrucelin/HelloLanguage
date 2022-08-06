using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0345
{
    public class Solution0345
    {
        private HashSet<char> vowels = new HashSet<char> { 'a', 'A', 'e', 'E', 'i', 'I', 'o', 'O', 'u', 'U' };

        public string ReverseVowels(string s)
        {
            char[] arr = s.ToCharArray();

            int left = 0, right = arr.Length - 1;
            while (true)
            {
                for (; left < right && !vowels.Contains(arr[left]); left++) ;
                for (; right > left && !vowels.Contains(arr[right]); right--) ;
                if (left < right)
                {
                    Swap(arr, left, right);

                    left++;
                    right--;
                }
                else
                    break;
            }

            return new string(arr);
        }

        private void Swap(char[] arr, int i, int j)
        {
            char temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
