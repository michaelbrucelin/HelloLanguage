#### 方法一：深度优先搜索

**思路与算法**

我们可以通过深度优先搜索来解决此题。首先通过深度优先搜索来得到二叉树的高度 height（注意高度从 0 开始），然后创建一个行数为 m\=height+1，列数为 n\=2^height+1^−1 的答案数组 res 放置节点的值（字符串形式）。根节点的值应当放在当前空间的第一行正中间。根节点所在的行与列会将剩余空间划分为两部分（左下部分和右下部分），然后递归地将左子树输出在左下部分空间，右子树输出在右下部分空间即可。

**代码**

```Python3
class Solution:
    def printTree(self, root: Optional[TreeNode]) -> List[List[str]]:
        def calDepth(node: Optional[TreeNode]) -> int:
            return max(calDepth(node.left) + 1 if node.left else 0, calDepth(node.right) + 1 if node.right else 0)
        height = calDepth(root)

        m = height + 1
        n = 2 ** m - 1
        ans = [[''] * n for _ in range(m)]
        def dfs(node: Optional[TreeNode], r: int, c: int) -> None:
            ans[r][c] = str(node.val)
            if node.left:
                dfs(node.left, r + 1, c - 2 ** (height - r - 1))
            if node.right:
                dfs(node.right, r + 1, c + 2 ** (height - r - 1))
        dfs(root, 0, (n - 1) // 2)
        return ans

```

```C++
class Solution {
public:
    int calDepth(TreeNode* root) {
        int h = 0;
        if (root->left) {
            h = max(h, calDepth(root->left) + 1);
        }
        if (root->right) {
            h = max(h, calDepth(root->right) + 1);
        }
        return h;
    }

    void dfs(vector<vector<string>>& res, TreeNode* root, int r, int c, const int& height) {
        res[r][c] = to_string(root->val);
        if (root->left) {
            dfs(res, root->left, r + 1, c - (1 << (height - r - 1)), height);
        }
        if (root->right) {
            dfs(res, root->right, r + 1, c + (1 << (height - r - 1)), height);
        }
    }

    vector<vector<string>> printTree(TreeNode* root) {
        int height = calDepth(root);
        int m = height + 1;
        int n = (1 << (height + 1)) - 1;
        vector<vector<string>> res(m, vector<string>(n, ""));
        dfs(res, root, 0, (n - 1) / 2, height);
        return res;
    }
};

```

```Java
class Solution {
    public List<List<String>> printTree(TreeNode root) {
        int height = calDepth(root);
        int m = height + 1;
        int n = (1 << (height + 1)) - 1;
        List<List<String>> res = new ArrayList<List<String>>();
        for (int i = 0; i < m; i++) {
            List<String> row = new ArrayList<String>();
            for (int j = 0; j < n; j++) {
                row.add("");
            }
            res.add(row);
        }
        dfs(res, root, 0, (n - 1) / 2, height);
        return res;
    }

    public int calDepth(TreeNode root) {
        int h = 0;
        if (root.left != null) {
            h = Math.max(h, calDepth(root.left) + 1);
        }
        if (root.right != null) {
            h = Math.max(h, calDepth(root.right) + 1);
        }
        return h;
    }

    public void dfs(List<List<String>> res, TreeNode root, int r, int c, int height) {
        res.get(r).set(c, Integer.toString(root.val));
        if (root.left != null) {
            dfs(res, root.left, r + 1, c - (1 << (height - r - 1)), height);
        }
        if (root.right != null) {
            dfs(res, root.right, r + 1, c + (1 << (height - r - 1)), height);
        }
    }
}

```

```C#
public class Solution {
    public IList<IList<string>> PrintTree(TreeNode root) {
        int height = CalDepth(root);
        int m = height + 1;
        int n = (1 << (height + 1)) - 1;
        IList<IList<string>> res = new List<IList<string>>();
        for (int i = 0; i < m; i++) {
            IList<string> row = new List<string>();
            for (int j = 0; j < n; j++) {
                row.Add("");
            }
            res.Add(row);
        }
        DFS(res, root, 0, (n - 1) / 2, height);
        return res;
    }

    public int CalDepth(TreeNode root) {
        int h = 0;
        if (root.left != null) {
            h = Math.Max(h, CalDepth(root.left) + 1);
        }
        if (root.right != null) {
            h = Math.Max(h, CalDepth(root.right) + 1);
        }
        return h;
    }

    public void DFS(IList<IList<string>> res, TreeNode root, int r, int c, int height) {
        res[r][c] = root.val.ToString();
        if (root.left != null) {
            DFS(res, root.left, r + 1, c - (1 << (height - r - 1)), height);
        }
        if (root.right != null) {
            DFS(res, root.right, r + 1, c + (1 << (height - r - 1)), height);
        }
    }
}

```

