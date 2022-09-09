#### [](https://leetcode.cn/problems/binary-tree-postorder-traversal//#方法一：递归)方法一：递归

**思路与算法**

首先我们需要了解什么是二叉树的后序遍历：按照访问左子树——右子树——根节点的方式遍历这棵树，而在访问左子树或者右子树的时候，我们按照同样的方式遍历，直到遍历完整棵树。因此整个遍历过程天然具有递归的性质，我们可以直接用递归函数来模拟这一过程。

定义 `postorder(root)` 表示当前遍历到 `root` 节点的答案。按照定义，我们只要递归调用 `postorder(root->left)` 来遍历 `root` 节点的左子树，然后递归调用 `postorder(root->right)` 来遍历 `root` 节点的右子树，最后将 `root` 节点的值加入答案即可，递归终止的条件为碰到空节点。

**代码**

```C++
class Solution {
public:
    void postorder(TreeNode *root, vector<int> &res) {
        if (root == nullptr) {
            return;
        }
        postorder(root->left, res);
        postorder(root->right, res);
        res.push_back(root->val);
    }

    vector<int> postorderTraversal(TreeNode *root) {
        vector<int> res;
        postorder(root, res);
        return res;
    }
};

```

```Java
class Solution {
    public List<Integer> postorderTraversal(TreeNode root) {
        List<Integer> res = new ArrayList<Integer>();
        postorder(root, res);
        return res;
    }

    public void postorder(TreeNode root, List<Integer> res) {
        if (root == null) {
            return;
        }
        postorder(root.left, res);
        postorder(root.right, res);
        res.add(root.val);
    }
}

```

```Python3
class Solution:
    def postorderTraversal(self, root: TreeNode) -> List[int]:
        def postorder(root: TreeNode):
            if not root:
                return
            postorder(root.left)
            postorder(root.right)
            res.append(root.val)
        
        res = list()
        postorder(root)
        return res

```

```Golang
func postorderTraversal(root *TreeNode) (res []int) {
    var postorder func(*TreeNode)
    postorder = func(node *TreeNode) {
        if node == nil {
            return
        }
        postorder(node.Left)
        postorder(node.Right)
        res = append(res, node.Val)
    }
    postorder(root)
    return
}

```

```C
void postorder(struct TreeNode *root, int *res, int *resSize) {
    if (root == NULL) {
        return;
    }
    postorder(root->left, res, resSize);
    postorder(root->right, res, resSize);
    res[(*resSize)++] = root->val;
}

int *postorderTraversal(struct TreeNode *root, int *returnSize) {
    int *res = malloc(sizeof(int) * 2001);
    *returnSize = 0;
    postorder(root, res, returnSize);
    return res;
}

```

**复杂度分析**

-   时间复杂度：O(n)，其中 n 是二叉搜索树的节点数。每一个节点恰好被遍历一次。

-   空间复杂度：O(n)，为递归过程中栈的开销，平均情况下为 O(log⁡n)，最坏情况下树呈现链状，为 O(n)。
