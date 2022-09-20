#### [](https://leetcode.cn/problems/partition-to-k-equal-sum-subsets/solution/hua-fen-wei-kge-xiang-deng-de-zi-ji-by-l-v66o//#��������״̬ѹ��-��̬�滮)��������״̬ѹ�� + ��̬�滮

**˼·���㷨**

����ͬ�������á���̬�滮�����֡��Ե����ϡ��ķ���������Ƿ���ڿ��з�����ͬ��������һ������ S ����ʾ��ǰ���õ����ּ��ϣ��ӵ�λ����λ���� i λΪ 0 ���ʾ���� nums[i] ����ʹ�ã������ʾ nums[i] �ѱ�ʹ�á�Ȼ�������� dp[S] ����ʾ�ڿ��õ�����״̬Ϊ SSS ��������Ƿ���ܿ��У���ʼȫ��״̬Ϊ��¼Ϊ������״̬ False��ֻ�� dp[0]=True Ϊ����״̬��ͬ������ÿ�ζ��ڵ�ǰ״̬�´ӿ��õ�������ѡ��һ�����֣�����ʱѡ��ȫ������ȡģ��С�ڵ��� per����˵��ѡ������ֺ��״̬�ټ���������������ǿ�������������ģ����Ҵ�ʱ���״Ϊ���ܿ���״̬�������һ�����ܴﵽ���㡣���� dp[U] ���ɣ����� U ��ʾȫ������ʹ�õļ���״̬��

**����**

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

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�O(n��2^n^)������ n Ϊ���� nums �ĳ��ȣ����� 2^n^ ��״̬��ÿһ��״̬������ n �γ��ԡ�
-   �ռ临�Ӷȣ�O(2^n^)������ n Ϊ���� nums �ĳ��ȣ���ҪΪ״̬����Ŀռ俪����
