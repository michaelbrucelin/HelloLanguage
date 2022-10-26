#### [](https://leetcode.cn/problems/shortest-bridge/solution/by-ac_oier-56ly//#���鼯-˫��-bfs)���鼯 + ˫�� BFS

**ʹ�á����鼯������������ǳ�����Ȼ���������ĵ�ֱ���ӣ������á�˫�� BFS���������ͨ·��**

Ϊ�˷��㣬���ǽ� `grid` ��Ϊ `g`��

������������ g[i][j]=1 �Ľڵ���������ͨ�ķ���ֵͬΪ 1 �Ľڵ���в��鼯��ͨ��ά����

������������� `d1` �� `d2` �ֱ�洢�������Ľڵ㣨�Զ�Ԫ�� (x,y) �ķ�ʽ����ӣ�����ʹ��������ϣ�� `m1` �� `m2` ����¼���������������ýڵ������ĵĲ������Խڵ��һά���Ϊ `key`�������Ĳ���Ϊ `value`����

�����ʹ�á�˫�� BFS�������ʹ��������ͨ����Сͨ·��ÿ�δӶ����н��ٵĽ�����չ��ֻ����δ��������Ľڵ㣨û�б���ǰ��ϣ������¼���Ž�����Ӳ��������Ĳ���������չ�ڵ�������һ�����ж�Ӧ�Ĺ�ϣ����г��ֹ���˵���ҵ������ͨ·��

���룺

```Java
class Solution {
    static int N = 10010;
    static int[] p = new int[N];
    static int[][] dirs = new int[][]{{1,0},{-1,0},{0,1},{0,-1}};
    int n;
    int getIdx(int x, int y) {
        return x * n + y;
    }
    int find(int x) {
        if (p[x] != x) p[x] = find(p[x]);
        return p[x];
    }
    void union(int x, int y) {
        p[find(x)] = p[find(y)];
    }
    public int shortestBridge(int[][] g) {
        n = g.length;
        for (int i = 0; i <= n * n; i++) p[i] = i;
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (g[i][j] == 0) continue;
                for (int[] di : dirs) {
                    int x = i + di[0], y = j + di[1];
                    if (x < 0 || x >= n || y < 0 || y >= n) continue;
                    if (g[x][y] == 0) continue;
                    union(getIdx(i, j), getIdx(x, y));
                }
            }
        }
        int a = -1, b = -1;
        Deque<int[]> d1 = new ArrayDeque<>(), d2 = new ArrayDeque<>();
        Map<Integer, Integer> m1 = new HashMap<>(), m2 = new HashMap<>();
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < n; j++) {
                if (g[i][j] == 0) continue;
                int idx = getIdx(i, j), root = find(idx);
                if (a == -1) a = root;    
                else if (a != root && b == -1) b = root;
                if (root == a) {
                    d1.addLast(new int[]{i, j});
                    m1.put(idx, 0);
                } else if (root == b) {
                    d2.addLast(new int[]{i, j});
                    m2.put(idx, 0);
                }
            }
        }
        while (!d1.isEmpty() && !d2.isEmpty()) {
            int t = -1;
            if (d1.size() < d2.size()) t = update(d1, m1, m2);
            else t = update(d2, m2, m1);
            if (t != -1) return t - 1;
        }
        return -1; // never
    }
    int update(Deque<int[]> d, Map<Integer, Integer> m1, Map<Integer, Integer> m2) {
        int sz = d.size();
        while (sz-- > 0) {
            int[] info = d.pollFirst();
            int x = info[0], y = info[1], idx = getIdx(x, y), step = m1.get(idx);
            for (int[] di : dirs) {
                int nx = x + di[0], ny = y + di[1], nidx = getIdx(nx, ny);
                if (nx < 0 || nx >= n || ny < 0 || ny >= n) continue;
                if (m1.containsKey(nidx)) continue;
                if (m2.containsKey(nidx)) return step + 1 + m2.get(nidx);
                d.addLast(new int[]{nx, ny});
                m1.put(nidx, step + 1);
            }
        }
        return -1;
    }
}
```

