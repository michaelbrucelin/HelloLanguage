#### 方法一：简单枚举 + 动态规划

**思路与算法**

我们可以将给定字符串 sequence 的每一个位置作为结束位置，判断前面的若干个字符是否恰好是字符串 word。如果第 i 个位置是，那么可以记录 valid[i] 的值为 1，否则为 0。

当我们得到了数组 valid 后，就可以计算最大重复值了。我们可以得到递推式：

$f[i]=\left\{\begin{array}{lr}
    f[i-\vert word \vert]+1, & valid[i] = 1 \wedge i \ge \vert word \vert \\
    1, & valid[i] = 1 \wedge i \lt \vert word \vert \\
    0, & otherwise
\end{array}\right.$

f[i]={f[i−∣word∣]+1,valid[i]=1∧i≥∣word∣1,valid[i]=1∧i<∣word∣0,otherwise f[i] = \\begin{cases} f[i-|\\textit{word}|] + 1, & \\textit{valid}[i]=1 \\wedge i \\geq |\\textit{word}| \\\\ 1, & \\textit{valid}[i]=1 \\wedge i < |\\textit{word}| \\\\ 0, & \\text{otherwise} \\end{cases} f[i]\=⎩⎨⎧f[i−∣word∣]+1,1,0,valid[i]\=1∧i≥∣word∣valid[i]\=1∧i<∣word∣otherwise

这里 f[i] 表示字符串 word 在第 i 个位置最后一次出现时的最大重复值，那么只有在 valid[i] 为 1 时最大重复值才不为 0，需要进行递推。字符串 word 在第 i 个位置前出现的最大重复值可以通过 f[i−∣word∣] 获得（其中 ∣word∣ 表示字符串 word 的长度），如果该项没有意义，那么它的值为 0。

最终的答案即为数组 f 中的最大值。注意到在求解 f[i] 时，我们无需存储除了 valid[i] 以外的数组 valid 的项。因此可以省去数组 valid。

**代码**

```C++
class Solution {
public:
    int maxRepeating(string sequence, string word) {
        int n = sequence.size(), m = word.size();
        if (n < m) {
            return 0;
        }

        vector<int> f(n);
        for (int i = m - 1; i < n; ++i) {
            bool valid = true;
            for (int j = 0; j < m; ++j) {
                if (sequence[i - m + j + 1] != word[j]) {
                    valid = false;
                    break;
                }
            }
            if (valid) {
                f[i] = (i == m - 1 ? 0 : f[i - m]) + 1;
            }
        }
        
        return *max_element(f.begin(), f.end());
    }
};
```

```Java
class Solution {
    public int maxRepeating(String sequence, String word) {
        int n = sequence.length(), m = word.length();
        if (n < m) {
            return 0;
        }

        int[] f = new int[n];
        for (int i = m - 1; i < n; ++i) {
            boolean valid = true;
            for (int j = 0; j < m; ++j) {
                if (sequence.charAt(i - m + j + 1) != word.charAt(j)) {
                    valid = false;
                    break;
                }
            }
            if (valid) {
                f[i] = (i == m - 1 ? 0 : f[i - m]) + 1;
            }
        }

        return Arrays.stream(f).max().getAsInt();
    }
}
```

```C#
public class Solution {
    public int MaxRepeating(string sequence, string word) {
        int n = sequence.Length, m = word.Length;
        if (n < m) {
            return 0;
        }

        int[] f = new int[n];
        for (int i = m - 1; i < n; ++i) {
            bool valid = true;
            for (int j = 0; j < m; ++j) {
                if (sequence[i - m + j + 1] != word[j]) {
                    valid = false;
                    break;
                }
            }
            if (valid) {
                f[i] = (i == m - 1 ? 0 : f[i - m]) + 1;
            }
        }

        return f.Max();
    }
}
```

```Python
class Solution:
    def maxRepeating(self, sequence: str, word: str) -> int:
        n, m = len(sequence), len(word)
        if n < m:
            return 0
        
        f = [0] * n
        for i in range(m - 1, n):
            valid = True
            for j in range(m):
                if sequence[i - m + j + 1] != word[j]:
                    valid = False
                    break
            if valid:
                f[i] = (0 if i == m - 1 else f[i - m]) + 1
        
        return max(f)
```

```C
#define MAX(a, b) ((a) > (b) ? (a) : (b))

int maxRepeating(char * sequence, char * word){
    int n = strlen(sequence), m = strlen(word);
    if (n < m) {
        return 0;
    }

    int f[n];
    memset(f, 0, sizeof(f));
    for (int i = m - 1; i < n; ++i) {
        bool valid = true;
        for (int j = 0; j < m; ++j) {
            if (sequence[i - m + j + 1] != word[j]) {
                valid = false;
                break;
            }
        }
        if (valid) {
            f[i] = (i == m - 1 ? 0 : f[i - m]) + 1;
        }
    }
    int res = 0;
    for (int i = 0; i < n; i++) {
        res = MAX(res, f[i]);
    }
    return res;
}
```

```JavaScript
var maxRepeating = function(sequence, word) {
    const n = sequence.length, m = word.length;
    if (n < m) {
        return 0;
    }

    const f = new Array(n).fill(0);
    for (let i = m - 1; i < n; ++i) {
        let valid = true;
        for (let j = 0; j < m; ++j) {
            if (sequence[i - m + j + 1] !== word[j]) {
                valid = false;
                break;
            }
        }
        if (valid) {
            f[i] = (i === m - 1 ? 0 : f[i - m]) + 1;
        }
    }

    return _.max(f);
};
```

```Go
func maxRepeating(sequence, word string) (ans int) {
    n, m := len(sequence), len(word)
    if n < m {
        return
    }
    f := make([]int, n)
    for i := m - 1; i < n; i++ {
        if sequence[i-m+1:i+1] == word {
            if i == m-1 {
                f[i] = 1
            } else {
                f[i] = f[i-m] + 1
            }
            if f[i] > ans {
                ans = f[i]
            }
        }
    }
    return
}
```

**复杂度分析**

-   时间复杂度：O(mn)，其中 n 和 m 分别是字符串 sequence 和 word 的长度。
-   空间复杂度：O(n)，即为数组 f 需要使用的空间。
