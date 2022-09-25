#### [](https://leetcode.cn/problems/rotated-digits/solution/xuan-zhuan-shu-zi-by-leetcode-solution-q9bh//#方法一：枚举每一个数)方法一：枚举每一个数

**思路与算法**

根据题目的要求，一个数是好数，当且仅当：

-   数中没有出现 3,4,7；

-   数中至少出现一次 2 或 5 或 6 或 9；

-   对于 0,1,8 则没有要求。


因此，我们可以枚举 [1,n] 的每一个正整数，并以此判断它们是否满足上述要求即可。在下面的代码中，我们用 valid 记录数是否满足第一条要求，diff 记录数是否满足第二条要求。

**代码**

```C++
class Solution {
public:
    int rotatedDigits(int n) {
        int ans = 0;
        for (int i = 1; i <= n; ++i) {
            string num = to_string(i);
            bool valid = true, diff = false;
            for (char ch: num) {
                if (check[ch - '0'] == -1) {
                    valid = false;
                }
                else if (check[ch - '0'] == 1) {
                    diff = true;
                }
            }
            if (valid && diff) {
                ++ans;
            }
        }
        return ans;
    }

private:
    static constexpr int check[10] = {0, 0, 1, -1, -1, 1, 1, -1, 0, 1};
};

```

```Java
class Solution {
    static int[] check = {0, 0, 1, -1, -1, 1, 1, -1, 0, 1};

    public int rotatedDigits(int n) {
        int ans = 0;
        for (int i = 1; i <= n; ++i) {
            String num = String.valueOf(i);
            boolean valid = true, diff = false;
            for (int j = 0; j < num.length(); ++j) {
                char ch = num.charAt(j);
                if (check[ch - '0'] == -1) {
                    valid = false;
                } else if (check[ch - '0'] == 1) {
                    diff = true;
                }
            }
            if (valid && diff) {
                ++ans;
            }
        }
        return ans;
    }
}

```

```C#
public class Solution {
    static int[] check = {0, 0, 1, -1, -1, 1, 1, -1, 0, 1};

    public int RotatedDigits(int n) {
        int ans = 0;
        for (int i = 1; i <= n; ++i) {
            string num = i.ToString();
            bool valid = true, diff = false;
            foreach (char ch in num) {
                if (check[ch - '0'] == -1) {
                    valid = false;
                } else if (check[ch - '0'] == 1) {
                    diff = true;
                }
            }
            if (valid && diff) {
                ++ans;
            }
        }
        return ans;
    }
}

```

```Python
class Solution:
    def rotatedDigits(self, n: int) -> int:
        check = [0, 0, 1, -1, -1, 1, 1, -1, 0, 1]

        ans = 0
        for i in range(1, n + 1):
            num = [int(digit) for digit in str(i)]
            valid, diff = True, False
            for digit in num:
                if check[digit] == -1:
                    valid = False
                elif check[digit] == 1:
                    diff = True
            if valid and diff:
                ans += 1
        
        return ans

```

```C
const int check[10] = {0, 0, 1, -1, -1, 1, 1, -1, 0, 1};

int rotatedDigits(int n){
    int ans = 0;
    for (int i = 1; i <= n; ++i) {
        char num[8];
        sprintf(num, "%d", i);
        bool valid = true, diff = false;
        for (int j = 0; num[j]; j++) {
            if (check[num[j] - '0'] == -1) {
                valid = false;
            }
            else if (check[num[j] - '0'] == 1) {
                diff = true;
            }
        }
        if (valid && diff) {
            ++ans;
        }
    }
    return ans;
}

```

```JavaScript
const check = [0, 0, 1, -1, -1, 1, 1, -1, 0, 1];
var rotatedDigits = function(n) {
    let ans = 0;
    for (let i = 1; i <= n; ++i) {
        const num = '' + i;
        let valid = true, diff = false;
        for (let j = 0; j < num.length; ++j) {
            const ch = num[j];
            if (check[ch.charCodeAt() - '0'.charCodeAt()] === -1) {
                valid = false;
            } else if (check[ch.charCodeAt() - '0'.charCodeAt()] === 1) {
                diff = true;
            }
        }
        if (valid && diff) {
            ++ans;
        }
    }
    return ans;
};

```

```Go
var check = [10]int{0, 0, 1, -1, -1, 1, 1, -1, 0, 1}

func rotatedDigits(n int) (ans int) {
    for i := 1; i <= n; i++ {
        valid, diff := true, false
        for _, c := range strconv.Itoa(i) {
            if check[c-'0'] == -1 {
                valid = false
            } else if check[c-'0'] == 1 {
                diff = true
            }
        }
        if valid && diff {
            ans++
        }
    }
    return
}

```

**复杂度分析**

-   时间复杂度：O(nlog⁡n)。数 n 的数位有 ⌈log⁡10n⌉+1=O(log⁡n) 个，其中 ⌈⋅⌉ 表示向上取整。因此总时间复杂度为 O(nlog⁡n)。

-   空间复杂度：O(log⁡n)。使用的空间分为两部分，第一部分为代码中记录每一个数位类型的数组 check 需要使用的 O(10)=O(1) 的空间，第二部分为将数 i 转化为字符串需要使用的临时空间，大小为 O(log⁡n)。这一部分的空间也可以优化至 O(1)，只需要每次将 i 对 10 进行取模，从低位到高位获取 i 的每一个数位即可。
