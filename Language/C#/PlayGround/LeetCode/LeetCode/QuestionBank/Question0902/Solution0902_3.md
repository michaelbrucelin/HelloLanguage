﻿#### [](https://leetcode.cn/problems/numbers-at-most-n-given-digit-set/solution/zui-da-wei-n-de-shu-zi-zu-he-by-leetcode-f3yi//#方法二：数学)方法二：数学

**细节**

我们令 m=∣digits∣，根据题意可知一个合法的数仅包含 digits 中的数字，如果我们把 digits 中数字从小到大映射为 [1,2,⋯ ,m]，此时我们可以很方便的进行计算。例如，当 digits 包含 [1,3,5,7] 时，我们将它映射为 [1,2,3,4]，那么合法的数也从 [1,3,5,7,11,13,15,17,31,⋯ ] 映射为 [1,2,3,4,11,12,13,14,21,⋯ ]。这样映射完成后，对于任何一个映射后的数我们可以用类似进制转换的方式计算出所有小于等于它的合法数的数目，例如 34 就是从小到大第 3×m+4=3×4+4=16 个合法的数，此时小于等于 34 就有 16 个。

根据上述结论，我们可以先求出小于等于 n 的最大合法数 C，随后对它按照进制的方式进行映射，小于等于 C 的合法数的个数即为小于等于 n 的合法数的个数。

**算法**

如果求出了小于等于 n 的最大的合法的数 C，后面的两步（映射，进制转换）的方法就都比较简单，在此我们重点说明求出 C 的方法。

我们从 n 的最高位开始遍历，每次参考 n 中每一位对应的数字，写入当前数位对应的数字。设数字 n 的前 i 位构成的数字为 num[i]，数字 n 的第 i 位对应的数字为 s[i]。设标志位 isLimit 用来标识当前已经写入的 C 与数字 n 的前 i 的关系，如果当前的 C=num[i]，则此时 isLimit=true；如果当前的 C<num[i]，则此时 isLimit=false。我们在遍历 n 的第 i 位时需进行分类讨论：

-   如果 isLimit 为 false，表示当前已经写入的数 C 小于 n 的前 i−1 位构成的数字，则此时我们应当贪心直接在 C 的末尾追加 digits 中最大的数字，此时构成的数字最大且小于等于 n；
-   如果 isLimit 为 true，表示当前已经写入的数 C 等于 n 的前 i−1 位构成的数字，此时需要分类讨论：
    -   如果此时 digits 中存在数字 d 满足 d≤s[i]，此时我们应该直接在 C 的末尾添加满足上述条件下的最大数字 d。如果选中的数字满足 d<s[i]，此时构造的 C 一定满足 C<num[i]，isLimit 应标记为 false。
    -   如果此时 digits 中所有的数字 d 均满足 d>s[i]，则此时我们应该将 C 中已经压入的数字进行缩小，此时我们应该找到第一个可以缩小的数字，我们依次将已经写入的数字弹出找到第一个可以进行缩小的数字。如果可以找到进行缩小的数字，则我们将其缩小为比该数字小的数，接着依次贪心地将所有的数位填充为 digits 中最大的数；如果无法找到进行缩小的数字，则此时我们需要将 C 的位数减少 1 位，接着依次贪心地将所有的数位填充为 digits 中最大的数。此时构造的 C 一定满足 C<num[i]，isLimit 应标记为 false。

下面给出一个更加具体的例子：n=11000,digits\=["1","3","5","7"]。
-   初始化 C=0，当我们遍历第 1 位时，此时 s[1]=1，我们找到满足小于等于 s[1] 的数字 1，此时 C=1；
-   当我们遍历第 2 位时，此时 s[2]=1，我们找到满足小于等于 s[2] 的数字 1，此时 C=11；
-   当我们遍历第 3 位时，此时 s[3]=0，我们无法找到满足小于等于 s[3] 的数字，此时我们需要 C 弹出数字，由于不存在比 1 更小的数字，因此此时 C 只能减少位数，并贪心地压入数字 7，此时 C=77，设标志位 isLimit=false；
-   当我们遍历第 4 位时，由于标志位 isLimit=false，此时贪心地压入数字 7，此时 C=777；
-   当我们遍历第 5 位时，由于标志位 isLimit=false，此时贪心地压入数字 7，此时 C=7777；

因此最终构造满足小于等于 11000 的最大数字为 7777。

