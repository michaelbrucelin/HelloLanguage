#### [](https://leetcode.cn/problems/letter-case-permutation/solution/zi-mu-da-xiao-xie-quan-pai-lie-by-leetco-cwpx//#方法二：回溯)方法二：回溯

同样的思路我们还可以采用回溯的思想，从左往右依次遍历字符，当在进行搜索时，搜索到字符串 s 的第 i 个字符 c 时:
-   如果 c 为一个数字，则我们继续检测下一个字符；
-   如果 c 为一个字母，我们将字符中的第 i 个字符 c 改变大小写形式后，往后继续搜索，完成改写形式的子状态搜索后，我们将 c 进行恢复，继续往后搜索；
-   如果当前完成字符串搜索后，则表示当前的子状态已经搜索完成，该序列为全排列中的一个；

由于每个字符的大小写形式刚好差了 32，因此在大小写装换时可以用 c^32（异或运算） 来进行转换和恢复。

```Python
class Solution:
    def letterCasePermutation(self, s: str) -> List[str]:
        ans = []
        def dfs(s: List[str], pos: int) -> None:
            while pos < len(s) and s[pos].isdigit():
                pos += 1
            if pos == len(s):
                ans.append(''.join(s))
                return
            dfs(s, pos + 1)
            s[pos] = s[pos].swapcase()
            dfs(s, pos + 1)
            s[pos] = s[pos].swapcase()
        dfs(list(s), 0)
        return ans
```

```C++
class Solution {
public:
    void dfs(string &s, int pos, vector<string> &res) {
        while (pos < s.size() && isdigit(s[pos])) {
            pos++;
        }
        if (pos == s.size()) {
            res.emplace_back(s);
            return;
        }
        s[pos] ^= 32;
        dfs(s, pos + 1, res);
        s[pos] ^= 32;
        dfs(s, pos + 1, res);
    }

    vector<string> letterCasePermutation(string s) {
        vector<string> ans;
        dfs(s, 0, ans);
        return ans;
    }
};
```

```Java
class Solution {
    public List<String> letterCasePermutation(String s) {
        List<String> ans = new ArrayList<String>();
        dfs(s.toCharArray(), 0, ans);
        return ans;
    }

    public void dfs(char[] arr, int pos, List<String> res) {
        while (pos < arr.length && Character.isDigit(arr[pos])) {
            pos++;
        }
        if (pos == arr.length) {
            res.add(new String(arr));
            return;
        }
        arr[pos] ^= 32;
        dfs(arr, pos + 1, res);
        arr[pos] ^= 32;
        dfs(arr, pos + 1, res);
    }
}
```

```C#
public class Solution {
    public IList<string> LetterCasePermutation(string s) {
        IList<string> ans = new List<string>();
        DFS(s.ToCharArray(), 0, ans);
        return ans;
    }

    public void DFS(char[] arr, int pos, IList<string> res) {
        while (pos < arr.Length && char.IsDigit(arr[pos])) {
            pos++;
        }
        if (pos == arr.Length) {
            res.Add(new string(arr));
            return;
        }
        arr[pos] = (char) (arr[pos] ^ 32);
        DFS(arr, pos + 1, res);
        arr[pos] = (char) (arr[pos] ^ 32);
        DFS(arr, pos + 1, res);
    }
}
```

```C
void dfs(char *s, int pos, char **res,int* returnSize) {
    while (s[pos] != '\0' && isdigit(s[pos])) {
        pos++;
    }
    if (s[pos] == '\0') {
        res[*returnSize] = (char *)malloc(sizeof(char) * (strlen(s) + 1));
        strcpy(res[*returnSize], s);
        (*returnSize)++;
        return;
    }
    s[pos] ^= 32;
    dfs(s, pos + 1, res, returnSize);
    s[pos] ^= 32;
    dfs(s, pos + 1, res, returnSize);
}

char ** letterCasePermutation(char * s, int* returnSize) {
    int n = strlen(s);
    *returnSize = 0;
    char **ans = (char **)malloc(sizeof(char *) * (1 << n));
    dfs(s, 0, ans, returnSize);
    return ans;
}
```

```Go
func letterCasePermutation(s string) (ans []string) {
    var dfs func([]byte, int)
    dfs = func(s []byte, pos int) {
        for pos < len(s) && unicode.IsDigit(rune(s[pos])) {
            pos++
        }
        if pos == len(s) {
            ans = append(ans, string(s))
            return
        }
        dfs(s, pos+1)
        s[pos] ^= 32
        dfs(s, pos+1)
        s[pos] ^= 32
    }
    dfs([]byte(s), 0)
    return
}
```

```JavaScript
var letterCasePermutation = function(s) {
    const ans = [];
    const dfs = (arr, pos, res) => {
        while (pos < arr.length && isDigit(arr[pos])) {
            pos++;
        }
        if (pos === arr.length) {
            res.push(arr.join(""));
            return;
        }
        arr[pos] = String.fromCharCode(arr[pos].charCodeAt() ^ 32);
        dfs(arr, pos + 1, res);
        arr[pos] = String.fromCharCode(arr[pos].charCodeAt() ^ 32);
        dfs(arr, pos + 1, res);
        }
    dfs([...s], 0, ans);
    return ans;
};

const isDigit = (ch) => {
    return parseFloat(ch).toString() === "NaN" ? false : true;
}
```

**复杂度分析**

-   时间复杂度：$O(n \times 2^n)$，其中 n 表示字符串的长度。递归深度最多为 n，所有可能的递归子状态最多为 $2^n$ 个，每次个子状态的搜索时间为 O(n)，因此时间复杂度为 $O(n \times 2^n)$。
-   空间复杂度：$O(n \times 2^n)$。递归深度最多为 n，所有可能的递归子状态最多为 $2^n$ 个，每次个子状态的搜索时间为 O(n)，因此时间复杂度为 $O(n \times 2^n)$。
