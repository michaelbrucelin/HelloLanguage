using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0662
{
    public class Solution0662
    {
        private Dictionary<int, (int minid, int maxid)> buffer = new Dictionary<int, (int minid, int maxid)>();

        /// <summary>
        ///                0
        ///       1                  2
        ///   3       4         5         6
        /// 7   8   9   10   11   12   13   14
        /// 假定父节点层数为level，索引为n，那么左子节点索引为2n+1，右子节点索引为2n+2，层数均为level+1
        /// DFS一次即可
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int WidthOfBinaryTree(TreeNode root)
        {
            GetTreeDistribution(root, 0, 0);

            int result = 0;
            foreach (var item in buffer.Values)
                if (item.maxid - item.minid + 1 > result)
                    result = item.maxid - item.minid + 1;

            return result;
        }

        private void GetTreeDistribution(TreeNode node, int level, int index)
        {
            if (!buffer.ContainsKey(level))
                buffer.Add(level, (index, index));
            else
            {
                int minid = buffer[level].minid;
                int maxid = buffer[level].maxid;
                if (index < minid) buffer[level] = (index, maxid);
                else if (index > maxid) buffer[level] = (minid, index);
            }

            if (node.left != null) GetTreeDistribution(node.left, level + 1, index * 2 + 1);
            if (node.right != null) GetTreeDistribution(node.right, level + 1, index * 2 + 2);
        }
    }
}
