#### [](https://leetcode.cn/problems/binary-tree-preorder-traversal/solution/er-cha-shu-de-qian-xu-bian-li-by-leetcode-solution//#方法三：morris-遍历)方法三：Morris 遍历

**思路与算法**

有一种巧妙的方法可以在线性时间内，只占用常数空间来实现前序遍历。这种方法由 J. H. Morris 在 1979 年的论文「Traversing Binary Trees Simply and Cheaply」中首次提出，因此被称为 Morris 遍历。

Morris 遍历的核心思想是利用树的大量空闲指针，实现空间开销的极限缩减。其前序遍历规则总结如下：

1.  新建临时节点，令该节点为 `root`；
    
2.  如果当前节点的左子节点为空，将当前节点加入答案，并遍历当前节点的右子节点；
    
3.  如果当前节点的左子节点不为空，在当前节点的左子树中找到当前节点在中序遍历下的前驱节点：
    
    -   如果前驱节点的右子节点为空，将前驱节点的右子节点设置为当前节点。然后将当前节点加入答案，并将前驱节点的右子节点更新为当前节点。当前节点更新为当前节点的左子节点。
        
    -   如果前驱节点的右子节点为当前节点，将它的右子节点重新设为空。当前节点更新为当前节点的右子节点。
        
4.  重复步骤 2 和步骤 3，直到遍历结束。
    

这样我们利用 Morris 遍历的方法，前序遍历该二叉树，即可实现线性时间与常数空间的遍历。

**代码**

```C++
class Solution {
public:
    vector<int> preorderTraversal(TreeNode *root) {
        vector<int> res;
        if (root == nullptr) {
            return res;
        }

        TreeNode *p1 = root, *p2 = nullptr;

        while (p1 != nullptr) {
            p2 = p1->left;
            if (p2 != nullptr) {
                while (p2->right != nullptr && p2->right != p1) {
                    p2 = p2->right;
                }
                if (p2->right == nullptr) {
                    res.emplace_back(p1->val);
                    p2->right = p1;
                    p1 = p1->left;
                    continue;
                } else {
                    p2->right = nullptr;
                }
            } else {
                res.emplace_back(p1->val);
            }
            p1 = p1->right;
        }
        return res;
    }
};

```

```Java
class Solution {
    public List<Integer> preorderTraversal(TreeNode root) {
        List<Integer> res = new ArrayList<Integer>();
        if (root == null) {
            return res;
        }

        TreeNode p1 = root, p2 = null;

        while (p1 != null) {
            p2 = p1.left;
            if (p2 != null) {
                while (p2.right != null && p2.right != p1) {
                    p2 = p2.right;
                }
                if (p2.right == null) {
                    res.add(p1.val);
                    p2.right = p1;
                    p1 = p1.left;
                    continue;
                } else {
                    p2.right = null;
                }
            } else {
                res.add(p1.val);
            }
            p1 = p1.right;
        }
        return res;
    }
}

```

```Python3
class Solution:
    def preorderTraversal(self, root: TreeNode) -> List[int]:
        res = list()
        if not root:
            return res
        
        p1 = root
        while p1:
            p2 = p1.left
            if p2:
                while p2.right and p2.right != p1:
                    p2 = p2.right
                if not p2.right:
                    res.append(p1.val)
                    p2.right = p1
                    p1 = p1.left
                    continue
                else:
                    p2.right = None
            else:
                res.append(p1.val)
            p1 = p1.right
        
        return res

```

```Golang
func preorderTraversal(root *TreeNode) (vals []int) {
    var p1, p2 *TreeNode = root, nil
    for p1 != nil {
        p2 = p1.Left
        if p2 != nil {
            for p2.Right != nil && p2.Right != p1 {
                p2 = p2.Right
            }
            if p2.Right == nil {
                vals = append(vals, p1.Val)
                p2.Right = p1
                p1 = p1.Left
                continue
            }
            p2.Right = nil
        } else {
            vals = append(vals, p1.Val)
        }
        p1 = p1.Right
    }
    return
}

```

```C
int* preorderTraversal(struct TreeNode* root, int* returnSize) {
    int* res = malloc(sizeof(int) * 2000);
    *returnSize = 0;
    if (root == NULL) {
        return res;
    }

    struct TreeNode *p1 = root, *p2 = NULL;

    while (p1 != NULL) {
        p2 = p1->left;
        if (p2 != NULL) {
            while (p2->right != NULL && p2->right != p1) {
                p2 = p2->right;
            }
            if (p2->right == NULL) {
                res[(*returnSize)++] = p1->val;
                p2->right = p1;
                p1 = p1->left;
                continue;
            } else {
                p2->right = NULL;
            }
        } else {
            res[(*returnSize)++] = p1->val;
        }
        p1 = p1->right;
    }
    return res;
}

```

**复杂度分析**

-   时间复杂度：O(n)，其中 n 是二叉树的节点数。没有左子树的节点只被访问一次，有左子树的节点被访问两次。

-   空间复杂度：O(1)。只操作已经存在的指针（树的空闲指针），因此只需要常数的额外空间。
