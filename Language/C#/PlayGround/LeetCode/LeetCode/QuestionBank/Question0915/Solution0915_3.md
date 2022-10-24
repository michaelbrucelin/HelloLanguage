#### [](https://leetcode.cn/problems/partition-array-into-disjoint-intervals/solution/fen-ge-shu-zu-by-leetcode-solution-t4pm//#方法二：一次遍历)方法二：一次遍历

**思路和算法**

假设我们预先规定了一个 left 的划分，其最大值为 maxLeft，划分位置为 leftPos，表示 nums[0,leftPos] 都属于 left。如果 leftPos 右侧所有元素都大于等于它，那么该划分方案是合法的。

但如果我们找到 nums[i]，其中 i>leftPos，并且 nums[i]<maxLeft，那么意味着 leftPos 作为划分位置是非法的，需要更新 leftPos=i，以及 $maxLeft=\mathop{max}\limits_{⁡0}^{i} nums[i]$。

因此，我们首先初始化 maxLeft=nums[0]，leftPos=0，然后在 [1,n−2] 范围内从小到大遍历 i，过程中维护一个变量 curMax，它的值是 $\mathop{max}\limits_{⁡0}^{i} nums[i]$。此时如果有 nums[i]<maxLeft，就按照上述方法更新。最终遍历结束时，答案就是 leftPos+1。

```Python
class Solution:
    def partitionDisjoint(self, nums: List[int]) -> int:
        n = len(nums)
        cur_max = left_max = nums[0]
        left_pos = 0
        for i in range(1, n - 1):
            cur_max = max(cur_max, nums[i])
            if nums[i] < left_max:
                left_max, left_pos = cur_max, i
        return left_pos + 1
```

```C++
class Solution {
public:
    int partitionDisjoint(vector<int>& nums) {
        int n = nums.size();
        int leftMax = nums[0], leftPos = 0, curMax = nums[0];
        for (int i = 1; i < n - 1; i++) {
            curMax = max(curMax, nums[i]);
            if (nums[i] < leftMax) {
                leftMax = curMax;
                leftPos = i;
            }
        }
        return leftPos + 1;
    }
};
```

```Java
class Solution {
    public int partitionDisjoint(int[] nums) {
        int n = nums.length;
        int leftMax = nums[0], leftPos = 0, curMax = nums[0];
        for (int i = 1; i < n - 1; i++) {
            curMax = Math.max(curMax, nums[i]);
            if (nums[i] < leftMax) {
                leftMax = curMax;
                leftPos = i;
            }
        }
        return leftPos + 1;
    }
}
```

```C#
public class Solution {
    public int PartitionDisjoint(int[] nums) {
        int n = nums.Length;
        int leftMax = nums[0], leftPos = 0, curMax = nums[0];
        for (int i = 1; i < n - 1; i++) {
            curMax = Math.Max(curMax, nums[i]);
            if (nums[i] < leftMax) {
                leftMax = curMax;
                leftPos = i;
            }
        }
        return leftPos + 1;
    }
}
```

```C
#define MAX(a, b) ((a) > (b) ? (a) : (b))

int partitionDisjoint(int* nums, int numsSize) {
    int leftMax = nums[0], leftPos = 0, curMax = nums[0];
    for (int i = 1; i < numsSize - 1; i++) {
        curMax = MAX(curMax, nums[i]);
        if (nums[i] < leftMax) {
            leftMax = curMax;
            leftPos = i;
        }
    }
    return leftPos + 1;
}
```

```JavaScript
var partitionDisjoint = function(nums) {
    const n = nums.length;
    let leftMax = nums[0], leftPos = 0, curMax = nums[0];
    for (let i = 1; i < n - 1; i++) {
        curMax = Math.max(curMax, nums[i]);
        if (nums[i] < leftMax) {
            leftMax = curMax;
            leftPos = i;
        }
    }
    return leftPos + 1;
};
```

```Go
func partitionDisjoint(nums []int) int {
    n := len(nums)
    leftMax, leftPos, curMax := nums[0], 0, nums[0]
    for i := 1; i < n-1; i++ {
        curMax = max(curMax, nums[i])
        if nums[i] < leftMax {
            leftMax = curMax
            leftPos = i
        }
    }
    return leftPos + 1
}

func max(a, b int) int {
    if b > a {
        return b
    }
    return a
}
```

**复杂度分析**

-   时间复杂度：O(n)，其中 n 是 nums 的长度。从前到后遍历 i 的时间复杂度为 O(n)。
-   空间复杂度：O(1)。算法只使用了常数个变量。
