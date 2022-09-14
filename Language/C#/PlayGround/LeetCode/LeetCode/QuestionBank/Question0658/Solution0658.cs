using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0658
{
    public class Solution0658 : Interface0658
    {
        public IList<int> FindClosestElements(int[] arr, int k, int x)
        {
            if (k == arr.Length) return arr;
            if (x <= arr[0]) return arr.Take(k).ToArray();
            if (x >= arr[arr.Length - 1]) return arr.Skip(arr.Length - k).ToArray();

            List<int> result = new List<int>();

            int[] helper = new int[arr.Length];
            int minid = 0;  // 第一个最小值index
            for (int i = 0; i < arr.Length; i++)
            {
                helper[i] = x < arr[i] ? arr[i] - x : x - arr[i];
                if (helper[i] < helper[minid])
                    minid = i;
            }

            result.Add(arr[minid]);
            int cnt = 1;
            int left = minid - 1, right = minid + 1;
            while (cnt < k)
            {
                if (left == -1)
                    result.Add(arr[right++]);
                else if (right == arr.Length)
                    result.Insert(0, arr[left--]);
                else
                {
                    if (helper[left] <= helper[right]) result.Insert(0, arr[left--]);
                    else result.Add(arr[right++]);
                }

                cnt++;
            }

            return result;
        }
    }
}
