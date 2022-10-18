#### [](https://leetcode.cn/problems/numbers-at-most-n-given-digit-set/solution/zui-da-wei-n-de-shu-zi-zu-he-by-leetcode-f3yi//#方法一：数位动态规划)方法一：数位动态规划

本题为典型的数位动态规划题目，可以阅读「[数位 DP](https://leetcode.cn/link/?target=https://oi-wiki.org/dp/number/)」详细了解。我们称满足 x≤n 且仅包含 digits 中出现的数字的 x 为合法的，则本题需要找出所有合法的 x 的个数。

设 n 是一个十进制的 k 位数，所有数字位数小于 k 且由 digits 组成的数字则一定是小于 n 的。我们用 dp[i][0] 表示由 digits 构成且 n 的前 i 位的数字的个数，dp[i][1] 表示由 digits 构成且等于 n 的前 i 位的数字的个数，可知 dp[i][1] 的取值只能为 0 和 1。

例如：n=2345,digits=["1","2","3","4"]。

则 dp[1][0],dp[2][0],dp[3][0],dp[4][0] 分别表示小于 2,23,234,2345 的合法数的个数，dp[1][1],dp[2][1],dp[3][1],dp[4][1] 分别表示等于 2,23,234,2345 的合法数的个数。

设 digits 中的字符数目为 m 个，数字 n 的前 j 位构成的数字为 num[j]，数字 n 的第 j 个字符为 s[j]，当遍历到 n 的第 i 位时：

-   当满足 i>1 时，此时任意数字 d 构成的数字一定满足 d<num[i]；
-   设数字 a<num[i−1]，则此时在 a 的末尾追加一个数字 d 构成的数为 a×10+d，此时可以知道 d 取 0,1,⋯ ,9 中任意数字均满足小于 a×10+d<num[i]=num[i−1]×10+s[i]；
-   设数字 a=num[i−1]，则此时在 a 的末尾追加一个数字 d 构成的数为 a×10+d，此时可以知道 d<s[i] 时，才能满足 a×10+d<num[i]=num[i−1]×10+s[i]；
-   初始化时令 dp[0][1]=1，如果前 i 位中存在某一位 j ，对于任意数字 d 均不能满足 d=s[j]，则此时 dp[i][1]=0；

根据上述描述从小到到计算 dp，设 C[i] 表示数组 digits 中小于 n 的第 i 位数字的元素个数，则状态转移方程为：

$dp[i][0]=\left\{\begin{array}{lr}C[i],&i=1\\m+dp[i-1][0]\times m+dp[i-1][1]\times C[i],&i>1\end{array}\right.$

我们计算出前 k 位小于 n 的数字的个数 dp[k][0]，前 k 位等于 n 的数字的个数 dp[k][1]，最终的答案为 dp[k][0]+dp[k][1]。

```Python
class Solution:
    def atMostNGivenDigitSet(self, digits: List[str], n: int) -> int:
        m = len(digits)
        s = str(n)
        k = len(s)
        dp = [[0, 0] for _ in range(k + 1)]
        dp[0][1] = 1
        for i in range(1, k + 1):
            for d in digits:
                if d == s[i - 1]:
                    dp[i][1] = dp[i - 1][1]
                elif d < s[i - 1]:
                    dp[i][0] += dp[i - 1][1]
                else:
                    break
            if i > 1:
                dp[i][0] += m + dp[i - 1][0] * m
        return sum(dp[k])
```

```C++
class Solution {
public:
    int atMostNGivenDigitSet(vector<string>& digits, int n) {
        string s = to_string(n);
        int m = digits.size(), k = s.size();
        vector<vector<int>> dp(k + 1, vector<int>(2));
        dp[0][1] = 1;
        for (int i = 1; i <= k; i++) {
            for (int j = 0; j < m; j++) {
                if (digits[j][0] == s[i - 1]) {
                    dp[i][1] = dp[i - 1][1];
                } else if (digits[j][0] < s[i - 1]) {
                    dp[i][0] += dp[i - 1][1];
                } else {
                    break;
                }
            }
            if (i > 1) {
                dp[i][0] += m + dp[i - 1][0] * m;
            }
        }
        return dp[k][0] + dp[k][1];
    }
};
```

```Java
class Solution {
    public int atMostNGivenDigitSet(String[] digits, int n) {
        String s = Integer.toString(n);
        int m = digits.length, k = s.length();
        int[][] dp = new int[k + 1][2];
        dp[0][1] = 1;
        for (int i = 1; i <= k; i++) {
            for (int j = 0; j < m; j++) {
                if (digits[j].charAt(0) == s.charAt(i - 1)) {
                    dp[i][1] = dp[i - 1][1];
                } else if (digits[j].charAt(0) < s.charAt(i - 1)) {
                    dp[i][0] += dp[i - 1][1];
                } else {
                    break;
                }
            }
            if (i > 1) {
                dp[i][0] += m + dp[i - 1][0] * m;
            }
        }
        return dp[k][0] + dp[k][1];
    }
}
```

```C#
public class Solution {
    public int AtMostNGivenDigitSet(string[] digits, int n) {
        string s = n.ToString();
        int m = digits.Length, k = s.Length;
        int[][] dp = new int[k + 1][];
        for (int i = 0; i <= k; i++) {
            dp[i] = new int[2];
        }
        dp[0][1] = 1;
        for (int i = 1; i <= k; i++) {
            for (int j = 0; j < m; j++) {
                if (digits[j][0] == s[i - 1]) {
                    dp[i][1] = dp[i - 1][1];
                } else if (digits[j][0] < s[i - 1]) {
                    dp[i][0] += dp[i - 1][1];
                } else {
                    break;
                }
            }
            if (i > 1) {
                dp[i][0] += m + dp[i - 1][0] * m;
            }
        }
        return dp[k][0] + dp[k][1];
    }
}
```

```C
#define MAX_STR_LEN 32

int atMostNGivenDigitSet(char ** digits, int digitsSize, int n) {
    char s[MAX_STR_LEN];
    sprintf(s, "%d", n);
    int m = digitsSize, k = strlen(s);
    int dp[MAX_STR_LEN][2];
    memset(dp, 0, sizeof(dp));
    dp[0][1] = 1;
    for (int i = 1; i <= k; i++) {
        for (int j = 0; j < m; j++) {
            if (digits[j][0] == s[i - 1]) {
                dp[i][1] = dp[i - 1][1];
            } else if (digits[j][0] < s[i - 1]) {
                dp[i][0] += dp[i - 1][1];
            } else {
                break;
            }
        }
        if (i > 1) {
            dp[i][0] += m + dp[i - 1][0] * m;
        }
    }
    return dp[k][0] + dp[k][1];
}
```

```JavaScript
var atMostNGivenDigitSet = function(digits, n) {
    const s = '' + n;
    const m = digits.length, k = s.length;
    const dp = new Array(k + 1).fill(0).map(() => new Array(2).fill(0));
    dp[0][1] = 1;
    for (let i = 1; i <= k; i++) {
        for (let j = 0; j < m; j++) {
            if (digits[j][0] === s[i - 1]) {
                dp[i][1] = dp[i - 1][1];
            } else if (digits[j][0] < s[i - 1]) {
                dp[i][0] += dp[i - 1][1];
            } else {
                break;
            }
        }
        if (i > 1) {
            dp[i][0] += m + dp[i - 1][0] * m;
        }
    }
    return dp[k][0] + dp[k][1];
};
```

```Go
func atMostNGivenDigitSet(digits []string, n int) int {
    m := len(digits)
    s := strconv.Itoa(n)
    k := len(s)
    dp := make([][2]int, k+1)
    dp[0][1] = 1
    for i := 1; i <= k; i++ {
        for _, d := range digits {
            if d[0] == s[i-1] {
                dp[i][1] = dp[i-1][1]
            } else if d[0] < s[i-1] {
                dp[i][0] += dp[i-1][1]
            } else {
                break
            }
        }
        if i > 1 {
            dp[i][0] += m + dp[i-1][0]*m
        }
    }
    return dp[k][0] + dp[k][1]
}
```

**复杂度分析**

-   时间复杂度：O(log⁡n×k)，其中 n 为给定数字，k 表示给定的数字的种类。需要遍历 n 的所有数位的数字，n 含有的数字个数为 $log_{⁡10}n$，检测每一位时都需要遍历一遍给定的数字，因此总的时间复杂度为 O(log⁡n×k)。
-   空间复杂度：O(log⁡n)，其中 n 为给定数字。需要需要保存每一位上可能数字的组合数目，因此需要的空间复杂度为 O(log⁡n)。
