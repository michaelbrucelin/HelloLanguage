#### [1768\. ����ϲ��ַ���](https://leetcode.cn/problems/merge-strings-alternately/)

�Ѷȣ���

���������ַ��� `word1` �� `word2` ������� `word1` ��ʼ��ͨ�����������ĸ���ϲ��ַ��������һ���ַ�������һ���ַ��������ͽ����������ĸ׷�ӵ��ϲ����ַ�����ĩβ��

���� **�ϲ�����ַ���** ��

**ʾ�� 1��**

```
���룺word1 = "abc", word2 = "pqr"
�����"apbqcr"
���ͣ��ַ����ϲ����������ʾ��
word1��  a   b   c
word2��    p   q   r
�ϲ���  a p b q c r
```

**ʾ�� 2��**

```
���룺word1 = "ab", word2 = "pqrs"
�����"apbqrs"
���ͣ�ע�⣬word2 �� word1 ����"rs" ��Ҫ׷�ӵ��ϲ����ַ�����ĩβ��
word1��  a   b 
word2��    p   q   r   s
�ϲ���  a p b q   r   s
```

**ʾ�� 3��**

```
���룺word1 = "abcd", word2 = "pq"
�����"apbqcd"
���ͣ�ע�⣬word1 �� word2 ����"cd" ��Ҫ׷�ӵ��ϲ����ַ�����ĩβ��
word1��  a   b   c   d
word2��    p   q 
�ϲ���  a p b q c   d
```

**��ʾ��**

-   `1 <= word1.length, word2.length <= 100`
-   `word1` �� `word2` ��СдӢ����ĸ���
