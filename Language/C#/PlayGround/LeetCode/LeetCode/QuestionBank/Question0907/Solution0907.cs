using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0907
{
    public class Solution0907 : Interface0907
    {
        /// <summary>
        /// 1. 计算每个字符的贡献值,参考Question0828，原理是一致的
        ///     这时，问题就转变为找出任意位置元素左侧和右侧第一个小于它的元素的位置，
        ///     如果遍历查找，O(n^2)，但是题目中规定数组长度达到30000，不合适，所以这里用单调栈实现
        /// 2. 单调栈参考Question0496
        /// 3. (A+B)%M = (A%M + B%M)%M
        /// 
        /// ================ 未完成 ================
        /// 组合会产生有重复
        /// 测试用例：{ 71, 55, 82, 55 }
        /// 已修正，左边找第一个小于的元素，右边找第一个小于等于的元素即可。
        /// ========================================
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int SumSubarrayMins(int[] arr)
        {
            Stack<(int id, int value)> stack = new Stack<(int id, int value)>();
            int len = arr.Length;

            int[] helper1 = new int[len];
            stack.Push((-1, int.MinValue));                 // 哨兵
            for (int i = 0; i < len; i++)
            {
                while (stack.Peek().value >= arr[i]) stack.Pop();
                helper1[i] = Math.Abs(stack.Peek().id - i);
                stack.Push((i, arr[i]));
            }

            int[] helper2 = new int[len];
            stack.Clear(); stack.Push((len, int.MinValue));  // 哨兵
            for (int i = len - 1; i >= 0; i--)
            {
                while (stack.Peek().value > arr[i]) stack.Pop();
                helper2[i] = Math.Abs(stack.Peek().id - i);
                stack.Push((i, arr[i]));
            }

            long result = 0;
            const int MOD = 1000000007;
            for (int i = 0; i < len; i++)
                result = (result + ((long)helper1[i] * helper2[i] * arr[i]) % MOD) % MOD;

            return (int)result;
        }
    }
}
