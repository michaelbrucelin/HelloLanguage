#### [](https://leetcode.cn/problems/swap-adjacent-in-lr-string/solution/by-ac_oier-ye71//#˫ָ��)˫ָ��

�������⣬����ÿ���ƶ�Ҫô�ǽ� `XL` ��Ϊ `LX`��Ҫô�ǽ� `RX` ��Ϊ `XR`���������߲����ɷֱ����� `L` Խ����� `X` �����ƶ����� `R` Խ����� `X` �����ƶ���

����� `start` �� `end` �������ͬ�� `L` �� `R` ��Ȼ�����������ʣ�

1.  �����ͬ�� `L` : `start` ���±겻С�� `end` ���±꣨�� `L` ���������ƶ���
2.  �����ͬ�� `R` : `start` ���±겻���� `end` ���±꣨�� `R` ���������ƶ���

���С���š���ָ�� `LR` �ַ����г��ֵ����˳��

���룺

```Java
class Solution {
    public boolean canTransform(String start, String end) {
        int n = start.length(), i = 0, j = 0;
        while (i < n || j < n) {
            while (i < n && start.charAt(i) == 'X') i++;
            while (j < n && end.charAt(j) == 'X') j++;
            if (i == n || j == n) return i == j;
            if (start.charAt(i) != end.charAt(j)) return false;
            if (start.charAt(i) == 'L' && i < j) return false;
            if (start.charAt(i) == 'R' && i > j) return false;
            i++; j++;
        }
        return i == j;
    }
}

```

-   ʱ�临�Ӷȣ�O(n)
-   �ռ临�Ӷȣ�O(1)
