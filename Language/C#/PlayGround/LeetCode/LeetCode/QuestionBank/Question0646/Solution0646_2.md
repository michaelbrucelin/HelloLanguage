#### 前言

这题和「[435\. 无重叠区间](https://leetcode.cn/problems/non-overlapping-intervals/)」类似，区别就是：

1.  此题中，数对链中相邻的数对，前者的第二个数字必须小于后者的第一个数字。而在「[435\. 无重叠区间](https://leetcode.cn/problems/non-overlapping-intervals/)」中，相邻的区间，前者的结束时间需小于等于后者的开始时间。
2.  此题返回最长数对链的长度，而 「[435\. 无重叠区间](https://leetcode.cn/problems/non-overlapping-intervals/)」返回形成无重叠区间，最少需要删除多少区间（即原长度减去最长数对链的长度）。

此题解也按照「[435\. 无重叠区间的官方题解](https://leetcode.cn/problems/non-overlapping-intervals/solution/wu-zhong-die-qu-jian-by-leetcode-solutio-cpsb/)」进行编写。

#### [](https://leetcode.cn/problems/maximum-length-of-pair-chain/solution/zui-chang-shu-dui-lian-by-leetcode-solut-ifpn//#方法一：动态规划)方法一：动态规划

**思路**

定义 dp[i] 为以 pairs[i] 为结尾的最长数对链的长度。计算 dp[i]时，可以先找出所有的满足 pairs[i][0]\>pairs[j][1] 的 j，并求出最大的 dp[j]，dp[i] 的值即可赋为这个最大值加一。这种动态规划的思路要求计算 dp[i] 时，所有潜在的 dp[j] 已经计算完成，可以先将 pairs 进行排序来满足这一要求。初始化时，dp 需要全部赋值为 1。

**代码**

```Python3
class Solution:
    def findLongestChain(self, pairs: List[List[int]]) -> int:
        pairs.sort()
        dp = [1] * len(pairs)
        for i in range(len(pairs)):
            for j in range(i):
                if pairs[i][0] > pairs[j][1]:
                    dp[i] = max(dp[i], dp[j] + 1)
        return dp[-1]

```

```C++
class Solution {
public:
    int findLongestChain(vector<vector<int>>& pairs) {
        int n = pairs.size();
        sort(pairs.begin(), pairs.end());
        vector<int> dp(n, 1);
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < i; j++) {
                if (pairs[i][0] > pairs[j][1]) {
                    dp[i] = max(dp[i], dp[j] + 1);
                }
            }
        }
        return dp[n - 1];
    }
};

```

```Java
class Solution {
    public int findLongestChain(int[][] pairs) {
        int n = pairs.length;
        Arrays.sort(pairs, (a, b) -> a[0] - b[0]);
        int[] dp = new int[n];
        Arrays.fill(dp, 1);
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < i; j++) {
                if (pairs[i][0] > pairs[j][1]) {
                    dp[i] = Math.max(dp[i], dp[j] + 1);
                }
            }
        }
        return dp[n - 1];
    }
}

```

```C#
public class Solution {
    public int FindLongestChain(int[][] pairs) {
        int n = pairs.Length;
        Array.Sort(pairs, (a, b) => a[0] - b[0]);
        int[] dp = new int[n];
        Array.Fill(dp, 1);
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < i; j++) {
                if (pairs[i][0] > pairs[j][1]) {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
        }
        return dp[n - 1];
    }
}

```

```C
#define MAX(a, b) ((a) > (b) ? (a) : (b))

static inline int cmp(const void *pa, const void *pb) {
    if ((*(int **)pa)[0] == (*(int **)pb)[0]) {
        return (*(int **)pa)[1] == (*(int **)pb)[1];
    } 
    return (*(int **)pa)[0] - (*(int **)pb)[0];
}

int findLongestChain(int** pairs, int pairsSize, int* pairsColSize){
    qsort(pairs, pairsSize, sizeof(int *), cmp);
    int *dp = (int *)malloc(sizeof(int) * pairsSize);
    for (int i = 0; i < pairsSize; i++) {
        dp[i] = 1;
    }
    for (int i = 0; i < pairsSize; i++) {
        for (int j = 0; j < i; j++) {
            if (pairs[i][0] > pairs[j][1]) {
                dp[i] = MAX(dp[i], dp[j] + 1);
            }
        }
    }
    int ret = dp[pairsSize - 1];
    free(dp);
    return ret;
}

```

```Golang
func findLongestChain(pairs [][]int) int {
    sort.Slice(pairs, func(i, j int) bool { return pairs[i][0] < pairs[j][0] })
    n := len(pairs)
    dp := make([]int, n)
    for i, p := range pairs {
        dp[i] = 1
        for j, q := range pairs[:i] {
            if p[0] > q[1] {
                dp[i] = max(dp[i], dp[j]+1)
            }
        }
    }
    return dp[n-1]
}

func max(a, b int) int {
    if b > a {
        return b
    }
    return a
}

```

```JavaScript
var findLongestChain = function(pairs) {
    const n = pairs.length;
    pairs.sort((a, b) => a[0] - b[0]);
    const dp = new Array(n).fill(1);
    for (let i = 0; i < n; i++) {
        for (let j = 0; j < i; j++) {
            if (pairs[i][0] > pairs[j][1]) {
                dp[i] = Math.max(dp[i], dp[j] + 1);
            }
        }
    }
    return dp[n - 1];
};

```

**复杂度分析**

-   时间复杂度：O(n^2^)，其中 n 为 pairs 的长度。排序的时间复杂度为 O(nlogn)，两层 for 循环的时间复杂度为 O(n^2^)。

-   空间复杂度：O(n)，数组 dp 的空间复杂度为 O(n)。
