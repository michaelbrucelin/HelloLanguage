#### 方法三：位运算

数组 nums 中有 n−1 个数，在这 n−1 个数的后面添加从 0 到 n−1 的每个整数，则添加了 n 个整数，共有 2n−1 个整数。

在 2n−1 个整数中，缺失的数字只在后面 n 个整数中出现一次，其余的数字在前面 n−1 个整数中（即数组中）和后面 n 个整数中各出现一次，即其余的数字都出现了两次。

根据出现的次数的奇偶性，可以使用按位异或运算得到缺失的数字。按位异或运算 ⊕ 满足交换律和结合律，且对任意整数 x 都满足 x⊕x\=0 和 x⊕0\=x。

由于上述 2n−1 个整数中，缺失的数字出现了一次，其余的数字都出现了两次，因此对上述 2n−1 个整数进行按位异或运算，结果即为缺失的数字。

```Java
class Solution {
    public int missingNumber(int[] nums) {
        int xor = 0;
        int n = nums.length + 1;
        for (int i = 0; i < n - 1; i++) {
            xor ^= nums[i];
        }
        for (int i = 0; i <= n - 1; i++) {
            xor ^= i;
        }
        return xor;
    }
}
```

```C#
public class Solution {
    public int MissingNumber(int[] nums) {
        int xor = 0;
        int n = nums.Length + 1;
        for (int i = 0; i < n - 1; i++) {
            xor ^= nums[i];
        }
        for (int i = 0; i <= n - 1; i++) {
            xor ^= i;
        }
        return xor;
    }
}
```

```C++
class Solution {
public:
    int missingNumber(vector<int>& nums) {
        int res = 0;
        int n = nums.size() + 1;
        for (int i = 0; i < n - 1; i++) {
            res ^= nums[i];
        }
        for (int i = 0; i <= n - 1; i++) {
            res ^= i;
        }
        return res;
    }
};
```

```JavaScript
var missingNumber = function(nums) {
    let xor = 0;
    const n = nums.length + 1;
    for (let i = 0; i < n - 1; i++) {
        xor ^= nums[i];
    }
    for (let i = 0; i <= n - 1; i++) {
        xor ^= i;
    }
    return xor;
};
```

```TypeScript
var missingNumber = function(nums) {
    let xor: number = 0;
    const n: number = nums.length;
    for (let i = 0; i < n - 1; i++) {
        xor ^= nums[i];
    }
    for (let i = 0; i <= n - 1; i++) {
        xor ^= i;
    }
    return xor;
};
```

```Go
func missingNumber(nums []int) (xor int) {
    for i, num := range nums {
        xor ^= i ^ num
    }
    return xor ^ len(nums)
}
```

```Python
class Solution:
    def missingNumber(self, nums: List[int]) -> int:
        xor = 0
        for i, num in enumerate(nums):
            xor ^= i ^ num
        return xor ^ len(nums)
```

**复杂度分析**

-   时间复杂度：O(n)，其中 n 是数组 nums 的长度加 1。需要对 2n−1 个数字计算按位异或的结果。
-   空间复杂度：O(1)。
