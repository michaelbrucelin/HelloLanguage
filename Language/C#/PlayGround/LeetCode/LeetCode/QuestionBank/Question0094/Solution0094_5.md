#### [](https://leetcode.cn/problems/binary-tree-inorder-traversal/solution/er-cha-shu-de-zhong-xu-bian-li-by-leetcode-solutio//#��������morris-�������)��������Morris �������

**˼·���㷨**

**Morris �����㷨**����һ�ֱ����������ķ��������ܽ��ǵݹ����������ռ临�ӶȽ�Ϊ O(1)��

**Morris �����㷨**���岽�����£����赱ǰ�������Ľڵ�Ϊ x����

1.  ��� x �����ӣ��Ƚ� x ��ֵ��������飬�ٷ��� x ���Һ��ӣ��� x\=x.right��
2.  ��� x �����ӣ����ҵ� x �����������ҵĽڵ㣨**��������������������һ���ڵ㣬xxx ����������е�ǰ���ڵ�**�������Ǽ�Ϊ predecessor������ predecessor ���Һ����Ƿ�Ϊ�գ��������²�����
    -   ��� predecessor ���Һ���Ϊ�գ������Һ���ָ�� x��Ȼ����� x �����ӣ��� x\=x.left��
    -   ��� predecessor ���Һ��Ӳ�Ϊ�գ����ʱ���Һ���ָ�� x��˵�������Ѿ������� x �������������ǽ� predecessor ���Һ����ÿգ��� x ��ֵ��������飬Ȼ����� x ���Һ��ӣ��� x\=x.right��
3.  �ظ�����������ֱ����������������

![](./assets/img/Solution0094_5_01.png)
![](./assets/img/Solution0094_5_02.png)
![](./assets/img/Solution0094_5_03.png)
![](./assets/img/Solution0094_5_04.png)
![](./assets/img/Solution0094_5_05.png)
![](./assets/img/Solution0094_5_06.png)
![](./assets/img/Solution0094_5_07.png)
![](./assets/img/Solution0094_5_08.png)
![](./assets/img/Solution0094_5_09.png)
![](./assets/img/Solution0094_5_10.png)
![](./assets/img/Solution0094_5_11.png)
![](./assets/img/Solution0094_5_12.png)
![](./assets/img/Solution0094_5_13.png)
![](./assets/img/Solution0094_5_14.png)
![](./assets/img/Solution0094_5_15.png)
![](./assets/img/Solution0094_5_16.png)
![](./assets/img/Solution0094_5_17.png)
![](./assets/img/Solution0094_5_18.png)
![](./assets/img/Solution0094_5_19.png)

��ʵ�����������ǾͶ���һ�������赱ǰ�������Ľڵ�Ϊ x���� x �������������ұߵĽڵ���Һ���ָ�� x��������������������ɺ�����ͨ�����ָ���߻��� x������ͨ�����ָ��֪�������Ѿ��������������������������ͨ��ջ��ά����ʡȥ��ջ�Ŀռ临�Ӷȡ�

**����**

```C++
class Solution {
public:
    vector<int> inorderTraversal(TreeNode* root) {
        vector<int> res;
        TreeNode *predecessor = nullptr;

        while (root != nullptr) {
            if (root->left != nullptr) {
                // predecessor �ڵ���ǵ�ǰ root �ڵ�������һ����Ȼ��һֱ���������޷���Ϊֹ
                predecessor = root->left;
                while (predecessor->right != nullptr && predecessor->right != root) {
                    predecessor = predecessor->right;
                }
                
                // �� predecessor ����ָ��ָ�� root����������������
                if (predecessor->right == nullptr) {
                    predecessor->right = root;
                    root = root->left;
                }
                // ˵���������Ѿ��������ˣ�������Ҫ�Ͽ�����
                else {
                    res.push_back(root->val);
                    predecessor->right = nullptr;
                    root = root->right;
                }
            }
            // ���û�����ӣ���ֱ�ӷ����Һ���
            else {
                res.push_back(root->val);
                root = root->right;
            }
        }
        return res;
    }
};
```

