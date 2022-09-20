#### [](https://leetcode.cn/problems/partition-to-k-equal-sum-subsets/solution/hua-fen-wei-kge-xiang-deng-de-zi-ji-by-l-v66o//#����һ��״̬ѹ��-���仯����)����һ��״̬ѹ�� + ���仯����

**˼·���㷨**

��Ŀ��������Ϊ n ������ nums�������� k��������Ҫ�ж��Ƿ��ܽ�����ֳ� k ���ܺ���ȵķǿ��Ӽ������ȼ�������ĺ� all����� all ���� k �ı�������ô���������кϷ���������ʱֱ�ӷ��� False������������Ҫ�õ� k ����Ϊ $per=\frac{all}{k}$ �ļ��ϣ���ô����ÿ�γ���ѡ��һ�����������е�������ѡ���ǰ��ѡ���ֺ͵��� per ��˵���õ���һ�����ϣ�����ѡ���ֺʹ��� per ʱ���������γ�һ�����ϴӶ�ֹͣ��������ѡ���µ����֡�����Ϊ n ���� 1��n��16���������ǿ�����һ������ S ����ʾ��ǰ���õ����ּ��ϣ��ӵ�λ����λ���� i λΪ 1 ���ʾ���� nums[i] ����ʹ�ã������ʾ nums[i] �ѱ�ʹ�á�Ϊ�˱�����ͬ״̬���ظ����㣬������ dp[S] ����ʾ�ڿ��õ�����״̬Ϊ S ��������Ƿ���У���ʼȫ��״̬Ϊ��¼Ϊ����״̬ True���������ǾͿ���ͨ�����仯�������֡��Զ����¡��ķ�ʽ���������ԭʼ״̬�Ŀ����ԣ�����״̬�����в������κ�����ʱ���� S\=0 ʱ����ʾԭʼ������԰�����ĿҪ�������з��䣬��ʱ���� True ���ɡ�

**����**

```Python
class Solution:
    def canPartitionKSubsets(self, nums: List[int], k: int) -> bool:
        all = sum(nums)
        if all % k:
            return False
        per = all // k
        nums.sort()  # ���������֦
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
                if s >> i & 1 and dfs(s ^ (1 << i), (p + nums[i]) % per):  # p + nums[i] ���� per ʱ��Ϊ 0
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

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�O(n��2^n^)������ n Ϊ���� nums �ĳ��ȣ����� 2^n^ ��״̬��ÿһ��״̬������ n �γ��ԡ�
-   �ռ临�Ӷȣ�O(2^n^)������ n Ϊ���� nums �ĳ��ȣ���ҪΪ״̬����Ŀռ俪����
