#### [](https://leetcode.cn/problems/rectangle-area-ii/solution/ju-xing-mian-ji-ii-by-leetcode-solution-ulqz//#方法一：离散化-扫描线-使用简单数组实时维护)方法一：离散化 + 扫描线 + 使用简单数组实时维护

**思路与算法**

我们先解释扫描线的概念：想象一条竖直的直线从平面的最左端扫到最右端，在扫描的过程中，直线上的一些线段会被给定的矩形覆盖。将这些覆盖的线段长度进行积分，就可以得到矩形的面积之和。每个矩形有一个左边界和一个右边界，在扫描到矩形的左边界时，覆盖的长度可能会增加；在扫描到矩形的右边界时，覆盖的长度可能会减少。如果给定了 n 个矩形，那么覆盖的线段长度最多变化 2n 次，此时我们就可以将两次变化之间的部分合并起来，一起计算：即这一部分矩形的面积，等于覆盖的线段长度，乘以扫描线在水平方向移动过的距离。

因此，我们可以首先将所有矩形的左右边界按照横坐标进行排序，这样就确定了扫描线扫描的顺序。随后我们遍历这些左右边界，一次性地处理掉一批横坐标相同的左右边界，对应地增加或者减少覆盖的长度。在这之后，下一个未遍历到的坐右边界的横坐标，减去这一批左右边界的横坐标，就是扫描线在水平方向移动过的距离。

那么我们如何维护「覆盖的线段长度」呢？这里同样可以使用到离散化的技巧（扫描线就是一种离散化的技巧，将大范围的连续的坐标转化成 2n 个离散的坐标）。由于矩形的上下边界也只有 2n 个，它们会将 y 轴分成 2n+1 个部分，中间的 2n−1 个部分均为线段，会被矩形覆盖到（最外侧的 2 个部分为射线，不会被矩形覆盖到），并且每一个线段要么完全被覆盖，要么完全不被覆盖。因此我们可以使用两个长度为 2n−1 的数组 seg 和 length，其中 seg[i] 表示第 i 个线段被矩形覆盖的次数，length[i] 表示第 i 个线段的长度。当扫描线遇到一个左边界时，我们就将左边界覆盖到的线段对应的 seg[i] 全部加 1；遇到一个右边界时，我们就将右边界覆盖到的线段对应的 seg[i] 全部减 1。在处理掉一批横坐标相同的左右边界后，seg[i] 如果大于 0，说明它被覆盖，我们累加所有的 length[i]，即可得到「覆盖的线段长度」。

**代码**

```C++
class Solution {
public:
    int rectangleArea(vector<vector<int>>& rectangles) {
        int n = rectangles.size();
        vector<int> hbound;
        for (const auto& rect: rectangles) {
            // 下边界
            hbound.push_back(rect[1]);
            // 上边界
            hbound.push_back(rect[3]);
        }
        sort(hbound.begin(), hbound.end());
        hbound.erase(unique(hbound.begin(), hbound.end()), hbound.end());
        int m = hbound.size();
        // 「思路与算法部分」的 length 数组并不需要显式地存储下来
        // length[i] 可以通过 hbound[i+1] - hbound[i] 得到
        vector<int> seg(m - 1);

        vector<tuple<int, int, int>> sweep;
        for (int i = 0; i < n; ++i) {
            // 左边界
            sweep.emplace_back(rectangles[i][0], i, 1);
            // 右边界
            sweep.emplace_back(rectangles[i][2], i, -1);
        }
        sort(sweep.begin(), sweep.end());

        long long ans = 0;
        for (int i = 0; i < sweep.size(); ++i) {
            int j = i;
            while (j + 1 < sweep.size() && get<0>(sweep[i]) == get<0>(sweep[j + 1])) {
                ++j;
            }
            if (j + 1 == sweep.size()) {
                break;
            }
            // 一次性地处理掉一批横坐标相同的左右边界
            for (int k = i; k <= j; ++k) {
                auto&& [_, idx, diff] = sweep[k];
                int left = rectangles[idx][1], right = rectangles[idx][3];
                for (int x = 0; x < m - 1; ++x) {
                    if (left <= hbound[x] && hbound[x + 1] <= right) {
                        seg[x] += diff;
                    }
                }
            }
            int cover = 0;
            for (int k = 0; k < m - 1; ++k) {
                if (seg[k] > 0) {
                    cover += (hbound[k + 1] - hbound[k]);
                }
            }
            ans += static_cast<long long>(cover) * (get<0>(sweep[j + 1]) - get<0>(sweep[j]));
            i = j;
        }
        return ans % static_cast<int>(1e9 + 7);
    }
};
```

