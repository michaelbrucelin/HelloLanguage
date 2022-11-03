using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1668
{
    public class Solution1668 : Interface1668
    {
        /// <summary>
        /// 朴素查找
        /// </summary>
        /// <param name="sequence"></param>
        /// <param name="word"></param>
        /// <returns></returns>
        public int MaxRepeating(string sequence, string word)
        {
            if (word.Length > sequence.Length) return 0;

            int result = 0, ptr = 0;
            while (ptr < sequence.Length && sequence[ptr] != word[0]) ptr++;
            while (sequence.Length - ptr > word.Length * result)              // 余下的字符串可能产生更大的结果
            {
                int temp = 0, i = ptr;
                for (; i < sequence.Length; i++)
                {
                    if (sequence[i] != word[(i - ptr) % word.Length]) break;
                    if ((i - ptr + 1) % word.Length == 0) temp++;
                }
                result = Math.Max(result, temp);
                // ptr = i;  // 这样回溯是错误的，例如用例：sequence = "aaabaaaabaaabaaaabaaaabaaaabaaaaba"; word = "aaaba";
                ptr++;       // 更好的方式是采用类似于KMP算法next数组的方式进行回溯，这里直接简单粗暴的遍历了
                while (ptr < sequence.Length && sequence[ptr] != word[0]) ptr++;
            }

            return result;
        }
    }
}
