#### [方法二：类二分查找](https://leetcode.cn/problems/divide-two-integers/solutions/1041939/liang-shu-xiang-chu-by-leetcode-solution-5hic/)

**前言**

常规意义下的二分查找为：给定区间 [l,r]，取该区间的中点 $mid=\lfloor \frac{l+r}{2} \rfloor$，根据 mid 处是否满足某一条件，来决定移动左边界 l 还是右边界 r。

我们也可以考虑另一种二分查找的方法：
-   记 k 为满足 $2^k \leq r-l < 2^{k+1}$ 的 k 值。
-   二分查找会进行 k+1 次。在第 $i(1 \leq i \leq k+1)$ 次二分查找时，设区间为 $[l_i, r_i]$，我们取 $mid=l_i + 2^{k+1-i}$：
-   如果 mid 不在 $[l_i, r_i]$ 的范围内，那么我们直接忽略这次二分查找；
-   如果 mid 在 $[l_i, r_i]$ 的范围内，并且 mid 处满足某一条件，我们就将 $l_i$ 更新为 mid，否则同样忽略这次二分查找。

最终 $l_i$ 即为二分查找的结果。这样做的正确性在于：
> 设在常规意义下的二分查找的答案为 ans，记 δ 为 ans 与左边界的差值 ans−l。δ 不会大于 r−l，并且 δ 一定可以用 $2^k, 2^{k-1}, 2^{k-2}, \cdots, 2^1, 2^0$ 中的若干个元素之和表示（考虑 δ 的二进制表示的意义即可）。因此上述二分查找是正确的。

**思路与算法**

基于上述的二分查找的方法，我们可以设计出如下的算法：

-   我们首先不断地将 Y 乘以 2（通过加法运算实现），并将这些结果放入数组中，其中数组的第 i 项就等于 $Y \times 2^i$。这一过程直到 Y 的两倍严格小于 X 为止。
-   我们对数组进行逆序遍历。当遍历到第 i 项时，如果其大于等于 X，我们就将答案增加 $2^i$，并且将 X 中减去这一项的值。

本质上，上述的逆序遍历就模拟了二分查找的过程。

**代码**

```cpp
class Solution {
public:
    int divide(int dividend, int divisor) {
        // 考虑被除数为最小值的情况
        if (dividend == INT_MIN) {
            if (divisor == 1) {
                return INT_MIN;
            }
            if (divisor == -1) {
                return INT_MAX;
            }
        }
        // 考虑除数为最小值的情况
        if (divisor == INT_MIN) {
            return dividend == INT_MIN ? 1 : 0;
        }
        // 考虑被除数为 0 的情况
        if (dividend == 0) {
            return 0;
        }
        
        // 一般情况，使用类二分查找
        // 将所有的正数取相反数，这样就只需要考虑一种情况
        bool rev = false;
        if (dividend > 0) {
            dividend = -dividend;
            rev = !rev;
        }
        if (divisor > 0) {
            divisor = -divisor;
            rev = !rev;
        }

        vector<int> candidates = {divisor};
        // 注意溢出
        while (candidates.back() >= dividend - candidates.back()) {
            candidates.push_back(candidates.back() + candidates.back());
        }
        int ans = 0;
        for (int i = candidates.size() - 1; i >= 0; --i) {
            if (candidates[i] >= dividend) {
                ans += (1 << i);
                dividend -= candidates[i];
            }
        }

        return rev ? -ans : ans;
    }
};
```

```java
class Solution {
    public int divide(int dividend, int divisor) {
        // 考虑被除数为最小值的情况
        if (dividend == Integer.MIN_VALUE) {
            if (divisor == 1) {
                return Integer.MIN_VALUE;
            }
            if (divisor == -1) {
                return Integer.MAX_VALUE;
            }
        }
        // 考虑除数为最小值的情况
        if (divisor == Integer.MIN_VALUE) {
            return dividend == Integer.MIN_VALUE ? 1 : 0;
        }
        // 考虑被除数为 0 的情况
        if (dividend == 0) {
            return 0;
        }
        
        // 一般情况，使用类二分查找
        // 将所有的正数取相反数，这样就只需要考虑一种情况
        boolean rev = false;
        if (dividend > 0) {
            dividend = -dividend;
            rev = !rev;
        }
        if (divisor > 0) {
            divisor = -divisor;
            rev = !rev;
        }

        List<Integer> candidates = new ArrayList<Integer>();
        candidates.add(divisor);
        int index = 0;
        // 注意溢出
        while (candidates.get(index) >= dividend - candidates.get(index)) {
            candidates.add(candidates.get(index) + candidates.get(index));
            ++index;
        }
        int ans = 0;
        for (int i = candidates.size() - 1; i >= 0; --i) {
            if (candidates.get(i) >= dividend) {
                ans += 1 << i;
                dividend -= candidates.get(i);
            }
        }

        return rev ? -ans : ans;
    }
}
```

