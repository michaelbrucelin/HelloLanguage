## 线段树

抽象成区间求和问题后，涉及「单点修改」和「区间查询」，再结合节点数量为 1e3，可使用 `build` 4n 空间不带懒标记的线段树进行求解。

设计线段树节点 `Node` 包含属性：左节点下标 `l`、右节点下标 `r` 和当前区间 [l,r] 所对应的最值 val。

构建线段树的过程为基本的线段树模板内容，而构建答案树的过程与递归分治过程类型（将线性找最值过程用线段树优化）。

代码：

```Java
class Solution {
    class Node {
        int l, r, val;
        Node (int _l, int _r) {
            l = _l; r = _r;
        }
    }
    void build(int u, int l, int r) {
        tr[u] = new Node(l, r);
        if (l == r) return ;
        int mid = l + r >> 1;
        build(u << 1, l, mid);
        build(u << 1 | 1, mid + 1, r);
    }
    void update(int u, int x, int v) {
        if (tr[u].l == x && tr[u].r == x) {
            tr[u].val = Math.max(tr[u].val, v);
            return ;
        }
        int mid = tr[u].l + tr[u].r >> 1;
        if (x <= mid) update(u << 1, x, v);
        else update(u << 1 | 1, x, v);
        pushup(u);
    }
    int query(int u, int l, int r) {
        if (l <= tr[u].l && tr[u].r <= r) return tr[u].val;
        int mid = tr[u].l + tr[u].r >> 1, ans = 0;
        if (l <= mid) ans = query(u << 1, l, r);
        if (r > mid) ans = Math.max(ans, query(u << 1 | 1, l, r));
        return ans;
    }
    void pushup(int u) {
        tr[u].val = Math.max(tr[u << 1].val, tr[u << 1 | 1].val);
    }
    Node[] tr = new Node[4010];
    int[] hash = new int[1010];
    public TreeNode constructMaximumBinaryTree(int[] nums) {
        int n = nums.length;
        build(1, 1, n);
        for (int i = 0; i < n; i++) {
            hash[nums[i]] = i + 1;
            update(1, i + 1, nums[i]);
        }
        return dfs(nums, 1, n);
    }
    TreeNode dfs(int[] nums, int l, int r) {
        if (l > r) return null;
        int val = query(1, l, r), idx = hash[val];
        TreeNode ans = new TreeNode(val);
        ans.left = dfs(nums, l, idx - 1);
        ans.right = dfs(nums, idx + 1, r);
        return ans;
    }
}

```

```TypeScript
class TNode {
    l = 0; r = 0; val = 0;
    constructor (_l: number, _r: number) {
        this.l = _l; this.r = _r;
    }
}
const tr: TNode[] = new Array<TNode>(4010)
const hash: number[] = new Array<number>(1010)
function constructMaximumBinaryTree(nums: number[]): TreeNode | null {
    const n = nums.length
    build(1, 1, n)
    for (let i = 0; i < n; i++) {
        hash[nums[i]] = i + 1
        update(1, i + 1, nums[i])
    }
    return dfs(nums, 1, n)
};
function build(u: number, l: number, r: number): void {
    tr[u] = new TNode(l, r)
    if (l == r) return 
    const mid = l + r >> 1
    build(u << 1, l, mid)
    build(u << 1 | 1, mid + 1, r)
}
function update(u: number, x: number, v: number): void {
    if (tr[u].l == x && tr[u].r == x) {
        tr[u].val = Math.max(tr[u].val, v)
        return 
    }
    const mid = tr[u].l + tr[u].r >> 1
    if (x <= mid) update(u << 1, x, v)
    else update(u << 1 | 1, x, v)
    pushup(u)
}
function query(u: number, l: number, r: number): number {
    if (l <= tr[u].l && tr[u].r <= r) return tr[u].val
    let mid = tr[u].l + tr[u].r >> 1, ans = 0
    if (l <= mid) ans = query(u << 1, l, r)
    if (r > mid) ans = Math.max(ans, query(u << 1 | 1, l, r))
    return ans
}
function pushup(u: number): void {
    tr[u].val = Math.max(tr[u << 1].val, tr[u << 1 | 1].val)
}
function dfs(nums: number[], l: number, r: number): TreeNode {
    if (l > r) return null
    let val = query(1, l, r), idx = hash[val]
    const ans = new TreeNode(val)
    ans.left = dfs(nums, l, idx - 1)
    ans.right = dfs(nums, idx + 1, r)
    return ans
}


```

-   时间复杂度：构建线段树复杂度为 O(nlog⁡n)；构造答案树复杂度为 O(nlog⁡n)。整体复杂度为 O(nlog⁡n)
-   空间复杂度：O(n)
