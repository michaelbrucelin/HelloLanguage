#### [1694\. ���¸�ʽ���绰����](https://leetcode.cn/problems/reformat-phone-number/)

�Ѷȣ���

����һ���ַ�����ʽ�ĵ绰���� `number` ��`number` �����֡��ո� `' '`�������ۺ� `'-'` ��ɡ�

���㰴������ʽ���¸�ʽ���绰���롣

-   ���ȣ�**ɾ��** ���еĿո�����ۺš�
-   ��Σ������������ **ÿ 3 ��һ��** �ֿ飬**ֱ��** ʣ�� 4 ����������֡�ʣ�µ����ֽ��������涨�ٷֿ飺
    -   2 �����֣������� 2 �����ֵĿ顣
    -   3 �����֣������� 3 �����ֵĿ顣
    -   4 �����֣������ֱ� 2 �����ֵĿ顣

��������ۺŽ���Щ������������ע�⣬���¸�ʽ�������� **��Ӧ��** ���ɽ��� 1 �����ֵĿ飬���� **���** ���������� 2 �����ֵĿ顣

���ظ�ʽ����ĵ绰���롣

**ʾ�� 1��**

```
���룺number = "1-23-45 6"
�����"123-456"
���ͣ������� "123456"
���� 1�����г��� 4 �����֣�������ȡ 3 �����ַ�Ϊһ�顣�� 1 ������ "123" ��
���� 2��ʣ�� 3 �����֣������Ƿ��뵥���� 3 �����ֵĿ顣�� 2 ������ "456" ��
������Щ���õ� "123-456" ��
```

**ʾ�� 2��**

```
���룺number = "123 4-567"
�����"123-45-67"
���ͣ������� "1234567".
���� 1�����г��� 4 �����֣�������ȡ 3 �����ַ�Ϊһ�顣�� 1 ������ "123" ��
���� 2��ʣ�� 4 �����֣����Խ����Ƿֳ������� 2 �����ֵĿ顣�� 2 ��ֱ��� "45" �� "67" ��
������Щ���õ� "123-45-67" ��

```

**ʾ�� 3��**

```
���룺number = "123 4-5678"
�����"123-456-78"
���ͣ������� "12345678" ��
���� 1���� 1 ���� "123" ��
���� 2���� 2 ���� "456" ��
���� 3��ʣ�� 2 �����֣������Ƿ��뵥���� 2 �����ֵĿ顣�� 3 ������ "78" ��
������Щ���õ� "123-456-78" ��
```

**ʾ�� 4��**

```
���룺number = "12"
�����"12"

```

**ʾ�� 5��**

```
���룺number = "--17-5 229 35-39475 "
�����"175-229-353-94-75"

```

**��ʾ��**

-   `2 <= number.length <= 100`
-   `number` �����ֺ��ַ� `'-'` �� `' '` ��ɡ�
-   `number` �����ٺ� **2** �����֡