#### ���������еı��ֵ

�ڷ���һ�Ļ����ϣ����ǿ��Կ������� (i,j)����Ϊ����λ�õ�����Ϊ mat\[i\]\[j\]\=1 �Ҹ��к͸����� 1 ��������Ϊ 1���ݴˣ������ j �е�**���ֵ**Ϊ���������� 1 �������е� 1 ������֮�͡�����֤����(i,j) Ϊ����λ�õĳ�Ҫ�����ǣ��� j �еı��ֵǡ��Ϊ 1��

-   ��� (i,j) Ϊ����λ�ã���˵���� j ��ֻ��һ�� 1����һ�� 1 ���ڵĵ� i ��Ҳֻ������һ�� 1����ô���ձ��ֵ�Ķ���ɵã��� j �еı��ֵΪ 1��
-   ����� j �еı��ֵΪ 1����ô˵������ֻ����һ�� 1����֤������� x �� 1��x\>1������� j �еı��ֵһ�� ��x����Ȼֻ����һ�� 1�������ڵ� i �У���ô���ֵҲ�ǵ� i ���е� 1 �������������� i ��Ҳ���ҽ������ 1������ (i,j) Ϊ����λ�á�

��ô�������������λ�õ��������������ֵΪ 1 ���е�������

��һ���أ����ǿ�����ԭʼ����ĵ�һ������Ϊ���Ǳ���еĶ���ռ䣬�Ӷ�ʹ�ռ临�ӶȽ��� O(1)��

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

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�O(m��n)������ m Ϊ���� mat ��������n Ϊ���� mat ��������
-   �ռ临�Ӷȣ�O(1)����������ԭʼ����Ŀռ�����Ϊ���ǵĸ����ռ䣬�������ǽ�ʹ�ó����ռ䡣