```Python
class Solution:
    def atMostNGivenDigitSet(self, digits: List[str], n: int) -> int:
        m = len(digits)
        s = str(n)
        bits = []
        is_limit = True
        for c in s:
            if not is_limit:
                bits.append(m - 1)
                continue
            select_index = -1
            for j, d in enumerate(digits):
                if d > c:
                    break
                select_index = j
            if select_index >= 0:
                bits.append(select_index)
                if digits[select_index] < c:
                    is_limit = False
            else:
                sz = len(bits)
                while bits and bits[-1] == 0:
                    bits.pop()
                if bits:
                    bits[-1] -= 1
                else:
                    sz -= 1
                while len(bits) <= sz:
                    bits.append(m - 1)
                is_limit = False
        ans = 0
        for b in bits:
            ans = ans * m + b + 1
        return ans

```

```C++
class Solution {
public:
    int atMostNGivenDigitSet(vector<string>& digits, int n) {
        string s = to_string(n);
        int m = digits.size(), k = s.size();
        vector<int> bits;
        bool isLimit = true;
        for (int i = 0; i < k; i++) {
            if (!isLimit) {
                bits.emplace_back(m - 1);
            } else {
                int selectIndex = -1;
                for (int j = 0; j < m; j++) {
                    if (digits[j][0] <= s[i]) {
                        selectIndex = j;
                    } else {
                        break;
                    }
                }
                if (selectIndex >= 0) {
                    bits.emplace_back(selectIndex);
                    if (digits[selectIndex][0] < s[i]) {
                        isLimit = false;
                    }
                } else {
                    int len = bits.size();
                    while (!bits.empty() && bits.back() == 0) {
                        bits.pop_back();
                    }
                    if (!bits.empty()) {
                        bits.back() -= 1;
                    } else {
                        len--;
                    }
                    while ((int)bits.size() <= len) {
                        bits.emplace_back(m - 1);
                    }
                    isLimit = false;
                }
            }
        }
        int ans = 0;
        for (int i = 0; i < bits.size(); i++) {
            ans = ans * m + (bits[i] + 1);
        }
        return ans;
    }
};
```

```Java
class Solution {
    public int atMostNGivenDigitSet(String[] digits, int n) {
        String s = Integer.toString(n);
        int m = digits.length, k = s.length();
        List<Integer> bits = new ArrayList<Integer>();
        boolean isLimit = true;
        for (int i = 0; i < k; i++) {
            if (!isLimit) {
                bits.add(m - 1);
            } else {
                int selectIndex = -1;
                for (int j = 0; j < m; j++) {
                    if (digits[j].charAt(0) <= s.charAt(i)) {
                        selectIndex = j;
                    } else {
                        break;
                    }
                }
                if (selectIndex >= 0) {
                    bits.add(selectIndex);
                    if (digits[selectIndex].charAt(0) < s.charAt(i)) {
                        isLimit = false;
                    }
                } else {
                    int len = bits.size();
                    while (!bits.isEmpty() && bits.get(bits.size() - 1) == 0) {
                        bits.remove(bits.size() - 1);
                    }
                    if (!bits.isEmpty()) {
                        bits.set(bits.size() - 1, bits.get(bits.size() - 1) - 1);
                    } else {
                        len--;
                    }
                    while (bits.size() <= len) {
                        bits.add(m - 1);
                    }
                    isLimit = false;
                }
            }
        }
        int ans = 0;
        for (int i = 0; i < bits.size(); i++) {
            ans = ans * m + (bits.get(i) + 1);
        }
        return ans;
    }
}
```

```C#
public class Solution {
    public int AtMostNGivenDigitSet(string[] digits, int n) {
        string s = n.ToString();
        int m = digits.Length, k = s.Length;
        IList<int> bits = new List<int>();
        bool isLimit = true;
        for (int i = 0; i < k; i++) {
            if (!isLimit) {
                bits.Add(m - 1);
            } else {
                int selectIndex = -1;
                for (int j = 0; j < m; j++) {
                    if (digits[j][0] <= s[i]) {
                        selectIndex = j;
                    } else {
                        break;
                    }
                }
                if (selectIndex >= 0) {
                    bits.Add(selectIndex);
                    if (digits[selectIndex][0] < s[i]) {
                        isLimit = false;
                    }
                } else {
                    int len = bits.Count;
                    while (bits.Count > 0 && bits[bits.Count - 1] == 0) {
                        bits.RemoveAt(bits.Count - 1);
                    }
                    if (bits.Count > 0) {
                        bits[bits.Count - 1]--;
                    } else {
                        len--;
                    }
                    while (bits.Count <= len) {
                        bits.Add(m - 1);
                    }
                    isLimit = false;
                }
            }
        }
        int ans = 0;
        for (int i = 0; i < bits.Count; i++) {
            ans = ans * m + (bits[i] + 1);
        }
        return ans;
    }
}
```