```Java
class Solution {
    public List<Integer> inorderTraversal(TreeNode root) {
        List<Integer> res = new ArrayList<Integer>();
        TreeNode predecessor = null;

        while (root != null) {
            if (root.left != null) {
                // predecessor �ڵ���ǵ�ǰ root �ڵ�������һ����Ȼ��һֱ���������޷���Ϊֹ
                predecessor = root.left;
                while (predecessor.right != null && predecessor.right != root) {
                    predecessor = predecessor.right;
                }
                
                // �� predecessor ����ָ��ָ�� root����������������
                if (predecessor.right == null) {
                    predecessor.right = root;
                    root = root.left;
                }
                // ˵���������Ѿ��������ˣ�������Ҫ�Ͽ�����
                else {
                    res.add(root.val);
                    predecessor.right = null;
                    root = root.right;
                }
            }
            // ���û�����ӣ���ֱ�ӷ����Һ���
            else {
                res.add(root.val);
                root = root.right;
            }
        }
        return res;
    }
}
```

```JavaScript
var inorderTraversal = function(root) {
    const res = [];
    let predecessor = null;

    while (root) {
        if (root.left) {
            // predecessor �ڵ���ǵ�ǰ root �ڵ�������һ����Ȼ��һֱ���������޷���Ϊֹ
            predecessor = root.left;
            while (predecessor.right && predecessor.right !== root) {
                predecessor = predecessor.right;
            }

            // �� predecessor ����ָ��ָ�� root����������������
            if (!predecessor.right) {
                predecessor.right = root;
                root = root.left;
            }
            // ˵���������Ѿ��������ˣ�������Ҫ�Ͽ�����
            else {
                res.push(root.val);
                predecessor.right = null;
                root = root.right;
            }
        }
        // ���û�����ӣ���ֱ�ӷ����Һ���
        else {
            res.push(root.val);
            root = root.right;
        }
    }

    return res;
};
```

```Golang
func inorderTraversal(root *TreeNode) (res []int) {
for root != nil {
if root.Left != nil {
// predecessor �ڵ��ʾ��ǰ root �ڵ�������һ����Ȼ��һֱ���������޷���Ϊֹ�Ľڵ�
predecessor := root.Left
for predecessor.Right != nil && predecessor.Right != root {
// ����������û�����ù�ָ�� root�������������
predecessor = predecessor.Right
}
if predecessor.Right == nil {
// �� predecessor ����ָ��ָ�� root��������������������� root.Left �󣬾���ͨ�����ָ��ص� root
predecessor.Right = root
// ����������
root = root.Left
} else { // predecessor ����ָ���Ѿ�ָ���� root�����ʾ������ root.Left �Ѿ���������
res = append(res, root.Val)
// �ָ�ԭ��
predecessor.Right = nil
// ����������
root = root.Right
}
} else { // û��������
res = append(res, root.Val)
// �����������������������
// ��û�����������������������ѱ����꣬root ��ͨ��֮ǰ���õ�ָ��ص���������ĸ��ڵ�
root = root.Right
}
}
return
}
```

```C
int* inorderTraversal(struct TreeNode* root, int* returnSize) {
    int* res = malloc(sizeof(int) * 501);
    *returnSize = 0;
    struct TreeNode* predecessor = NULL;

    while (root != NULL) {
        if (root->left != NULL) {
            // predecessor �ڵ���ǵ�ǰ root �ڵ�������һ����Ȼ��һֱ���������޷���Ϊֹ
            predecessor = root->left;
            while (predecessor->right != NULL && predecessor->right != root) {
                predecessor = predecessor->right;
            }

            // �� predecessor ����ָ��ָ�� root����������������
            if (predecessor->right == NULL) {
                predecessor->right = root;
                root = root->left;
            }
            // ˵���������Ѿ��������ˣ�������Ҫ�Ͽ�����
            else {
                res[(*returnSize)++] = root->val;
                predecessor->right = NULL;
                root = root->right;
            }
        }
        // ���û�����ӣ���ֱ�ӷ����Һ���
        else {
            res[(*returnSize)++] = root->val;
            root = root->right;
        }
    }
    return res;
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�O(n)������ n Ϊ�����������Ľڵ������Morris ������ÿ���ڵ�ᱻ�������Σ������ʱ�临�Ӷ�Ϊ O(2n)\=O(n)��
-   �ռ临�Ӷȣ�O(1)��
