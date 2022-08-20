#### ������������ջ

**˼·���㷨**

���ǿ��Խ���Ŀ�й������Ĺ��̵ȼ�ת��Ϊ����Ĺ�����̣�

-   ��ʼʱ������ֻ��һ�����ڵ㣬���д洢���������飻
    
-   ��ÿһ�������У����ǿ��ԡ���ѡ��һ���洢�˳���һ�����Ľڵ㣬�ҳ����е����ֵ���洢�ڸýڵ㡣���ֵ�������鲿���·ŵ��ýڵ�����ӽڵ㣬�Ҳ�����鲿���·ŵ��ýڵ�����ӽڵ㣻
    
-   ������еĽڵ㶼ǡ�ô洢��һ��������ô���������
    

�������չ��������һ������������谴����Ŀ��Ҫ�󡸵ݹ项�ؽ��й��죬����ÿ�ο��ԡ���ѡ��һ���ڵ���й��졣����������һ�����ġ���������������͡�������������������߶������𵽱�����������Ч����

��Ȼ�����������ѡ����ô���ǲ���ÿ��ѡ�����������ֵ**���**���Ǹ��ڵ���й��졣����һ�������ǾͿ��Ա�֤����������Ԫ�ؽ��������˳�����ι���ÿ���ڵ㡣��ˣ�

> ������ѡ��Ľڵ�����������ֵΪ nums\[i\] ʱ�����д��� nums\[i\] ��Ԫ���Ѿ����������������������ĳһ���ڵ��У�������С�� nums\[i\] ��Ԫ�ػ�û�б��������

���˵����

> �����չ���������ϣ��� nums\[i\] Ϊ���ڵ����������ԭ�����ж�Ӧ�����䣬��߽�Ϊ **nums\[i\] ����һ���������Ԫ�����ڵ�λ��**���ұ߽�Ϊ **nums\[i\] �Ҳ��һ���������Ԫ�����ڵ�λ��**�����ұ߽��Ϊ���߽硣
> 
> ���ĳһ��߽粻���ڣ�����һ��߽�Ϊ����ı߽硣�������߽�������ڣ�˵����Ϊ���ֵ�������ڵ㡣

���ң�

> nums\[i\] �ĸ�����������߽��н�С���Ǹ�Ԫ�ض�Ӧ�Ľڵ㡣

