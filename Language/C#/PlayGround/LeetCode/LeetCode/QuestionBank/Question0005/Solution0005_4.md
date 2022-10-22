#### [](https://leetcode.cn/problems/longest-palindromic-substring/solution/zui-chang-hui-wen-zi-chuan-by-leetcode-solution//#方法三：-算法)方法三：Manacher\\text{Manacher}Manacher 算法

还有一个复杂度为 O(n) 的 Manacher 算法。然而本算法十分复杂，一般不作为面试内容。这里给出，仅供有兴趣的同学挑战自己。

为了表述方便，我们定义一个新概念**臂长**，表示中心扩展算法向外扩展的长度。如果一个位置的最大回文字符串长度为 `2 * length + 1` ，其臂长为 `length`。

下面的讨论只涉及长度为奇数的回文字符串。长度为偶数的回文字符串我们将会在最后与长度为奇数的情况统一起来。

**思路与算法**

在中心扩展算法的过程中，我们能够得出每个位置的臂长。那么当我们要得出以下一个位置 `i` 的臂长时，能不能利用之前得到的信息呢？

答案是肯定的。具体来说，如果位置 `j` 的臂长为 `length`，并且有 `j + length > i`，如下图所示：

![](./assets/img/Solution0005_4.png)

当在位置 `i` 开始进行中心拓展时，我们可以先找到 `i` 关于 `j` 的对称点 `2 * j - i`。那么如果点 `2 * j - i` 的臂长等于 `n`，我们就可以知道，点 `i` 的臂长至少为 `min(j + length - i, n)`。那么我们就可以直接跳过 `i` 到 `i + min(j + length - i, n)` 这部分，从 `i + min(j + length - i, n) + 1` 开始拓展。

我们只需要在中心扩展法的过程中记录右臂在最右边的回文字符串，将其中心作为 `j`，在计算过程中就能最大限度地避免重复计算。

那么现在还有一个问题：如何处理长度为偶数的回文字符串呢？

我们可以通过一个特别的操作将奇偶数的情况统一起来：我们向字符串的头尾以及每两个字符中间添加一个特殊字符 `#`，比如字符串 `aaba` 处理后会变成 `#a#a#b#a#`。那么原先长度为偶数的回文字符串 `aa` 会变成长度为奇数的回文字符串 `#a#a#`，而长度为奇数的回文字符串 `aba` 会变成长度仍然为奇数的回文字符串 `#a#b#a#`，我们就不需要再考虑长度为偶数的回文字符串了。

注意这里的特殊字符不需要是没有出现过的字母，我们可以使用任何一个字符来作为这个特殊字符。这是因为，当我们只考虑长度为奇数的回文字符串时，每次我们比较的两个字符奇偶性一定是相同的，所以原来字符串中的字符不会与插入的特殊字符互相比较，不会因此产生问题。

```Java
class Solution {
    public String longestPalindrome(String s) {
        int start = 0, end = -1;
        StringBuffer t = new StringBuffer("#");
        for (int i = 0; i < s.length(); ++i) {
            t.append(s.charAt(i));
            t.append('#');
        }
        t.append('#');
        s = t.toString();

        List<Integer> arm_len = new ArrayList<Integer>();
        int right = -1, j = -1;
        for (int i = 0; i < s.length(); ++i) {
            int cur_arm_len;
            if (right >= i) {
                int i_sym = j * 2 - i;
                int min_arm_len = Math.min(arm_len.get(i_sym), right - i);
                cur_arm_len = expand(s, i - min_arm_len, i + min_arm_len);
            } else {
                cur_arm_len = expand(s, i, i);
            }
            arm_len.add(cur_arm_len);
            if (i + cur_arm_len > right) {
                j = i;
                right = i + cur_arm_len;
            }
            if (cur_arm_len * 2 + 1 > end - start) {
                start = i - cur_arm_len;
                end = i + cur_arm_len;
            }
        }

        StringBuffer ans = new StringBuffer();
        for (int i = start; i <= end; ++i) {
            if (s.charAt(i) != '#') {
                ans.append(s.charAt(i));
            }
        }
        return ans.toString();
    }

    public int expand(String s, int left, int right) {
        while (left >= 0 && right < s.length() && s.charAt(left) == s.charAt(right)) {
            --left;
            ++right;
        }
        return (right - left - 2) / 2;
    }
}
```

