using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCSharp.Algorithm.Tree.BinaryTree
{
    /// <summary>
    /// 先序遍历二叉树
    /// </summary>
    public class Traverse_PreOrder
    {
        #region 递归
        /// <summary>
        /// 递归
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public List<char> Traverse_Recursive(TreeNode root)
        {
            List<char> result = new List<char>();
            if (root == null) return result;

            result.Add(root.Value);
            if (root.Left != null) result.AddRange(Traverse_Recursive(root.Left));
            if (root.Right != null) result.AddRange(Traverse_Recursive(root.Right));

            return result;
        }

        /// <summary>
        /// 递归2
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public List<char> Traverse_Recursive2(TreeNode root)
        {
            List<char> result = new List<char>();
            if (root == null) return result;

            dfs(root, result);

            return result;
        }

        private void dfs(TreeNode node, List<char> buffer)
        {
            // if (node == null) return;  // null不会进来

            buffer.Add(node.Value);
            if (node.Left != null) dfs(node.Left, buffer);
            if (node.Right != null) dfs(node.Right, buffer);
        }
        #endregion

        #region 迭代
        /// <summary>
        /// 迭代
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
        public List<char> Traverse_Iteration(TreeNode root)
        {
            List<char> result = new List<char>();
            if (root == null) return result;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode ptr = root;
            while (ptr != null)
            {
                result.Add(ptr.Value);
                if (ptr.Left != null)
                {
                    if (ptr.Right != null) stack.Push(ptr.Right);
                    ptr = ptr.Left;
                }
                else
                {
                    if (ptr.Right != null) ptr = ptr.Right;
                    else if (stack.Count > 0) ptr = stack.Pop();
                    else break;
                }
            }

            return result;
        }

        /// <summary>
        /// 迭代2
        /// 用迭代的方式实现Traverse_Recursive2()的递归函数，两种方式是等价的，
        /// 区别在于递归的时候隐式地维护了一个栈，而这里在迭代的时候需要显式地将这个栈模拟出来，其余的实现与细节都相同。
        /// 具体步骤见：Traverse_PreOrder_Iteration2_01.png - Traverse_PreOrder_Iteration2_14.png
        /// 
        /// 与Traverse_Iteration()的差异在于，这个是模拟递归，栈的操作更多（有没必要的操作）
        /// 例如当前节点已经处理过了，只需要将其右子节点入栈即可，而这里却将当前节点入栈，具体二者的性能如何没有测试
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public List<char> Traverse_Iteration2(TreeNode root)
        {
            List<char> result = new List<char>();
            if (root == null) return result;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode ptr = root;
            while (ptr != null || stack.Count > 0)
            {
                while (ptr != null) { result.Add(ptr.Value); stack.Push(ptr); ptr = ptr.Left; }
                ptr = stack.Pop();  // 与Traverse_Iteration()的主要差异就在这两行代码，
                ptr = ptr.Right;    // 这里由于是将父节点入栈，所以弹栈之后还要指向其右孩子，而Traverse_Iteration()由于是直接将右孩子入栈，所以弹栈后直接可用
            }

            return result;
        }
        #endregion

        #region Morris
        /// <summary>
        /// 迭代，Morris
        /// 类似于线索二叉树的方式迭代，时间复杂度为O(n)，空间复杂度为O(1)，但是由于在遍历的过程中会更改树的结构，所以不适合并发的场景
        /// 具体步骤见：Traverse_PreOrder_Morris.jpg
        /// 
        /// 1. 将指针指向根节点
        /// 2. 指针无左孩子，输出指针，指针指向其右孩子
        /// 3. 指针有左孩子，找到指针中序遍历的前驱节点，即左子树中最右边的节点（顺着左孩子一直找右孩子，直至右孩子为空或右孩子是指针）
        ///     3.1. 如果前驱节点的右孩子为空，将前驱的右孩子指向指针，输出指针，指针指向其左孩子
        ///     3.2. 如果前驱节点的右孩子是指针，将前驱的右孩子设置为空（恢复树的形状），指针指向其右孩子
        /// 4. 重复2、3直至指针为空
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public List<char> Traverse_Morris(TreeNode root)
        {
            List<char> result = new List<char>();
            if (root == null) return result;

            TreeNode ptr = root, pre;
            while (ptr != null)
            {
                if (ptr.Left == null) { result.Add(ptr.Value); ptr = ptr.Right; }
                else
                {
                    pre = ptr.Left; while (pre.Right != null && pre.Right != ptr) pre = pre.Right;
                    if (pre.Right == null)
                    {
                        pre.Right = ptr; result.Add(ptr.Value); ptr = ptr.Left;
                    }
                    else
                    {
                        pre.Right = null; ptr = ptr.Right;
                    }
                }
            }

            return result;
        }
        #endregion

        #region 染色法
        /// <summary>
        /// 迭代，染色法
        /// 这种方法的本质是每个节点都要入栈两次后才能访问其元素值，但是代码结构还是挺漂亮的，具体细节见Traverse_Dyeing.md
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public List<char> Traverse_Dyeing(TreeNode root)
        {
            List<char> result = new List<char>();
            if (root == null) return result;

            Stack<(bool tag, TreeNode node)> stack = new Stack<(bool, TreeNode)>();  // true:白色, false:灰色
            stack.Push((true, root));
            while (stack.Count > 0)
            {
                var item = stack.Pop();
                if (item.node == null) continue;
                if (item.tag)
                {
                    stack.Push((true, item.node.Right));
                    stack.Push((true, item.node.Left));
                    stack.Push((false, item.node));
                }
                else
                    result.Add(item.node.Value);
            }

            return result;
        }
        #endregion
    }
}
