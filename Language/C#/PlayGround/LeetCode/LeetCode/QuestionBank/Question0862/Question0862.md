#### [862\. ������Ϊ K �����������](https://leetcode.cn/problems/shortest-subarray-with-sum-at-least-k/)

�Ѷȣ�����

����һ���������� `nums` ��һ������ `k` ���ҳ� `nums` �к�����Ϊ `k` �� **��̷ǿ�������** �������ظ�������ĳ��ȡ���������������� **������** ������ `-1` ��

**������** �������� **����** ��һ���֡�

**ʾ�� 1��**

```
���룺nums = [1], k = 1
�����1
```

**ʾ�� 2��**

```
���룺nums = [1,2], k = 4
�����-1
```

**ʾ�� 3��**

```
���룺nums = [2,-1,2], k = 3
�����3
```

**��ʾ��**

-   `1 <= nums.length <= 10<sup>5</sup>`
-   `-10<sup>5</sup> <= nums[i] <= 10<sup>5</sup>`
-   `1 <= k <= 10<sup>9</sup>`