```TypeScript
let n: number
const p = new Array<number>(10010).fill(0)
const dirs = [[0,1],[0,-1],[1,0],[-1,0]]
function shortestBridge(g: number[][]): number {
    function getIdx(x: number, y: number): number {
        return x * n + y
    }
    function find(x: number): number {
        if (p[x] != x) p[x] = find(p[x])
        return p[x]
    }
    function union(x: number, y: number): void {
        p[find(x)] = p[find(y)]
    }
    function update(d: Array<Array<number>>, m1: Map<number, number>, m2: Map<number, number>): number {
        let sz = d.length
        while (sz-- > 0) {
            const info = d.shift()
            const x = info[0], y = info[1], idx = getIdx(x, y), step = m1.get(idx)
            for (const di of dirs) {
                const nx = x + di[0], ny = y + di[1], nidx = getIdx(nx, ny)
                if (nx < 0 || nx >= n || ny < 0 || ny >= n) continue
                if (m1.has(nidx)) continue
                if (m2.has(nidx)) return step + 1 + m2.get(nidx)
                d.push([nx, ny])
                m1.set(nidx, step + 1)
            }
        }
        return -1
    }
    n = g.length
    for (let i = 0; i < n * n; i++) p[i] = i
    for (let i = 0; i < n; i++) {
        for (let j = 0; j < n; j++) {
            if (g[i][j] == 0) continue
            for (const di of dirs) {
                const x = i + di[0], y = j + di[1]
                if (x < 0 || x >= n || y < 0 || y >= n) continue
                if (g[x][y] == 0) continue
                union(getIdx(i, j), getIdx(x, y))
            }
        }
    }
    let a = -1, b = -1
    const d1 = new Array<number[]>(), d2 = new Array<number[]>()
    const m1 = new Map<number, number>(), m2 = new Map<number, number>()
    for (let i = 0; i < n; i++) {
        for (let j = 0; j < n; j++) {
            if (g[i][j] == 0) continue
            const idx = getIdx(i, j), root = find(idx)
            if (a == -1) a = root
            else if (a != root && b == -1) b = root
            if (a == root) {
                d1.push([i, j])
                m1.set(idx, 0)
            } else if (b == root) {
                d2.push([i, j])
                m2.set(idx, 0)
            }
        }
    }
    while (d1.length != 0 && d2.length != 0) {
        let t = -1
        if (d1.length < d2.length) t = update(d1, m1, m2)
        else t = update(d2, m2, m1)
        if (t != -1) return t - 1
    }
    return -1
}
```

```Python
import queue

class Solution:
    def shortestBridge(self, g: List[List[int]]) -> int:
        def getIdx(x, y):
            return x * n + y

        def find(x):
            if p[x] != x:
                p[x] = find(p[x])
            return p[x]

        def union(x, y):
            p[find(x)] = p[find(y)]

        def update(d, cur, other):
            sz = d.qsize()
            while sz != 0:
                x, y = d.get()
                idx, step = getIdx(x, y), cur.get(getIdx(x, y))
                for di in dirs:
                    nx, ny = x + di[0], y + di[1]
                    nidx = getIdx(nx, ny)
                    if nx < 0 or nx >= n or ny < 0 or ny >= n:
                        continue
                    if nidx in cur:
                        continue
                    if nidx in other:
                        return step + 1 + other.get(nidx)
                    d.put([nx, ny])
                    cur[nidx] = step + 1
                sz -= 1
            return -1

        n = len(g)
        p = [i for i in range(n * n + 10)]
        dirs = [[1, 0], [-1, 0], [0, 1], [0, -1]]
        for i in range(n):
            for j in range(n):
                if g[i][j] == 0:
                    continue
                for di in dirs:
                    x, y = i + di[0], j + di[1]
                    if x < 0 or x >= n or y < 0 or y >= n:
                        continue
                    if g[x][y] == 0:
                        continue
                    union(getIdx(i, j), getIdx(x, y))
        a, b = -1, -1
        d1, d2 = queue.Queue(), queue.Queue()
        m1, m2 = {}, {}
        for i in range(n):
            for j in range(n):
                if g[i][j] == 0:
                    continue
                idx, root = getIdx(i, j), find(getIdx(i, j))
                if a == -1:
                    a = root
                elif a != root and b == -1:
                    b = root
                if a == root:
                    d1.put([i, j])
                    m1[idx] = 0
                elif b == root:
                    d2.put([i, j])
                    m2[idx] = 0
        while not d1.empty() and not d2.empty():
            t = -1
            if d1.qsize() < d2.qsize():
                t = update(d1, m1, m2)
            else:
                t = update(d2, m2, m1)
            if t != -1:
                return t - 1
        return -1
```

-   ʱ�临�Ӷȣ�$O(n^2)$
-   �ռ临�Ӷȣ�$O(n^2)$
