#### [777\. ��LR�ַ����н��������ַ�](https://leetcode.cn/problems/swap-adjacent-in-lr-string/)

�Ѷȣ��е�

��һ���� `'L'` , `'R'` �� `'X'` �����ַ���ɵ��ַ���������`"RXXLRXRXL"`���н����ƶ�������һ���ƶ�����ָ��һ��`"LX"`�滻һ��`"XL"`��������һ��`"XR"`�滻һ��`"RX"`���ָ�����ʼ�ַ���`start`�ͽ����ַ���`end`�����д���룬���ҽ�������һϵ���ƶ�����ʹ��`start`����ת����`end`ʱ�� ����`True`��

**ʾ�� :**

```
����: start = "RXXLRXRXL", end = "XRLXXRRLX"
���: True
����:
���ǿ���ͨ�����¼�����startת����end:
RXXLRXRXL ->
XRXLRXRXL ->
XRLXRXRXL ->
XRLXXRRXL ->
XRLXXRRLX

```

**��ʾ��**

-   `1 <= len(start) = len(end) <= 10000`��
-   `start`��`end`�е��ַ���������`'L'`, `'R'`��`'X'`��
