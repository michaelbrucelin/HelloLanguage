#### 方法二：最长递增子序列

**思路**

方法一实际上是「[300\. 最长递增子序列](https://leetcode.cn/problems/longest-increasing-subsequence/)」的动态规划解法，这个解法可以改造为贪心 + 二分查找的形式。用一个数组 arr 来记录当前最优情况，arr[i] 就表示长度为 i+1 的数对链的末尾可以取得的最小值，遇到一个新数对时，先用二分查找得到这个数对可以放置的位置，再更新 arr。

**代码**

```Python3
class Solution:
    def findLongestChain(self, pairs: List[List[int]]) -> int:
        pairs.sort()
        arr = []
        for x, y in pairs:
            i = bisect_left(arr, x)
            if i < len(arr):
                arr[i] = min(arr[i], y)
            else:
                arr.append(y)
        return len(arr)

```

```C++
class Solution {
public:
    int findLongestChain(vector<vector<int>>& pairs) {
        sort(pairs.begin(), pairs.end());
        vector<int> arr;
        for (auto p : pairs) {
            int x = p[0], y = p[1];
            if (arr.size() == 0 || x > arr.back()) {
                arr.emplace_back(y);
            } else {
                int idx = lower_bound(arr.begin(), arr.end(), x) - arr.begin();
                arr[idx] = min(arr[idx], y);
            }
        }
        return arr.size();
    }
};

```

```Java
class Solution {
    public int findLongestChain(int[][] pairs) {
        Arrays.sort(pairs, (a, b) -> a[0] - b[0]);
        List<Integer> arr = new ArrayList<Integer>();
        for (int[] p : pairs) {
            int x = p[0], y = p[1];
            if (arr.isEmpty() || x > arr.get(arr.size() - 1)) {
                arr.add(y);
            } else {
                int idx = binarySearch(arr, x);
                arr.set(idx, Math.min(arr.get(idx), y));
            }
        }
        return arr.size();
    }

    public int binarySearch(List<Integer> arr, int x) {
        int low = 0, high = arr.size() - 1;
        while (low < high) {
            int mid = low + (high - low) / 2;
            if (arr.get(mid) >= x) {
                high = mid;
            } else {
                low = mid + 1;
            }
        }
        return low;
    }
}

```

```C#
public class Solution {
    public int FindLongestChain(int[][] pairs) {
        Array.Sort(pairs, (a, b) => a[0] - b[0]);
        IList<int> arr = new List<int>();
        foreach (int[] p in pairs) {
            int x = p[0], y = p[1];
            if (arr.Count == 0 || x > arr[arr.Count - 1]) {
                arr.Add(y);
            } else {
                int idx = BinarySearch(arr, x);
                arr[idx] = Math.Min(arr[idx], y);
            }
        }
        return arr.Count;
    }

    public int BinarySearch(IList<int> arr, int x) {
        int low = 0, high = arr.Count - 1;
        while (low < high) {
            int mid = low + (high - low) / 2;
            if (arr[mid] >= x) {
                high = mid;
            } else {
                low = mid + 1;
            }
        }
        return low;
    }
}

```

```C
#define MIN(a, b) ((a) < (b) ? (a) : (b))

static inline int cmp(const void *pa, const void *pb) {
    if ((*(int **)pa)[0] == (*(int **)pb)[0]) {
        return (*(int **)pa)[1] == (*(int **)pb)[1];
    } 
    return (*(int **)pa)[0] - (*(int **)pb)[0];
}

int lowerbound(const int *arr, int left, int right, int val) {
    int ret = -1;
    while (left <= right) {
        int mid = (left + right) >> 1;
        if (arr[mid] >= val) {
            ret = mid;
            right = mid - 1;
        } else {
            left = mid + 1;
        }
    }
    return ret;
}

int findLongestChain(int** pairs, int pairsSize, int* pairsColSize){
    qsort(pairs, pairsSize, sizeof(int *), cmp);
    int *arr = (int *)malloc(sizeof(int) * pairsSize);
    int pos = 0;
    for (int i = 0; i < pairsSize; i++) {
        int x = pairs[i][0], y = pairs[i][1];
        if (pos == 0 || x > arr[pos - 1]) {
            arr[pos++] = y;
        } else {
            int idx = lowerbound(arr, 0, pos - 1, x);
            arr[idx] = MIN(arr[idx], y);
        }
    }
    free(arr);
    return pos;
}

```

```Golang
func findLongestChain(pairs [][]int) int {
    sort.Slice(pairs, func(i, j int) bool { return pairs[i][0] < pairs[j][0] })
    arr := []int{}
    for _, p := range pairs {
        i := sort.SearchInts(arr, p[0])
        if i < len(arr) {
            arr[i] = min(arr[i], p[1])
        } else {
            arr = append(arr, p[1])
        }
    }
    return len(arr)
}

func min(a, b int) int {
    if a > b {
        return b
    }
    return a
}

```

```JavaScript
var findLongestChain = function(pairs) {
    pairs.sort((a, b) => a[0] - b[0]);
    const arr = [];
    for (const p of pairs) {
        let x = p[0], y = p[1];
        if (arr.length === 0 || x > arr[arr.length - 1]) {
            arr.push(y);
        } else {
            const idx = binarySearch(arr, x);
            arr[idx] =  Math.min(arr[idx], y);
        }
    }
    return arr.length;
}

const binarySearch = (arr, x) => {
    let low = 0, high = arr.length - 1;
    while (low < high) {
        const mid = low + Math.floor((high - low) / 2);
        if (arr[mid] >= x) {
            high = mid;
        } else {
            low = mid + 1;
        }
    }
    return low;
};


```

**复杂度分析**

-   时间复杂度：O(nlogn)，其中 n 为 pairs 的长度。排序的时间复杂度为 O(nlogn)，二分查找的时间复杂度为 O(nlogn)，二分的次数为 O(n)。

-   空间复杂度：O(n)，数组 arr 的长度最多为 O(n)。