```c#
public class Solution {
    public int Divide(int dividend, int divisor) {
        // 考虑被除数为最小值的情况
        if (dividend == int.MinValue) {
            if (divisor == 1) {
                return int.MinValue;
            }
            if (divisor == -1) {
                return int.MaxValue;
            }
        }
        // 考虑除数为最小值的情况
        if (divisor == int.MinValue) {
            return dividend == int.MinValue ? 1 : 0;
        }
        // 考虑被除数为 0 的情况
        if (dividend == 0) {
            return 0;
        }
        
        // 一般情况，使用类二分查找
        // 将所有的正数取相反数，这样就只需要考虑一种情况
        bool rev = false;
        if (dividend > 0) {
            dividend = -dividend;
            rev = !rev;
        }
        if (divisor > 0) {
            divisor = -divisor;
            rev = !rev;
        }

        IList<int> candidates = new List<int>();
        candidates.Add(divisor);
        int index = 0;
        // 注意溢出
        while (candidates[index] >= dividend - candidates[index]) {
            candidates.Add(candidates[index] + candidates[index]);
            ++index;
        }
        int ans = 0;
        for (int i = candidates.Count - 1; i >= 0; --i) {
            if (candidates[i] >= dividend) {
                ans += 1 << i;
                dividend -= candidates[i];
            }
        }

        return rev ? -ans : ans;
    }
}
```

```python
class Solution:
    def divide(self, dividend: int, divisor: int) -> int:
        INT_MIN, INT_MAX = -2**31, 2**31 - 1

        # 考虑被除数为最小值的情况
        if dividend == INT_MIN:
            if divisor == 1:
                return INT_MIN
            if divisor == -1:
                return INT_MAX
        
        # 考虑除数为最小值的情况
        if divisor == INT_MIN:
            return 1 if dividend == INT_MIN else 0
        # 考虑被除数为 0 的情况
        if dividend == 0:
            return 0
        
        # 一般情况，使用类二分查找
        # 将所有的正数取相反数，这样就只需要考虑一种情况
        rev = False
        if dividend > 0:
            dividend = -dividend
            rev = not rev
        if divisor > 0:
            divisor = -divisor
            rev = not rev
        
        candidates = [divisor]
        # 注意溢出
        while candidates[-1] >= dividend - candidates[-1]:
            candidates.append(candidates[-1] + candidates[-1])
        
        ans = 0
        for i in range(len(candidates) - 1, -1, -1):
            if candidates[i] >= dividend:
                ans += (1 << i)
                dividend -= candidates[i]

        return -ans if rev else ans
```

```go
func divide(dividend, divisor int) int {
    if dividend == math.MinInt32 { // 考虑被除数为最小值的情况
        if divisor == 1 {
            return math.MinInt32
        }
        if divisor == -1 {
            return math.MaxInt32
        }
    }
    if divisor == math.MinInt32 { // 考虑除数为最小值的情况
        if dividend == math.MinInt32 {
            return 1
        }
        return 0
    }
    if dividend == 0 { // 考虑被除数为 0 的情况
        return 0
    }

    // 一般情况，使用二分查找
    // 将所有的正数取相反数，这样就只需要考虑一种情况
    rev := false
    if dividend > 0 {
        dividend = -dividend
        rev = !rev
    }
    if divisor > 0 {
        divisor = -divisor
        rev = !rev
    }

    candidates := []int{divisor}
    for y := divisor; y >= dividend-y; { // 注意溢出
        y += y
        candidates = append(candidates, y)
    }

    ans := 0
    for i := len(candidates) - 1; i >= 0; i-- {
        if candidates[i] >= dividend {
            ans |= 1 << i
            dividend -= candidates[i]
        }
    }
    if rev {
        return -ans
    }
    return ans
}
```

```javascript
var divide = function(dividend, divisor) {
    const MAX_VALUE = 2 ** 31 - 1, MIN_VALUE = -(2 ** 31);
    // 考虑被除数为最小值的情况
    if (dividend === MIN_VALUE) {
        if (divisor === 1) {
            return MIN_VALUE;
        }
        if (divisor === -1) {
            return MAX_VALUE;
        }
    }
    // 考虑除数为最小值的情况
    if (divisor === MIN_VALUE) {
        return dividend === MIN_VALUE ? 1 : 0;
    }
    // 考虑被除数为 0 的情况
    if (dividend === 0) {
        return 0;
    }
    
    // 一般情况，使用类二分查找
    // 将所有的正数取相反数，这样就只需要考虑一种情况
    let rev = false;
    if (dividend > 0) {
        dividend = -dividend;
        rev = !rev;
    }
    if (divisor > 0) {
        divisor = -divisor;
        rev = !rev;
    }

    const candidates = [divisor];
    let index = 0;
    // 注意溢出
    while (candidates[index] >= dividend - candidates[index]) {
        candidates.push(candidates[index] + candidates[index]);
        ++index;
    }
    let ans = 0;
    for (let i = candidates.length - 1; i >= 0; --i) {
        if (candidates[i] >= dividend) {
            ans += 1 << i;
            dividend -= candidates[i];
        }
    }

    return rev ? -ans : ans;
};
```

**复杂度分析**

-   时间复杂度：O(log⁡C)O，即为二分查找需要的时间。方法二时间复杂度优于方法一的原因是：方法一的每一步二分查找都需要重新计算 Z×Y 的值，需要 O(log⁡C) 的时间复杂度；而方法二的每一步的权重都是 2 的幂，在二分查找开始前就都是已知的值，因此我们可以在 O(log⁡C) 的时间内，一次性将它们全部预处理出来。
-   空间复杂度：O(log⁡C)O，即为需要存储的 $Y \times 2^i$ 的数量。
