#### [](https://leetcode.cn/problems/maximum-swap//#方法二：贪心)方法二：贪心

设整数 num 从右向左的数字分别为 (d0,d1,d2,⋯ ,dn−1)，则此时我们可以知道: num\=∑i\=0n−1di×10i，假设我们对位于 j,k 位上的数字进行交换，其中满足 0≤j<k<n，则可以知道交换后的值 val 如下:

val\=∑i\=0n−1(di×10i)+(dj−dk)×10k−(dj−dk)×10j
   \=∑i\=0n−1(di×10i)+(dj−dk)×(10k−10j)

根据以上等式我们可以看出，若使得 val 的值最大，应依次满足如下条件：

-   最优的交换一定需要满足 dj\>dk；
-   在满足 dj\>dk 时，应该保证索引 k 越大从而使得数字 val 越大；
-   在同样大小的数字 dk 时，应使得数字 dj 越大从而使得 val 越大；
-   在同样大小的数字 dj 时，应使得索引 j 越小从而使得 val 越大；

通过以上可以观察到右边越大的数字与左边较小的数字进行交换，这样产生的整数才能保证越大。因此我们可以利用贪心法则，尝试将数字中右边较大的数字与左边较小的数字进行交换，这样即可保证得到的整数值最大。具体做法如下：

-   我们将从右向左扫描数字数组，并记录当前已经扫描过的数字的最大值的索引为 maxId 且保证 maxId 越靠近数字的右侧，此时则说明 charArray\[maxId\] 则为当前已经扫描过的最大值。
-   如果检测到当前数字 charArray\[i\]<charArray\[maxId\]，此时则说明索引 i 的右侧的数字最大值为 charArray\[maxId\]，此时我们可以尝试将 charArray\[i\] 与 charArray\[maxId\] 进行交换即可得到一个比 num 更大的值。我们尝试记录当前可以交换的数对 (i,maxId)，根据贪心法则，此时最左边的 i 构成的可交换的数对进行交换后形成的整数值最大。

```Python
class Solution:
    def maximumSwap(self, num: int) -> int:
        s = list(str(num))
        n = len(s)
        maxIdx = n - 1
        idx1 = idx2 = -1
        for i in range(n - 1, -1, -1):
            if s[i] > s[maxIdx]:
                maxIdx = i
            elif s[i] < s[maxIdx]:
                idx1, idx2 = i, maxIdx
        if idx1 < 0:
            return num
        s[idx1], s[idx2] = s[idx2], s[idx1]
        return int(''.join(s))

```

```C++
class Solution {
public:
    int maximumSwap(int num) {
        string charArray = to_string(num);
        int n = charArray.size();
        int maxIdx = n - 1;
        int idx1 = -1, idx2 = -1;
        for (int i = n - 1; i >= 0; i--) {
            if (charArray[i] > charArray[maxIdx]) {
                maxIdx = i;
            } else if (charArray[i] < charArray[maxIdx]) {
                idx1 = i;
                idx2 = maxIdx;
            }
        }
        if (idx1 >= 0) {
            swap(charArray[idx1], charArray[idx2]);
            return stoi(charArray);
        } else {
            return num;
        }
    }
};

```

```Java
class Solution {
    public int maximumSwap(int num) {
        char[] charArray = String.valueOf(num).toCharArray();
        int n = charArray.length;
        int maxIdx = n - 1;
        int idx1 = -1, idx2 = -1;
        for (int i = n - 1; i >= 0; i--) {
            if (charArray[i] > charArray[maxIdx]) {
                maxIdx = i;
            } else if (charArray[i] < charArray[maxIdx]) {
                idx1 = i;
                idx2 = maxIdx;
            }
        }
        if (idx1 >= 0) {
            swap(charArray, idx1, idx2);
            return Integer.parseInt(new String(charArray));
        } else {
            return num;
        }
    }

    public void swap(char[] charArray, int i, int j) {
        char temp = charArray[i];
        charArray[i] = charArray[j];
        charArray[j] = temp;
    }
}

```

```C#
public class Solution {
    public int MaximumSwap(int num) {
        char[] charArray = num.ToString().ToCharArray();
        int n = charArray.Length;
        int maxIdx = n - 1;
        int idx1 = -1, idx2 = -1;
        for (int i = n - 1; i >= 0; i--) {
            if (charArray[i] > charArray[maxIdx]) {
                maxIdx = i;
            } else if (charArray[i] < charArray[maxIdx]) {
                idx1 = i;
                idx2 = maxIdx;
            }
        }
        if (idx1 >= 0) {
            Swap(charArray, idx1, idx2);
            return int.Parse(new string(charArray));
        } else {
            return num;
        }
    }

    public void Swap(char[] charArray, int i, int j) {
        char temp = charArray[i];
        charArray[i] = charArray[j];
        charArray[j] = temp;
    }
}

```

```C
#define MAX_LEN 32

static inline void swap(char* a, char* b) {
    char c = *a;
    *a = *b;
    *b = c;
}

int maximumSwap(int num) {
    char charArray[MAX_LEN];
    sprintf(charArray, "%d", num);
    int n = strlen(charArray);
    char maxIdx = n - 1;
    int idx1 = -1, idx2 = -1;
    for (int i = n - 1; i >= 0; i--) {
        if (charArray[i] > charArray[maxIdx]) {
            maxIdx = i;
        } else if (charArray[i] < charArray[maxIdx]) {
            idx1 = i;
            idx2 = maxIdx;
        }
    }
    if (idx1 >= 0) {
        swap(&charArray[idx1], &charArray[idx2]);
        return atoi(charArray);
    } else {
        return num;
    }
}

```

```JavaScript
var maximumSwap = function(num) {
    const charArray = [...'' + num];
    const n = charArray.length;
    let maxIdx = n - 1;
    let idx1 = -1, idx2 = -1;
    for (let i = n - 1; i >= 0; i--) {
        if (charArray[i] > charArray[maxIdx]) {
            maxIdx = i;
        } else if (charArray[i] < charArray[maxIdx]) {
            idx1 = i;
            idx2 = maxIdx;
        }
    }
    if (idx1 >= 0) {
        swap(charArray, idx1, idx2);
        return parseInt(charArray.join(''));
    } else {
        return num;
    }
}

const swap = (charArray, i, j) => {
    const temp = charArray[i];
    charArray[i] = charArray[j];
    charArray[j] = temp;
};

```

```Go
func maximumSwap(num int) int {
    s := []byte(strconv.Itoa(num))
    n := len(s)
    maxIdx, idx1, idx2 := n-1, -1, -1
    for i := n - 1; i >= 0; i-- {
        if s[i] > s[maxIdx] {
            maxIdx = i
        } else if s[i] < s[maxIdx] {
            idx1, idx2 = i, maxIdx
        }
    }
    if idx1 < 0 {
        return num
    }
    s[idx1], s[idx2] = s[idx2], s[idx1]
    v, _ := strconv.Atoi(string(s))
    return v
}

```

**复杂度分析**

-   时间复杂度：O(log⁡^num^)，其中整数 num 为给定的数字。num 转换为十进制数，有 O(log^⁡num^) 个数字，需要遍历一次所有的数字即可。

-   空间复杂度：O(log^⁡num^)，其中整数 num 为给定的数字。num 转换为十进制数，有 O(log^⁡num^) 个数字，需要保存 num 所有的数字。
