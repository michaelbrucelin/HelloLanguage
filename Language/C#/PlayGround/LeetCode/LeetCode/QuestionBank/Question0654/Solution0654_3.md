#### 方法二：单调栈

**思路与算法**

我们可以将题目中构造树的过程等价转换为下面的构造过程：

-   初始时，我们只有一个根节点，其中存储了整个数组；
    
-   在每一步操作中，我们可以「任选」一个存储了超过一个数的节点，找出其中的最大值并存储在该节点。最大值左侧的数组部分下放到该节点的左子节点，右侧的数组部分下放到该节点的右子节点；
    
-   如果所有的节点都恰好存储了一个数，那么构造结束。
    

由于最终构造出的是一棵树，因此无需按照题目的要求「递归」地进行构造，而是每次可以「任选」一个节点进行构造。这里可以类比一棵树的「深度优先搜索」和「广度优先搜索」，二者都可以起到遍历整棵树的效果。

既然可以任意进行选择，那么我们不妨每次选择数组中最大值**最大**的那个节点进行构造。这样一来，我们就可以保证按照数组中元素降序排序的顺序依次构造每个节点。因此：

> 当我们选择的节点中数组的最大值为 nums\[i\] 时，所有大于 nums\[i\] 的元素已经被构造过（即被单独放入某一个节点中），所有小于 nums\[i\] 的元素还没有被构造过。

这就说明：

> 在最终构造出的树上，以 nums\[i\] 为根节点的子树，在原数组中对应的区间，左边界为 **nums\[i\] 左侧第一个比它大的元素所在的位置**，右边界为 **nums\[i\] 右侧第一个比它大的元素所在的位置**。左右边界均为开边界。
> 
> 如果某一侧边界不存在，则那一侧边界为数组的边界。如果两侧边界均不存在，说明其为最大值，即根节点。

并且：

> nums\[i\] 的父结点是两个边界中较小的那个元素对应的节点。

因此，我们的任务变为：找出每一个元素左侧和右侧第一个比它大的元素所在的位置。这就是一个经典的单调栈问题了，可以参考 [503\. 下一个更大元素 II](https://leetcode.cn/problems/next-greater-element-ii/)。如果左侧的元素较小，那么该元素就是左侧元素的右子节点；如果右侧的元素较小，那么该元素就是右侧元素的左子节点。

**代码**

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

我们还可以把最后构造树的过程放进单调栈求解的步骤中，省去用来存储左右边界的数组。下面的代码理解起来较为困难，同一个节点的左右子树会被多次赋值，读者可以仔细品味其妙处所在。

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

**复杂度分析**

-   时间复杂度：O(n)，其中 nnn 是数组 nums 的长度。单调栈求解左右边界和构造树均需要 O(n) 的时间。
    
-   空间复杂度：O(n)，即为单调栈和数组 tree 需要使用的空间。
