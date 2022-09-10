#### [](https://leetcode.cn/problems/trim-a-binary-search-tree/solution/xiu-jian-er-cha-sou-suo-shu-by-leetcode-qe7q1//#������������)������������

���һ����� node ����Ҫ�󣬼�����ֵλ������ \[low,high\]����ô������������������Ӧ������޼���

�������������������޼���

-   node ������Ϊ�ս�㣺����Ҫ�޼�

-   node ������ǿգ�

    -   ����������� left ��ֵС�� low����ô left �Լ� left ����������������Ҫ�����ǽ� node ��������Ϊ left ���ҽ�㣬Ȼ�������¶� node �������������޼���

    -   ����������� left ��ֵ���ڵ��� low������Ϊ node ��ֵ�Ѿ�����Ҫ������ left ��������һ������Ҫ�󡣻��ڴˣ�����ֻ��Ҫ�� left �������������޼��������� node ���� left ��Ȼ�������¶� node �������������޼���


���Ϲ��̿��Ե��������������������޼�ͬ��

���ǶԸ��������жϣ��������㲻����Ҫ�����ǽ��������Ϊ��Ӧ��������ҽ�㣬ֱ����������Ҫ��Ȼ�󽫸������Ϊ����Ҫ��Ľ�㣬�����޼���������������������

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

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�O(n)O(n)O(n)������ nnn Ϊ�������Ľ����Ŀ�������� nnn ����㡣
    
-   �ռ临�Ӷȣ�O(1)O(1)O(1)��
