#### [](https://leetcode.cn/problems/letter-case-permutation/solution/zi-mu-da-xiao-xie-quan-pai-lie-by-leetco-cwpx//#方法三：二进制位图)方法三：二进制位图

假设字符串 s 有 m 个字母，那么全排列就有 $2^m$ 个字符串序列，且可以用位掩码 bits 唯一地表示一个字符串。
-   bits 的第 i 为 0 表示字符串 s 中从左往右第 i 个字母为小写形式；
-   bits 的第 i 为 1 表示字符串 s 中从左往右第 i 个字母为大写形式；

我们采用的位掩码只计算字符串 s 中的字母，对于数字则直接跳过，通过位图计算从而构造正确的全排列。我们依次检测字符串第 i 个字符串 c：
-   如果字符串 c 为数字，则我们直接在当前的序列中添加字符串 c；
-   如果字符串 c 为字母，且 c 为字符串中的第 k 个字母，如果掩码 bits 中的第 k 位为 0，则添加字符串 c 的小写形式；如果掩码 bits 中的第 k 位为 1，则添加字符串 c 的大写形式；

```Python
class Solution:
    def letterCasePermutation(self, s: str) -> List[str]:
        ans = []
        m = sum(c.isalpha() for c in s)
        for mask in range(1 << m):
            t, k = [], 0
            for c in s:
                if c.isalpha():
                    t.append(c.upper() if mask >> k & 1 else c.lower())
                    k += 1
                else:
                    t.append(c)
            ans.append(''.join(t))
        return ans
```

```C++
class Solution {
public:
    vector<string> letterCasePermutation(string s) {
        int n = s.size();
        int m = 0;
        for (auto c : s) {
            if (isalpha(c)) {
                m++;
            }
        }
        vector<string> ans;
        for (int mask = 0; mask < (1 << m); mask++) {
            string str;
            for (int j = 0, k = 0; j < n; j++) {
                if (isalpha(s[j]) && (mask & (1 << k++))) {
                    str.push_back(toupper(s[j]));
                } else {
                    str.push_back(tolower(s[j]));
                }
            }
            ans.emplace_back(str);
        }
        return ans;
    }
};
```

```Java
class Solution {
    public List<String> letterCasePermutation(String s) {
        int n = s.length();
        int m = 0;
        for (int i = 0; i < n; i++) {
            if (Character.isLetter(s.charAt(i))) {
                m++;
            }
        }
        List<String> ans = new ArrayList<String>();
        for (int mask = 0; mask < (1 << m); mask++) {
            StringBuilder sb = new StringBuilder();
            for (int j = 0, k = 0; j < n; j++) {
                if (Character.isLetter(s.charAt(j)) && (mask & (1 << k++)) != 0) {
                    sb.append(Character.toUpperCase(s.charAt(j)));
                } else {
                    sb.append(Character.toLowerCase(s.charAt(j)));
                }
            }
            ans.add(sb.toString());
        }
        return ans;
    }
}
```

```C#
public class Solution {
    public IList<string> LetterCasePermutation(string s) {
        int n = s.Length;
        int m = 0;
        for (int i = 0; i < n; i++) {
            if (char.IsLetter(s[i])) {
                m++;
            }
        }
        IList<string> ans = new List<string>();
        for (int mask = 0; mask < (1 << m); mask++) {
            StringBuilder sb = new StringBuilder();
            for (int j = 0, k = 0; j < n; j++) {
                if (char.IsLetter(s[j]) && (mask & (1 << k++)) != 0) {
                    sb.Append(char.ToUpper(s[j]));
                } else {
                    sb.Append(char.ToLower(s[j]));
                }
            }
            ans.Add(sb.ToString());
        }
        return ans;
    }
}
```

```C
char ** letterCasePermutation(char * s, int* returnSize){
    int n = strlen(s);
    int m = 0;
    for (int i = 0; i < n; i++) {
        if (isalpha(s[i])) {
            m++;
        }
    }
    char **ans = (char **)malloc(sizeof(char *) * (1 << m));
    for (int mask = 0; mask < (1 << m); mask++) {
        ans[mask] = (char *)malloc(sizeof(char) * (n + 1));
        ans[mask][n] = '\0';
        for (int j = 0, k = 0; j < n; j++) {
            if (isalpha(s[j]) && (mask & (1 << k++))) {
                ans[mask][j] = toupper(s[j]);
            } else {
                ans[mask][j] = tolower(s[j]);
            }
        }
    }
    *returnSize = (1 << m);
    return ans;
}
```

```Go
func letterCasePermutation(s string) (ans []string) {
    m := 0
    for _, c := range s {
        if unicode.IsLetter(c) {
            m++
        }
    }
    for mask := 0; mask < 1<<m; mask++ {
        t, k := []rune(s), 0
        for i, c := range t {
            if unicode.IsLetter(c) {
                if mask>>k&1 > 0 {
                    t[i] = unicode.ToUpper(c)
                } else {
                    t[i] = unicode.ToLower(c)
                }
                k++
            }
        }
        ans = append(ans, string(t))
    }
    return
}
```

```JavaScript
var letterCasePermutation = function(s) {
    const n = s.length;
    let m = 0;
    for (let i = 0; i < n; i++) {
        if (isLetter(s[i])) {
            m++;
        }
    }
    const ans = [];
    for (let mask = 0; mask < (1 << m); mask++) {
        let sb = '';
        for (let j = 0, k = 0; j < n; j++) {
            if (isLetter(s[j]) && (mask & (1 << k++)) !== 0) {
                sb += s[j].toUpperCase();
            } else {
                sb += s[j].toLowerCase();
            }
        }
        ans.push(sb);
    }
    return ans;
};

const isDigit = (ch) => {
    return parseFloat(ch).toString() === "NaN" ? false : true;
}

const isLetter = (ch) => {
    return 'a' <= ch && ch <= 'z' || 'A' <= ch && ch <= 'Z';
}
```

**复杂度分析**

-   时间复杂度：$O(n \times 2^n)$，其中 n 表示字符串的长度。最多有 $2^n$ 个序列，生成每个序列的时间为 O(n)，总的时间复杂度为 $O(n \times 2^n)$。
-   空间复杂度：O(1)。除返回值以外不需要额外的空间。
