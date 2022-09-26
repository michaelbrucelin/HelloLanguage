#### [](https://leetcode.cn/problems/missing-two-lcci/solution/xiao-shi-de-liang-ge-shu-zi-by-leetcode-zuwq3//#方法一：位运算)方法一：位运算

**思路与算法**

寻找消失的数字，最直观的方法是使用哈希表存储数组中出现过的数字。由于这道题有时间复杂度 O(n) 和空间复杂度 O(1) 的要求，因此不能使用哈希表求解，必须使用其他方法。利用位运算的性质，可以达到时间复杂度 O(n) 和空间复杂度 O(1)。

由于从 1 到 n 的整数中有两个整数消失，其余每个整数都在数组中出现一次，因此数组的长度是 n−2。在数组中的 n−2 个数后面添加从 1 到 n 的每个整数各一次，则得到 2n−2 个数字，其中两个在数组中消失的数字各出现一次，其余每个数字各出现两次。

假设数组 nums 中消失的两个数字分别是 x1 和 x2。如果把上述 2n−2 个数字全部异或起来，得到结果 x，那么一定有：

x=x1⊕x2

其中 ⊕ 表示异或运算。这是因为 nums 中出现两次的元素都会因为异或运算的性质 a⊕b⊕b=a 抵消掉，那么最终的结果就只剩下 x1 和 x2 的异或和。

显然 x≠0，因为如果 x=0，那么说明 x1=x2，这样 x1 和 x2 就不是在上述 2n−2 个数字中只出现一次的数字了。因此，我们可以使用位运算 x & -x 取出 x 的二进制表示中最低位那个 1，设其为第 l 位，那么 x1 和 x2 中的某一个数的二进制表示的第 l 位为 0，另一个数的二进制表示的第 l 位为 1。在这种情况下，x1⊕x2 的二进制表示的第 l 位才能为 1。

这样一来，我们就可以把从 1 到 n 的所有整数分成两类，其中一类包含所有二进制表示的第 l 位为 0 的数，另一类包含所有二进制表示的第 l 位为 1 的数。可以发现：

-   对于任意一个在数组 nums 中出现一次的数字，这些数字在上述 2n−2 个数字中出现两次，两次出现会被包含在同一类中；

-   对于任意一个在数组 nums 中消失的数字，即 x1 和 x2，这些数字在上述 2n−2 个数字中出现一次，会被包含在不同类中。


因此，如果我们将每一类的元素全部异或起来，那么其中一类会得到 x1，另一类会得到 x2。这样我们就找出了这两个只出现一次的元素。

**代码**

```C++
class Solution {
public:
    vector<int> missingTwo(vector<int>& nums) {
        int xorsum = 0;
        int n = nums.size() + 2;
        for (int num : nums) {
            xorsum ^= num;
        }
        for (int i = 1; i <= n; i++) {
            xorsum ^= i;
        }
        // 防止溢出
        int lsb = (xorsum == INT_MIN ? xorsum : xorsum & (-xorsum));
        int type1 = 0, type2 = 0;
        for (int num : nums) {
            if (num & lsb) {
                type1 ^= num;
            } else {
                type2 ^= num;
            }
        }
        for (int i = 1; i <= n; i++) {
            if (i & lsb) {
                type1 ^= i;
            } else {
                type2 ^= i;
            }
        }
        return {type1, type2};
    }
};

```

```Java
class Solution {
    public int[] missingTwo(int[] nums) {
        int xorsum = 0;
        int n = nums.length + 2;
        for (int num : nums) {
            xorsum ^= num;
        }
        for (int i = 1; i <= n; i++) {
            xorsum ^= i;
        }
        // 防止溢出
        int lsb = (xorsum == Integer.MIN_VALUE ? xorsum : xorsum & (-xorsum));
        int type1 = 0, type2 = 0;
        for (int num : nums) {
            if ((num & lsb) != 0) {
                type1 ^= num;
            } else {
                type2 ^= num;
            }
        }
        for (int i = 1; i <= n; i++) {
            if ((i & lsb) != 0) {
                type1 ^= i;
            } else {
                type2 ^= i;
            }
        }
        return new int[]{type1, type2};
    }
}

```