```Python
class Solution:
    def expand(self, s, left, right):
        while left >= 0 and right < len(s) and s[left] == s[right]:
            left -= 1
            right += 1
        return (right - left - 2) // 2

    def longestPalindrome(self, s: str) -> str:
        end, start = -1, 0
        s = '#' + '#'.join(list(s)) + '#'
        arm_len = []
        right = -1
        j = -1
        for i in range(len(s)):
            if right >= i:
                i_sym = 2 * j - i
                min_arm_len = min(arm_len[i_sym], right - i)
                cur_arm_len = self.expand(s, i - min_arm_len, i + min_arm_len)
            else:
                cur_arm_len = self.expand(s, i, i)
            arm_len.append(cur_arm_len)
            if i + cur_arm_len > right:
                j = i
                right = i + cur_arm_len
            if 2 * cur_arm_len + 1 > end - start:
                start = i - cur_arm_len
                end = i + cur_arm_len
        return s[start+1:end+1:2]
```

```C++
class Solution {
public:
    int expand(const string& s, int left, int right) {
        while (left >= 0 && right < s.size() && s[left] == s[right]) {
            --left;
            ++right;
        }
        return (right - left - 2) / 2;
    }

    string longestPalindrome(string s) {
        int start = 0, end = -1;
        string t = "#";
        for (char c: s) {
            t += c;
            t += '#';
        }
        t += '#';
        s = t;

        vector<int> arm_len;
        int right = -1, j = -1;
        for (int i = 0; i < s.size(); ++i) {
            int cur_arm_len;
            if (right >= i) {
                int i_sym = j * 2 - i;
                int min_arm_len = min(arm_len[i_sym], right - i);
                cur_arm_len = expand(s, i - min_arm_len, i + min_arm_len);
            } else {
                cur_arm_len = expand(s, i, i);
            }
            arm_len.push_back(cur_arm_len);
            if (i + cur_arm_len > right) {
                j = i;
                right = i + cur_arm_len;
            }
            if (cur_arm_len * 2 + 1 > end - start) {
                start = i - cur_arm_len;
                end = i + cur_arm_len;
            }
        }

        string ans;
        for (int i = start; i <= end; ++i) {
            if (s[i] != '#') {
                ans += s[i];
            }
        }
        return ans;
    }
};
```

```Go
func longestPalindrome(s string) string {
    start, end := 0, -1
    t := "#"
    for i := 0; i < len(s); i++ {
        t += string(s[i]) + "#"
    }
    t += "#"
    s = t
    arm_len := []int{}
    right, j := -1, -1
    for i := 0; i < len(s); i++ {
        var cur_arm_len int
        if right >= i {
            i_sym := j * 2 - i
            min_arm_len := min(arm_len[i_sym], right-i)
            cur_arm_len = expand(s, i-min_arm_len, i+min_arm_len)
        } else {
            cur_arm_len = expand(s, i, i)
        }
        arm_len = append(arm_len, cur_arm_len)
        if i + cur_arm_len > right {
            j = i
            right = i + cur_arm_len
        }
        if cur_arm_len * 2 + 1 > end - start {
            start = i - cur_arm_len
            end = i + cur_arm_len
        }
    }
    ans := ""
    for i := start; i <= end; i++ {
        if s[i] != '#' {
            ans += string(s[i])
        }
    }
    return ans
}

func expand(s string, left, right int) int {
    for ; left >= 0 && right < len(s) && s[left] == s[right]; left, right = left-1, right+1 { }
    return (right - left - 2) / 2
}

func min(x, y int) int {
    if x < y {
        return x
    }
    return y
}
```

**复杂度分析**

-   时间复杂度：O(n)，其中 n 是字符串的长度。由于对于每个位置，扩展要么从当前的最右侧臂长 `right` 开始，要么只会进行一步，而 `right` 最多向前走 O(n) 步，因此算法的复杂度为 O(n)。
-   空间复杂度：O(n)，我们需要 O(n) 的空间记录每个位置的臂长。
