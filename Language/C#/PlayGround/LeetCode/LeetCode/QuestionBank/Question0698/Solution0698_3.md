#### [](https://leetcode.cn/problems/partition-to-k-equal-sum-subsets/solution/hua-fen-wei-kge-xiang-deng-de-zi-ji-by-l-v66o//#方法二：状态压缩-动态规划)方法二：状态压缩 + 动态规划

**思路与算法**

我们同样可以用「动态规划」这种「自底向上」的方法来求解是否存在可行方案：同样我们用一个整数 S 来表示当前可用的数字集合：从低位到高位，第 i 位为 0 则表示数字 nums[i] 可以使用，否则表示 nums[i] 已被使用。然后我们用 dp[S] 来表示在可用的数字状态为 SSS 的情况下是否可能可行，初始全部状态为记录为不可行状态 False，只记 dp[0]=True 为可行状态。同样我们每次对于当前状态下从可用的数字中选择一个数字，若此时选择全部数字取模后小于等于 per。则说明选择该数字后的状态再继续往下添加数字是可能能满足题意的，并且此时标记状为可能可行状态，否则就一定不能达到满足。最终 dp[U] 即可，其中 U 表示全部数字使用的集合状态。

**代码**

```Python
class Solution:
    def canPartitionKSubsets(self, nums: List[int], k: int) -> bool:
        all = sum(nums)
        if all % k:
            return False
        per = all // k
        nums.sort()
        if nums[-1] > per:
            return False
        n = len(nums)
        dp = [False] * (1 << n)
        dp[0] = True
        cursum = [0] * (1 << n)
        for i in range(0, 1 << n):
            if not dp[i]:
                continue
            for j in range(n):
                if cursum[i] + nums[j] > per:
                    break
                if (i >> j & 1) == 0:
                    next = i | (1 << j)
                    if not dp[next]:
                        cursum[next] = (cursum[i] + nums[j]) % per
                        dp[next] = True
        return dp[(1 << n) - 1]

```

```Java
class Solution {
    public boolean canPartitionKSubsets(int[] nums, int k) {
        int all = Arrays.stream(nums).sum();
        if (all % k != 0) {
            return false;
        }
        int per = all / k;
        Arrays.sort(nums);
        int n = nums.length;
        if (nums[n - 1] > per) {
            return false;
        }
        boolean[] dp = new boolean[1 << n];
        int[] curSum = new int[1 << n];
        dp[0] = true;
        for (int i = 0; i < 1 << n; i++) {
            if (!dp[i]) {
                continue;
            }
            for (int j = 0; j < n; j++) {
                if (curSum[i] + nums[j] > per) {
                    break;
                }
                if (((i >> j) & 1) == 0) {
                    int next = i | (1 << j);
                    if (!dp[next]) {
                        curSum[next] = (curSum[i] + nums[j]) % per;
                        dp[next] = true;
                    }
                }
            }
        }
        return dp[(1 << n) - 1];
    }
}

```

```C#
public class Solution {
    public bool CanPartitionKSubsets(int[] nums, int k) {
        int all = nums.Sum();
        if (all % k != 0) {
            return false;
        }
        int per = all / k;
        Array.Sort(nums);
        int n = nums.Length;
        if (nums[n - 1] > per) {
            return false;
        }
        bool[] dp = new bool[1 << n];
        int[] curSum = new int[1 << n];
        dp[0] = true;
        for (int i = 0; i < 1 << n; i++) {
            if (!dp[i]) {
                continue;
            }
            for (int j = 0; j < n; j++) {
                if (curSum[i] + nums[j] > per) {
                    break;
                }
                if (((i >> j) & 1) == 0) {
                    int next = i | (1 << j);
                    if (!dp[next]) {
                        curSum[next] = (curSum[i] + nums[j]) % per;
                        dp[next] = true;
                    }
                }
            }
        }
        return dp[(1 << n) - 1];
    }
}

```

