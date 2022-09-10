#### [](https://leetcode.cn/problems/trim-a-binary-search-tree/solution/xiu-jian-er-cha-sou-suo-shu-by-leetcode-qe7q1//#方法二：迭代)方法二：迭代

如果一个结点 node 符合要求，即它的值位于区间 \[low,high\]，那么它的左子树与右子树应该如何修剪？

我们先讨论左子树的修剪：

-   node 的左结点为空结点：不需要修剪

-   node 的左结点非空：

    -   如果它的左结点 left 的值小于 low，那么 left 以及 left 的左子树都不符合要求，我们将 node 的左结点设为 left 的右结点，然后再重新对 node 的左子树进行修剪。

    -   如果它的左结点 left 的值大于等于 low，又因为 node 的值已经符合要求，所以 left 的右子树一定符合要求。基于此，我们只需要对 left 的左子树进行修剪。我们令 node 等于 left ，然后再重新对 node 的左子树进行修剪。


以上过程可以迭代处理。对于右子树的修剪同理。

我们对根结点进行判断，如果根结点不符合要求，我们将根结点设为对应的左结点或右结点，直到根结点符合要求，然后将根结点作为符合要求的结点，依次修剪它的左子树与右子树。

```Python3
class Solution:
    def trimBST(self, root: Optional[TreeNode], low: int, high: int) -> Optional[TreeNode]:
        while root and (root.val < low or root.val > high):
            root = root.right if root.val < low else root.left
        if root is None:
            return None
        node = root
        while node.left:
            if node.left.val < low:
                node.left = node.left.right
            else:
                node = node.left
        node = root
        while node.right:
            if node.right.val > high:
                node.right = node.right.left
            else:
                node = node.right
        return root

```

```C++
class Solution {
public:
    TreeNode* trimBST(TreeNode* root, int low, int high) {
        while (root && (root->val < low || root->val > high)) {
            if (root->val < low) {
                root = root->right;
            } else {
                root = root->left;
            }
        }
        if (root == nullptr) {
            return nullptr;
        }
        for (auto node = root; node->left; ) {
            if (node->left->val < low) {
                node->left = node->left->right;
            } else {
                node = node->left;
            }
        }
        for (auto node = root; node->right; ) {
            if (node->right->val > high) {
                node->right = node->right->left;
            } else {
                node = node->right;
            }
        }
        return root;
    }
};

```

```Java
class Solution {
    public TreeNode trimBST(TreeNode root, int low, int high) {
        while (root != null && (root.val < low || root.val > high)) {
            if (root.val < low) {
                root = root.right;
            } else {
                root = root.left;
            }
        }
        if (root == null) {
            return null;
        }
        for (TreeNode node = root; node.left != null; ) {
            if (node.left.val < low) {
                node.left = node.left.right;
            } else {
                node = node.left;
            }
        }
        for (TreeNode node = root; node.right != null; ) {
            if (node.right.val > high) {
                node.right = node.right.left;
            } else {
                node = node.right;
            }
        }
        return root;
    }
}

```

```C#
public class Solution {
    public TreeNode TrimBST(TreeNode root, int low, int high) {
        while (root != null && (root.val < low || root.val > high)) {
            if (root.val < low) {
                root = root.right;
            } else {
                root = root.left;
            }
        }
        if (root == null) {
            return null;
        }
        for (TreeNode node = root; node.left != null; ) {
            if (node.left.val < low) {
                node.left = node.left.right;
            } else {
                node = node.left;
            }
        }
        for (TreeNode node = root; node.right != null; ) {
            if (node.right.val > high) {
                node.right = node.right.left;
            } else {
                node = node.right;
            }
        }
        return root;
    }
}

```

```C
struct TreeNode* trimBST(struct TreeNode* root, int low, int high){
    while (root && (root->val < low || root->val > high)) {
        if (root->val < low) {
            root = root->right;
        } else {
            root = root->left;
        }
    }
    if (root == NULL) {
        return NULL;
    }
    for (struct TreeNode* node = root; node->left; ) {
        if (node->left->val < low) {
            node->left = node->left->right;
        } else {
            node = node->left;
        }
    }
    for (struct TreeNode* node = root; node->right; ) {
        if (node->right->val > high) {
            node->right = node->right->left;
        } else {
            node = node->right;
        }
    }
    return root;
}

```

```JavaScript
var trimBST = function(root, low, high) {
    while (root && (root.val < low || root.val > high)) {
        if (root.val < low) {
            root = root.right;
        } else {
            root = root.left;
        }
    }
    if (!root) {
        return null;
    }
    for (let node = root; node.left; ) {
        if (node.left.val < low) {
            node.left = node.left.right;
        } else {
            node = node.left;
        }
    }
    for (let node = root; node.right; ) {
        if (node.right.val > high) {
            node.right = node.right.left;
        } else {
            node = node.right;
        }
    }
    return root;
};

```

```Golang
func trimBST(root *TreeNode, low, high int) *TreeNode {
    for root != nil && (root.Val < low || root.Val > high) {
        if root.Val < low {
            root = root.Right
        } else {
            root = root.Left
        }
    }
    if root == nil {
        return nil
    }
    for node := root; node.Left != nil; {
        if node.Left.Val < low {
            node.Left = node.Left.Right
        } else {
            node = node.Left
        }
    }
    for node := root; node.Right != nil; {
        if node.Right.Val > high {
            node.Right = node.Right.Left
        } else {
            node = node.Right
        }
    }
    return root
}

```

**复杂度分析**

-   时间复杂度：O(n)O(n)O(n)，其中 nnn 为二叉树的结点数目。最多访问 nnn 个结点。
    
-   空间复杂度：O(1)O(1)O(1)。
