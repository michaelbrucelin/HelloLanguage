#### [](https://leetcode.cn/problems/possible-bipartition/solution/ke-neng-de-er-fen-fa-by-leetcode-solutio-guo7//#方法三：并查集)方法三：并查集

**思路与算法**

同样我们也可以用「并查集」来进行分组判断：由于最后只有两组，所以某一个人全部不喜欢人一定会在同一个组中，我们可以用「并查集」进行连接，并判断这个人是否与他不喜欢的人相连，如果相连则表示存在冲突，否则说明此人和他不喜欢的人在当前可以进行合法分组。

**代码**

```Python
class UnionFind:
    def __init__(self, n: int):
        self.fa = list(range(n))
        self.rank = [1] * n

    def find(self, x: int) -> int:
        if self.fa[x] != x:
            self.fa[x] = self.find(self.fa[x])
        return self.fa[x]

    def union(self, x: int, y: int) -> None:
        fx, fy = self.find(x), self.find(y)
        if fx == fy:
            return
        if self.rank[fx] < self.rank[fy]:
            fx, fy = fy, fx
        self.rank[fx] += self.rank[fy]
        self.fa[fy] = fx

    def is_connected(self, x: int, y: int) -> bool:
        return self.find(x) == self.find(y)

class Solution:
    def possibleBipartition(self, n: int, dislikes: List[List[int]]) -> bool:
        g = [[] for _ in range(n)]
        for x, y in dislikes:
            g[x - 1].append(y - 1)
            g[y - 1].append(x - 1)
        uf = UnionFind(n)
        for x, nodes in enumerate(g):
            for y in nodes:
                uf.union(nodes[0], y)
                if uf.is_connected(x, y):
                    return False
        return True
```

```C++
class Solution {
public:
    int findFa(int x, vector<int>& fa) {
        return fa[x] < 0 ? x : fa[x] = findFa(fa[x], fa);
    }

    void unit(int x, int y, vector<int>& fa) {
        x = findFa(x, fa);
        y = findFa(y, fa);
        if (x == y) {
            return ;
        }
        if (fa[x] < fa[y]) {
            swap(x, y);
        }
        fa[x] += fa[y];
        fa[y] = x;
    }

    bool isconnect(int x, int y, vector<int>& fa) {
        x = findFa(x, fa);
        y = findFa(y, fa);
        return x == y;
    }

    bool possibleBipartition(int n, vector<vector<int>>& dislikes) {
        vector<int> fa(n + 1, -1);
        vector<vector<int>> g(n + 1);
        for (auto& p : dislikes) {
            g[p[0]].push_back(p[1]);
            g[p[1]].push_back(p[0]);
        }
        for (int i = 1; i <= n; ++i) {
            for (int j = 0; j < g[i].size(); ++j) {
                unit(g[i][0], g[i][j], fa);
                if (isconnect(i, g[i][j], fa)) {
                    return false;
                }
            }
        }
        return true;
    }
};
```

```Java
class Solution {
    public boolean possibleBipartition(int n, int[][] dislikes) {
        int[] fa = new int[n + 1];
        Arrays.fill(fa, -1);
        List<Integer>[] g = new List[n + 1];
        for (int i = 0; i <= n; ++i) {
            g[i] = new ArrayList<Integer>();
        }
        for (int[] p : dislikes) {
            g[p[0]].add(p[1]);
            g[p[1]].add(p[0]);
        }
        for (int i = 1; i <= n; ++i) {
            for (int j = 0; j < g[i].size(); ++j) {
                unit(g[i].get(0), g[i].get(j), fa);
                if (isconnect(i, g[i].get(j), fa)) {
                    return false;
                }
            }
        }
        return true;
    }

    public void unit(int x, int y, int[] fa) {
        x = findFa(x, fa);
        y = findFa(y, fa);
        if (x == y) {
            return ;
        }
        if (fa[x] < fa[y]) {
            int temp = x;
            x = y;
            y = temp;
        }
        fa[x] += fa[y];
        fa[y] = x;
    }

    public boolean isconnect(int x, int y, int[] fa) {
        x = findFa(x, fa);
        y = findFa(y, fa);
        return x == y;
    }

    public int findFa(int x, int[] fa) {
        return fa[x] < 0 ? x : (fa[x] = findFa(fa[x], fa));
    }
}
```

