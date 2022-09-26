﻿#### [](https://leetcode.cn/problems/rotated-digits/solution/xuan-zhuan-shu-zi-by-leetcode-solution-q9bh//#方法二：数位动态规划)方法二：数位动态规划

**思路与算法**

我们也可以用数位动态规划的思路解决本题。由于在一个数之前填加前导零不会改变数本身的好坏，因此我们只需要考虑所有位数与 n 相同并且小于等于 n 的数（可以有前导零）即可。

记 f(pos,bound,diff) 为满足如下要求的好数的个数：

-   只从第 pos 位开始考虑。这里数的最高位为第 0 位，最低位为第 len−1 位，其中 len 是数 n 的长度。在计算 f(pos,bound,diff) 时，会假设第 0 位到第 pos−1 位已经固定，并且会用 bound 和 diff 两个布尔变量表示这些数位的「状态」；

-   从第 0 位到第 pos−1 位的数是否「贴着」n，记为 bound。例如当 n=12345，pos=3 时，如果前面的数位是 123，那就表示贴着 n，如果是 122,121,⋯，那就表示没有贴着 n。区分是否「贴着」n 的作用是，如果 bound 为真，第 pos 位只能在 0 到 n 的第 pos 位进行选择，否则构造出的数就超过 n 了；如果 bound 为假，那么第 pos 位可以在 0 到 9 之间任意选择；
 
-   从第 0 位到第 pos−1 位的数中是否至少出现了一次 2 或 5 或 6 或 9，记为 diff。在进行状态转移时，我们只会枚举（第 pos 位的数）0/1/2/5/6/8/9 而不枚举 3/4/7，这样可以保证数一定是可以旋转的，只需要额外的状态 diff 就能表示其是否为好数。


根据上述的定义，我们需要求出的答案即为 f(0,True,False)。

在进行状态转移时，我们只需要枚举第 pos 位选择的数，其可以选择的范围根据 bound 的不同而不同（上述定义中已经详细阐述过）。我们可以写出如下的状态转移方程：

f(pos,bound,diff)=∑f(pos+1,bound’,diff’)

那么如何根据选择的数，确定 bound’\\textit{bound'}bound’ 和 diff’\\textit{diff'}diff’ 呢？我们可以发现：

-   bound’ 为真，当且仅当 bound 为真，并且选择的数恰好与 n 的第 pos 个数位相同；

-   diff’ 为真，当且仅当 diff 为真，或者选择的数在 2/5/6/9 中。


动态规划的边界情况为出现在 pos 等于 n 的长度时，此时所有数位已经确定，那么我们通过 diff 就可以知道其是否为好数：如果 diff 为真，那么 f(pos,bound,diff) 的值为 1，否则为 0。

该方法使用记忆化搜索编写代码更为方便。

**代码**

-   C++
-   Java
-   C#
-   Python3
-   C
-   JavaScript
-   Golang

```C++
class Solution {
public:
    int rotatedDigits(int n) {
        vector<int> digits;
        while (n) {
            digits.push_back(n % 10);
            n /= 10;
        }
        reverse(digits.begin(), digits.end());
        
        memset(memo, -1, sizeof(memo));
        function<int(int, bool, bool)> dfs = [&](int pos, bool bound, bool diff) -> int {
            if (pos == digits.size()) {
                return diff;
            }
            if (memo[pos][bound][diff] != -1) {
                return memo[pos][bound][diff];
            }

            int ret = 0;
            for (int i = 0; i <= (bound ? digits[pos] : 9); ++i) {
                if (check[i] != -1) {
                    ret += dfs(
                        pos + 1,
                        bound && (i == digits[pos]),
                        diff || (check[i] == 1)
                    );
                }
            }
            return memo[pos][bound][diff] = ret;
        };
        
        int ans = dfs(0, true, false);
        return ans;
    }

private:
    static constexpr int check[10] = {0, 0, 1, -1, -1, 1, 1, -1, 0, 1};
    int memo[5][2][2];
};

```

```Java
class Solution {
    static int[] check = {0, 0, 1, -1, -1, 1, 1, -1, 0, 1};
    int[][][] memo = new int[5][2][2];
    List<Integer> digits = new ArrayList<Integer>();

    public int rotatedDigits(int n) {
        while (n != 0) {
            digits.add(n % 10);
            n /= 10;
        }
        Collections.reverse(digits);

        for (int i = 0; i < 5; ++i) {
            for (int j = 0; j < 2; ++j) {
                Arrays.fill(memo[i][j], -1);
            }
        }

        int ans = dfs(0, 1, 0);
        return ans;
    }

    public int dfs(int pos, int bound, int diff) {
        if (pos == digits.size()) {
            return diff;
        }
        if (memo[pos][bound][diff] != -1) {
            return memo[pos][bound][diff];
        }

        int ret = 0;
        for (int i = 0; i <= (bound != 0 ? digits.get(pos) : 9); ++i) {
            if (check[i] != -1) {
                ret += dfs(
                    pos + 1,
                    bound != 0 && i == digits.get(pos) ? 1 : 0,
                    diff != 0 || check[i] == 1 ? 1 : 0
                );
            }
        }
        return memo[pos][bound][diff] = ret;
    }
}

```