```C
#define MAX_STR_LEN 32

int atMostNGivenDigitSet(char ** digits, int digitsSize, int n){
    char s[MAX_STR_LEN];
    sprintf(s, "%d", n);
    int m = digitsSize, k = strlen(s);
    int bits[MAX_STR_LEN], pos = 0;
    bool isLimit = true;
    for (int i = 0; i < k; i++) {
        if (!isLimit) {
            bits[pos++] = m - 1;
        } else {
            int selectIndex = -1;
            for (int j = 0; j < m; j++) {
                if (digits[j][0] <= s[i]) {
                    selectIndex = j;
                } else {
                    break;
                }
            }
            if (selectIndex >= 0) {
                bits[pos++] = selectIndex;
                if (digits[selectIndex][0] < s[i]) {
                    isLimit = false;
                }
            } else {
                int len = pos;
                while (pos > 0 && bits[pos - 1] == 0) {
                    pos--;
                }
                if (pos > 0) {
                    bits[pos - 1] -= 1;
                } else {
                    len--;
                }
                while (pos <= len) {
                    bits[pos++] = m - 1;
                }
                isLimit = false;
            }
        }
    }
    int ans = 0;
    for (int i = 0; i < pos; i++) {
        ans = ans * m + (bits[i] + 1);
    }
    return ans;
}
```

```JavaScript
var atMostNGivenDigitSet = function(digits, n) {
    const s = '' + n;
    const m = digits.length, k = s.length;
    const bits = [];
    let isLimit = true;
    for (let i = 0; i < k; i++) {
        if (!isLimit) {
            bits.push(m - 1);
        } else {
            let selectIndex = -1;
            for (let j = 0; j < m; j++) {
                if (digits[j][0] <= s[i]) {
                    selectIndex = j;
                } else {
                    break;
                }
            }
            if (selectIndex >= 0) {
                bits.push(selectIndex);
                if (digits[selectIndex][0] < s[i]) {
                    isLimit = false;
                }
            } else {
                let len = bits.length;
                while (bits.length !== 0 && bits[bits.length - 1] === 0) {
                    bits.pop();
                }
                if (bits.length !== 0) {
                    const n = bits.length;
                    bits.splice(n - 1, 1, bits[n - 1] - 1);
                } else {
                    len--;
                }
                while (bits.length <= len) {
                    bits.push(m - 1);
                }
                isLimit = false;
            }
        }
    }
    let ans = 0;
    for (let i = 0; i < bits.length; i++) {
        ans = ans * m + (bits[i] + 1);
    }
    return ans;
};
```

```Go
func atMostNGivenDigitSet(digits []string, n int) (ans int) {
    m := len(digits)
    s := strconv.Itoa(n)
    bits := []int{}
    isLimit := true
    for _, c := range s {
        if !isLimit {
            bits = append(bits, m-1)
            continue
        }
        selectIndex := -1
        for j, d := range digits {
            if d[0] > byte(c) {
                break
            }
            selectIndex = j
        }
        if selectIndex >= 0 {
            bits = append(bits, selectIndex)
            if digits[selectIndex][0] < byte(c) {
                isLimit = false
            }
        } else {
            sz := len(bits)
            for len(bits) > 0 && bits[len(bits)-1] == 0 {
                bits = bits[:len(bits)-1]
            }
            if len(bits) > 0 {
                bits[len(bits)-1]--
            } else {
                sz--
            }
            for len(bits) <= sz {
                bits = append(bits, m-1)
            }
            isLimit = false
        }
    }
    for _, b := range bits {
        ans = ans*m + b + 1
    }
    return
}
```

**复杂度分析**

-   时间复杂度：O(log⁡n×k)，其中 n 为给定数字，k 表示给定的数字的种类。需要遍历 n 的所有数位的数字，n 含有的数字个数为 $log_{⁡10}n$，检测每一位时都需要遍历一遍给定的数字，因此总的时间复杂度为 O(log⁡n×k)。
-   空间复杂度：O(log⁡n)，其中 n 为给定数字。需要需要保存每一位上可能数字的组合数目，因此需要的空间复杂度为 O(log⁡n)。
