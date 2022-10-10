#### [](https://leetcode.cn/problems/score-of-parentheses/solution/gua-hao-de-fen-shu-by-leetcode-solution-we6b//#方法三：计算最终分数和)方法三：计算最终分数和

根据题意，s 的分数与 1 分的 () 有关。对于每个 ()，它的最终分数与它所处的深度有关，如果深度为 bal，那么它的最终分数为 2^bal^。我们统计所有 () 的最终分数和即可。

```Python
class Solution:
    def scoreOfParentheses(self, s: str) -> int:
        ans = bal = 0
        for i, c in enumerate(s):
            bal += 1 if c == '(' else -1
            if c == ')' and s[i - 1] == '(':
                ans += 1 << bal
        return ans

```

```C++
class Solution {
public:
    int scoreOfParentheses(string s) {
        int bal = 0, n = s.size(), res = 0;
        for (int i = 0; i < n; i++) {
            bal += (s[i] == '(' ? 1 : -1);
            if (s[i] == ')' && s[i - 1] == '(') {
                res += 1 << bal;
            }
        }
        return res;
    }
};

```

```Java
class Solution {
    public int scoreOfParentheses(String s) {
        int bal = 0, n = s.length(), res = 0;
        for (int i = 0; i < n; i++) {
            bal += (s.charAt(i) == '(' ? 1 : -1);
            if (s.charAt(i) == ')' && s.charAt(i - 1) == '(') {
                res += 1 << bal;
            }
        }
        return res;
    }
}

```

```C#
public class Solution {
    public int ScoreOfParentheses(string s) {
        int bal = 0, n = s.Length, res = 0;
        for (int i = 0; i < n; i++) {
            bal += (s[i] == '(' ? 1 : -1);
            if (s[i] == ')' && s[i - 1] == '(') {
                res += 1 << bal;
            }
        }
        return res;
    }
}

```

```C
int scoreOfParentheses(char * s) {
    int bal = 0, n = strlen(s), res = 0;
    for (int i = 0; i < n; i++) {
        bal += (s[i] == '(' ? 1 : -1);
        if (s[i] == ')' && s[i - 1] == '(') {
            res += 1 << bal;
        }
    }
    return res;
}

```

```Go
func scoreOfParentheses(s string) (ans int) {
    bal := 0
    for i, c := range s {
        if c == '(' {
            bal++
        } else {
            bal--
            if s[i-1] == '(' {
                ans += 1 << bal
            }
        }
    }
    return
}

```

```JavaScript
var scoreOfParentheses = function(s) {
    let bal = 0, n = s.length, res = 0;
    for (let i = 0; i < n; i++) {
        bal += (s[i] == '(' ? 1 : -1);
        if (s[i] == ')' && s[i - 1] === '(') {
            res += 1 << bal;
        }
    }
    return res;
};

```

**复杂度分析**

-   时间复杂度：O(n)，其中 n 是字符串的长度。
-   空间复杂度：O(1)。
