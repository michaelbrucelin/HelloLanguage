using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0813
{
    public class Solution0813 : Interface0813
    {
        /// <summary>
        /// 预处理 + 暴力解
        /// 先预先生成数组的“前缀和”数组，例如[1,2,3,4,5] -> [1,3,6,10,15]，这样可以O(1)计算出任意子数组的和，即平均值
        /// 然后暴力尝试所有可能
        /// 
        /// 测试结果是正确的，但是提交会超时，将测试用例4中的k改为7，提交即会超时
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public double LargestSumOfAverages(int[] nums, int k)
        {
            int len = nums.Length;
            double[] helper = new double[len + 1];
            int sum = 0;
            for (int i = 0; i < len; i++) helper[i + 1] = (sum += nums[i]);
            // for (int i = 1; i < len; i++) nums[i] += nums[i - 1];  // 可以直接复写nums，节省内存

            double result = -1;
            dfs(helper, 0, k, 0, ref result);

            return result;
        }

        private void dfs(double[] helper, int start, int level, double buffer, ref double result)
        {
            int len = helper.Length - 1;  // nums的长度，而不是helper的长度
            if (level > 1)
            {
                for (int i = start; i < len - level + 1; i++)
                {
                    double _buffer = buffer + (helper[i + 1] - helper[start]) / (i + 1 - start);
                    dfs(helper, i + 1, level - 1, _buffer, ref result);
                }
            }
            else
            {
                buffer += (helper[len] - helper[start]) / (len - start);
                result = Math.Max(result, buffer);
            }
        }
    }
}