```C++
class Solution {
public:
    bool canPartitionKSubsets(vector<int>& nums, int k) {
        int all = accumulate(nums.begin(), nums.end(), 0);
        if (all % k > 0) {
            return false;
        }
        int per = all / k; 
        sort(nums.begin(), nums.end());
        if (nums.back() > per) {
            return false;
        }
        int n = nums.size();
        vector<bool> dp(1 << n, false);
        vector<int> curSum(1 << n, 0);
        dp[0] = true;
        for (int i = 0; i < 1 << n; i++) {
            if (!dp[i]) {
                continue;
            }
            for (int j = 0; j < n; j++) {
                if (curSum[i] + nums[j] > per) {
                    break;
                }
                if (((i >> j) & 1) == 0) {
                    int next = i | (1 << j);
                    if (!dp[next]) {
                        curSum[next] = (curSum[i] + nums[j]) % per;
                        dp[next] = true;
                    }
                }
            }
        }
        return dp[(1 << n) - 1];
    }
};

```

```C
static inline int cmp(const void *pa, const void *pb) {
    return *(int *)pa - *(int *)pb;
}

bool canPartitionKSubsets(int* nums, int numsSize, int k) {
    int all = 0;
    for (int i = 0; i < numsSize; i++) {
        all += nums[i];
    }
    if (all % k > 0) {
        return false;
    }
    int per = all / k; 
    qsort(nums, numsSize, sizeof(int), cmp);
    if (nums[numsSize - 1] > per) {
        return false;
    }
    bool *dp = (bool *)malloc(sizeof(bool) * (1 << numsSize));
    int *curSum = (int *)malloc(sizeof(int) * (1 << numsSize));
    memset(dp, false, sizeof(bool) * (1 << numsSize));
    memset(curSum, 0, sizeof(int) * (1 << numsSize));
    dp[0] = true;
    for (int i = 0; i < 1 << numsSize; i++) {
        if (!dp[i]) {
            continue;
        }
        for (int j = 0; j < numsSize; j++) {
            if (curSum[i] + nums[j] > per) {
                break;
            }
            if (((i >> j) & 1) == 0) {
                int next = i | (1 << j);
                if (!dp[next]) {
                    curSum[next] = (curSum[i] + nums[j]) % per;
                    dp[next] = true;
                }
            }
        }
    }
    bool res = dp[(1 << numsSize) - 1];
    free(dp);
    free(curSum);
    return res;
}

```

```JavaScript
var canPartitionKSubsets = function(nums, k) {
    const all = _.sum(nums);
    if (all % k !== 0) {
        return false;
    }
    let per = all / k;
    nums.sort((a, b) => a - b);
    const n = nums.length;
    if (nums[n - 1] > per) {
        return false;
    }
    const dp = new Array(1 << n).fill(false);
    const curSum = new Array(1 << n).fill(0);
    dp[0] = true;
    for (let i = 0; i < 1 << n; i++) {
        if (!dp[i]) {
            continue;
        }
        for (let j = 0; j < n; j++) {
            if (curSum[i] + nums[j] > per) {
                break;
            }
            if (((i >> j) & 1) == 0) {
                let next = i | (1 << j);
                if (!dp[next]) {
                    curSum[next] = (curSum[i] + nums[j]) % per;
                    dp[next] = true;
                }
            }
        }
    }
    return dp[(1 << n) - 1];
}

```

```Go
func canPartitionKSubsets(nums []int, k int) bool {
    all := 0
    for _, v := range nums {
        all += v
    }
    if all%k > 0 {
        return false
    }
    per := all / k
    sort.Ints(nums)
    n := len(nums)
    if nums[n-1] > per {
        return false
    }

    dp := make([]bool, 1<<n)
    dp[0] = true
    curSum := make([]int, 1<<n)
    for i, v := range dp {
        if !v {
            continue
        }
        for j, num := range nums {
            if curSum[i]+num > per {
                break
            }
            if i>>j&1 == 0 {
                next := i | 1<<j
                if !dp[next] {
                    curSum[next] = (curSum[i] + nums[j]) % per
                    dp[next] = true

                }
            }
        }
    }
    return dp[1<<n-1]
}

```

**复杂度分析**

-   时间复杂度：O(n×2^n^)，其中 n 为数组 nums 的长度，共有 2^n^ 个状态，每一个状态进行了 n 次尝试。
-   空间复杂度：O(2^n^)，其中 n 为数组 nums 的长度，主要为状态数组的空间开销。
