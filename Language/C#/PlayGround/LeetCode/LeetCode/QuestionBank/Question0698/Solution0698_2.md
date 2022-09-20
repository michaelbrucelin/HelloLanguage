#### [](https://leetcode.cn/problems/partition-to-k-equal-sum-subsets/solution/hua-fen-wei-kge-xiang-deng-de-zi-ji-by-l-v66o//#方法一：状态压缩-记忆化搜索)方法一：状态压缩 + 记忆化搜索

**思路与算法**

题目给定长度为 n 的数组 nums，和整数 k，我们需要判断是否能将数组分成 k 个总和相等的非空子集。首先计算数组的和 all，如果 all 不是 k 的倍数，那么不可能能有合法方案，此时直接返回 False。否则我们需要得到 k 个和为 $per=\frac{all}{k}$ 的集合，那么我们每次尝试选择一个还在数组中的数，若选择后当前已选数字和等于 per 则说明得到了一个集合，而已选数字和大于 per 时，不可能形成一个集合从而停止继续往下选择新的数字。又因为 n 满足 1≤n≤16，所以我们可以用一个整数 S 来表示当前可用的数字集合：从低位到高位，第 i 位为 1 则表示数字 nums[i] 可以使用，否则表示 nums[i] 已被使用。为了避免相同状态的重复计算，我们用 dp[S] 来表示在可用的数字状态为 S 的情况下是否可行，初始全部状态为记录为可行状态 True。这样我们就可以通过记忆化搜索这种「自顶向下」的方式来进行求解原始状态的可行性，而当状态集合中不存在任何数字时，即 S\=0 时，表示原始数组可以按照题目要求来进行分配，此时返回 True 即可。

**代码**

```Python
class Solution:
    def canPartitionKSubsets(self, nums: List[int], k: int) -> bool:
        all = sum(nums)
        if all % k:
            return False
        per = all // k
        nums.sort()  # 方便下面剪枝
        if nums[-1] > per:
            return False
        n = len(nums)

        @cache
        def dfs(s, p):
            if s == 0:
                return True
            for i in range(n):
                if nums[i] + p > per:
                    break
                if s >> i & 1 and dfs(s ^ (1 << i), (p + nums[i]) % per):  # p + nums[i] 等于 per 时置为 0
                    return True
            return False
        return dfs((1 << n) - 1, 0)

```

```Java
class Solution {
    int[] nums;
    int per, n;
    boolean[] dp;

    public boolean canPartitionKSubsets(int[] nums, int k) {
        this.nums = nums;
        int all = Arrays.stream(nums).sum();
        if (all % k != 0) {
            return false;
        }
        per = all / k;
        Arrays.sort(nums);
        n = nums.length;
        if (nums[n - 1] > per) {
            return false;
        }
        dp = new boolean[1 << n];
        Arrays.fill(dp, true);
        return dfs((1 << n) - 1, 0);
    }

    public boolean dfs(int s, int p) {
        if (s == 0) {
            return true;
        }
        if (!dp[s]) {
            return dp[s];
        }
        dp[s] = false;
        for (int i = 0; i < n; i++) {
            if (nums[i] + p > per) {
                break;
            }
            if (((s >> i) & 1) != 0) {
                if (dfs(s ^ (1 << i), (p + nums[i]) % per)) {
                    return true;
                }
            }
        }
        return false;
    }
}

```

```C#
public class Solution {
    int[] nums;
    int per, n;
    bool[] dp;

    public bool CanPartitionKSubsets(int[] nums, int k) {
        this.nums = nums;
        int all = nums.Sum();
        if (all % k != 0) {
            return false;
        }
        per = all / k;
        Array.Sort(nums);
        n = nums.Length;
        if (nums[n - 1] > per) {
            return false;
        }
        dp = new bool[1 << n];
        Array.Fill(dp, true);
        return DFS((1 << n) - 1, 0);
    }

    public bool DFS(int s, int p) {
        if (s == 0) {
            return true;
        }
        if (!dp[s]) {
            return dp[s];
        }
        dp[s] = false;
        for (int i = 0; i < n; i++) {
            if (nums[i] + p > per) {
                break;
            }
            if (((s >> i) & 1) != 0) {
                if (DFS(s ^ (1 << i), (p + nums[i]) % per)) {
                    return true;
                }
            }
        }
        return false;
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
        vector<bool> dp(1 << n, true);
        function<bool(int,int)> dfs = [&](int s, int p)->bool {
            if (s == 0) {
                return true;
            }
            if (!dp[s]) {
                return dp[s];
            }
            dp[s] = false;
            for (int i = 0; i < n; i++) {
                if (nums[i] + p > per) {
                    break;
                }
                if ((s >> i) & 1) {
                    if (dfs(s ^ (1 << i), (p + nums[i]) % per)) {
                        return true;
                    }
                }
            }
            return false;
        };
        return dfs((1 << n) - 1, 0);
    }
};

```

```C
static inline int cmp(const void *pa, const void *pb) {
    return *(int *)pa - *(int *)pb;
}

static bool dfs(int s, int p, int per, int* nums, int numsSize, bool* dp) {
    if (s == 0) {
        return true;
    }
    if (!dp[s]) {
        return dp[s];
    }
    dp[s] = false;
    for (int i = 0; i < numsSize; i++) {
        if (nums[i] + p > per) {
            break;
        }
        if ((s >> i) & 1) {
            if (dfs(s ^ (1 << i), (p + nums[i]) % per, per, nums, numsSize, dp)) {
                return true;
            }
        }
    }
    return false;
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
    memset(dp, true, sizeof(bool) * (1 << numsSize));
    return dfs((1 << numsSize) - 1, 0, per, nums, numsSize, dp);
}

```

```JavaScript
var canPartitionKSubsets = function(nums, k) {
    const dfs = (s, p) => {
        if (s === 0) {
            return true;
        }
        if (!dp[s]) {
            return dp[s];
        }
        dp[s] = false;
        for (let i = 0; i < n; i++) {
            if (nums[i] + p > per) {
                break;
            }
            if (((s >> i) & 1) != 0) {
                if (dfs(s ^ (1 << i), (p + nums[i]) % per)) {
                    return true;
                }
            }
        }
        return false;
    };
    const all = _.sum(nums);
    if (all % k !== 0) {
        return false;
    }
    per = all / k;
    nums.sort((a, b) => a - b);
    n = nums.length;
    if (nums[n - 1] > per) {
        return false;
    }
    dp = new Array(1 << n).fill(true);
    return dfs((1 << n) - 1, 0);
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
    for i := range dp {
        dp[i] = true
    }
    var dfs func(int, int) bool
    dfs = func(s, p int) bool {
        if s == 0 {
            return true
        }
        if !dp[s] {
            return dp[s]
        }
        dp[s] = false
        for i, num := range nums {
            if num+p > per {
                break
            }
            if s>>i&1 > 0 && dfs(s^1<<i, (p+nums[i])%per) {
                return true
            }
        }
        return false
    }
    return dfs(1<<n-1, 0)
}

```

**复杂度分析**

-   时间复杂度：O(n×2^n^)，其中 n 为数组 nums 的长度，共有 2^n^ 个状态，每一个状态进行了 n 次尝试。
-   空间复杂度：O(2^n^)，其中 n 为数组 nums 的长度，主要为状态数组的空间开销。
