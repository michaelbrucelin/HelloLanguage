using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0658
{
    public class Solution0658_2 : Interface0658
    {
        public IList<int> FindClosestElements(int[] arr, int k, int x)
        {
            if (k == arr.Length) return arr;
            if (x <= arr[0]) return arr.Take(k).ToArray();
            if (x >= arr[arr.Length - 1]) return arr.Skip(arr.Length - k).ToArray();

            LinkedList<int> result = new LinkedList<int>();
            int minid = 0;                                   // 第一个最小值index
            int min = x < arr[0] ? arr[0] - x : x - arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (Math.Abs(arr[i] - x) < min)
                {
                    minid = i;
                    min = x < arr[i] ? arr[i] - x : x - arr[i];
                }
                else if (Math.Abs(arr[i] - x) > min)
                    break;  // 由于arr是升序排序，所以可以直接跳出循环
            }

            result.AddLast(arr[minid]);
            int cnt = 1;
            int left = minid - 1, right = minid + 1;
            while (cnt < k)
            {
                if (left == -1)
                    result.AddLast(arr[right++]);
                else if (right == arr.Length)
                    result.AddFirst(arr[left--]);
                else
                {
                    if (Math.Abs(arr[left] - x) <= Math.Abs(arr[right] - x)) result.AddFirst(arr[left--]);
                    else result.AddLast(arr[right++]);
                }

                cnt++;
            }

            return result.ToArray();
        }
    }
}
