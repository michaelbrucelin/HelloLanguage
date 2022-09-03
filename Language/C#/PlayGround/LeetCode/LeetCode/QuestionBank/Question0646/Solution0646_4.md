#### 方法三：贪心

**思路**

要挑选最长数对链的第一个数对时，最优的选择是挑选第二个数字最小的，这样能给挑选后续的数对留下更多的空间。挑完第一个数对后，要挑第二个数对时，也是按照相同的思路，是在剩下的数对中，第一个数字满足题意的条件下，挑选第二个数字最小的。按照这样的思路，可以先将输入按照第二个数字排序，然后不停地判断第一个数字是否能满足大于前一个数对的第二个数字即可。

**代码**

```Python3
class Solution(object):
    def findLongestChain(self, pairs: List[List[int]]) -> int:
        cur, res = -inf, 0
        for x, y in sorted(pairs, key=lambda p: p[1]):
            if cur < x:
                cur = y
                res += 1
        return res

```

```C++
class Solution {
public:
    int findLongestChain(vector<vector<int>>& pairs) {
        int curr = INT_MIN, res = 0;
        sort(pairs.begin(), pairs.end(), [](const vector<int> &a, const vector<int> &b) {
            return a[1] < b[1];
        });
        for (auto &p : pairs) {
            if (curr < p[0]) {
                curr = p[1];
                res++;
            }
        }
        return res;
    }
};

```

```Java
class Solution {
    public int findLongestChain(int[][] pairs) {
        int curr = Integer.MIN_VALUE, res = 0;
        Arrays.sort(pairs, (a, b) -> a[1] - b[1]);
        for (int[] p : pairs) {
            if (curr < p[0]) {
                curr = p[1];
                res++;
            }
        }
        return res;
    }
}

```

```C#
public class Solution {
    public int FindLongestChain(int[][] pairs) {
        int curr = int.MinValue, res = 0;
        Array.Sort(pairs, (a, b) => a[1] - b[1]);
        foreach (int[] p in pairs) {
            if (curr < p[0]) {
                curr = p[1];
                res++;
            }
        }
        return res;
    }
}

```

```C
static inline int cmp(const void *pa, const void *pb) {
    return (*(int **)pa)[1] - (*(int **)pb)[1];
}

int findLongestChain(int** pairs, int pairsSize, int* pairsColSize){
    int curr = INT_MIN, res = 0;
    qsort(pairs, pairsSize, sizeof(int *), cmp);
    for (int i = 0; i < pairsSize; i++) {
        if (curr < pairs[i][0]) {
            curr = pairs[i][1];
            res += 1;
        }
    }
    return res;
}

```

```Golang
func findLongestChain(pairs [][]int) (ans int) {
    sort.Slice(pairs, func(i, j int) bool { return pairs[i][1] < pairs[j][1] })
    cur := math.MinInt32
    for _, p := range pairs {
        if cur < p[0] {
            cur = p[1]
            ans++
        }
    }
    return
}

```

```JavaScript
var findLongestChain = function(pairs) {
    let curr = -Number.MAX_VALUE, res = 0;
    pairs.sort((a, b) => a[1] - b[1]);
    for (const p of pairs) {
        if (curr < p[0]) {
            curr = p[1];
            res++;
        }
    }
    return res;
}

```

**复杂度分析**

-   时间复杂度：O(nlogn)，其中 n 为 pairs 的长度。排序的时间复杂度为 O(nlogn)。

-   空间复杂度：O(logn)，为排序的空间复杂度。