```C
#define MAX(a, b) ((a) > (b) ? (a) : (b))
#define MAX_VAL_LEN 32

int calDepth(struct TreeNode* root) {
    int h = 0;
    if (root->left) {
        h = MAX(h, calDepth(root->left) + 1);
    }
    if (root->right) {
        h = MAX(h, calDepth(root->right) + 1);
    }
    return h;
}

void dfs(char ***res, struct TreeNode* root, int r, int c, const int height) {
    sprintf(res[r][c], "%d", root->val);
    if (root->left) {
        dfs(res, root->left, r + 1, c - (1 << (height - r - 1)), height);
    }
    if (root->right) {
        dfs(res, root->right, r + 1, c + (1 << (height - r - 1)), height);
    }
}

char ***printTree(struct TreeNode* root, int* returnSize, int** returnColumnSizes) {
    int height = calDepth(root);
    int m = height + 1;
    int n = (1 << (height + 1)) - 1;
    char ***res = (char ***)malloc(sizeof(char **) * m);
    for (int i = 0; i < m; i++) {
        res[i] = (char **)malloc(sizeof(char *) * n);
        for (int j = 0; j < n; j++) {
            res[i][j] = (char *)malloc(sizeof(char) * MAX_VAL_LEN);
            res[i][j][0] = '\0';
        }
    }
    dfs(res, root, 0, (n - 1) / 2, height);
    *returnSize = m;
    *returnColumnSizes = (int *)malloc(sizeof(int) * m);
    for (int i = 0; i < m; i++) {
        (*returnColumnSizes)[i] = n;
    }
    return res;
}

```

```Golang
func calDepth(node *TreeNode) int {
    h := 0
    if node.Left != nil {
        h = calDepth(node.Left) + 1
    }
    if node.Right != nil {
        h = max(h, calDepth(node.Right)+1)
    }
    return h
}

func printTree(root *TreeNode) [][]string {
    height := calDepth(root)
    m := height + 1
    n := 1<<m - 1
    ans := make([][]string, m)
    for i := range ans {
        ans[i] = make([]string, n)
    }
    var dfs func(*TreeNode, int, int)
    dfs = func(node *TreeNode, r, c int) {
        ans[r][c] = strconv.Itoa(node.Val)
        if node.Left != nil {
            dfs(node.Left, r+1, c-1<<(height-r-1))
        }
        if node.Right != nil {
            dfs(node.Right, r+1, c+1<<(height-r-1))
        }
    }
    dfs(root, 0, (n-1)/2)
    return ans
}

func max(a, b int) int {
    if b > a {
        return b
    }
    return a
}

```

```JavaScript
var printTree = function(root) {
    const calDepth = (root) => {
        let h = 0;
        if (root.left) {
            h = Math.max(h, calDepth(root.left) + 1);
        }
        if (root.right) {
            h = Math.max(h, calDepth(root.right) + 1);
        }
        return h;
    }

    const dfs = (res, root, r, c, height) => {
        res[r][c] = root.val.toString();
        if (root.left) {
            dfs(res, root.left, r + 1, c - (1 << (height - r - 1)), height);
        }
        if (root.right) {
            dfs(res, root.right, r + 1, c + (1 << (height - r - 1)), height);
        }
    }

    const height = calDepth(root);
    const m = height + 1;
    const n = (1 << (height + 1)) - 1;
    const res = new Array(m).fill(0).map(() => new Array(n).fill(''));
    dfs(res, root, 0, Math.floor((n - 1) / 2), height);
    return res;
};

```

**复杂度分析**

-   时间复杂度：O(height×2^height^)，其中 height 是二叉树的高度。需要填充 (height+1)×(2^height+1^−1) 的数组。
    
-   空间复杂度：O(height)，其中 height 是二叉树的高度。空间复杂度主要是递归调用的栈空间，取决于二叉树的高度。注意返回值不计入空间复杂度。
