#### [](https://leetcode.cn/problems/binary-tree-inorder-traversal/solution/er-cha-shu-de-zhong-xu-bian-li-by-leetcode-solutio//#������������)������������

**˼·���㷨**

����һ�ĵݹ麯������Ҳ�����õ����ķ�ʽʵ�֣����ַ�ʽ�ǵȼ۵ģ��������ڵݹ��ʱ����ʽ��ά����һ��ջ���������ڵ�����ʱ����Ҫ��ʽ�ؽ����ջģ���������������ͬ������ʵ�ֿ��Կ�����Ĵ��롣

![](./Solution0094_4_01.png)
![](./Solution0094_4_02.png)
![](./Solution0094_4_03.png)
![](./Solution0094_4_04.png)
![](./Solution0094_4_05.png)
![](./Solution0094_4_06.png)
![](./Solution0094_4_07.png)
![](./Solution0094_4_08.png)
![](./Solution0094_4_09.png)
![](./Solution0094_4_10.png)
![](./Solution0094_4_11.png)
![](./Solution0094_4_12.png)
![](./Solution0094_4_13.png)
![](./Solution0094_4_14.png)

**����**

```C++
class Solution {
public:
    vector<int> inorderTraversal(TreeNode* root) {
        vector<int> res;
        stack<TreeNode*> stk;
        while (root != nullptr || !stk.empty()) {
            while (root != nullptr) {
                stk.push(root);
                root = root->left;
            }
            root = stk.top();
            stk.pop();
            res.push_back(root->val);
            root = root->right;
        }
        return res;
    }
};

```

```Java
class Solution {
    public List<Integer> inorderTraversal(TreeNode root) {
        List<Integer> res = new ArrayList<Integer>();
        Deque<TreeNode> stk = new LinkedList<TreeNode>();
        while (root != null || !stk.isEmpty()) {
            while (root != null) {
                stk.push(root);
                root = root.left;
            }
            root = stk.pop();
            res.add(root.val);
            root = root.right;
        }
        return res;
    }
}

```

```JavaScript
var inorderTraversal = function(root) {
    const res = [];
    const stk = [];
    while (root || stk.length) {
        while (root) {
            stk.push(root);
            root = root.left;
        }
        root = stk.pop();
        res.push(root.val);
        root = root.right;
    }
    return res;
};

```

```Golang
func inorderTraversal(root *TreeNode) (res []int) {
stack := []*TreeNode{}
for root != nil || len(stack) > 0 {
for root != nil {
stack = append(stack, root)
root = root.Left
}
root = stack[len(stack)-1]
stack = stack[:len(stack)-1]
res = append(res, root.Val)
root = root.Right
}
return
}

```

```C
int* inorderTraversal(struct TreeNode* root, int* returnSize) {
    *returnSize = 0;
    int* res = malloc(sizeof(int) * 501);
    struct TreeNode** stk = malloc(sizeof(struct TreeNode*) * 501);
    int top = 0;
    while (root != NULL || top > 0) {
        while (root != NULL) {
            stk[top++] = root;
            root = root->left;
        }
        root = stk[--top];
        res[(*returnSize)++] = root->val;
        root = root->right;
    }
    return res;
}

```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�O(n)������ n Ϊ�������ڵ�ĸ������������ı�����ÿ���ڵ�ᱻ����һ����ֻ�ᱻ����һ�Ρ�

-   �ռ临�Ӷȣ�O(n)���ռ临�Ӷ�ȡ����ջ��ȣ���ջ����ڶ�����Ϊһ����������»�ﵽ O(n) �ļ���
