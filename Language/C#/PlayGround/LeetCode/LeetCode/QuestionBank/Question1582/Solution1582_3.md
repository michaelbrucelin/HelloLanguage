#### ����һ��ģ��

**˼·���㷨**

��Ŀ������һ����СΪ m��n �ľ��� mat������������е�����Ԫ��Ϊ 1 ���� 0�����ڸ���**����λ��**�Ķ��壺��� mat[i][j]\=1,i��[0,m),j��[0,n))�����ҵ� i �к͵� j �е�����Ԫ�ؾ�Ϊ 0����λ�� (i,j) Ϊ**����λ��**����ô����ö��ÿһ��λ�ã�Ȼ��������λ�õĶ������жϸ�λ���Ƿ�����Ҫ������Ϊ�����е�ÿһ��Ԫ��ֻ��Ϊ 1 ���� 0���������ǿ���Ԥ�����ÿһ�к��еĺ������ٵĵõ�ÿһ�к����е� 1 �ĸ�����

**����**

```Python3
class Solution:
    def numSpecial(self, mat: List[List[int]]) -> int:
        rows_sum = [sum(row) for row in mat]
        cols_sum = [sum(col) for col in zip(*mat)]
        res = 0
        for i, row in enumerate(mat):
            for j, x in enumerate(row):
                if x == 1 and rows_sum[i] == 1 and cols_sum[j] == 1:
                    res += 1
        return res

```

```Java
class Solution {
    public int numSpecial(int[][] mat) {
        int m = mat.length, n = mat[0].length;
        int[] rowsSum = new int[m];
        int[] colsSum = new int[n];
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                rowsSum[i] += mat[i][j];
                colsSum[j] += mat[i][j];
            }
        }
        int res = 0;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (mat[i][j] == 1 && rowsSum[i] == 1 && colsSum[j] == 1) {
                    res++;
                }
            }
        }
        return res;
    }
}

```

```C#
public class Solution {
    public int NumSpecial(int[][] mat) {
        int m = mat.Length, n = mat[0].Length;
        int[] rowsSum = new int[m];
        int[] colsSum = new int[n];
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                rowsSum[i] += mat[i][j];
                colsSum[j] += mat[i][j];
            }
        }
        int res = 0;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (mat[i][j] == 1 && rowsSum[i] == 1 && colsSum[j] == 1) {
                    res++;
                }
            }
        }
        return res;
    }
}

```

```C++
class Solution {
public:
    int numSpecial(vector<vector<int>>& mat) {
        int m = mat.size(), n = mat[0].size();
        vector<int> rowsSum(m);
        vector<int> colsSum(n);
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                rowsSum[i] += mat[i][j];
                colsSum[j] += mat[i][j];
            }
        }
        int res = 0;
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                if (mat[i][j] == 1 && rowsSum[i] == 1 && colsSum[j] == 1) {
                    res++;
                }
            }
        }
        return res;
    }
};

```

```C
int numSpecial(int** mat, int matSize, int* matColSize) {
    int m = matSize, n = matColSize[0];
    int *rowsSum = (int *)malloc(sizeof(int) * m);
    int *colsSum = (int *)malloc(sizeof(int) * n);
    memset(rowsSum, 0, sizeof(int) * m);
    memset(colsSum, 0, sizeof(int) * n);
    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            rowsSum[i] += mat[i][j];
            colsSum[j] += mat[i][j];
        }
    }
    int res = 0;
    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; j++) {
            if (mat[i][j] == 1 && rowsSum[i] == 1 && colsSum[j] == 1) {
                res++;
            }
        }
    }
    free(rowsSum);
    free(colsSum);
    return res;
}

```

```JavaScript
var numSpecial = function(mat) {
    const m = mat.length, n = mat[0].length;
    const rowsSum = new Array(m).fill(0);
    const colsSum = new Array(n).fill(0);
    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            rowsSum[i] += mat[i][j];
            colsSum[j] += mat[i][j];
        }
    }
    let res = 0;
    for (let i = 0; i < m; i++) {
        for (let j = 0; j < n; j++) {
            if (mat[i][j] === 1 && rowsSum[i] === 1 && colsSum[j] === 1) {
                res++;
            }
        }
    }
    return res;
};

```

```Golang
func numSpecial(mat [][]int) (ans int) {
    rowsSum := make([]int, len(mat))
    colsSum := make([]int, len(mat[0]))
    for i, row := range mat {
        for j, x := range row {
            rowsSum[i] += x
            colsSum[j] += x
        }
    }
    for i, row := range mat {
        for j, x := range row {
            if x == 1 && rowsSum[i] == 1 && colsSum[j] == 1 {
                ans++
            }
        }
    }
    return
}

```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�O(m��n)������ m Ϊ���� mat ��������nnn Ϊ���� mat ��������
-   �ռ临�Ӷȣ�O(m+n)����ҪΪԤ����ÿһ�к��еĿռ俪����
