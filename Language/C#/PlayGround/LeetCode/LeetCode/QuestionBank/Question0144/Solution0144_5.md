#### [](https://leetcode.cn/problems/binary-tree-preorder-traversal/solution/er-cha-shu-de-qian-xu-bian-li-by-leetcode-solution//#��������morris-����)��������Morris ����

**˼·���㷨**

��һ������ķ�������������ʱ���ڣ�ֻռ�ó����ռ���ʵ��ǰ����������ַ����� J. H. Morris �� 1979 ������ġ�Traversing Binary Trees Simply and Cheaply�����״��������˱���Ϊ Morris ������

Morris �����ĺ���˼�����������Ĵ�������ָ�룬ʵ�ֿռ俪���ļ�����������ǰ����������ܽ����£�

1.  �½���ʱ�ڵ㣬��ýڵ�Ϊ `root`��
    
2.  �����ǰ�ڵ�����ӽڵ�Ϊ�գ�����ǰ�ڵ����𰸣���������ǰ�ڵ�����ӽڵ㣻
    
3.  �����ǰ�ڵ�����ӽڵ㲻Ϊ�գ��ڵ�ǰ�ڵ�����������ҵ���ǰ�ڵ�����������µ�ǰ���ڵ㣺
    
    -   ���ǰ���ڵ�����ӽڵ�Ϊ�գ���ǰ���ڵ�����ӽڵ�����Ϊ��ǰ�ڵ㡣Ȼ�󽫵�ǰ�ڵ����𰸣�����ǰ���ڵ�����ӽڵ����Ϊ��ǰ�ڵ㡣��ǰ�ڵ����Ϊ��ǰ�ڵ�����ӽڵ㡣
        
    -   ���ǰ���ڵ�����ӽڵ�Ϊ��ǰ�ڵ㣬���������ӽڵ�������Ϊ�ա���ǰ�ڵ����Ϊ��ǰ�ڵ�����ӽڵ㡣
        
4.  �ظ����� 2 �Ͳ��� 3��ֱ������������
    

������������ Morris �����ķ�����ǰ������ö�����������ʵ������ʱ���볣���ռ�ı�����

**����**

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

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�O(n)������ n �Ƕ������Ľڵ�����û���������Ľڵ�ֻ������һ�Σ����������Ľڵ㱻�������Ρ�

-   �ռ临�Ӷȣ�O(1)��ֻ�����Ѿ����ڵ�ָ�루���Ŀ���ָ�룩�����ֻ��Ҫ�����Ķ���ռ䡣