```C#
public class Solution {
    public int[] MissingTwo(int[] nums) {
        int xorsum = 0;
        int n = nums.Length + 2;
        foreach (int num in nums) {
            xorsum ^= num;
        }
        for (int i = 1; i <= n; i++) {
            xorsum ^= i;
        }
        // 防止溢出
        int lsb = (xorsum == int.MinValue ? xorsum : xorsum & (-xorsum));
        int type1 = 0, type2 = 0;
        foreach (int num in nums) {
            if ((num & lsb) != 0) {
                type1 ^= num;
            } else {
                type2 ^= num;
            }
        }
        for (int i = 1; i <= n; i++) {
            if ((i & lsb) != 0) {
                type1 ^= i;
            } else {
                type2 ^= i;
            }
        }
        return new int[]{type1, type2};
    }
}

```

```Python
class Solution:
    def missingTwo(self, nums: List[int]) -> List[int]:
        xorsum = 0
        n = len(nums) + 2
        for num in nums:
            xorsum ^= num
        for i in range(1, n + 1):
            xorsum ^= i
        
        lsb = xorsum & (-xorsum)
        type1 = type2 = 0
        for num in nums:
            if num & lsb:
                type1 ^= num
            else:
                type2 ^= num
        for i in range(1, n + 1):
            if i & lsb:
                type1 ^= i
            else:
                type2 ^= i
        
        return [type1, type2]

```

```JavaScript
var missingTwo = function(nums) {
    let xorsum = 0;
    let n = nums.length + 2;
    for (const num of nums) {
        xorsum ^= num;
    }
    for (let i = 1; i <= n; i++) {
        xorsum ^= i;
    }
    let type1 = 0, type2 = 0;
    const lsb = xorsum & (-xorsum);
    for (const num of nums) {
        if (num & lsb) {
            type1 ^= num;
        } else {
            type2 ^= num;
        }
    }
    for (let i = 1; i <= n; i++) {
        if (i & lsb) {
            type1 ^= i;
        } else {
            type2 ^= i;
        }
    }
    return [type1, type2];
};

```

```Go
func missingTwo(nums []int) []int {
    xorSum := 0
    n := len(nums) + 2
    for _, num := range nums {
        xorSum ^= num
    }
    for i := 1; i <= n; i++ {
        xorSum ^= i
    }
    lsb := xorSum & -xorSum
    type1, type2 := 0, 0
    for _, num := range nums {
        if num&lsb > 0 {
            type1 ^= num
        } else {
            type2 ^= num
        }
    }
    for i := 1; i <= n; i++ {
        if i&lsb > 0 {
            type1 ^= i
        } else {
            type2 ^= i
        }
    }
    return []int{type1, type2}
}

```

```C
int* missingTwo(int* nums, int numsSize, int* returnSize) {
    int xorsum = 0;
    int n = numsSize + 2;
    for (int i = 0; i < numsSize; i++) {
        xorsum ^= nums[i];
    }
    for (int i = 1; i <= n; i++) {
        xorsum ^= i;
    }
    // 防止溢出
    int lsb = (xorsum == INT_MIN ? xorsum : xorsum & (-xorsum));
    int type1 = 0, type2 = 0;
    for (int i = 0; i < numsSize; i++) {
        int num = nums[i];
        if (num & lsb) {
            type1 ^= num;
        } else {
            type2 ^= num;
        }
    }
    for (int i = 1; i <= n; i++) {
        if (i & lsb) {
            type1 ^= i;
        } else {
            type2 ^= i;
        }
    }

    int *ans = (int *)malloc(sizeof(int) * 2);
    ans[0] = type1;
    ans[1] = type2;
    *returnSize = 2;
    return ans;
}

```

**复杂度分析**

-   时间复杂度：O(n)，其中 n 是最大的整数。需要遍历的数字有 2n−2 个，共遍历两次。

-   空间复杂度：O(1)。
