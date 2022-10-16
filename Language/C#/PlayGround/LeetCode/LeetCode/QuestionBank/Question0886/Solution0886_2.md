#### [](https://leetcode.cn/problems/possible-bipartition/solution/ke-neng-de-er-fen-fa-by-leetcode-solutio-guo7//#方法一：深度优先搜索)方法一：深度优先搜索

**思路与算法**

首先题目给定 n 个人为一组（编号为 1,2,…,n），其中 n 为偶数，并给出数组 dislike，其中 dislike[i]={ai,bi} 表示编号 ai 的用户不喜欢用户 bi，1≤ai<bi≤n。现在判断是否能将 n 个人分成两组，并满足当一个人不喜欢某一个人时，该两人不在同一组中出现。

我们可以尝试用「染色法」来解决问题：假设第一组中的人是红色，第二组中的人为蓝色。我们依次遍历每一个人，如果当前的人没有被分组，就将其分到第一组（即染为红色），那么这个人不喜欢的人必须分到第二组中（染为蓝色）。然后任何新被分到第二组中的人，其不喜欢的人必须被分到第一组，依此类推。如果在染色的过程中存在冲突，就表示这个任务是不可能完成的，否则说明染色的过程有效（即存在合法的分组方案）。

**代码**

```Python
class Solution:
    def possibleBipartition(self, n: int, dislikes: List[List[int]]) -> bool:
        g = [[] for _ in range(n)]
        for x, y in dislikes:
            g[x - 1].append(y - 1)
            g[y - 1].append(x - 1)
        color = [0] * n  # color[x] = 0 表示未访问节点 x
        def dfs(x: int, c: int) -> bool:
            color[x] = c
            return all(color[y] != c and (color[y] or dfs(y, -c)) for y in g[x])
        return all(c or dfs(i, 1) for i, c in enumerate(color))
```

```C++
class Solution {
public:
    bool dfs(int curnode, int nowcolor, vector<int>& color, const vector<vector<int>>& g) {
        color[curnode] = nowcolor;
        for (auto& nextnode : g[curnode]) {
            if (color[nextnode] && color[nextnode] == color[curnode]) {
                return false;
            }
            if (!color[nextnode] && !dfs(nextnode, 3 ^ nowcolor, color, g)) {
                return false;
            }
        }
        return true;
    }

    bool possibleBipartition(int n, vector<vector<int>>& dislikes) {
        vector<int> color(n + 1, 0);
        vector<vector<int>> g(n + 1);
        for (auto& p : dislikes) {
            g[p[0]].push_back(p[1]);
            g[p[1]].push_back(p[0]);
        }
        for (int i = 1; i <= n; ++i) {
            if (color[i] == 0 && !dfs(i, 1, color, g)) {
                return false;
            }
        }
        return true;
    }
};
```

```Java
class Solution {
    public boolean possibleBipartition(int n, int[][] dislikes) {
        int[] color = new int[n + 1];
        List<Integer>[] g = new List[n + 1];
        for (int i = 0; i <= n; ++i) {
            g[i] = new ArrayList<Integer>();
        }
        for (int[] p : dislikes) {
            g[p[0]].add(p[1]);
            g[p[1]].add(p[0]);
        }
        for (int i = 1; i <= n; ++i) {
            if (color[i] == 0 && !dfs(i, 1, color, g)) {
                return false;
            }
        }
        return true;
    }

    public boolean dfs(int curnode, int nowcolor, int[] color, List<Integer>[] g) {
        color[curnode] = nowcolor;
        for (int nextnode : g[curnode]) {
            if (color[nextnode] != 0 && color[nextnode] == color[curnode]) {
                return false;
            }
            if (color[nextnode] == 0 && !dfs(nextnode, 3 ^ nowcolor, color, g)) {
                return false;
            }
        }
        return true;
    }
}
```

