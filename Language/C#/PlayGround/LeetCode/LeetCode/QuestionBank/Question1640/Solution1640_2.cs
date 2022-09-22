using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1640
{
    public class Solution1640_2 : Interface1640
    {
        public bool CanFormArray(int[] arr, int[][] pieces)
        {
            Dictionary<int, int[]> helper = pieces.ToDictionary(arr => arr[0]);

            int i = 0;
            while (i < arr.Length)
            {
                if (!helper.ContainsKey(arr[i])) return false;
                int[] tar = helper[arr[i]];
                for (int j = 0; j < tar.Length; j++, i++)    // j可以从1开始遍历
                    if (arr[i] != tar[j]) return false;
            }

            return true;
        }
    }
}
