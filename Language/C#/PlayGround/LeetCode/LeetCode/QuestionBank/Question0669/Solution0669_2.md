#### [](https://leetcode.cn/problems/trim-a-binary-search-tree/solution/xiu-jian-er-cha-sou-suo-shu-by-leetcode-qe7q1//#����һ���ݹ�)����һ���ݹ�

�Ը���� root ����������ȱ��������ڵ�ǰ���ʵĽ�㣬������Ϊ�ս�㣬ֱ�ӷ��ؿս�㣻�������ֵС�� low����ô˵���ý�㼰������������������Ҫ�����Ƿ��ض������ҽ������޼���Ľ�����������ֵ���� high����ô˵���ý�㼰������������������Ҫ�����Ƿ��ض����������������޼���Ľ�����������ֵλ������ [low,high]�����ǽ�����������Ϊ�������������޼���Ľ�����ҽ����Ϊ�����������������޼���Ľ����

```Python3
class Solution:
    def trimBST(self, root: Optional[TreeNode], low: int, high: int) -> Optional[TreeNode]:
        if root is None:
            return None
        if root.val < low:
            return self.trimBST(root.right, low, high)
        if root.val > high:
            return self.trimBST(root.left, low, high)
        root.left = self.trimBST(root.left, low, high)
        root.right = self.trimBST(root.right, low, high)
        return root

```

```C++
class Solution {
public:
    TreeNode* trimBST(TreeNode* root, int low, int high) {
        if (root == nullptr) {
            return nullptr;
        }
        if (root->val < low) {
            return trimBST(root->right, low, high);
        } else if (root->val > high) {
            return trimBST(root->left, low, high);
        } else {
            root->left = trimBST(root->left, low, high);
            root->right = trimBST(root->right, low, high);
            return root;
        }
    }
};

```

```Java
class Solution {
    public TreeNode trimBST(TreeNode root, int low, int high) {
        if (root == null) {
            return null;
        }
        if (root.val < low) {
            return trimBST(root.right, low, high);
        } else if (root.val > high) {
            return trimBST(root.left, low, high);
        } else {
            root.left = trimBST(root.left, low, high);
            root.right = trimBST(root.right, low, high);
            return root;
        }
    }
}

```

```C#
public class Solution {
    public TreeNode TrimBST(TreeNode root, int low, int high) {
        if (root == null) {
            return null;
        }
        if (root.val < low) {
            return TrimBST(root.right, low, high);
        } else if (root.val > high) {
            return TrimBST(root.left, low, high);
        } else {
            root.left = TrimBST(root.left, low, high);
            root.right = TrimBST(root.right, low, high);
            return root;
        }
    }
}

```

```C
struct TreeNode* trimBST(struct TreeNode* root, int low, int high){
    if (root == NULL) {
        return NULL;
    }
    if (root->val < low) {
        return trimBST(root->right, low, high);
    } else if (root->val > high) {
        return trimBST(root->left, low, high);
    } else {
        root->left = trimBST(root->left, low, high);
        root->right = trimBST(root->right, low, high);
        return root;
    }
}

```

```JavaScript
var trimBST = function(root, low, high) {
    if (!root) {
        return null;
    }
    if (root.val < low) {
        return trimBST(root.right, low, high);
    } else if (root.val > high) {
        return trimBST(root.left, low, high);
    } else {
        root.left = trimBST(root.left, low, high);
        root.right = trimBST(root.right, low, high);
        return root;
    }
};

```

```Golang
func trimBST(root *TreeNode, low, high int) *TreeNode {
    if root == nil {
        return nil
    }
    if root.Val < low {
        return trimBST(root.Right, low, high)
    }
    if root.Val > high {
        return trimBST(root.Left, low, high)
    }
    root.Left = trimBST(root.Left, low, high)
    root.Right = trimBST(root.Right, low, high)
    return root
}

```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�O(n)������ n Ϊ�������Ľ����Ŀ��

-   �ռ临�Ӷȣ�O(n)���ݹ�ջ��������Ҫ O(n) �Ŀռ䡣
