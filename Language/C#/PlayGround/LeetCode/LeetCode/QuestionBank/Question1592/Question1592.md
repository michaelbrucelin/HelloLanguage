#### [1592\. �������е��ʼ�Ŀո�](https://leetcode.cn/problems/rearrange-spaces-between-words/)

�Ѷȣ���

����һ���ַ��� `text` �����ַ��������ɱ��ո��Χ�ĵ�����ɡ�ÿ��������һ�����߶��СдӢ����ĸ��ɣ�������������֮�����ٴ���һ���ո���Ŀ����������֤ `text` **���ٰ���һ������** ��

�����������пո�ʹÿ�����ڵ���֮��Ŀո���Ŀ�� **���** ���������� **���** ����Ŀ�������������ƽ���������пո��� **������Ŀո�������ַ���ĩβ** ����Ҳ��ζ�ŷ��ص��ַ���Ӧ����ԭ `text` �ַ����ĳ�����ȡ�

���� **�������пո����ַ���** ��

**ʾ�� 1��**

```
���룺text = "  this   is  a sentence "
�����"this   is   a   sentence"
���ͣ��ܹ��� 9 ���ո�� 4 �����ʡ����Խ� 9 ���ո�ƽ�����䵽���ڵ���֮�䣬���ڵ��ʼ�ո���Ϊ��9 / (4-1) = 3 ����

```

**ʾ�� 2��**

```
���룺text = " practice   makes   perfect"
�����"practice   makes   perfect "
���ͣ��ܹ��� 7 ���ո�� 3 �����ʡ�7 / (3-1) = 3 ���ո���� 1 ������Ŀո񡣶���Ŀո���Ҫ�����ַ�����ĩβ��

```

**ʾ�� 3��**

```
���룺text = "hello   world"
�����"hello   world"

```

**ʾ�� 4��**

```
���룺text = "  walks  udp package   into  bar a"
�����"walks  udp  package  into  bar  a "

```

**ʾ�� 5��**

```
���룺text = "a"
�����"a"

```

**��ʾ��**

-   `1 <= text.length <= 100`
-   `text` ��СдӢ����ĸ�� `' '` ���
-   `text` �����ٰ���һ������