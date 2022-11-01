#### [](https://leetcode.cn/problems/check-if-two-string-arrays-are-equivalent/solution/jian-cha-liang-ge-zi-fu-chuan-shu-zu-shi-9iuo//#方法二：遍历)方法二：遍历

**思路与算法**

更进一步的想法，我们可以直接在 word1 和 word2 上进行对比，避免额外创建字符串。

设置两个指针 p1 和 p2 分别表示遍历到了 word1[p1] 和 word2[p2]，另外还需设置两个指针 i 和 j，表示正在对比 word1[p1][i] 和 word2[p2][j]。

如果 word1[p1][i]≠word2[p2][j]，则直接返回 false。否则 i+1，当 i=word1[p1].length 时，表示对比到当前字符串末尾，需要将 p1+1，i 赋值为 0。j 和 p2 同理。

当 p1<word1.length 或者 p2<word2.length 不满足时，算法结束。最终两个数组相等条件即为 p1=word1.length 并且 p2=word2.length。

**代码**

```Python
class Solution:
    def arrayStringsAreEqual(self, word1: List[str], word2: List[str]) -> bool:
        p1 = p2 = i = j = 0
        while p1 < len(word1) and p2 < len(word2):
            if word1[p1][i] != word2[p2][j]:
                return False
            i += 1
            if i == len(word1[p1]):
                p1 += 1
                i = 0
            j += 1
            if j == len(word2[p2]):
                p2 += 1
                j = 0
        return p1 == len(word1) and p2 == len(word2)
```

```C++
class Solution {
public:
    bool arrayStringsAreEqual(vector<string>& word1, vector<string>& word2) {
        int p1 = 0, p2 = 0, i = 0, j = 0;
        while (p1 < word1.size() && p2 < word2.size()) {
            if (word1[p1][i] != word2[p2][j]) {
                return false;
            }
            i++;
            if (i == word1[p1].size()) {
                p1++;
                i = 0;
            }
            j++;
            if (j == word2[p2].size()) {
                p2++;
                j = 0;
            }
        }
        return p1 == word1.size() && p2 == word2.size();
    }
};
```

```Java
class Solution {
    public boolean arrayStringsAreEqual(String[] word1, String[] word2) {
        int p1 = 0, p2 = 0, i = 0, j = 0;
        while (p1 < word1.length && p2 < word2.length) {
            if (word1[p1].charAt(i) != word2[p2].charAt(j)) {
                return false;
            }
            i++;
            if (i == word1[p1].length()) {
                p1++;
                i = 0;
            }
            j++;
            if (j == word2[p2].length()) {
                p2++;
                j = 0;
            }
        }
        return p1 == word1.length && p2 == word2.length;
    }
}
```

```C#
public class Solution {
    public bool ArrayStringsAreEqual(string[] word1, string[] word2) {
        int p1 = 0, p2 = 0, i = 0, j = 0;
        while (p1 < word1.Length && p2 < word2.Length) {
            if (word1[p1][i] != word2[p2][j]) {
                return false;
            }
            i++;
            if (i == word1[p1].Length) {
                p1++;
                i = 0;
            }
            j++;
            if (j == word2[p2].Length) {
                p2++;
                j = 0;
            }
        }
        return p1 == word1.Length && p2 == word2.Length;
    }
}
```

```Go
func arrayStringsAreEqual(word1, word2 []string) bool {
    var p1, p2, i, j int
    for p1 < len(word1) && p2 < len(word2) {
        if word1[p1][i] != word2[p2][j] {
            return false
        }
        i++
        if i == len(word1[p1]) {
            p1++
            i = 0
        }

        j++
        if j == len(word2[p2]) {
            p2++
            j = 0
        }
    }
    return p1 == len(word1) && p2 == len(word2)
}
```

```JavaScript
var arrayStringsAreEqual = function(word1, word2) {
    let p1 = 0, p2 = 0, i = 0, j = 0;
    while (p1 < word1.length && p2 < word2.length) {
        if (word1[p1][i] !== word2[p2][j]) {
            return false;
        }
        i++;
        if (i === word1[p1].length) {
            p1++;
            i = 0;
        }
        j++;
        if (j === word2[p2].length) {
            p2++;
            j = 0;
        }
    }
    return p1 == word1.length && p2 == word2.length;
};
```

```C
bool arrayStringsAreEqual(char ** word1, int word1Size, char ** word2, int word2Size) {
    int p1 = 0, p2 = 0, i = 0, j = 0;
    while (p1 < word1Size && p2 < word2Size) {
        if (word1[p1][i] != word2[p2][j]) {
            return false;
        }
        i++;
        if (word1[p1][i] == '\0') {
            p1++;
            i = 0;
        }
        j++;
        if (word2[p2][j] == '\0') {
            p2++;
            j = 0;
        }
    }
    return p1 == word1Size && p2 == word2Size;
}
```

**复杂度分析**

-   时间复杂度：O(n+m)，其中 n 和 m 分别是$\sum word1[i].length$和$\sum word2[i].length$。
-   空间复杂度：O(1)。算法只使用了常数个变量来表示指针。
