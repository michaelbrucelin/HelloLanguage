#### [](https://leetcode.cn/problems/k-th-symbol-in-grammar/solution/di-kge-yu-fa-fu-hao-by-leetcode-solution-zgwd//#方法一：递归)方法一：递归

**思路与算法**

首先题目给出一个 n 行的表（索引从 1 开始）。并给出表的构造规则为：第一行仅有一个 0，然后接下来的每一行可以由上一行中 0 替换为 01，1 替换为 10 来生成。

-   比如当 n=3 时，第 1 行是 0，第 2 行是 01，第 3 行是 0110。

现在要求表第 n 行中第 k 个数字，$1 \leq k \leq 2^n$。首先我们可以看到第 i 行中会有 $2^{i−1}$ 个数字，$1 \leq i \leq n$，且其中第 j 个数字按照构造规则会生第 i+1 行中的第 2∗j−1 和 2∗j 个数字，$1 \leq j \leq 2^{i-1}$。即对于第 i+1 行中的第 x 个数字 num1，$1 \leq x \leq 2^i$，会被第 i 行中第 $\lfloor \frac{x+1}{2} \rfloor$ 个数字 num2 生成。且满足规则：

-   当 num2=0 时，num2 会生成 01：
$num1=\left\{\begin{array}{lr}
    0, x \equiv 1(mod2) \\
    1, x \equiv 0(mod2)
\end{array}\right.$
-   当 num2=1 时，num2 会生成 10：
$num1=\left\{\begin{array}{lr}
    1, x \equiv 1(mod2) \\
    0, x \equiv 0(mod2)
\end{array}\right.$

并且进一步总结我们可以得到：num1=(x&1)⊕1⊕num2，其中 & 为「与」运算符， ⊕ 为「异或」运算符。那么我们从第 n 不断往上递归求解，并且当在第一行时只有一个数字，直接返回 0 即可。

**代码**

```Python
class Solution:
    def kthGrammar(self, n: int, k: int) -> int:
        if n == 1:
            return 0
        return (k & 1) ^ 1 ^ self.kthGrammar(n - 1, (k + 1) // 2)
```

```Java
class Solution {
    public int kthGrammar(int n, int k) {
        if (n == 1) {
            return 0;
        }
        return (k & 1) ^ 1 ^ kthGrammar(n - 1, (k + 1) / 2);
    }
}
```

```C#
public class Solution {
    public int KthGrammar(int n, int k) {
        if (n == 1) {
            return 0;
        }
        return (k & 1) ^ 1 ^ KthGrammar(n - 1, (k + 1) / 2);
    }
}
```

```C++
class Solution {
public:
    int kthGrammar(int n, int k) {
        if (n == 1) {
            return 0;
        }
        return (k & 1) ^ 1 ^ kthGrammar(n - 1, (k + 1) / 2);
    }
};
```

```C
int kthGrammar(int n, int k){
    if (n == 1) {
        return 0;
    }
    return (k & 1) ^ 1 ^ kthGrammar(n - 1, (k + 1) / 2);
}
```

```JavaScript
var kthGrammar = function(n, k) {
    if (n === 1) {
        return 0;
    }
    return (k & 1) ^ 1 ^ kthGrammar(n - 1, (k + 1) / 2);
};
```

```Go
func kthGrammar(n, k int) int {
    if n == 1 {
        return 0
    }
    return k&1 ^ 1 ^ kthGrammar(n-1, (k+1)/2)
}
```

**复杂度分析**

-   时间复杂度：O(n)，其中 n 为题目给定表的行数，递归深度为 n。
-   空间复杂度：O(n)，其中 n 为题目给定表的行数，主要为递归的空间开销。
