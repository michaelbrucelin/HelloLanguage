#### [方法二：矩阵快速幂](https://leetcode.cn/problems/domino-and-tromino-tiling/solutions/1962465/duo-mi-nuo-he-tuo-mi-nuo-ping-pu-by-leet-7n0j/)

关于矩阵快速幂的讲解可以参考官方题解「[70\. 爬楼梯](https://leetcode.cn/problems/climbing-stairs/solutions/286022/pa-lou-ti-by-leetcode-solution/)」的方法二，本文不再作详细说明。由方法一可知，平铺到某一列时的所有覆盖状态可以用一个列向量 x 来表示，那么初始时 $x = [0 0 0 1]^T$。一次状态转移等价于在左边乘上矩阵：
$A = \begin{bmatrix} 0&0&0&1 \\ 1&0&1&0 \\ 1&1&0&0 \\ 1&1&1&1 \\ \end{bmatrix}$

那么 n 次状态转移后，所有覆盖状态对应的列向量为 $A^n x$，其中 $A^n$ 可以使用矩阵快速幂来计算。根据 x 的值，可以知道最终所有的覆盖状态对应的列向量为 $A^n$ 的第 3 列，返回该列向量的第 3 个元素即可。

```python
class Solution:
    def numTilings(self, n: int) -> int:
        MOD = 10 ** 9 + 7

        def multiply(a: List[List[int]], b: List[List[int]]) -> List[List[int]]:
            rows, columns, temp = len(a), len(b[0]), len(b)
            c = [[0] * columns for _ in range(rows)]
            for i in range(rows):
                for j in range(columns):
                    for k in range(temp):
                        c[i][j] = (c[i][j] + a[i][k] * b[k][j]) % MOD
            return c

        def matrixPow(mat: List[List[int]], n: int) -> List[List[int]]:
            ret = [
                [1, 0, 0, 0],
                [0, 1, 0, 0],
                [0, 0, 1, 0],
                [0, 0, 0, 1],
            ]
            while n:
                if n & 1:
                    ret = multiply(ret, mat)
                n >>= 1
                mat = multiply(mat, mat)
            return ret

        mat = [
            [0, 0, 0, 1],
            [1, 0, 1, 0],
            [1, 1, 0, 0],
            [1, 1, 1, 1],
        ]
        res = matrixPow(mat, n)
        return res[3][3]
```

```cpp
const long long mod = 1e9 + 7;
class Solution {
public:
    vector<vector<long long>> mulMatrix(const vector<vector<long long>> &m1, const vector<vector<long long>> &m2) {
        int n1 = m1.size(), n2 = m2.size(), n3 = m2[0].size();
        vector<vector<long long>> res(n1, vector<long long>(n3));
        for (int i = 0; i < n1; i++) {
            for (int k = 0; k < n3; k++) {
                for (int j = 0; j < n2; j++) {
                    res[i][k] = (res[i][k] + m1[i][j] * m2[j][k]) % mod;
                }
            }
        }
        return res;
    }

    int numTilings(int n) {
        vector<vector<long long>> mat = {
            {0, 0, 0, 1},
            {1, 0, 1, 0},
            {1, 1, 0, 0},
            {1, 1, 1, 1}
        };
        vector<vector<long long>> matn = {
            {1, 0, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 1, 0},
            {0, 0, 0, 1}
        };
        while (n) {
            if (n & 1) {
                matn = mulMatrix(matn, mat);
            }
            mat = mulMatrix(mat, mat);
            n >>= 1;
        }
        return matn[3][3];
    }
};
```

```java
class Solution {
    static final int MOD = 1000000007;

    public int numTilings(int n) {
        int[][] mat = {
            {0, 0, 0, 1},
            {1, 0, 1, 0},
            {1, 1, 0, 0},
            {1, 1, 1, 1}
        };
        int[][] matn = {
            {1, 0, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 1, 0},
            {0, 0, 0, 1}
        };
        while (n > 0) {
            if ((n & 1) != 0) {
                matn = mulMatrix(matn, mat);
            }
            mat = mulMatrix(mat, mat);
            n >>= 1;
        }
        return matn[3][3];
    }

    public int[][] mulMatrix(int[][] m1, int[][] m2) {
        int n1 = m1.length, n2 = m2.length, n3 = m2[0].length;
        int[][] res = new int[n1][n3];
        for (int i = 0; i < n1; i++) {
            for (int k = 0; k < n3; k++) {
                for (int j = 0; j < n2; j++) {
                    res[i][k] = (int) ((res[i][k] + (long) m1[i][j] * m2[j][k]) % MOD);
                }
            }
        }
        return res;
    }
}
```

```c#
public class Solution {
    const int MOD = 1000000007;

    public int NumTilings(int n) {
        int[][] mat = {
            new int[]{0, 0, 0, 1},
            new int[]{1, 0, 1, 0},
            new int[]{1, 1, 0, 0},
            new int[]{1, 1, 1, 1}
        };
        int[][] matn = {
            new int[]{1, 0, 0, 0},
            new int[]{0, 1, 0, 0},
            new int[]{0, 0, 1, 0},
            new int[]{0, 0, 0, 1}
        };
        while (n > 0) {
            if ((n & 1) != 0) {
                matn = MulMatrix(matn, mat);
            }
            mat = MulMatrix(mat, mat);
            n >>= 1;
        }
        return matn[3][3];
    }

    public int[][] MulMatrix(int[][] m1, int[][] m2) {
        int n1 = m1.Length, n2 = m2.Length, n3 = m2[0].Length;
        int[][] res = new int[n1][];
        for (int i = 0; i < n1; i++) {
            res[i] = new int[n3];
            for (int k = 0; k < n3; k++) {
                for (int j = 0; j < n2; j++) {
                    res[i][k] = (int) ((res[i][k] + (long) m1[i][j] * m2[j][k]) % MOD);
                }
            }
        }
        return res;
    }
}
```

```c
const long long mod = 1e9 + 7;

struct Matrix {
    long long mat[4][4];
};

struct Matrix mulMatrix(const struct Matrix *m1, const struct Matrix *m2) {
    struct Matrix res;
    memset(&res, 0, sizeof(res));
    for (int i = 0; i < 4; i++) {
        for (int k = 0; k < 4; k++) {
            for (int j = 0; j < 4; j++) {
                res.mat[i][k] = (res.mat[i][k] + m1->mat[i][j] * m2->mat[j][k]) % mod;
            }
        }
    }
    return res;
}

int numTilings(int n) {
    long long mat1[4][4] = {
        {0, 0, 0, 1},
        {1, 0, 1, 0},
        {1, 1, 0, 0},
        {1, 1, 1, 1}
    };
    long long mat2[4][4] = {
        {1, 0, 0, 0},
        {0, 1, 0, 0},
        {0, 0, 1, 0},
        {0, 0, 0, 1}
    };
    struct Matrix mat, matn;
    memcpy(mat.mat, mat1, sizeof(mat1));
    memcpy(matn.mat, mat2, sizeof(mat2));
    while (n) {
        if (n & 1) {
            matn = mulMatrix(&matn, &mat);
        }
        mat = mulMatrix(&mat, &mat);
        n >>= 1;
    }
    return matn.mat[3][3];
}
```

```go
const mod int = 1e9 + 7

type matrix [4][4]int

func (a matrix) mul(b matrix) matrix {
    c := matrix{}
    for i, row := range a {
        for j := range b[0] {
            for k, v := range row {
                c[i][j] = (c[i][j] + v*b[k][j]) % mod
            }
        }
    }
    return c
}

func (a matrix) pow(n int) matrix {
    res := matrix{}
    for i := range res {
        res[i][i] = 1
    }
    for ; n > 0; n >>= 1 {
        if n&1 > 0 {
            res = res.mul(a)
        }
        a = a.mul(a)
    }
    return res
}

func numTilings(n int) int {
    m := matrix{
        {0, 0, 0, 1},
        {1, 0, 1, 0},
        {1, 1, 0, 0},
        {1, 1, 1, 1},
    }
    return m.pow(n)[3][3]
}
```

**复杂度分析**

-   时间复杂度：O(log⁡n)，其中 n 是总列数。矩阵快速幂的时间复杂度为 O(log⁡n)。
-   空间复杂度：O(1)。