��ˣ����ǵ������Ϊ���ҳ�ÿһ��Ԫ�������Ҳ��һ���������Ԫ�����ڵ�λ�á������һ������ĵ���ջ�����ˣ����Բο� [503\. ��һ������Ԫ�� II](https://leetcode.cn/problems/next-greater-element-ii/)���������Ԫ�ؽ�С����ô��Ԫ�ؾ������Ԫ�ص����ӽڵ㣻����Ҳ��Ԫ�ؽ�С����ô��Ԫ�ؾ����Ҳ�Ԫ�ص����ӽڵ㡣

**����**

```C++
class Solution {
public:
    TreeNode* constructMaximumBinaryTree(vector<int>& nums) {
        int n = nums.size();
        vector<int> stk;
        vector<int> left(n, -1), right(n, -1);
        vector<TreeNode*> tree(n);
        for (int i = 0; i < n; ++i) {
            tree[i] = new TreeNode(nums[i]);
            while (!stk.empty() && nums[i] > nums[stk.back()]) {
                right[stk.back()] = i;
                stk.pop_back();
            }
            if (!stk.empty()) {
                left[i] = stk.back();
            }
            stk.push_back(i);
        }

        TreeNode* root = nullptr;
        for (int i = 0; i < n; ++i) {
            if (left[i] == -1 && right[i] == -1) {
                root = tree[i];
            }
            else if (right[i] == -1 || (left[i] != -1 && nums[left[i]] < nums[right[i]])) {
                tree[left[i]]->right = tree[i];
            }
            else {
                tree[right[i]]->left = tree[i];
            }
        }
        return root;
    }
};

```

```Java
class Solution {
    public TreeNode constructMaximumBinaryTree(int[] nums) {
        int n = nums.length;
        Deque<Integer> stack = new ArrayDeque<Integer>();
        int[] left = new int[n];
        int[] right = new int[n];
        Arrays.fill(left, -1);
        Arrays.fill(right, -1);
        TreeNode[] tree = new TreeNode[n];
        for (int i = 0; i < n; ++i) {
            tree[i] = new TreeNode(nums[i]);
            while (!stack.isEmpty() && nums[i] > nums[stack.peek()]) {
                right[stack.pop()] = i;
            }
            if (!stack.isEmpty()) {
                left[i] = stack.peek();
            }
            stack.push(i);
        }

        TreeNode root = null;
        for (int i = 0; i < n; ++i) {
            if (left[i] == -1 && right[i] == -1) {
                root = tree[i];
            } else if (right[i] == -1 || (left[i] != -1 && nums[left[i]] < nums[right[i]])) {
                tree[left[i]].right = tree[i];
            } else {
                tree[right[i]].left = tree[i];
            }
        }
        return root;
    }
}

```

```C#
public class Solution {
    public TreeNode ConstructMaximumBinaryTree(int[] nums) {
        int n = nums.Length;
        Stack<int> stack = new Stack<int>();
        int[] left = new int[n];
        int[] right = new int[n];
        Array.Fill(left, -1);
        Array.Fill(right, -1);
        TreeNode[] tree = new TreeNode[n];
        for (int i = 0; i < n; ++i) {
            tree[i] = new TreeNode(nums[i]);
            while (stack.Count > 0 && nums[i] > nums[stack.Peek()]) {
                right[stack.Pop()] = i;
            }
            if (stack.Count > 0) {
                left[i] = stack.Peek();
            }
            stack.Push(i);
        }

        TreeNode root = null;
        for (int i = 0; i < n; ++i) {
            if (left[i] == -1 && right[i] == -1) {
                root = tree[i];
            } else if (right[i] == -1 || (left[i] != -1 && nums[left[i]] < nums[right[i]])) {
                tree[left[i]].right = tree[i];
            } else {
                tree[right[i]].left = tree[i];
            }
        }
        return root;
    }
}

```

```Python3
class Solution:
    def constructMaximumBinaryTree(self, nums: List[int]) -> Optional[TreeNode]:
        n = len(nums)
        stk = list()
        left, right = [-1] * n, [-1] * n
        tree = [None] * n

        for i in range(n):
            tree[i] = TreeNode(nums[i])
            while stk and nums[i] > nums[stk[-1]]:
                right[stk[-1]] = i
                stk.pop()
            if stk:
                left[i] = stk[-1]
            stk.append(i)
        
        root = None
        for i in range(n):
            if left[i] == right[i] == -1:
                root = tree[i]
            elif right[i] == -1 or (left[i] != -1 and nums[left[i]] < nums[right[i]]):
                tree[left[i]].right = tree[i]
            else:
                tree[right[i]].left = tree[i]
        
        return root

```

```C
struct TreeNode* constructMaximumBinaryTree(int* nums, int numsSize) {
    int *stack = (int *)malloc(sizeof(int) * numsSize);
    int *left = (int *)malloc(sizeof(int) * numsSize);
    int *right = (int *)malloc(sizeof(int) * numsSize);
    memset(left, -1, sizeof(int) * numsSize);
    memset(right, -1, sizeof(int) * numsSize);
    struct TreeNode** tree = (struct TreeNode **)malloc(sizeof(struct TreeNode*) * numsSize);
    int top = 0;
    for (int i = 0; i < numsSize; ++i) {
        tree[i] = (struct TreeNode*)malloc(sizeof(struct TreeNode));
        tree[i]->val = nums[i];
        tree[i]->left = NULL;
        tree[i]->right = NULL;
        while (top > 0 && nums[i] > nums[stack[top - 1]]) {
            right[stack[top - 1]] = i;
            top--;
        }
        if (top > 0) {
            left[i] = stack[top - 1];
        }
        stack[top++] = i;
    }

    struct TreeNode* root = NULL;
    for (int i = 0; i < numsSize; ++i) {
        if (left[i] == -1 && right[i] == -1) {
            root = tree[i];
        }
        else if (right[i] == -1 || (left[i] != -1 && nums[left[i]] < nums[right[i]])) {
            tree[left[i]]->right = tree[i];
        }
        else {
            tree[right[i]]->left = tree[i];
        }
    }
    free(left);
    free(right);
    free(stack);
    return root;
}

```

```JavaScript
var constructMaximumBinaryTree = function(nums) {
    const n = nums.length;
    const stack = [];
    const left = new Array(n).fill(-1);
    const right = new Array(n).fill(-1);
    const tree = new Array(n).fill(-1);
    for (let i = 0; i < n; ++i) {
        tree[i] = new TreeNode(nums[i]);
        while (stack.length && nums[i] > nums[stack[stack.length - 1]]) {
            right[stack.pop()] = i;
        }
        if (stack.length) {
            left[i] = stack[stack.length - 1];
        }
        stack.push(i);
    }

    let root = null;
    for (let i = 0; i < n; ++i) {
        if (left[i] === -1 && right[i] === -1) {
            root = tree[i];
        } else if (right[i] === -1 || (left[i] !== -1 && nums[left[i]] < nums[right[i]])) {
            tree[left[i]].right = tree[i];
        } else {
            tree[right[i]].left = tree[i];
        }
    }
    return root;
};

```

```Golang
func constructMaximumBinaryTree(nums []int) *TreeNode {
    n := len(nums)
    left := make([]int, n)
    right := make([]int, n)
    for i := range right {
        right[i] = -1
    }
    tree := make([]*TreeNode, n)
    stk := []int{-1}
    for i, num := range nums {
        tree[i] = &TreeNode{Val: num}
        for len(stk) > 1 && num > nums[stk[len(stk)-1]] {
            right[stk[len(stk)-1]] = i
            stk = stk[:len(stk)-1]
        }
        left[i] = stk[len(stk)-1]
        stk = append(stk, i)
    }

    var root *TreeNode
    for i, node := range tree {
        l, r := left[i], right[i]
        if l == -1 && r == -1 {
            root = node
        } else if r == -1 || l != -1 && nums[l] < nums[r] {
            tree[l].Right = node
        } else {
            tree[r].Left = node
        }
    }
    return root
}

```

���ǻ����԰���������Ĺ��̷Ž�����ջ���Ĳ����У�ʡȥ�����洢���ұ߽�����顣����Ĵ������������Ϊ���ѣ�ͬһ���ڵ�����������ᱻ��θ�ֵ�����߿�����ϸƷζ������ڡ�

```C++
class Solution {
public:
    TreeNode* constructMaximumBinaryTree(vector<int>& nums) {
        int n = nums.size();
        vector<int> stk;
        vector<TreeNode*> tree(n);
        for (int i = 0; i < n; ++i) {
            tree[i] = new TreeNode(nums[i]);
            while (!stk.empty() && nums[i] > nums[stk.back()]) {
                tree[i]->left = tree[stk.back()];
                stk.pop_back();
            }
            if (!stk.empty()) {
                tree[stk.back()]->right = tree[i];
            }
            stk.push_back(i);
        }
        return tree[stk[0]];
    }
};

```

```Java
class Solution {
    public TreeNode constructMaximumBinaryTree(int[] nums) {
        int n = nums.length;
        List<Integer> stack = new ArrayList<Integer>();
        TreeNode[] tree = new TreeNode[n];
        for (int i = 0; i < n; ++i) {
            tree[i] = new TreeNode(nums[i]);
            while (!stack.isEmpty() && nums[i] > nums[stack.get(stack.size() - 1)]) {
                tree[i].left = tree[stack.get(stack.size() - 1)];
                stack.remove(stack.size() - 1);
            }
            if (!stack.isEmpty()) {
                tree[stack.get(stack.size() - 1)].right = tree[i];
            }
            stack.add(i);
        }
        return tree[stack.get(0)];
    }
}

```

```C#
public class Solution {
    public TreeNode ConstructMaximumBinaryTree(int[] nums) {
        int n = nums.Length;
        IList<int> stack = new List<int>();
        TreeNode[] tree = new TreeNode[n];
        for (int i = 0; i < n; ++i) {
            tree[i] = new TreeNode(nums[i]);
            while (stack.Count > 0 && nums[i] > nums[stack[stack.Count - 1]]) {
                tree[i].left = tree[stack[stack.Count - 1]];
                stack.RemoveAt(stack.Count - 1);
            }
            if (stack.Count > 0) {
                tree[stack[stack.Count - 1]].right = tree[i];
            }
            stack.Add(i);
        }
        return tree[stack[0]];
    }
}

```

```Python3
class Solution:
    def constructMaximumBinaryTree(self, nums: List[int]) -> Optional[TreeNode]:
        n = len(nums)
        stk = list()
        tree = [None] * n

        for i in range(n):
            tree[i] = TreeNode(nums[i])
            while stk and nums[i] > nums[stk[-1]]:
                tree[i].left = tree[stk[-1]]
                stk.pop()
            if stk:
                tree[stk[-1]].right = tree[i]
            stk.append(i)
        
        return tree[stk[0]]

```

```C
struct TreeNode* constructMaximumBinaryTree(int* nums, int numsSize) {
    int *stack = (int *)malloc(sizeof(int) * numsSize);
    struct TreeNode** tree = (struct TreeNode **)malloc(sizeof(struct TreeNode*) * numsSize);
    int top = 0;
    for (int i = 0; i < numsSize; ++i) {
        tree[i] = (struct TreeNode *)malloc(sizeof(struct TreeNode));
        tree[i]->val = nums[i];
        tree[i]->left = NULL;
        tree[i]->right = NULL;
        while (top > 0 && nums[i] > nums[stack[top - 1]]) {
            tree[i]->left = tree[stack[top - 1]];
            top--;
        }
        if (top > 0) {
            tree[stack[top - 1]]->right = tree[i];
        }
        stack[top++] = i;
    }
    int root = stack[0];
    free(stack);
    return tree[root];
}

```

```JavaScript
var constructMaximumBinaryTree = function(nums) {
    const n = nums.length;
    const stack = [];
    const tree = new Array(n).fill(0);
    for (let i = 0; i < n; ++i) {
        tree[i] = new TreeNode(nums[i]);
        while (stack.length && nums[i] > nums[stack[stack.length - 1]]) {
            tree[i].left = tree[stack[stack.length - 1]];
            stack.pop();
        }
        if (stack.length) {
            tree[stack[stack.length - 1]].right = tree[i];
        }
        stack.push(i);
    }
    return tree[stack[0]];
};

```

```Golang
func constructMaximumBinaryTree(nums []int) *TreeNode {
    tree := make([]*TreeNode, len(nums))
    stk := []int{}
    for i, num := range nums {
        tree[i] = &TreeNode{Val: num}
        for len(stk) > 0 && num > nums[stk[len(stk)-1]] {
            tree[i].Left = tree[stk[len(stk)-1]]
            stk = stk[:len(stk)-1]
        }
        if len(stk) > 0 {
            tree[stk[len(stk)-1]].Right = tree[i]
        }
        stk = append(stk, i)
    }
    return tree[stk[0]]
}

```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�O(n)������ nnn ������ nums �ĳ��ȡ�����ջ������ұ߽�͹���������Ҫ O(n) ��ʱ�䡣
    
-   �ռ临�Ӷȣ�O(n)����Ϊ����ջ������ tree ��Ҫʹ�õĿռ䡣
