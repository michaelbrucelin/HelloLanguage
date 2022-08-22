using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0655
{
    public class Solution0655
    {
        /// <summary>
        /// level 0:                 0
        /// index 1:                 7
        /// level 1:        1                  2
        /// index 1:        3                  11
        /// level 2:    3       4         5         6
        /// index 2:    1       5         9         13
        /// level 3:  7   8   9   10   11   12   13   14
        /// index 3:  0   2   4   6    8    10   12   14
        /// 然后找规律即可，总共4层，那么每层的数组长度为2^4-1
        /// 第3层，元素从2^0-1开始，每隔2^1一个元素
        /// 第2层，元素从2^1-1开始，每隔2^2一个元素
        /// 第1层，元素从2^2-1开始，每隔2^3一个元素
        /// 第0层，元素从2^3-1开始，每隔2^4一个元素
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<string>> PrintTree(TreeNode root)
        {
            List<IList<string>> result = new List<IList<string>>();

            // 广度优先遍历，找出每层的值
            Queue<TreeNode> buffer = new Queue<TreeNode>();
            buffer.Enqueue(root);
            bool hasNode = true;
            while (hasNode)
            {
                hasNode = false;
                int count = buffer.Count;
                result.Add(new List<string>());
                for (int i = 0; i < count; i++)
                {
                    TreeNode node = buffer.Dequeue();
                    if (node == null)
                    {
                        result[result.Count - 1].Add("");
                        buffer.Enqueue(null);
                        buffer.Enqueue(null);
                    }
                    else
                    {
                        result[result.Count - 1].Add(node.val.ToString());
                        buffer.Enqueue(node.left);
                        buffer.Enqueue(node.right);
                        if (!hasNode && (node.left != null || node.right != null))
                            hasNode = true;
                    }
                }
            }

            // 将找到的每层的值插入到对应的位置
            int levelcnt = result.Count;
            List<string> template = Enumerable.Repeat("", (int)Math.Pow(2, levelcnt) - 1).ToList();
            for (int i = 0; i < result.Count; i++)
            {
                List<string> item = template.ToList();

                int start = (int)Math.Pow(2, levelcnt - i - 1) - 1;
                int interval = (int)Math.Pow(2, levelcnt - i);
                int index = 0;
                while (start < item.Count)
                {
                    item[start] = result[i][index++];
                    start += interval;
                }

                result[i] = item;
            }

            return result;
        }
    }
}
