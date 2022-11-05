#### [前言](https://leetcode.cn/problems/divide-two-integers/solutions/1041939/liang-shu-xiang-chu-by-leetcode-solution-5hic/)

由于题目规定了「只能存储 32 位整数」，本题解的正文部分和代码中都不会使用任何 64 位整数。**诚然，使用 64 位整数可以极大地方便我们的编码，但这是违反题目规则的。**

如果除法结果溢出，那么我们需要返回 $2^{31}−1$ 作为答案。因此在编码之前，我们可以首先对于溢出或者容易出错的边界情况进行讨论：
-   当被除数为 32 位有符号整数的最小值 $-2^{31}$ 时：
    -   如果除数为 1，那么我们可以直接返回答案 $-2^{31}$；
    -   如果除数为 −1，那么答案为 $2^{31}$，产生了溢出。此时我们需要返回 $2^{31}-1$。
-   当除数为 32 位有符号整数的最小值 $-2^{31}$ 时：
    -   如果被除数同样为 $-2^{31}$，那么我们可以直接返回答案 1；
    -   对于其余的情况，我们返回答案 0。
-   当被除数为 0 时，我们可以直接返回答案 0。

对于一般的情况，根据除数和被除数的符号，我们需要考虑 4 种不同的可能性。因此，为了方便编码，我们可以将被除数或者除数取相反数，使得它们符号相同。

如果我们将被除数和除数都变为正数，那么可能会导致溢出。例如当被除数为 $-2^{31}$ 时，它的相反数 $2^{31}$ 产生了溢出。因此，我们可以考虑将被除数和除数都变为负数，这样就不会有溢出的问题，在编码时只需要考虑 1 种情况了。

如果我们将被除数和除数的其中（恰好）一个变为了正数，那么在返回答案之前，我们需要对答案也取相反数。

#### 方法一：二分查找

**思路与算法**

根据「前言」部分的讨论，我们记被除数为 X，除数为 Y，并且 X 和 Y 都是负数。我们需要找出 X/Y 的结果 Z。Z 一定是正数或 0。

根据除法以及余数的定义，我们可以将其改成乘法的等价形式，即：
$Z \times Y \ge X \gt (Z+1) \times Y$

因此，我们可以使用二分查找的方法得到 Z，即找出**最大**的 Z 使得 Z×Y≥X 成立。