```Java
class Solution {
    public int rectangleArea(int[][] rectangles) {
        final int MOD = 1000000007;
        int n = rectangles.length;
        Set<Integer> set = new HashSet<Integer>();
        for (int[] rect : rectangles) {
            // 下边界
            set.add(rect[1]);
            // 上边界
            set.add(rect[3]);
        }
        List<Integer> hbound = new ArrayList<Integer>(set);
        Collections.sort(hbound);
        int m = hbound.size();
        // 「思路与算法部分」的 length 数组并不需要显式地存储下来
        // length[i] 可以通过 hbound[i+1] - hbound[i] 得到
        int[] seg = new int[m - 1];

        List<int[]> sweep = new ArrayList<int[]>();
        for (int i = 0; i < n; ++i) {
            // 左边界
            sweep.add(new int[]{rectangles[i][0], i, 1});
            // 右边界
            sweep.add(new int[]{rectangles[i][2], i, -1});
        }
        Collections.sort(sweep, (a, b) -> {
            if (a[0] != b[0]) {
                return a[0] - b[0];
            } else if (a[1] != b[1]) {
                return a[1] - b[1];
            } else {
                return a[2] - b[2];
            }
        });

        long ans = 0;
        for (int i = 0; i < sweep.size(); ++i) {
            int j = i;
            while (j + 1 < sweep.size() && sweep.get(i)[0] == sweep.get(j + 1)[0]) {
                ++j;
            }
            if (j + 1 == sweep.size()) {
                break;
            }
            // 一次性地处理掉一批横坐标相同的左右边界
            for (int k = i; k <= j; ++k) {
                int[] arr = sweep.get(k);
                int idx = arr[1], diff = arr[2];
                int left = rectangles[idx][1], right = rectangles[idx][3];
                for (int x = 0; x < m - 1; ++x) {
                    if (left <= hbound.get(x) && hbound.get(x + 1) <= right) {
                        seg[x] += diff;
                    }
                }
            }
            int cover = 0;
            for (int k = 0; k < m - 1; ++k) {
                if (seg[k] > 0) {
                    cover += (hbound.get(k + 1) - hbound.get(k));
                }
            }
            ans += (long) cover * (sweep.get(j + 1)[0] - sweep.get(j)[0]);
            i = j;
        }
        return (int) (ans % MOD);
    }
}
```

