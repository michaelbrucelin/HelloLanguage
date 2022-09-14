using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0662
{
    public class Solution0662_2 : Interface0662
    {
        /// <summary>
        /// BFS再来一次
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int WidthOfBinaryTree(TreeNode root)
        {
            int result = 0;

            Queue<(TreeNode node, int index)> buffer = new Queue<(TreeNode node, int index)>();
            buffer.Enqueue((root, 0));
            while (buffer.Count > 0)
            {
                int size = buffer.Count;
                var firstnode = buffer.Dequeue();
                int minid = firstnode.index;
                int maxid = firstnode.index;
                if (firstnode.node.left != null) buffer.Enqueue((firstnode.node.left, firstnode.index * 2 + 1));
                if (firstnode.node.right != null) buffer.Enqueue((firstnode.node.right, firstnode.index * 2 + 2));

                for (int i = 1; i < size; i++)
                {
                    var nodeinfo = buffer.Dequeue();
                    if (nodeinfo.index < minid) minid = nodeinfo.index;
                    else if (nodeinfo.index > maxid) maxid = nodeinfo.index;

                    if (nodeinfo.node.left != null) buffer.Enqueue((nodeinfo.node.left, nodeinfo.index * 2 + 1));
                    if (nodeinfo.node.right != null) buffer.Enqueue((nodeinfo.node.right, nodeinfo.index * 2 + 2));
                }

                if (maxid - minid + 1 > result)
                    result = maxid - minid + 1;
            }

            return result;
        }

        /// <summary>
        /// BFS优化，由于每一层都是从左向右遍历节点，所以最大值一定是第一个节点与最后一个节点的距离
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int WidthOfBinaryTree2(TreeNode root)
        {
            int result = 0;

            Queue<(TreeNode node, int index)> buffer = new Queue<(TreeNode node, int index)>();
            buffer.Enqueue((root, 0));
            while (buffer.Count > 0)
            {
                int size = buffer.Count;

                var firstnode = buffer.Dequeue();
                int minid = firstnode.index;
                int maxid = firstnode.index;
                if (firstnode.node.left != null) buffer.Enqueue((firstnode.node.left, firstnode.index * 2 + 1));
                if (firstnode.node.right != null) buffer.Enqueue((firstnode.node.right, firstnode.index * 2 + 2));

                if (size > 1)
                {
                    for (int i = 1; i < size - 1; i++)
                    {
                        var nodeinfo = buffer.Dequeue();
                        if (nodeinfo.node.left != null) buffer.Enqueue((nodeinfo.node.left, nodeinfo.index * 2 + 1));
                        if (nodeinfo.node.right != null) buffer.Enqueue((nodeinfo.node.right, nodeinfo.index * 2 + 2));
                    }

                    var lastnode = buffer.Dequeue();
                    maxid = lastnode.index;
                    if (lastnode.node.left != null) buffer.Enqueue((lastnode.node.left, lastnode.index * 2 + 1));
                    if (lastnode.node.right != null) buffer.Enqueue((lastnode.node.right, lastnode.index * 2 + 2));
                }

                if (maxid - minid + 1 > result)
                    result = maxid - minid + 1;
            }

            return result;
        }
    }
}
