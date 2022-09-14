using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0768
{
    public class Solution0768_2 : Interface0768
    {
        /// <summary>
        /// 排序
        /// 最终的分组结果，每一组中的元素一定与排序后数组对应位置的元素完全一致（不包括顺序）
        /// 使用一个字典来识别分组元素与排序后数组对应的元素是否一致
        ///     逐位进行分析，原数组向字典中添加项，排序后数组负责从字典中移除项，如果某一刻字典为空，则找到了一个分组
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int MaxChunksToSorted(int[] arr)
        {
            int[] sortedArr = arr.ToArray();
            Array.Sort(sortedArr);

            int result = 0;
            Dictionary<int, int> buffer = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (!buffer.ContainsKey(arr[i]))        // 原始数组负责加
                    buffer.Add(arr[i], 1);
                else
                {
                    if (buffer[arr[i]] == -1)
                        buffer.Remove(arr[i]);
                    else
                        buffer[arr[i]]++;
                }

                if (!buffer.ContainsKey(sortedArr[i]))  // 有序数组负责减
                    buffer.Add(sortedArr[i], -1);
                else
                {
                    if (buffer[sortedArr[i]] == 1)
                        buffer.Remove(sortedArr[i]);
                    else
                        buffer[sortedArr[i]]--;
                }

                if (buffer.Count == 0)
                    result++;
            }

            return result;
        }
    }
}
