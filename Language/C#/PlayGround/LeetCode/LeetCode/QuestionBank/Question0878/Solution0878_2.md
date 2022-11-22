#### [方法一：容斥原理 + 二分查找](https://leetcode.cn/problems/nth-magical-number/solutions/1983699/di-n-ge-shen-qi-shu-zi-by-leetcode-solut-6vyy/)

**思路与算法**

题目给出三个数字 n，a，b，满足 $1 \le n \le 10^9$，$2 \le a, b \le 4 \times 10^4$，并给出「神奇数字」的定义：若一个正整数能被 a 和 b 整除，那么它就是「神奇」的。现在需要求出对于给定 a 和 b 的第 n 个「神奇数字」。设 f(x) 表示为小于等于 x 的「神奇数字」个数，因为小于等于 x 中能被 a 整除的数的个数为 $\lfloor \frac{x}{a} \rfloor$，小于等于 x 中能被 b 整除的个数为 $\lfloor \frac{x}{b} \rfloor$，小于等于 x 中同时能被 a 和 b 整除的个数为 $\lfloor \frac{x}{c} \rfloor$，其中 c 为 a 和 b 的最小公倍数，所以 f(x) 的表达式为：
$f(x) = \lfloor \frac{x}{a} \rfloor + \lfloor \frac{x}{b} \rfloor - \lfloor \frac{x}{c} \rfloor$

即f(x) 是一个随着 x 递增单调不减函数。那么我们可以通过「二分查找」来进行查找第 n 个「神奇数字」。

**代码**

```python
class Solution:
    def nthMagicalNumber(self, n: int, a: int, b: int) -> int:
        MOD = 10 ** 9 + 7
        l = min(a, b)
        r = n * min(a, b)
        c = lcm(a, b)
        while l <= r:
            mid = (l + r) // 2
            cnt = mid // a + mid // b - mid // c
            if cnt >= n:
                r = mid - 1
            else:
                l = mid + 1
        return (r + 1) % MOD
```

```cpp
class Solution {
public:
    const int MOD = 1e9 + 7;
    int nthMagicalNumber(int n, int a, int b) {
        long long l = min(a, b);
        long long r = (long long) n * min(a, b);
        int c = lcm(a, b);
        while (l <= r) {
            long long mid = (l + r) / 2;
            long long cnt = mid / a + mid / b - mid / c;
            if (cnt >= n) {
                r = mid - 1;
            } else {
                l = mid + 1;
            }
        }
        return (r + 1) % MOD;
    }
};
```

```java
class Solution {
    static final int MOD = 1000000007;

    public int nthMagicalNumber(int n, int a, int b) {
        long l = Math.min(a, b);
        long r = (long) n * Math.min(a, b);
        int c = lcm(a, b);
        while (l <= r) {
            long mid = (l + r) / 2;
            long cnt = mid / a + mid / b - mid / c;
            if (cnt >= n) {
                r = mid - 1;
            } else {
                l = mid + 1;
            }
        }
        return (int) ((r + 1) % MOD);
    }

    public int lcm(int a, int b) {
        return a * b / gcd(a, b);
    }

    public int gcd(int a, int b) {
        return b != 0 ? gcd(b, a % b) : a;
    }
}
```

```c#
public class Solution {
    const int MOD = 1000000007;

    public int NthMagicalNumber(int n, int a, int b) {
        long l = Math.Min(a, b);
        long r = (long) n * Math.Min(a, b);
        int c = LCM(a, b);
        while (l <= r) {
            long mid = (l + r) / 2;
            long cnt = mid / a + mid / b - mid / c;
            if (cnt >= n) {
                r = mid - 1;
            } else {
                l = mid + 1;
            }
        }
        return (int) ((r + 1) % MOD);
    }

    public int LCM(int a, int b) {
        return a * b / GCD(a, b);
    }

    public int GCD(int a, int b) {
        return b != 0 ? GCD(b, a % b) : a;
    }
}
```

```c
#define MIN(a, b) ((a) < (b) ? (a) : (b))
const int MOD = 1e9 + 7;

int gcd(int a, int b) {
    return b != 0 ? gcd(b, a % b) : a;
}

int lcm(int a, int b) {
    return a * b / gcd(a, b);
}

int nthMagicalNumber(int n, int a, int b) {
    long long l = MIN(a, b);
    long long r = (long long) n * MIN(a, b);
    int c = lcm(a, b);
    while (l <= r) {
        long long mid = (l + r) / 2;
        long long cnt = mid / a + mid / b - mid / c;
        if (cnt >= n) {
            r = mid - 1;
        } else {
            l = mid + 1;
        }
    }
    return (r + 1) % MOD;
}
```

```javascript
const MOD = 1000000007;
var nthMagicalNumber = function(n, a, b) {
    let l = Math.min(a, b);
    let r = n * Math.min(a, b);
    const c = lcm(a, b);
    while (l <= r) {
        const mid = Math.floor((l + r) / 2);
        const cnt = Math.floor(mid / a) + Math.floor(mid / b) - Math.floor(mid / c);
        if (cnt >= n) {
            r = mid - 1;
        } else {
            l = mid + 1;
        }
    }
    return (r + 1) % MOD;
}

const lcm = (a, b) => {
    return Math.floor(a * b / gcd(a, b));
}

const gcd = (a, b) => {
    return b !== 0 ? gcd(b, a % b) : a;
};
```

```go
const mod int = 1e9 + 7

func nthMagicalNumber(n, a, b int) int {
    l := min(a, b)
    r := n * min(a, b)
    c := a / gcd(a, b) * b
    for l <= r {
        mid := (l + r) / 2
        cnt := mid/a + mid/b - mid/c
        if cnt >= n {
            r = mid - 1
        } else {
            l = mid + 1
        }
    }
    return (r + 1) % mod
}

func min(a, b int) int {
    if a > b {
        return b
    }
    return a
}

func gcd(a, b int) int {
    if b != 0 {
        return gcd(b, a%b)
    }
    return a
}
```

**复杂度分析**

-   时间复杂度：$O(\log(n \times \max(a, b)))$，其中 n，b，c 为题目给定的数字。
-   空间复杂度：O(1)，仅使用常量空间开销。
