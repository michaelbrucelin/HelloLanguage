#### [����һ��ģ��](https://leetcode.cn/problems/champagne-tower/solutions/1979893/xiang-bin-ta-by-leetcode-solution-y87c/)

**˼·**

����ģ�⵹���Ĺ��̡����Ƚ����е� poured ������ȫ������ row=0 ����������С��������ʱ���ٽ�����Ĳ���ƽ��������һ������ڵ����������С������� row=0 ����������е�������ֱ���������ⲿ�����������е����ľ�������������һ������ڵ�һ����������������������ġ��������˼·���������ÿһ���ÿһֻ�����е������������� row=query_row �ı��ӵ����������ȡ�� query_glass �������е���������� 1 ����Сֵ���ء�

**����**

```python
class Solution:
    def champagneTower(self, poured: int, query_row: int, query_glass: int) -> float:
        row = [poured]
        for i in range(1, query_row + 1):
            nextRow = [0] * (i + 1)
            for j, volume in enumerate(row):
                if volume > 1:
                    nextRow[j] += (volume - 1) / 2
                    nextRow[j + 1] += (volume - 1) / 2
            row = nextRow
        return min(1, row[query_glass])
```

```java
class Solution {
    public double champagneTower(int poured, int query_row, int query_glass) {
        double[] row = {poured};
        for (int i = 1; i <= query_row; i++) {
            double[] nextRow = new double[i + 1];
            for (int j = 0; j < i; j++) {
                double volume = row[j];
                if (volume > 1) {
                    nextRow[j] += (volume - 1) / 2;
                    nextRow[j + 1] += (volume - 1) / 2;
                }
            }
            row = nextRow;
        }
        return Math.min(1, row[query_glass]);
    }
}
```

```c#
public class Solution {
    public double ChampagneTower(int poured, int query_row, int query_glass) {
        double[] row = {poured};
        for (int i = 1; i <= query_row; i++) {
            double[] nextRow = new double[i + 1];
            for (int j = 0; j < i; j++) {
                double volume = row[j];
                if (volume > 1) {
                    nextRow[j] += (volume - 1) / 2;
                    nextRow[j + 1] += (volume - 1) / 2;
                }
            }
            row = nextRow;
        }
        return Math.Min(1, row[query_glass]);
    }
}
```

```cpp
class Solution {
public:
    double champagneTower(int poured, int query_row, int query_glass) {
        vector<double> row = {(double)poured};
        for (int i = 1; i <= query_row; i++) {
            vector<double> nextRow(i + 1, 0.0);
            for (int j = 0; j < row.size(); j++) {
                double volume = row[j];
                if (volume > 1) {
                    nextRow[j] += (volume - 1) / 2;
                    nextRow[j + 1] += (volume - 1) / 2;
                }
            }
            row = nextRow;
        }            
        return min(1.0, row[query_glass]);
    }
};
```

```c
#define MIN(a, b) ((a) < (b) ? (a) : (b))

double champagneTower(int poured, int query_row, int query_glass) {
    double row[query_row + 2];
    int rowSize = 1;
    row[0] = poured;
    for (int i = 1; i <= query_row; i++) {
        double nextRow[i + 1];
        for (int j = 0; j <= i; j++) {
            nextRow[j] = 0.0;
        }
        for (int j = 0; j < rowSize; j++) {
            double volume = row[j];
            if (volume > 1) {
                nextRow[j] += (volume - 1) / 2;
                nextRow[j + 1] += (volume - 1) / 2;
            }
        }
        memcpy(row, nextRow, sizeof(double) * (i + 1));
        rowSize = i + 1;
    }            
    return MIN(1.0, row[query_glass]);
}
```

```javascript
var champagneTower = function(poured, query_row, query_glass) {
    let row = [poured];
    for (let i = 1; i <= query_row; i++) {
        const nextRow = new Array(i + 1).fill(0);
        for (let j = 0; j < i; j++) {
            const volume = row[j];
            if (volume > 1) {
                nextRow[j] += (volume - 1) / 2;
                nextRow[j + 1] += (volume - 1) / 2;
            }
        }
        row = nextRow;
    }
    return Math.min(1, row[query_glass]);
};
```

```go
func champagneTower(poured, queryRow, queryGlass int) float64 {
    row := []float64{float64(poured)}
    for i := 1; i <= queryRow; i++ {
        nextRow := make([]float64, i+1)
        for j, volume := range row {
            if volume > 1 {
                nextRow[j] += (volume - 1) / 2
                nextRow[j+1] += (volume - 1) / 2
            }
        }
        row = nextRow
    }
    return math.Min(1, row[queryGlass])
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(query\_row^2)$��ʹ�������� for ѭ����
-   �ռ临�Ӷȣ�$O(query\_row)$��ʹ�ù�������ʵ�ֵĿռ临�Ӷ��� $O(query\_row)$��
