#### [934\. ��̵���](https://leetcode.cn/problems/shortest-bridge/)

�Ѷ�:�е�

����һ����СΪ `n x n` �Ķ�Ԫ���� `grid` ������ `1` ��ʾ½�أ�`0` ��ʾˮ��

**��** �������������� `1` �γɵ�һ������飬������������ڵ��κ����� `1` ������`grid` �� **ǡ�ô���������** ��

����Խ����������� `0` ��Ϊ `1` ����ʹ������������������� **һ����** ��

���ر��뷭ת�� `0` ����С��Ŀ��

**ʾ�� 1��**

```
���룺grid = [[0,1],[1,0]]
�����1
```

**ʾ�� 2��**

```
���룺grid = [[0,1,0],[0,0,0],[0,0,1]]
�����2
```

**ʾ�� 3��**

```
���룺grid = [[1,1,1,1,1],[1,0,0,0,1],[1,0,1,0,1],[1,0,0,0,1],[1,1,1,1,1]]
�����1
```

**��ʾ��**

-   `n == grid.length == grid[i].length`
-   `2 <= n <= 100`
-   `grid[i][j]` Ϊ `0` �� `1`
-   `grid` ��ǡ��������