```C#
public class Solution {
    public int RectangleArea(int[][] rectangles) {
        const int MOD = 1000000007;
        int n = rectangles.Length;
        ISet<int> set = new HashSet<int>();
        foreach (int[] rect in rectangles) {
            // 下边界
            set.Add(rect[1]);
            // 上边界
            set.Add(rect[3]);
        }
        List<int> hbound = new List<int>(set);
        hbound.Sort();
        int m = hbound.Count;
        // 「思路与算法部分」的 length 数组并不需要显式地存储下来
        // length[i] 可以通过 hbound[i+1] - hbound[i] 得到
        int[] seg = new int[m - 1];

        List<Tuple<int, int, int>> sweep = new List<Tuple<int, int, int>>();
        for (int i = 0; i < n; ++i) {
            // 左边界
            sweep.Add(new Tuple<int, int, int>(rectangles[i][0], i, 1));
            // 右边界
            sweep.Add(new Tuple<int, int, int>(rectangles[i][2], i, -1));
        }
        sweep.Sort();

        long ans = 0;
        for (int i = 0; i < sweep.Count; ++i) {
            int j = i;
            while (j + 1 < sweep.Count && sweep[i].Item1 == sweep[j + 1].Item1) {
                ++j;
            }
            if (j + 1 == sweep.Count) {
                break;
            }
            // 一次性地处理掉一批横坐标相同的左右边界
            for (int k = i; k <= j; ++k) {
                Tuple<int, int, int> tuple = sweep[k];
                int idx = tuple.Item2, diff = tuple.Item3;
                int left = rectangles[idx][1], right = rectangles[idx][3];
                for (int x = 0; x < m - 1; ++x) {
                    if (left <= hbound[x] && hbound[x + 1] <= right) {
                        seg[x] += diff;
                    }
                }
            }
            int cover = 0;
            for (int k = 0; k < m - 1; ++k) {
                if (seg[k] > 0) {
                    cover += (hbound[k + 1] - hbound[k]);
                }
            }
            ans += (long) cover * (sweep[j + 1].Item1 - sweep[j].Item1);
            i = j;
        }
        return (int) (ans % MOD);
    }
}
```

```Python
class Solution:
    def rectangleArea(self, rectangles: List[List[int]]) -> int:
        hbound = set()
        for rect in rectangles:
            # 下边界
            hbound.add(rect[1])
            # 上边界
            hbound.add(rect[3])
        
        hbound = sorted(hbound)
        m = len(hbound)
        # 「思路与算法部分」的 length 数组并不需要显式地存储下来
        # length[i] 可以通过 hbound[i+1] - hbound[i] 得到
        seg = [0] * (m - 1)

        sweep = list()
        for i, rect in enumerate(rectangles):
            # 左边界
            sweep.append((rect[0], i, 1))
            # 右边界
            sweep.append((rect[2], i, -1))
        sweep.sort()

        ans = i = 0
        while i < len(sweep):
            j = i
            while j + 1 < len(sweep) and sweep[i][0] == sweep[j + 1][0]:
                j += 1
            if j + 1 == len(sweep):
                break
            
            # 一次性地处理掉一批横坐标相同的左右边界
            for k in range(i, j + 1):
                _, idx, diff = sweep[k]
                left, right = rectangles[idx][1], rectangles[idx][3]
                for x in range(m - 1):
                    if left <= hbound[x] and hbound[x + 1] <= right:
                        seg[x] += diff
            
            cover = 0
            for k in range(m - 1):
                if seg[k] > 0:
                    cover += (hbound[k + 1] - hbound[k])
            ans += cover * (sweep[j + 1][0] - sweep[j][0])
            i = j + 1
        
        return ans % (10**9 + 7)
```

