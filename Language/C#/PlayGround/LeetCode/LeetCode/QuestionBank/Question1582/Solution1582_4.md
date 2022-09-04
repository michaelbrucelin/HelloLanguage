#### 方法二：列的标记值

在方法一的基础上，我们可以看到对于 (i,j)，它为特殊位置的条件为 mat\[i\]\[j\]\=1 且该行和该列中 1 的数量都为 1。据此，定义第 j 列的**标记值**为：该列所有 1 所在行中的 1 的数量之和。下面证明，(i,j) 为特殊位置的充要条件是，第 j 列的标记值恰好为 1：

-   如果 (i,j) 为特殊位置，则说明第 j 列只有一个 1，这一个 1 所在的第 i 行也只有它这一个 1，那么按照标记值的定义可得，第 j 列的标记值为 1。
-   如果第 j 列的标记值为 1，那么说明该列只能有一个 1。反证：如果有 x 个 1（x\>1），则第 j 列的标记值一定 ≥x。既然只能有一个 1，设其在第 i 行，那么标记值也是第 i 行中的 1 的数量，即：第 i 行也有且仅有这个 1。所以 (i,j) 为特殊位置。

那么整个矩阵的特殊位置的数量就是最后标记值为 1 的列的数量。

进一步地，我们可以用原始矩阵的第一行来作为我们标记列的额外空间，从而使空间复杂度降至 O(1)。

```Python3
class Solution:
    def numSpecial(self, mat: List[List[int]]) -> int:
        for i, row in enumerate(mat):
            cnt1 = sum(row) - (i == 0)
            if cnt1:
                for j, x in enumerate(row):
                    if x == 1:
                        mat[0][j] += cnt1
        return sum(x == 1 for x in mat[0])

```

```Java
class Solution {
    public int numSpecial(int[][] mat) {
        int m = mat.length, n = mat[0].length;
        for (int i = 0; i < m; i++) {
            int cnt1 = 0;
            for (int j = 0; j < n; j++) {
                if (mat[i][j] == 1) {
                    cnt1++;
                }
            }
            if (i == 0) {
                cnt1--;
            }
            if (cnt1 > 0) {
                for (int j = 0; j < n; j++) {
                    if (mat[i][j] == 1) {
                        mat[0][j] += cnt1;
                    }
                }
            }
        }
        int sum = 0;
        for (int num : mat[0]) {
            if (num == 1) {
                sum++;
            }
        }
        return sum;
    }
}

```

```C#
public class Solution {
    public int NumSpecial(int[][] mat) {
        int m = mat.Length, n = mat[0].Length;
        for (int i = 0; i < m; i++) {
            int cnt1 = 0;
            for (int j = 0; j < n; j++) {
                if (mat[i][j] == 1) {
                    cnt1++;
                }
            }
            if (i == 0) {
                cnt1--;
            }
            if (cnt1 > 0) {
                for (int j = 0; j < n; j++) {
                    if (mat[i][j] == 1) {
                        mat[0][j] += cnt1;
                    }
                }
            }
        }
        int sum = 0;
        foreach (int num in mat[0]) {
            if (num == 1) {
                sum++;
            }
        }
        return sum;
    }
}

```

```C++
class Solution {
public:
    int numSpecial(vector<vector<int>>& mat) {
        int m = mat.size(), n = mat[0].size();
        for (int i = 0; i < m; i++) {
            int cnt1 = 0;
            for (int j = 0; j < n; j++) {
                if (mat[i][j] == 1) {
                    cnt1++;
                }
            }
            if (i == 0) {
                cnt1--;
            }
            if (cnt1 > 0) {
                for (int j = 0; j < n; j++) {
                    if (mat[i][j] == 1) {
                        mat[0][j] += cnt1;
                    }
                }
            }
        }
        int sum = 0;
        for (int i = 0; i < n; i++) {
            if (mat[0][i] == 1) {
                sum++;
            }
        }
        return sum;
    }
};

```

```C
int numSpecial(int** mat, int matSize, int* matColSize) {
    int m = matSize, n = matColSize[0];
    for (int i = 0; i < m; i++) {
        int cnt1 = 0;
        for (int j = 0; j < n; j++) {
            if (mat[i][j] == 1) {
                cnt1++;
            }
        }
        if (i == 0) {
            cnt1--;
        }
        if (cnt1 > 0) {
            for (int j = 0; j < n; j++) {
                if (mat[i][j] == 1) {
                    mat[0][j] += cnt1;
                }
            }
        }
    }
    int sum = 0;
    for (int i = 0; i < n; i++) {
        if (mat[0][i] == 1) {
            sum++;
        }
    }
    return sum;
}

```

```JavaScript
var numSpecial = function(mat) {
    const m = mat.length, n = mat[0].length;
    for (let i = 0; i < m; i++) {
        let cnt1 = 0;
        for (let j = 0; j < n; j++) {
            if (mat[i][j] === 1) {
                cnt1++;
            }
        }
        if (i === 0) {
            cnt1--;
        }
        if (cnt1 > 0) {
            for (let j = 0; j < n; j++) {
                if (mat[i][j] === 1) {
                    mat[0][j] += cnt1;
                }
            }
        }
    }
    let sum = 0;
    for (const num of mat[0]) {
        if (num === 1) {
            sum++;
        }
    }
    return sum;
};

```

```Golang
func numSpecial(mat [][]int) (ans int) {
    for i, row := range mat {
        cnt1 := 0
        for _, x := range row {
            cnt1 += x
        }
        if i == 0 {
            cnt1--
        }
        if cnt1 > 0 {
            for j, x := range row {
                if x == 1 {
                    mat[0][j] += cnt1
                }
            }
        }
    }
    for _, x := range mat[0] {
        if x == 1 {
            ans++
        }
    }
    return
}

```

**复杂度分析**

-   时间复杂度：O(m×n)，其中 m 为矩阵 mat 的行数，n 为矩阵 mat 的列数。
-   空间复杂度：O(1)，由于用了原始矩阵的空间来作为我们的辅助空间，所以我们仅使用常量空间。
