#### [](https://leetcode.cn/problems/k-th-symbol-in-grammar/solution/di-kge-yu-fa-fu-hao-by-leetcode-solution-zgwd//#方法三：找规律-位运算)方法三：找规律 + 位运算

**思路与算法**

在「方法二」的基础上，我们来进行优化，本质上我们其实只需要求在过程中的“翻转”总次数，如果“翻转”为偶数次则原问题求解为 0，否则为 1。

首先我们修改行的索引从 0 开始，此时原先第 p 行的索引现在为 p−1 行，第 i 行有 $2^i$ 位。那么对于某一行 i 中下标为 x 的数字，如果 $x<2^{i−1}$ 那么等价于求 i−1 中下标为 x 的数字，否则 x 的二进制位的从右往左第 i+1 位为 1，此时需要减去该位（“翻转”一次），然后递归求解即可。所以我们可以看到最后“翻转”的总次数只和初始状态下的下标 x 二进制表示中 1 的个数有关。因此原问题中求“翻转”的总次数就等价于求 k−1 的二进制表示中 1 的个数，求解方法具体可以参考题库题目[「191. 位1的个数」的官方题解](https://leetcode.cn/problems/number-of-1-bits/solution/wei-1de-ge-shu-by-leetcode-solution-jnwf/) 来更进一步学习求解。

**代码**

```Python
class Solution:
    def kthGrammar(self, n: int, k: int) -> int:
        # return (k - 1).bit_count() & 1
        k -= 1
        res = 0
        while k:
            k &= k - 1
            res ^= 1
        return res
```

```Java
class Solution {
    public int kthGrammar(int n, int k) {
        // return Integer.bitCount(k - 1) & 1;
        k--;
        int res = 0;
        while (k > 0) {
            k &= k - 1;
            res ^= 1;
        }
        return res;
    }
}
```

```C#
public class Solution {
    public int KthGrammar(int n, int k) {
        k--;
        int res = 0;
        while (k > 0) {
            k &= k - 1;
            res ^= 1;
        }
        return res;
    }
}
```

```C++
class Solution {
public:
    int kthGrammar(int n, int k) {
        // return __builtin_popcount(k - 1) & 1;
        k--;
        int res = 0;
        while (k > 0) {
            k &= k - 1;
            res ^= 1;
        }
        return res;
    }
};
```

```C
int kthGrammar(int n, int k){
    k--;
    int res = 0;
    while (k > 0) {
        k &= k - 1;
        res ^= 1;
    }
    return res;
}
```

```JavaScript
var kthGrammar = function(n, k) {
    k--;
    let res = 0;
    while (k > 0) {
        k &= k - 1;
        res ^= 1;
    }
    return res;
};
```

```Go
func kthGrammar(n, k int) (ans int) {
    // return bits.OnesCount(uint(k-1)) & 1
    for k--; k > 0; k &= k - 1 {
        ans ^= 1
    }
    return
}
```

**复杂度分析**

-   时间复杂度：O(log⁡k)，其中 k 为题目给定查询的下标。
-   空间复杂度：O(1)，仅使用常量变量。
