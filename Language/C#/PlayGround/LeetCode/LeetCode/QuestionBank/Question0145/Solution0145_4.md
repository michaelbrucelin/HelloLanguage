#### [](https://leetcode.cn/problems/binary-tree-postorder-traversal//#方法二：迭代)方法二：迭代

**思路与算法**

我们也可以用迭代的方式实现方法一的递归函数，两种方式是等价的，区别在于递归的时候隐式地维护了一个栈，而我们在迭代的时候需要显式地将这个栈模拟出来，其余的实现与细节都相同，具体可以参考下面的代码。

![](./assets/img/Solution0145_4_01.png)
![](./assets/img/Solution0145_4_02.png)
![](./assets/img/Solution0145_4_03.png)
![](./assets/img/Solution0145_4_04.png)
![](./assets/img/Solution0145_4_05.png)
![](./assets/img/Solution0145_4_06.png)
![](./assets/img/Solution0145_4_07.png)
![](./assets/img/Solution0145_4_08.png)
![](./assets/img/Solution0145_4_09.png)
![](./assets/img/Solution0145_4_10.png)
![](./assets/img/Solution0145_4_11.png)
![](./assets/img/Solution0145_4_12.png)
![](./assets/img/Solution0145_4_13.png)
![](./assets/img/Solution0145_4_14.png)
![](./assets/img/Solution0145_4_15.png)
![](./assets/img/Solution0145_4_16.png)
![](./assets/img/Solution0145_4_17.png)
![](./assets/img/Solution0145_4_18.png)
![](./assets/img/Solution0145_4_19.png)

**代码**

```C++
class Solution {
public:
    vector<int> postorderTraversal(TreeNode *root) {
        vector<int> res;
        if (root == nullptr) {
            return res;
        }

        stack<TreeNode *> stk;
        TreeNode *prev = nullptr;
        while (root != nullptr || !stk.empty()) {
            while (root != nullptr) {
                stk.emplace(root);
                root = root->left;
            }
            root = stk.top();
            stk.pop();
            if (root->right == nullptr || root->right == prev) {
                res.emplace_back(root->val);
                prev = root;
                root = nullptr;
            } else {
                stk.emplace(root);
                root = root->right;
            }
        }
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

        Deque<TreeNode> stack = new LinkedList<TreeNode>();
        TreeNode prev = null;
        while (root != null || !stack.isEmpty()) {
            while (root != null) {
                stack.push(root);
                root = root.left;
            }
            root = stack.pop();
            if (root.right == null || root.right == prev) {
                res.add(root.val);
                prev = root;
                root = null;
            } else {
                stack.push(root);
                root = root.right;
            }
        }
        return res;
    }
}
```

```Python
class Solution:
    def postorderTraversal(self, root: TreeNode) -> List[int]:
        if not root:
            return list()
        
        res = list()
        stack = list()
        prev = None

        while root or stack:
            while root:
                stack.append(root)
                root = root.left
            root = stack.pop()
            if not root.right or root.right == prev:
                res.append(root.val)
                prev = root
                root = None
            else:
                stack.append(root)
                root = root.right
        
        return res
```

```Go
func postorderTraversal(root *TreeNode) (res []int) {
    stk := []*TreeNode{}
    var prev *TreeNode
    for root != nil || len(stk) > 0 {
        for root != nil {
            stk = append(stk, root)
            root = root.Left
        }
        root = stk[len(stk)-1]
        stk = stk[:len(stk)-1]
        if root.Right == nil || root.Right == prev {
            res = append(res, root.Val)
            prev = root
            root = nil
        } else {
            stk = append(stk, root)
            root = root.Right
        }
    }
    return
}
```

```C
int *postorderTraversal(struct TreeNode *root, int *returnSize) {
    int *res = malloc(sizeof(int) * 2001);
    *returnSize = 0;
    if (root == NULL) {
        return res;
    }
    struct TreeNode **stk = malloc(sizeof(struct TreeNode *) * 2001);
    int top = 0;
    struct TreeNode *prev = NULL;
    while (root != NULL || top > 0) {
        while (root != NULL) {
            stk[top++] = root;
            root = root->left;
        }
        root = stk[--top];
        if (root->right == NULL || root->right == prev) {
            res[(*returnSize)++] = root->val;
            prev = root;
            root = NULL;
        } else {
            stk[top++] = root;
            root = root->right;
        }
    }
    return res;
}
```

**复杂度分析**

-   时间复杂度：O(n)，其中 n 是二叉搜索树的节点数。每一个节点恰好被遍历一次。
-   空间复杂度：O(n)，为迭代过程中显式栈的开销，平均情况下为 O(log⁡n)，最坏情况下树呈现链状，为 O(n)。
