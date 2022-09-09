#### [](https://leetcode.cn/problems/binary-tree-postorder-traversal//#方法三：morris-遍历)方法三：Morris 遍历

**思路与算法**

有一种巧妙的方法可以在线性时间内，只占用常数空间来实现后序遍历。这种方法由 J. H. Morris 在 1979 年的论文「Traversing Binary Trees Simply and Cheaply」中首次提出，因此被称为 Morris 遍历。

Morris 遍历的核心思想是利用树的大量空闲指针，实现空间开销的极限缩减。其后序遍历规则总结如下：

1.  新建临时节点，令该节点为 `root`；

2.  如果当前节点的左子节点为空，则遍历当前节点的右子节点；

3.  如果当前节点的左子节点不为空，在当前节点的左子树中找到当前节点在中序遍历下的前驱节点；

    -   如果前驱节点的右子节点为空，将前驱节点的右子节点设置为当前节点，当前节点更新为当前节点的左子节点。

    -   如果前驱节点的右子节点为当前节点，将它的右子节点重新设为空。倒序输出从当前节点的左子节点到该前驱节点这条路径上的所有节点。当前节点更新为当前节点的右子节点。

4.  重复步骤 2 和步骤 3，直到遍历结束。


这样我们利用 Morris 遍历的方法，后序遍历该二叉搜索树，即可实现线性时间与常数空间的遍历。

**代码**

```C++
class Solution {
public:
    void addPath(vector<int> &vec, TreeNode *node) {
        int count = 0;
        while (node != nullptr) {
            ++count;
            vec.emplace_back(node->val);
            node = node->right;
        }
        reverse(vec.end() - count, vec.end());
    }

    vector<int> postorderTraversal(TreeNode *root) {
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
                    p2->right = p1;
                    p1 = p1->left;
                    continue;
                } else {
                    p2->right = nullptr;
                    addPath(res, p1->left);
                }
            }
            p1 = p1->right;
        }
        addPath(res, root);
        return res;
    }
};

```

```Java
class Solution {
    public List<Integer> postorderTraversal(TreeNode root) {
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
                    p2.right = p1;
                    p1 = p1.left;
                    continue;
                } else {
                    p2.right = null;
                    addPath(res, p1.left);
                }
            }
            p1 = p1.right;
        }
        addPath(res, root);
        return res;
    }

    public void addPath(List<Integer> res, TreeNode node) {
        int count = 0;
        while (node != null) {
            ++count;
            res.add(node.val);
            node = node.right;
        }
        int left = res.size() - count, right = res.size() - 1;
        while (left < right) {
            int temp = res.get(left);
            res.set(left, res.get(right));
            res.set(right, temp);
            left++;
            right--;
        }
    }
}

```

```Python3
class Solution:
    def postorderTraversal(self, root: TreeNode) -> List[int]:
        def addPath(node: TreeNode):
            count = 0
            while node:
                count += 1
                res.append(node.val)
                node = node.right
            i, j = len(res) - count, len(res) - 1
            while i < j:
                res[i], res[j] = res[j], res[i]
                i += 1
                j -= 1
        
        if not root:
            return list()
        
        res = list()
        p1 = root

        while p1:
            p2 = p1.left
            if p2:
                while p2.right and p2.right != p1:
                    p2 = p2.right
                if not p2.right:
                    p2.right = p1
                    p1 = p1.left
                    continue
                else:
                    p2.right = None
                    addPath(p1.left)
            p1 = p1.right
        
        addPath(root)
        return res

```

```Golang
func reverse(a []int) {
    for i, n := 0, len(a); i < n/2; i++ {
        a[i], a[n-1-i] = a[n-1-i], a[i]
    }
}

func postorderTraversal(root *TreeNode) (res []int) {
    addPath := func(node *TreeNode) {
        resSize := len(res)
        for ; node != nil; node = node.Right {
            res = append(res, node.Val)
        }
        reverse(res[resSize:])
    }

    p1 := root
    for p1 != nil {
        if p2 := p1.Left; p2 != nil {
            for p2.Right != nil && p2.Right != p1 {
                p2 = p2.Right
            }
            if p2.Right == nil {
                p2.Right = p1
                p1 = p1.Left
                continue
            }
            p2.Right = nil
            addPath(p1.Left)
        }
        p1 = p1.Right
    }
    addPath(root)
    return
}

```

```C
void addPath(int *vec, int *vecSize, struct TreeNode *node) {
    int count = 0;
    while (node != NULL) {
        ++count;
        vec[(*vecSize)++] = node->val;
        node = node->right;
    }
    for (int i = (*vecSize) - count, j = (*vecSize) - 1; i < j; ++i, --j) {
        int t = vec[i];
        vec[i] = vec[j];
        vec[j] = t;
    }
}

int *postorderTraversal(struct TreeNode *root, int *returnSize) {
    int *res = malloc(sizeof(int) * 2001);
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
                p2->right = p1;
                p1 = p1->left;
                continue;
            } else {
                p2->right = NULL;
                addPath(res, returnSize, p1->left);
            }
        }
        p1 = p1->right;
    }
    addPath(res, returnSize, root);
    return res;
}

```

**复杂度分析**

-   时间复杂度：O(n)，其中 n 是二叉树的节点数。没有左子树的节点只被访问一次，有左子树的节点被访问两次。

-   空间复杂度：O(1)。只操作已经存在的指针（树的空闲指针），因此只需要常数的额外空间。
