#### [](https://leetcode.cn/problems/k-th-symbol-in-grammar/solution/di-kge-yu-fa-fu-hao-by-leetcode-solution-zgwd//#方法二：找规律-递归)方法二：找规律 + 递归

**思路与算法**

按照方法一，我们可以尝试写表中的前几行：

-   000
-   010101
-   011001100110
-   011010010110100101101001
-   ⋯ ⋯

我们可以注意到规律：每一行的后半部分正好为前半部分的“翻转”——前半部分是 0 后半部分变为 1，前半部分是 1，后半部分变为 0。且每一行的前半部分和上一行相同。我们可以通过「数学归纳法」来进行证明。

有了这个性质，那么我们再次思考原问题：对于查询某一个行第 k 个数字，如果 k 在后半部分，那么原问题就可以转化为求解该行前半部分的对应位置的“翻转”数字，又因为该行前半部分与上一行相同，所以又转化为上一行对应对应的“翻转”数字。那么按照这样一直递归下去，并在第一行时返回数字 0 即可。

**代码**

```Python
class Solution:
    def kthGrammar(self, n: int, k: int) -> int:
        if k == 1:
            return 0
        if k > (1 << (n - 2)):
            return 1 ^ self.kthGrammar(n - 1, k - (1 << (n - 2)))
        return self.kthGrammar(n - 1, k)
```

```Java
class Solution {
    public int kthGrammar(int n, int k) {
        if (k == 1) {
            return 0;
        }
        if (k > (1 << (n - 2))) {
            return 1 ^ kthGrammar(n - 1, k - (1 << (n - 2)));
        }
        return kthGrammar(n - 1, k);
    }
}
```

```C#
public class Solution {
    public int KthGrammar(int n, int k) {
        if (k == 1) {
            return 0;
        }
        if (k > (1 << (n - 2))) {
            return 1 ^ KthGrammar(n - 1, k - (1 << (n - 2)));
        }
        return KthGrammar(n - 1, k);
    }
}
```

```C++
class Solution {
public:
    int kthGrammar(int n, int k) {
        if (k == 1) {
            return 0;
        }
        if (k > (1 << (n - 2))) {
            return 1 ^ kthGrammar(n - 1, k - (1 << (n - 2)));
        }
        return kthGrammar(n - 1, k);
    }
};
```

```C
int kthGrammar(int n, int k){
    if (k == 1) {
        return 0;
    }
    if (k > (1 << (n - 2))) {
        return 1 ^ kthGrammar(n - 1, k - (1 << (n - 2)));
    }
    return kthGrammar(n - 1, k);
}
```

```JavaScript
var kthGrammar = function(n, k) {
    if (k === 1) {
        return 0;
    }
    if (k > (1 << (n - 2))) {
        return 1 ^ kthGrammar(n - 1, k - (1 << (n - 2)));
    }
    return kthGrammar(n - 1, k);
};
```

```Go
func kthGrammar(n, k int) int {
    if k == 1 {
        return 0
    }
    if k > 1<<(n-2) {
        return 1 ^ kthGrammar(n-1, k-1<<(n-2))
    }
    return kthGrammar(n-1, k)
}
```

**复杂度分析**

-   时间复杂度：O(n)，其中 n 为题目给定表的行数。
-   空间复杂度：O(n)，其中 n 为题目给定表的行数，主要为递归的空间开销。
