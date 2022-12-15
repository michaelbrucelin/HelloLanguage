using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCSharp.Algorithm.Tree.BinaryTree
{
    /// <summary>
    /// 层序遍历二叉树
    /// </summary>
    public class Traverse_LevelOrder
    {
        #region BFS
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public List<List<char>> Traverse_BFS(TreeNode root)
        {
            List<List<char>> result = new List<List<char>>();
            if (root == null) return result;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int cnt; while ((cnt = queue.Count) > 0)
            {
                List<char> list = new List<char>();
                for (int i = 0; i < cnt; i++)
                {
                    TreeNode node = queue.Dequeue();
                    list.Add(node.Value);
                    if (node.Left != null) queue.Enqueue(node.Left);
                    if (node.Right != null) queue.Enqueue(node.Right);
                }
                result.Add(list);
            }

            return result;
        }
        #endregion

        #region 递归
        /// <summary>
        /// 递归
        /// 前序遍历的递归，构造层序遍历的结果
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public List<List<char>> Traverse_Recursive(TreeNode root)
        {
            List<List<char>> result = new List<List<char>>();
            if (root == null) return result;

            dfs(root, result, 0);

            return result;
        }

        private void dfs(TreeNode node, List<List<char>> buffer, int level)
        {
            // if (node == null) return;  // null不会进来

            if (level == buffer.Count) buffer.Add(new List<char>());
            buffer[level].Add(node.Value);
            if (node.Left != null) dfs(node.Left, buffer, level + 1);
            if (node.Right != null) dfs(node.Right, buffer, level + 1);
        }
        #endregion

        #region 迭代
        /// <summary>
        /// 迭代
        /// 前序遍历的迭代，构造层序遍历的结果
        /// 1. 将指针指向根节点
        /// 2. 输出指针
        /// 3. 判断指针的孩子情况
        ///     3.1. 有左有右，右孩子入栈，指针指向左孩子
        ///     3.2. 有左无右，指针指向左孩子
        ///     3.2. 无左有右，指针指向右孩子
        ///     3.4. 无左无右，指针指向栈顶（弹栈）
        /// 4. 回到步骤2
        /// 5. 直至指针无左无右且栈空，遍历结束
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public List<List<char>> Traverse_Iteration(TreeNode root)
        {
            List<List<char>> result = new List<List<char>>();
            if (root == null) return result;

            Stack<(int level, TreeNode node)> stack = new Stack<(int, TreeNode)>();
            int level = 0; TreeNode ptr = root;
            while (ptr != null)
            {
                if (level == result.Count) result.Add(new List<char>());
                result[level].Add(ptr.Value);
                if (ptr.Left != null)
                {
                    if (ptr.Right != null) stack.Push((level + 1, ptr.Right));
                    ptr = ptr.Left;
                    level++;
                }
                else
                {
                    if (ptr.Right != null) { ptr = ptr.Right; level++; }
                    else if (stack.Count > 0) { var item = stack.Pop(); ptr = item.node; level = item.level; }
                    else break;
                }
            }

            return result;
        }

        /// <summary>
        /// 迭代2
        /// 前序遍历的迭代，构造层序遍历的结果
        /// 用迭代的方式实现Traverse_Recursive()的递归函数，两种方式是等价的，
        /// 区别在于递归的时候隐式地维护了一个栈，而这里在迭代的时候需要显式地将这个栈模拟出来，其余的实现与细节都相同。
        /// 具体步骤见：Traverse_PreOrder_Iteration2_01.png - Traverse_PreOrder_Iteration2_14.png
        /// 
        /// 与Traverse_Iteration()的差异在于，这个是模拟递归，栈的操作更多（有没必要的操作）
        /// 例如当前节点已经处理过了，只需要将其右子节点入栈即可，而这里却将当前节点入栈，具体二者的性能如何没有测试
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public List<List<char>> Traverse_Iteration2(TreeNode root)
        {
            List<List<char>> result = new List<List<char>>();
            if (root == null) return result;

            Stack<(int level, TreeNode node)> stack = new Stack<(int, TreeNode)>();
            int level = 0; TreeNode ptr = root;
            while (ptr != null || stack.Count > 0)
            {
                while (ptr != null)
                {
                    if (level == result.Count) result.Add(new List<char>());
                    result[level].Add(ptr.Value); stack.Push((level, ptr)); ptr = ptr.Left; level++;
                }
                var item = stack.Pop();
                ptr = item.node.Right;
                level = item.level + 1;
            }

            return result;
        }
        #endregion

        #region Morris
        /// <summary>
        /// 迭代，Morris
        /// 前序遍历的Morris迭代，构造层序遍历的结果
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public List<List<char>> Traverse_Morris(TreeNode root)
        {
            List<List<char>> result = new List<List<char>>();
            if (root == null) return result;

            return result;
        }
        #endregion

        #region 染色法
        /// <summary>
        /// 迭代，染色法
        /// 前序遍历的染色法迭代，构造层序遍历的结果
        /// 这种方法的本质是每个节点都要入栈两次后才能访问其元素值，具体细节见Traverse_Dyeing.md
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public List<List<char>> Traverse_Dyeing(TreeNode root)
        {
            List<List<char>> result = new List<List<char>>();
            if (root == null) return result;

            Stack<(bool tag, int level, TreeNode node)> stack = new Stack<(bool, int, TreeNode)>();  // true:白色, false:灰色
            int level = 0;
            stack.Push((true, level, root));
            while (stack.Count > 0)
            {
                var item = stack.Pop();
                int _level = item.level; TreeNode _node = item.node;
                if (_node == null) continue;
                if (item.tag)
                {
                    stack.Push((true, _level + 1, _node.Right));
                    stack.Push((true, _level + 1, _node.Left));
                    stack.Push((false, _level, _node));
                }
                else
                {
                    if (_level == result.Count) result.Add(new List<char>());
                    result[_level].Add(_node.Value);
                }
            }

            return result;
        }
        #endregion
    }
}
