#### [](https://leetcode.cn/problems/binary-tree-preorder-traversal/solution/er-cha-shu-de-qian-xu-bian-li-by-leetcode-solution//#方法一：递归)方法一：递归

**思路与算法**

首先我们需要了解什么是二叉树的前序遍历：按照访问根节点——左子树——右子树的方式遍历这棵树，而在访问左子树或者右子树的时候，我们按照同样的方式遍历，直到遍历完整棵树。因此整个遍历过程天然具有递归的性质，我们可以直接用递归函数来模拟这一过程。

定义 `preorder(root)` 表示当前遍历到 `root` 节点的答案。按照定义，我们只要首先将 `root` 节点的值加入答案，然后递归调用 `preorder(root.left)` 来遍历 `root` 节点的左子树，最后递归调用 `preorder(root.right)` 来遍历 `root` 节点的右子树即可，递归终止的条件为碰到空节点。

**代码**

```C++
class Solution {
public:
    void preorder(TreeNode *root, vector<int> &res) {
        if (root == nullptr) {
            return;
        }
        res.push_back(root->val);
        preorder(root->left, res);
        preorder(root->right, res);
    }

    vector<int> preorderTraversal(TreeNode *root) {
        vector<int> res;
        preorder(root, res);
        return res;
    }
};

```

```Java
class Solution {
    public List<Integer> preorderTraversal(TreeNode root) {
        List<Integer> res = new ArrayList<Integer>();
        preorder(root, res);
        return res;
    }

    public void preorder(TreeNode root, List<Integer> res) {
        if (root == null) {
            return;
        }
        res.add(root.val);
        preorder(root.left, res);
        preorder(root.right, res);
    }
}

```

```Python3
class Solution:
    def preorderTraversal(self, root: TreeNode) -> List[int]:
        def preorder(root: TreeNode):
            if not root:
                return
            res.append(root.val)
            preorder(root.left)
            preorder(root.right)
        
        res = list()
        preorder(root)
        return res

```

```Golang
func preorderTraversal(root *TreeNode) (vals []int) {
    var preorder func(*TreeNode)
    preorder = func(node *TreeNode) {
        if node == nil {
            return
        }
        vals = append(vals, node.Val)
        preorder(node.Left)
        preorder(node.Right)
    }
    preorder(root)
    return
}

```

```C
void preorder(struct TreeNode* root, int* res, int* resSize) {
    if (root == NULL) {
        return;
    }
    res[(*resSize)++] = root->val;
    preorder(root->left, res, resSize);
    preorder(root->right, res, resSize);
}

int* preorderTraversal(struct TreeNode* root, int* returnSize) {
    int* res = malloc(sizeof(int) * 2000);
    *returnSize = 0;
    preorder(root, res, returnSize);
    return res;
}

```

**复杂度分析**

-   时间复杂度：O(n)，其中 n 是二叉树的节点数。每一个节点恰好被遍历一次。

-   空间复杂度：O(n)，为递归过程中栈的开销，平均情况下为 O(log⁡n)，最坏情况下树呈现链状，为 O(n)。

