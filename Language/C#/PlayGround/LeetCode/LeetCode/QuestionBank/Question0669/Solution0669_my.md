# Solution0669

```text
              8
      4                 12
  2       6       10          14
1   3   5   7   9    11    13    15
```

下面分析上面的二叉查找树：

输入：low = 5, high = 11
输出：
```text
      8
  6       10
5   7   9    11
```

输入：low = 5, high = 13
输出：
```text
              8
      6                 12
  5       7       10          13
                9    11
```

输入：low = 3, high = 5
输出：
```text
  4
3   5
```

分析上面的输入与输出，可以得出下面的思路：
- 先找low
    - 如果low小于当前节点，继续向下（左节点）查找
    - 如果low等于当前节点，停止查找，并移除左节点
    - 如果low大于当前节点，移除当前节点，用右节点顶替当前节点
    - 直至找到叶子节点
- 再找high
    - 如果high大于当前节点，继续向下（右节点）查找
    - 如果high等于当前节点，停止查找，并移除右节点
    - 如果high小于当前节点，移除当前节点，用左节点顶替当前节点
    - 直至找到叶子节点