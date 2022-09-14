using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0658
{
    public class Solution0658_3 : Interface0658
    {
        public IList<int> FindClosestElements(int[] arr, int k, int x)
        {
            if (k == arr.Length) return arr;
            if (x <= arr[0]) return arr.Take(k).ToArray();
            if (x >= arr[arr.Length - 1]) return arr.Skip(arr.Length - k).ToArray();

            LinkedList<int> result = new LinkedList<int>();
            int right = BinarySearch(arr, x);
            int left = right - 1;

            int cnt = 0;
            while (cnt++ < k)
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
            }

            return result.ToArray();
        }

        private int BinarySearch(int[] arr, int x)
        {
            int low = 0, high = arr.Length - 1;
            while (low < high)
            {
                int mid = low + (high - low) / 2;
                if (arr[mid] >= x)
                    high = mid;
                else
                    low = mid + 1;
            }

            return low;
        }
    }
}
