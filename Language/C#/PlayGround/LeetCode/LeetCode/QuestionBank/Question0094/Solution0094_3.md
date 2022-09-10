#### [](https://leetcode.cn/problems/binary-tree-inorder-traversal/solution/er-cha-shu-de-zhong-xu-bian-li-by-leetcode-solutio//#����һ���ݹ�)����һ���ݹ�

**˼·���㷨**

����������Ҫ�˽�ʲô�Ƕ�������������������շ����������������ڵ㡪���������ķ�ʽ��������������ڷ���������������������ʱ�����ǰ���ͬ���ķ�ʽ������ֱ���������������������������������Ȼ���еݹ�����ʣ����ǿ���ֱ���õݹ麯����ģ����һ���̡�

���� `inorder(root)` ��ʾ��ǰ������ root �ڵ�Ĵ𰸣���ô���ն��壬����ֻҪ�ݹ���� `inorder(root.left)` ������ root �ڵ����������Ȼ�� root �ڵ��ֵ����𰸣��ٵݹ����`inorder(root.right)` ������ root �ڵ�����������ɣ��ݹ���ֹ������Ϊ�����սڵ㡣

**����**

```C++
class Solution {
public:
    void inorder(TreeNode* root, vector<int>& res) {
        if (!root) {
            return;
        }
        inorder(root->left, res);
        res.push_back(root->val);
        inorder(root->right, res);
    }
    vector<int> inorderTraversal(TreeNode* root) {
        vector<int> res;
        inorder(root, res);
        return res;
    }
};

```

```Java
class Solution {
    public List<Integer> inorderTraversal(TreeNode root) {
        List<Integer> res = new ArrayList<Integer>();
        inorder(root, res);
        return res;
    }

    public void inorder(TreeNode root, List<Integer> res) {
        if (root == null) {
            return;
        }
        inorder(root.left, res);
        res.add(root.val);
        inorder(root.right, res);
    }
}

```

```JavaScript
var inorderTraversal = function(root) {
    const res = [];
    const inorder = (root) => {
        if (!root) {
            return;
        }
        inorder(root.left);
        res.push(root.val);
        inorder(root.right);
    }
    inorder(root);
    return res;
};

```

```Golang
func inorderTraversal(root *TreeNode) (res []int) {
var inorder func(node *TreeNode)
inorder = func(node *TreeNode) {
if node == nil {
return
}
inorder(node.Left)
res = append(res, node.Val)
inorder(node.Right)
}
inorder(root)
return
}

```

```C
void inorder(struct TreeNode* root, int* res, int* resSize) {
    if (!root) {
        return;
    }
    inorder(root->left, res, resSize);
    res[(*resSize)++] = root->val;
    inorder(root->right, res, resSize);
}

int* inorderTraversal(struct TreeNode* root, int* returnSize) {
    int* res = malloc(sizeof(int) * 501);
    *returnSize = 0;
    inorder(root, res, returnSize);
    return res;
}

```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�O(n)������ n Ϊ�������ڵ�ĸ������������ı�����ÿ���ڵ�ᱻ����һ����ֻ�ᱻ����һ�Ρ�

-   �ռ临�Ӷȣ�O(n)���ռ临�Ӷ�ȡ���ڵݹ��ջ��ȣ���ջ����ڶ�����Ϊһ����������»�ﵽ O(n) �ļ���
