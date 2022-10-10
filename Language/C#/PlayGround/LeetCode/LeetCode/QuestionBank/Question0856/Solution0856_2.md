#### [](https://leetcode.cn/problems/score-of-parentheses/solution/gua-hao-de-fen-shu-by-leetcode-solution-we6b//#方法一：分治)方法一：分治

根据题意，一个平衡括号字符串 s 可以被分解为 A+B 或 (A) 的形式，因此我们可以对 s 进行分解，分而治之。

如何判断 s 应该分解为 A+B 或 (A) 的哪一种呢？我们将左括号记为 1，右括号记为 −1，如果 s 的某个非空前缀对应的和 bal=0，那么这个前缀就是一个平衡括号字符串。如果该前缀长度等于 s 的长度，那么 s 可以分解为 (A) 的形式；否则 s 可以分解为 A+B 的形式，其中 A 为该前缀。将 s 分解之后，我们递归地求解子问题，并且 s 的长度为 2 时，分数为 1。

```Python
class Solution:
    def scoreOfParentheses(self, s: str) -> int:
        n = len(s)
        if n == 2:
            return 1
        bal = 0
        for i, c in enumerate(s):
            bal += 1 if c == '(' else -1
            if bal == 0:
                if i == n - 1:
                    return 2 * self.scoreOfParentheses(s[1:-1])
                return self.scoreOfParentheses(s[:i + 1]) + self.scoreOfParentheses(s[i + 1:])

```

```C++
class Solution {
public:
    int scoreOfParentheses(string s) {
        if (s.size() == 2) {
            return 1;
        }
        int bal = 0, n = s.size(), len;
        for (int i = 0; i < n; i++) {
            bal += (s[i] == '(' ? 1 : -1);
            if (bal == 0) {
                len = i + 1;
                break;
            }
        }
        if (len == n) {
            return 2 * scoreOfParentheses(s.substr(1, n - 2));
        } else {
            return scoreOfParentheses(s.substr(0, len)) + scoreOfParentheses(s.substr(len, n - len));
        }
    }
};

```

```Java
class Solution {
    public int scoreOfParentheses(String s) {
        if (s.length() == 2) {
            return 1;
        }
        int bal = 0, n = s.length(), len = 0;
        for (int i = 0; i < n; i++) {
            bal += (s.charAt(i) == '(' ? 1 : -1);
            if (bal == 0) {
                len = i + 1;
                break;
            }
        }
        if (len == n) {
            return 2 * scoreOfParentheses(s.substring(1, n - 1));
        } else {
            return scoreOfParentheses(s.substring(0, len)) + scoreOfParentheses(s.substring(len));
        }
    }
}

```

```C#
public class Solution {
    public int ScoreOfParentheses(string s) {
        if (s.Length == 2) {
            return 1;
        }
        int bal = 0, n = s.Length, len = 0;
        for (int i = 0; i < n; i++) {
            bal += (s[i] == '(' ? 1 : -1);
            if (bal == 0) {
                len = i + 1;
                break;
            }
        }
        if (len == n) {
            return 2 * ScoreOfParentheses(s.Substring(1, n - 2));
        } else {
            return ScoreOfParentheses(s.Substring(0, len)) + ScoreOfParentheses(s.Substring(len));
        }
    }
}

```

```C
int scoreOfParentheses(char * s) {
    int n = strlen(s);
    if (n == 2) {
        return 1;
    }
    int bal = 0, len = 0;
    for (int i = 0; i < n; i++) {
        bal += (s[i] == '(' ? 1 : -1);
        if (bal == 0) {
            len = i + 1;
            break;
        }
    }
    if (len == n) {
        char str[n - 1];
        strncpy(str, s + 1, n - 2);
        str[n - 2] = '\0';
        return 2 * scoreOfParentheses(str);
    } else {
        char str1[len + 1], str2[n - len + 1];
        strncpy(str1, s, len);
        str1[len] = '\0';
        strncpy(str2, s + len, n - len);
        str2[n - len] = '\0';
        return scoreOfParentheses(str1) + scoreOfParentheses(str2);
    }
}

```

```Go
func scoreOfParentheses(s string) int {
    n := len(s)
    if n == 2 {
        return 1
    }
    for i, bal := 0, 0; ; i++ {
        if s[i] == '(' {
            bal++
        } else {
            bal--
            if bal == 0 {
                if i == n-1 {
                    return 2 * scoreOfParentheses(s[1:n-1])
                }
                return scoreOfParentheses(s[:i+1]) + scoreOfParentheses(s[i+1:])
            }
        }
    }
}

```

```JavaScript
var scoreOfParentheses = function(s) {
    if (s.length === 2) {
        return 1;
    }
    let bal = 0, n = s.length, len = 0;
    for (let i = 0; i < n; i++) {
        bal += (s[i] === '(' ? 1 : -1);
        if (bal === 0) {
            len = i + 1;
            break;
        }
    }
    if (len === n) {
        return 2 * scoreOfParentheses(s.slice(1, n - 1));
    } else {
        return scoreOfParentheses(s.slice(0, len)) + scoreOfParentheses(s.slice(len));
    }
};

```

**复杂度分析**

-   时间复杂度：O(n^2^)，其中 n 是字符串的长度。递归深度为 O(n)，每一层的所有函数调用的总时间复杂度都是 O(n)，因此总时间复杂度为 O(n^2^))。
-   空间复杂度：O(n^2^)。每一层都需要将字符串复制一遍，因此总空间复杂度为 O(n^2^)。对于字符串支持切片的语言，空间复杂度为递归栈所需的空间 O(n)。
