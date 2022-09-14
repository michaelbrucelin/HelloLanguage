using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1460
{
    public class Solution1460 : Interface1460
    {
        /// <summary>
        /// 只要两个数组中的元素完全相同，就一定有解
        /// </summary>
        /// <param name="target"></param>
        /// <param name="arr"></param>
        /// <returns></returns>
        public bool CanBeEqual(int[] target, int[] arr)
        {
            Dictionary<int, int> buffer = new Dictionary<int, int>();
            for (int i = 0; i < target.Length; i++)
            {
                if (!buffer.ContainsKey(target[i]))
                    buffer.Add(target[i], 1);
                else
                    buffer[target[i]]++;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (!buffer.ContainsKey(arr[i])) return false;

                if (buffer[arr[i]] == 1)
                    buffer.Remove(arr[i]);
                else
                    buffer[arr[i]]--;
            }

            return true;
        }
    }
}