```C
typedef struct {
    int key;
    UT_hash_handle hh;
} HashItem; 

typedef struct Tuple {
    int val[3];
} Tuple;

HashItem *hashFindItem(HashItem **obj, int key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, int key) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
    pEntry->key = key;
    HASH_ADD_INT(*obj, key, pEntry);
    return true;
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);  
        free(curr);             
    }
}

static inline int cmp1(const void *pa, const void *pb) {
    return *(int *)pa - *(int *)pb;
}

static inline int cmp2(const void *pa, const void *pb) {
    Tuple *a = (Tuple *)pa, *b = (Tuple *)pb;
    if (a->val[0] != b->val[0]) {
        return a->val[0] - b->val[0];
    } else if (a->val[1] != b->val[1]) {
        return a->val[1] - b->val[1];
    } else {
        return a->val[2] - b->val[2];
    }
}

int rectangleArea(int** rectangles, int rectanglesSize, int* rectanglesColSize){
    int n = rectanglesSize;
    HashItem *set = NULL;
    for (int i = 0; i < n; i++) {
        // 下边界
        hashAddItem(&set, rectangles[i][1]);
        // 上边界
        hashAddItem(&set, rectangles[i][3]);
    }
    int hboundSize = HASH_COUNT(set);
    int hbound[hboundSize], pos = 0;
    for (HashItem *pEntry = set; pEntry != NULL; pEntry = pEntry->hh.next) {
        hbound[pos++] = pEntry->key;
    }
    hashFree(&set);

    qsort(hbound, hboundSize, sizeof(int), cmp1);
    // 「思路与算法部分」的 length 数组并不需要显式地存储下来
    // length[i] 可以通过 hbound[i+1] - hbound[i] 得到
    int seg[hboundSize - 1];
    int sweepSize = n * 2;
    Tuple sweep[sweepSize];
    pos = 0;
    memset(seg, 0, sizeof(seg));
    for (int i = 0; i < n; ++i) {
        // 左边界
        sweep[pos].val[0] = rectangles[i][0];
        sweep[pos].val[1] = i;
        sweep[pos].val[2] = 1;
        pos++;
        // 右边界
        sweep[pos].val[0] = rectangles[i][2];
        sweep[pos].val[1] = i;
        sweep[pos].val[2] = -1;
        pos++;
    }
    qsort(sweep, sweepSize, sizeof(Tuple), cmp2);
    long long ans = 0;
    for (int i = 0; i < n * 2; ++i) {
        int j = i;
        while (j + 1 < sweepSize && sweep[i].val[0] == sweep[j + 1].val[0]) {
            ++j;
        }
        if (j + 1 == sweepSize) {
            break;
        }
        // 一次性地处理掉一批横坐标相同的左右边界
        for (int k = i; k <= j; ++k) {
            int idx = sweep[k].val[1], diff = sweep[k].val[2];
            int left = rectangles[idx][1], right = rectangles[idx][3];
            for (int x = 0; x < hboundSize - 1; ++x) {
                if (left <= hbound[x] && hbound[x + 1] <= right) {
                    seg[x] += diff;
                }
            }
        }
        int cover = 0;
        for (int k = 0; k < hboundSize - 1; ++k) {
            if (seg[k] > 0) {
                cover += (hbound[k + 1] - hbound[k]);
            }
        }
        ans += (long long)cover * (sweep[j + 1].val[0] - sweep[j].val[0]);
        i = j;
    }
    return ans % (long long)(1e9 + 7);
}
```

```Go
func rectangleArea(rectangles [][]int) (ans int) {
    n := len(rectangles) * 2
    hBound := make([]int, 0, n)
    for _, r := range rectangles {
        hBound = append(hBound, r[1], r[3])
    }
    // 排序，方便下面去重
    sort.Ints(hBound)
    m := 0
    for _, b := range hBound[1:] {
        if hBound[m] != b {
            m++
            hBound[m] = b
        }
    }
    hBound = hBound[:m+1]

    type tuple struct{ x, i, d int }
    sweep := make([]tuple, 0, n)
    for i, r := range rectangles {
        sweep = append(sweep, tuple{r[0], i, 1}, tuple{r[2], i, -1})
    }
    sort.Slice(sweep, func(i, j int) bool { return sweep[i].x < sweep[j].x })

    seg := make([]int, m)
    for i := 0; i < n; i++ {
        j := i
        for j+1 < n && sweep[j+1].x == sweep[i].x {
            j++
        }
        if j+1 == n {
            break
        }
        // 一次性地处理掉一批横坐标相同的左右边界
        for k := i; k <= j; k++ {
            idx, diff := sweep[k].i, sweep[k].d
            left, right := rectangles[idx][1], rectangles[idx][3]
            for x := 0; x < m; x++ {
                if left <= hBound[x] && hBound[x+1] <= right {
                    seg[x] += diff
                }
            }
        }
        cover := 0
        for k := 0; k < m; k++ {
            if seg[k] > 0 {
                cover += hBound[k+1] - hBound[k]
            }
        }
        ans += cover * (sweep[j+1].x - sweep[j].x)
        i = j
    }
    return ans % (1e9 + 7)
}
```

**复杂度分析**

-   时间复杂度：O(n^2^)，其中 n 是矩形的个数。
-   空间复杂度：O(n)，即为扫描线需要使用的空间。