```C#
public class Solution {
    public bool PossibleBipartition(int n, int[][] dislikes) {
        int[] fa = new int[n + 1];
        Array.Fill(fa, -1);
        IList<int>[] g = new IList<int>[n + 1];
        for (int i = 0; i <= n; ++i) {
            g[i] = new List<int>();
        }
        foreach (int[] p in dislikes) {
            g[p[0]].Add(p[1]);
            g[p[1]].Add(p[0]);
        }
        for (int i = 1; i <= n; ++i) {
            for (int j = 0; j < g[i].Count; ++j) {
                Unit(g[i][0], g[i][j], fa);
                if (Isconnect(i, g[i][j], fa)) {
                    return false;
                }
            }
        }
        return true;
    }

    public void Unit(int x, int y, int[] fa) {
        x = FindFa(x, fa);
        y = FindFa(y, fa);
        if (x == y) {
            return ;
        }
        if (fa[x] < fa[y]) {
            int temp = x;
            x = y;
            y = temp;
        }
        fa[x] += fa[y];
        fa[y] = x;
    }

    public bool Isconnect(int x, int y, int[] fa) {
        x = FindFa(x, fa);
        y = FindFa(y, fa);
        return x == y;
    }

    public int FindFa(int x, int[] fa) {
        return fa[x] < 0 ? x : (fa[x] = FindFa(fa[x], fa));
    }
}
```

```C
int findFa(int x, int* fa) {
    return fa[x] < 0 ? x : (fa[x] = findFa(fa[x], fa));
}

void swap(int *a, int *b) {
    int c = *a;
    *a = *b;
    *b = c;
}

void unit(int x, int y, int* fa) {
    x = findFa(x, fa);
    y = findFa(y, fa);
    if (x == y) {
        return ;
    }
    if (fa[x] < fa[y]) {
        swap(&x, &y);
    }
    fa[x] += fa[y];
    fa[y] = x;
}

bool isconnect(int x, int y, int* fa) {
    x = findFa(x, fa);
    y = findFa(y, fa);
    return x == y;
}

bool possibleBipartition(int n, int** dislikes, int dislikesSize, int* dislikesColSize) {
    int color[n + 1], fa[n + 1];
    struct ListNode *g[n + 1];
    for (int i = 0; i <= n; i++) {
        color[i] = 0, fa[i] = -1;
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
        for (struct ListNode *node = g[i]; node; node = node->next) {
            unit(g[i]->val, node->val, fa);
            if (isconnect(i, node->val, fa)) {
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
    const fa = new Array(n + 1).fill(-1);
    const g = new Array(n + 1).fill(0);
    for (let i = 0; i <= n; ++i) {
        g[i] = [];
    }
    for (const p of dislikes) {
        g[p[0]].push(p[1]);
        g[p[1]].push(p[0]);
    }
    for (let i = 1; i <= n; ++i) {
        for (let j = 0; j < g[i].length; ++j) {
            unit(g[i][0], g[i][j], fa);
            if (isconnect(i, g[i][j], fa)) {
                return false;
            }
        }
    }
    return true;
}

const unit = (x, y, fa) => {
    x = findFa(x, fa);
    y = findFa(y, fa);
    if (x === y) {
        return ;
    }
    if (fa[x] < fa[y]) {
        const temp = x;
        x = y;
        y = temp;
    }
    fa[x] += fa[y];
    fa[y] = x;
}

const isconnect = (x, y, fa) => {
    x = findFa(x, fa);
    y = findFa(y, fa);
    return x === y;
}

const findFa = (x, fa) => {
    return fa[x] < 0 ? x : (fa[x] = findFa(fa[x], fa));
}
```

```Go
type unionFind struct {
    parent, rank []int
}

func newUnionFind(n int) unionFind {
    parent := make([]int, n)
    for i := range parent {
        parent[i] = i
    }
    return unionFind{parent, make([]int, n)}
}

func (uf unionFind) find(x int) int {
    if uf.parent[x] != x {
        uf.parent[x] = uf.find(uf.parent[x])
    }
    return uf.parent[x]
}

func (uf unionFind) union(x, y int) {
    x, y = uf.find(x), uf.find(y)
    if x == y {
        return
    }
    if uf.rank[x] > uf.rank[y] {
        uf.parent[y] = x
    } else if uf.rank[x] < uf.rank[y] {
        uf.parent[x] = y
    } else {
        uf.parent[y] = x
        uf.rank[x]++
    }
}

func (uf unionFind) isConnected(x, y int) bool {
    return uf.find(x) == uf.find(y)
}

func possibleBipartition(n int, dislikes [][]int) bool {
    g := make([][]int, n)
    for _, d := range dislikes {
        x, y := d[0]-1, d[1]-1
        g[x] = append(g[x], y)
        g[y] = append(g[y], x)
    }
    uf := newUnionFind(n)
    for x, nodes := range g {
        for _, y := range nodes {
            uf.union(nodes[0], y)
            if uf.isConnected(x, y) {
                return false
            }
        }
    }
    return true
}
```

**复杂度分析**

-   时间复杂度：O(n+mα(n))，其中 n 题目给定的人数，m 为给定的 dislike 数组的大小，α 是反 Ackerman 函数。
-   空间复杂度：O(n+m)，其中 n 题目给定的人数，m 为给定的 dislike 数组的大小。