```C#
public class Solution {
    public bool PossibleBipartition(int n, int[][] dislikes) {
        int[] color = new int[n + 1];
        IList<int>[] g = new IList<int>[n + 1];
        for (int i = 0; i <= n; ++i) {
            g[i] = new List<int>();
        }
        foreach (int[] p in dislikes) {
            g[p[0]].Add(p[1]);
            g[p[1]].Add(p[0]);
        }
        for (int i = 1; i <= n; ++i) {
            if (color[i] == 0 && !DFS(i, 1, color, g)) {
                return false;
            }
        }
        return true;
    }

    public bool DFS(int curnode, int nowcolor, int[] color, IList<int>[] g) {
        color[curnode] = nowcolor;
        foreach (int nextnode in g[curnode]) {
            if (color[nextnode] != 0 && color[nextnode] == color[curnode]) {
                return false;
            }
            if (color[nextnode] == 0 && !DFS(nextnode, 3 ^ nowcolor, color, g)) {
                return false;
            }
        }
        return true;
    }
}
```

```C
bool dfs(int curnode, int nowcolor, int *color, struct ListNode **g) {
    color[curnode] = nowcolor;
    for (struct ListNode *nextnode = g[curnode]; nextnode; nextnode = nextnode->next) {
        if (color[nextnode->val] && color[nextnode->val] == color[curnode]) {
            return false;
        }
        if (!color[nextnode->val] && !dfs(nextnode->val, 3 ^ nowcolor, color, g)) {
            return false;
        }
    }
    return true;
}

bool possibleBipartition(int n, int** dislikes, int dislikesSize, int* dislikesColSize) {
    int color[n + 1];
    struct ListNode *g[n + 1];
    for (int i = 0; i <= n; i++) {
        color[i] = 0;
        g[i] = NULL;
    }
    for (int i = 0; i < dislikesSize; i++) {
        int a = dislikes[i][0], b = dislikes[i][1];
        struct ListNode *node = (struct ListNode *)malloc(sizeof(struct ListNode));
        node->val = a;
        node->next = g[b];
        g[b] = node;
        node = (struct ListNode *)malloc(sizeof(struct ListNode));
        node->val = b;
        node->next = g[a];
        g[a] = node;
    }
    for (int i = 1; i <= n; ++i) {
        if (color[i] == 0 && !dfs(i, 1, color, g)) {
            for (int j = 0; j <= n; j++) {
                struct ListNode * node = g[j];
                while (node) {
                    struct ListNode * prev = node;
                    node = node->next;
                    free(prev);
                }
            }
            return false;
        }
    }
    for (int j = 0; j <= n; j++) {
        struct ListNode * node = g[j];
        while (node) {
            struct ListNode * prev = node;
            node = node->next;
            free(prev);
        }
    }
    return true;
}
```

```JavaScript
var possibleBipartition = function(n, dislikes) {
    const dfs = (curnode, nowcolor, color, g) => {
        color[curnode] = nowcolor;
        for (const nextnode of g[curnode]) {
            if (color[nextnode] !== 0 && color[nextnode] === color[curnode]) {
                return false;
            }
            if (color[nextnode] === 0 && !dfs(nextnode, 3 ^ nowcolor, color, g)) {
                return false;
            }
        }
        return true;
    }
    const color = new Array(n + 1).fill(0);
    const g = new Array(n + 1).fill(0);
    for (let i = 0; i <= n; ++i) {
        g[i] = [];
    }
    for (const p of dislikes) {
        g[p[0]].push(p[1]);
        g[p[1]].push(p[0]);
    }
    for (let i = 1; i <= n; ++i) {
        if (color[i] === 0 && !dfs(i, 1, color, g)) {
            return false;
        }
    }
    return true;
};
```

```Go
func possibleBipartition(n int, dislikes [][]int) bool {
    g := make([][]int, n)
    for _, d := range dislikes {
        x, y := d[0]-1, d[1]-1
        g[x] = append(g[x], y)
        g[y] = append(g[y], x)
    }
    color := make([]int, n) // color[x] = 0 表示未访问节点 x
    var dfs func(int, int) bool
    dfs = func(x, c int) bool {
        color[x] = c
        for _, y := range g[x] {
            if color[y] == c || color[y] == 0 && !dfs(y, 3^c) {
                return false
            }
        }
        return true
    }
    for i, c := range color {
        if c == 0 && !dfs(i, 1) {
            return false
        }
    }
    return true
}
```

**复杂度分析**

-   时间复杂度：O(n+m)，其中 n 题目给定的人数，m 为给定的 dislike 数组的大小。
-   空间复杂度：O(n+m)，其中 n 题目给定的人数，m 为给定的 dislike 数组的大小。