```C#
public class Solution {
    static int[] check = {0, 0, 1, -1, -1, 1, 1, -1, 0, 1};
    int[,,] memo = new int[5, 2, 2];
    IList<int> digits = new List<int>();

    public int RotatedDigits(int n) {
        while (n != 0) {
            digits.Add(n % 10);
            n /= 10;
        }
        for (int i = 0, j = digits.Count - 1; i < j; ++i, --j) {
            int temp = digits[i];
            digits[i] = digits[j];
            digits[j] = temp;
        }

        for (int i = 0; i < 5; ++i) {
            for (int j = 0; j < 2; ++j) {
                for (int k = 0; k < 2; ++k) {
                    memo[i, j, k] = -1;
                }
            }
        }

        int ans = DFS(0, 1, 0);
        return ans;
    }

    public int DFS(int pos, int bound, int diff) {
        if (pos == digits.Count) {
            return diff;
        }
        if (memo[pos, bound, diff] != -1) {
            return memo[pos, bound, diff];
        }

        int ret = 0;
        for (int i = 0; i <= (bound != 0 ? digits[pos] : 9); ++i) {
            if (check[i] != -1) {
                ret += DFS(
                    pos + 1,
                    bound != 0 && i == digits[pos] ? 1 : 0,
                    diff != 0 || check[i] == 1 ? 1 : 0
                );
            }
        }
        return memo[pos, bound, diff] = ret;
    }
}

```

```Python
class Solution:
    def rotatedDigits(self, n: int) -> int:
        check = [0, 0, 1, -1, -1, 1, 1, -1, 0, 1]
        digits = [int(digit) for digit in str(n)]

        @cache
        def dfs(pos: int, bound: bool, diff: bool) -> int:
            if pos == len(digits):
                return int(diff)
            
            ret = 0
            for i in range(0, (digits[pos] if bound else 9) + 1):
                if check[i] != -1:
                    ret += dfs(
                        pos + 1,
                        bound and i == digits[pos],
                        diff or check[i] == 1
                    )
            
            return ret
            
        
        ans = dfs(0, True, False)
        dfs.cache_clear()
        return ans

```

```C
static const int check[10] = {0, 0, 1, -1, -1, 1, 1, -1, 0, 1};
int memo[5][2][2];

void reverse(int *arr, int l, int r) {
    while (l < r) {
        int element = arr[l];
        arr[l] = arr[r];
        arr[r] = element;
        l++, r--;
    }
}

int dfs(int pos, bool bound, bool diff, int *digits, int digitsSize) {
    if (pos == digitsSize) {
        return diff;
    }
    if (memo[pos][bound][diff] != -1) {
        return memo[pos][bound][diff];
    }

    int ret = 0;
    for (int i = 0; i <= (bound ? digits[pos] : 9); ++i) {
        if (check[i] != -1) {
            ret += dfs(pos + 1, bound && (i == digits[pos]), diff || (check[i] == 1), digits, digitsSize);
        }
    }
    return memo[pos][bound][diff] = ret;
};

int rotatedDigits(int n) {
    int digits[8];
    int pos = 0;
    while (n) {
        digits[pos++] = n % 10;
        n /= 10;
    }
    reverse(digits, 0, pos - 1);    
    memset(memo, -1, sizeof(memo));
    return dfs(0, true, false, digits, pos);
}

```

```JavaScript
var rotatedDigits = function(n) {
    const check = [0, 0, 1, -1, -1, 1, 1, -1, 0, 1];
    const memo = new Array(5).fill(0).map(() => new Array(2).fill(0).map(() => new Array(2).fill(-1)));
    let digits = [];

    const dfs = (pos, bound, diff) => {
        if (pos === digits.length) {
            return diff;
        }
        if (memo[pos][bound][diff] !== -1) {
            return memo[pos][bound][diff];
        }

        let ret = 0;
        for (let i = 0; i <= (bound !== 0 ? digits[pos] : 9); ++i) {
            if (check[i] != -1) {
                ret += dfs(
                    pos + 1,
                    bound !== 0 && i === digits[pos] ? 1 : 0,
                    diff !== 0 || check[i] === 1 ? 1 : 0
                );
            }
        }
        return memo[pos][bound][diff] = ret;
    }

    while (n !== 0) {
        digits.push(n % 10);
        n = Math.floor(n / 10);
    }
    digits = _.reverse(digits);

    const ans = dfs(0, 1, 0);
    return ans;
};

```

```Go
var check = [10]int{0, 0, 1, -1, -1, 1, 1, -1, 0, 1}

func rotatedDigits(n int) int {
    digits := strconv.Itoa(n)
    memo := [5][2][2]int{}
    for i := 0; i < 5; i++ {
        memo[i] = [2][2]int{{-1, -1}, {-1, -1}}
    }
    var dfs func(int, bool, bool) int
    dfs = func(pos int, bound, diff bool) (res int) {
        if pos == len(digits) {
            return bool2int(diff)
        }
        ptr := &memo[pos][bool2int(bound)][bool2int(diff)]
        if *ptr != -1 {
            return *ptr
        }
        lim := 9
        if bound {
            lim = int(digits[pos] - '0')
        }
        for i := 0; i <= lim; i++ {
            if check[i] != -1 {
                res += dfs(pos+1, bound && i == int(digits[pos]-'0'), diff || check[i] == 1)
            }
        }
        *ptr = res
        return
    }
    return dfs(0, true, false)
}

func bool2int(b bool) int {
    if b {
        return 1
    }
    return 0
}

```

**复杂度分析**

-   时间复杂度：O(log⁡n)。数 n 的数位有 ⌈log⁡10n⌉+1=O(log⁡n) 个，那么动态规划的状态有 O(log⁡n×2×2)=O(log⁡n) 个，每个状态需要 O(10)=O(1) 的时间进行转移，因此总时间复杂度为 O(log⁡n)。

-   空间复杂度：O(log⁡n)，即为动态规划中存储状态需要使用的空间。
