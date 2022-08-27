#### 方法：贪心

**思路**

直观感觉，我们应该先选择当前所剩最多的待写字母写入字符串中。举一个例子，如果 `A = 6, B = 2`，那么我们期望写出 `'aabaabaa'`。进一步说，设当前所剩最多的待写字母为 `x`，只有前两个已经写下的字母都是 `x` 的时候，下一个写入字符串中的字母才不应该选择它。

**算法**

我们定义 `A, B`：待写的 `'a'` 与 `'b'` 的数量。

设当前还需要写入字符串的 `'a'` 与 `'b'` 中较多的那一个为 `x`，如果我们已经连续写了两个 `x` 了，下一次我们应该写另一个字母。否则，我们应该继续写 `x`。

```Java
class Solution {
    public String strWithout3a3b(int A, int B) {
        StringBuilder ans = new StringBuilder();

        while (A > 0 || B > 0) {
            boolean writeA = false;
            int L = ans.length();
            if (L >= 2 && ans.charAt(L-1) == ans.charAt(L-2)) {
                if (ans.charAt(L-1) == 'b')
                    writeA = true;
            } else {
                if (A >= B)
                    writeA = true;
            }

            if (writeA) {
                A--;
                ans.append('a');
            } else {
                B--;
                ans.append('b');
            }
        }

        return ans.toString();
    }
}

```

```Python
class Solution(object):
    def strWithout3a3b(self, A, B):
        ans = []

        while A or B:
            if len(ans) >= 2 and ans[-1] == ans[-2]:
                writeA = ans[-1] == 'b'
            else:
                writeA = A >= B

            if writeA:
                A -= 1
                ans.append('a')
            else:
                B -= 1
                ans.append('b')

        return "".join(ans)

```

**复杂度分析**

-   时间复杂度：O(A+B)。

-   空间复杂度：O(A+B)。