由于我们不能使用乘法运算符，因此我们需要使用「快速乘」算法得到 Z×Y 的值。「快速乘」算法与「快速幂」类似，前者通过加法实现乘法，后者通过乘法实现幂运算。「快速幂」算法可以参考[「50. Pow(x, n)」的官方题解](https://leetcode-cn.com/problems/powx-n/solution/powx-n-by-leetcode-solution/)，「快速乘」算法只需要在「快速幂」算法的基础上，将乘法运算改成加法运算即可。

**细节**

由于我们只能使用 32 位整数，因此二分查找中会有很多细节。

首先，二分查找的下界为 1，上界为 $2^{31}-1$。唯一可能出现的答案为 $2^{31}$ 的情况已经被我们在「前言」部分进行了特殊处理，因此答案的最大值为 $2^{31}-1$。如果二分查找失败，那么答案一定为 0。

在实现「快速乘」时，我们需要使用加法运算，然而较大的 Z 也会导致加法运算溢出。例如我们要判断 A+B 是否小于 C 时（其中 A,B,C 均为负数），A+B 可能会产生溢出，因此我们必须将判断改为 A<C−B 是否成立。由于任意两个负数的差一定在 $[-2^{31}+1, 2^{31}-1]$ 范围内，这样就不会产生溢出。

读者可以阅读下面的代码和注释，理解如何避免使用乘法和除法，以及正确处理溢出问题。

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
        
        // 一般情况，使用二分查找
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

        // 快速乘
        auto quickAdd = [](int y, int z, int x) {
            // x 和 y 是负数，z 是正数
            // 需要判断 z * y >= x 是否成立
            int result = 0, add = y;
            while (z) {
                if (z & 1) {
                    // 需要保证 result + add >= x
                    if (result < x - add) {
                        return false;
                    }
                    result += add;
                }
                if (z != 1) {
                    // 需要保证 add + add >= x
                    if (add < x - add) {
                        return false;
                    }
                    add += add;
                }
                // 不能使用除法
                z >>= 1;
            }
            return true;
        };
        
        int left = 1, right = INT_MAX, ans = 0;
        while (left <= right) {
            // 注意溢出，并且不能使用除法
            int mid = left + ((right - left) >> 1);
            bool check = quickAdd(divisor, mid, dividend);
            if (check) {
                ans = mid;
                // 注意溢出
                if (mid == INT_MAX) {
                    break;
                }
                left = mid + 1;
            }
            else {
                right = mid - 1;
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
        
        // 一般情况，使用二分查找
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
        
        int left = 1, right = Integer.MAX_VALUE, ans = 0;
        while (left <= right) {
            // 注意溢出，并且不能使用除法
            int mid = left + ((right - left) >> 1);
            boolean check = quickAdd(divisor, mid, dividend);
            if (check) {
                ans = mid;
                // 注意溢出
                if (mid == Integer.MAX_VALUE) {
                    break;
                }
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }

        return rev ? -ans : ans;
    }

    // 快速乘
    public boolean quickAdd(int y, int z, int x) {
        // x 和 y 是负数，z 是正数
        // 需要判断 z * y >= x 是否成立
        int result = 0, add = y;
        while (z != 0) {
            if ((z & 1) != 0) {
                // 需要保证 result + add >= x
                if (result < x - add) {
                    return false;
                }
                result += add;
            }
            if (z != 1) {
                // 需要保证 add + add >= x
                if (add < x - add) {
                    return false;
                }
                add += add;
            }
            // 不能使用除法
            z >>= 1;
        }
        return true;
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
        
        // 一般情况，使用二分查找
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
        
        int left = 1, right = int.MaxValue, ans = 0;
        while (left <= right) {
            // 注意溢出，并且不能使用除法
            int mid = left + ((right - left) >> 1);
            bool check = quickAdd(divisor, mid, dividend);
            if (check) {
                ans = mid;
                // 注意溢出
                if (mid == int.MaxValue) {
                    break;
                }
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }

        return rev ? -ans : ans;
    }

    // 快速乘
    public bool quickAdd(int y, int z, int x) {
        // x 和 y 是负数，z 是正数
        // 需要判断 z * y >= x 是否成立
        int result = 0, add = y;
        while (z != 0) {
            if ((z & 1) != 0) {
                // 需要保证 result + add >= x
                if (result < x - add) {
                    return false;
                }
                result += add;
            }
            if (z != 1) {
                // 需要保证 add + add >= x
                if (add < x - add) {
                    return false;
                }
                add += add;
            }
            // 不能使用除法
            z >>= 1;
        }
        return true;
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
        
        # 一般情况，使用二分查找
        # 将所有的正数取相反数，这样就只需要考虑一种情况
        rev = False
        if dividend > 0:
            dividend = -dividend
            rev = not rev
        if divisor > 0:
            divisor = -divisor
            rev = not rev

        # 快速乘
        def quickAdd(y: int, z: int, x: int) -> bool:
            # x 和 y 是负数，z 是正数
            # 需要判断 z * y >= x 是否成立
            result, add = 0, y
            while z > 0:
                if (z & 1) == 1:
                    # 需要保证 result + add >= x
                    if result < x - add:
                        return False
                    result += add
                if z != 1:
                    # 需要保证 add + add >= x
                    if add < x - add:
                        return False
                    add += add
                # 不能使用除法
                z >>= 1
            return True
        
        left, right, ans = 1, INT_MAX, 0
        while left <= right:
            # 注意溢出，并且不能使用除法
            mid = left + ((right - left) >> 1)
            check = quickAdd(divisor, mid, dividend)
            if check:
                ans = mid
                # 注意溢出
                if mid == INT_MAX:
                    break
                left = mid + 1
            else:
                right = mid - 1

        return -ans if rev else ans
```

```go
// 快速乘
// x 和 y 是负数，z 是正数
// 判断 z * y >= x 是否成立
func quickAdd(y, z, x int) bool {
    for result, add := 0, y; z > 0; z >>= 1 { // 不能使用除法
        if z&1 > 0 {
            // 需要保证 result + add >= x
            if result < x-add {
                return false
            }
            result += add
        }
        if z != 1 {
            // 需要保证 add + add >= x
            if add < x-add {
                return false
            }
            add += add
        }
    }
    return true
}

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

    ans := 0
    left, right := 1, math.MaxInt32
    for left <= right {
        mid := left + (right-left)>>1 // 注意溢出，并且不能使用除法
        if quickAdd(divisor, mid, dividend) {
            ans = mid
            if mid == math.MaxInt32 { // 注意溢出
                break
            }
            left = mid + 1
        } else {
            right = mid - 1
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
    
    // 一般情况，使用二分查找
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
    
    let left = 1, right = MAX_VALUE, ans = 0;
    while (left <= right) {
        // 注意溢出，并且不能使用除法
        const mid = left + ((right - left) >> 1);
        const check = quickAdd(divisor, mid, dividend);
        if (check) {
            ans = mid;
            // 注意溢出
            if (mid === MAX_VALUE) {
                break;
            }
            left = mid + 1;
        } else {
            right = mid - 1;
        }
    }

    return rev ? -ans : ans;
}

// 快速乘
const quickAdd = (y, z, x) => {
    // x 和 y 是负数，z 是正数
    // 需要判断 z * y >= x 是否成立
    let result = 0, add = y;
    while (z !== 0) {
        if ((z & 1) !== 0) {
            // 需要保证 result + add >= x
            if (result < x - add) {
                return false;
            }
            result += add;
        }
        if (z !== 1) {
            // 需要保证 add + add >= x
            if (add < x - add) {
                return false;
            }
            add += add;
        }
        // 不能使用除法
        z >>= 1;
    }
    return true;
};
```

**复杂度分析**

-   时间复杂度：$O(log⁡^2 C)$，其中 C 表示 32 位整数的范围。二分查找的次数为 O(log⁡C)，其中的每一步我们都需要 O(log⁡C) 使用「快速乘」算法判断 Z×Y≥X 是否成立，因此总时间复杂度为 $O(log^2 C)$。
-   空间复杂度：O(1)。
