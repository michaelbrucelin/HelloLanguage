#### [595\. ��Ĺ���](https://leetcode.cn/problems/big-countries/)

SQL�ܹ�

`World` ����

```
+-------------+---------+
| Column Name | Type    |
+-------------+---------+
| name        | varchar |
| continent   | varchar |
| area        | int     |
| population  | int     |
| gdp         | int     |
+-------------+---------+
name �����ű���������
���ű���ÿһ���ṩ���������ơ�������½��������˿ں� GDP ֵ��

```

���һ����������������������֮һ������Ϊ�ù��� **���** ��

-   �������Ϊ 300 ��ƽ���������`3000000 km^2`��������
-   �˿�����Ϊ 2500 �򣨼� `25000000`��

��дһ�� SQL ��ѯ�Ա��� **���** �Ĺ������ơ��˿ں������

�� **����˳��** ���ؽ������

��ѯ�����ʽ��������ʾ��

**ʾ����**

```
���룺
World ����
+-------------+-----------+---------+------------+--------------+
| name        | continent | area    | population | gdp          |
+-------------+-----------+---------+------------+--------------+
| Afghanistan | Asia      | 652230  | 25500100   | 20343000000  |
| Albania     | Europe    | 28748   | 2831741    | 12960000000  |
| Algeria     | Africa    | 2381741 | 37100000   | 188681000000 |
| Andorra     | Europe    | 468     | 78115      | 3712000000   |
| Angola      | Africa    | 1246700 | 20609294   | 100990000000 |
+-------------+-----------+---------+------------+--------------+
�����
+-------------+------------+---------+
| name        | population | area    |
+-------------+------------+---------+
| Afghanistan | 25500100   | 652230  |
| Algeria     | 37100000   | 2381741 |
+-------------+------------+---------+

```