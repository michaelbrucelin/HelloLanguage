using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1640
{
    public class Solution1640 : Interface1640
    {
        public bool CanFormArray(int[] arr, int[][] pieces)
        {
            int id = 0;
            while (id < arr.Length)
            {
                bool flag = false;
                for (int i = 0; i < pieces.Length; i++)
                {
                    if (id < arr.Length && pieces[i][0] == arr[id])
                    {
                        flag = true;
                        for (int j = 0; j < pieces[i].Length; j++, id++)  // j可以从1开始遍历
                            if (pieces[i][j] != arr[id]) return false;
                    }
                }
                if (!flag) return false;
            }

            return true;
        }

        public bool CanFormArray2(int[] arr, int[][] pieces)
        {
            int id = 0;
            while (id < arr.Length)
            {
                bool flag = false;
                for (int i = 0; i < pieces.Length; i++)
                {
                    if (id < arr.Length && pieces[i][0] == arr[id])
                    {
                        flag = true; id++;
                        for (int j = 1; j < pieces[i].Length; j++, id++)  // j可以从1开始遍历
                            if (pieces[i][j] != arr[id]) return false;
                    }
                }
                if (!flag) return false;
            }

            return true;
        }
    }
}
