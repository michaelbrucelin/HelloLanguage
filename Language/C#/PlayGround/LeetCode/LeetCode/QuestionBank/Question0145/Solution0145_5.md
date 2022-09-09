#### [](https://leetcode.cn/problems/binary-tree-postorder-traversal//#��������morris-����)��������Morris ����

**˼·���㷨**

��һ������ķ�������������ʱ���ڣ�ֻռ�ó����ռ���ʵ�ֺ�����������ַ����� J. H. Morris �� 1979 ������ġ�Traversing Binary Trees Simply and Cheaply�����״��������˱���Ϊ Morris ������

Morris �����ĺ���˼�����������Ĵ�������ָ�룬ʵ�ֿռ俪���ļ����������������������ܽ����£�

1.  �½���ʱ�ڵ㣬��ýڵ�Ϊ `root`��

2.  �����ǰ�ڵ�����ӽڵ�Ϊ�գ��������ǰ�ڵ�����ӽڵ㣻

3.  �����ǰ�ڵ�����ӽڵ㲻Ϊ�գ��ڵ�ǰ�ڵ�����������ҵ���ǰ�ڵ�����������µ�ǰ���ڵ㣻

    -   ���ǰ���ڵ�����ӽڵ�Ϊ�գ���ǰ���ڵ�����ӽڵ�����Ϊ��ǰ�ڵ㣬��ǰ�ڵ����Ϊ��ǰ�ڵ�����ӽڵ㡣

    -   ���ǰ���ڵ�����ӽڵ�Ϊ��ǰ�ڵ㣬���������ӽڵ�������Ϊ�ա���������ӵ�ǰ�ڵ�����ӽڵ㵽��ǰ���ڵ�����·���ϵ����нڵ㡣��ǰ�ڵ����Ϊ��ǰ�ڵ�����ӽڵ㡣

4.  �ظ����� 2 �Ͳ��� 3��ֱ������������


������������ Morris �����ķ�������������ö���������������ʵ������ʱ���볣���ռ�ı�����

**����**

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

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�O(n)������ n �Ƕ������Ľڵ�����û���������Ľڵ�ֻ������һ�Σ����������Ľڵ㱻�������Ρ�

-   �ռ临�Ӷȣ�O(1)��ֻ�����Ѿ����ڵ�ָ�루���Ŀ���ָ�룩�����ֻ��Ҫ�����Ķ���ռ䡣
