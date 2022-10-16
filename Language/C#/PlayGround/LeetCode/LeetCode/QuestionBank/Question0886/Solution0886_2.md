#### [](https://leetcode.cn/problems/possible-bipartition/solution/ke-neng-de-er-fen-fa-by-leetcode-solutio-guo7//#����һ�������������)����һ�������������

**˼·���㷨**

������Ŀ���� n ����Ϊһ�飨���Ϊ 1,2,��,n�������� n Ϊż�������������� dislike������ dislike[i]={ai,bi} ��ʾ��� ai ���û���ϲ���û� bi��1��ai<bi��n�������ж��Ƿ��ܽ� n ���˷ֳ����飬�����㵱һ���˲�ϲ��ĳһ����ʱ�������˲���ͬһ���г��֡�

���ǿ��Գ����á�Ⱦɫ������������⣺�����һ���е����Ǻ�ɫ���ڶ����е���Ϊ��ɫ���������α���ÿһ���ˣ������ǰ����û�б����飬�ͽ���ֵ���һ�飨��ȾΪ��ɫ������ô����˲�ϲ�����˱���ֵ��ڶ����У�ȾΪ��ɫ����Ȼ���κ��±��ֵ��ڶ����е��ˣ��䲻ϲ�����˱��뱻�ֵ���һ�飬�������ơ������Ⱦɫ�Ĺ����д��ڳ�ͻ���ͱ�ʾ��������ǲ�������ɵģ�����˵��Ⱦɫ�Ĺ�����Ч�������ںϷ��ķ��鷽������

**����**

```Python
class Solution:
    def possibleBipartition(self, n: int, dislikes: List[List[int]]) -> bool:
        g = [[] for _ in range(n)]
        for x, y in dislikes:
            g[x - 1].append(y - 1)
            g[y - 1].append(x - 1)
        color = [0] * n  # color[x] = 0 ��ʾδ���ʽڵ� x
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
    color := make([]int, n) // color[x] = 0 ��ʾδ���ʽڵ� x
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

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�O(n+m)������ n ��Ŀ������������m Ϊ������ dislike ����Ĵ�С��
-   �ռ临�Ӷȣ�O(n+m)������ n ��Ŀ������������m Ϊ������ dislike ����Ĵ�С��
