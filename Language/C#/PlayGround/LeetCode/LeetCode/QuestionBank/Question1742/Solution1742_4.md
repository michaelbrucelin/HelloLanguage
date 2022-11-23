#### [����˼·](https://leetcode.cn/problems/maximum-number-of-balls-in-a-box/solutions/1986523/-by-muse-77-ru13/)

##### 1> ģ��

������Ŀ���������ǿ��������뵽�ķ�ʽ���Ǳ����ƽ⣬������`lowLimit`��ʼ����`hightLimit`����������ÿ�����ֵ�ÿһλ��Ȼ������мӺͲ�����**�ܺ;��Ǹ��������ڵĺ��ӱ��**����ô�ñ�ź���С������**��1**���ɡ����������ֶ�������Ϻ��ٱ������к��ӣ��ҳ����ĺ��������������Ϊ���ս�����ء�

������Ŀ�ġ���ʾ�������Ѿ�ָ��`1 <= lowLimit <= highLimit <= 10^5`����ô�����ӱ��Ӧ����С��`99999`�����õ�λ�ã�����`9+9+9+9+9=45`����ô���ǿ��Դ�������Ϊ**46**�����飬����`int[] resultMap = new int[46]`���������±�`index`��ʾ���ӱ�ţ�`resultMap[index]`��ʾ�����е�С��������

##### 2> �ҹ���

���ǿ��Ը������⣬��С��ӱ��Ϊ1��ʼ������ÿ�������У����ǻᷢ�����¹��ɣ�

> **��С��A�ǡ�9����ʱ��**�������ڱ��Ϊ`9`���������ô��һ��С��B��10�����ڵ�λ�ã����Ǳ��Ϊ`1`�����ӡ� **��С��A�ǡ�19����ʱ��**�������ڱ��Ϊ`10`���������ô��һ��С��B��20�����ڵ�λ�ã����Ǳ��Ϊ`2`�����ӡ� **��С��A�ǡ�29����ʱ��**�������ڱ��Ϊ`11`���������ô��һ��С��B��30�����ڵ�λ�ã����Ǳ��Ϊ`3`�����ӡ� ���� **��С��A�ǡ�99����ʱ��**�������ڱ��Ϊ`18`���������ô��һ��С��B��100�����ڵ�λ�ã����Ǳ��Ϊ`1`�����ӡ� ���� **��С��A�ǡ�999����ʱ��**�������ڱ��Ϊ`27`���������ô��һ��С��B��1000�����ڵ�λ�ã����Ǳ��Ϊ`1`�����ӡ� **�Դ����ơ���**

��˴�����������У����ǿ����ҳ����¹��ɣ�����**B���������ӱ�� = A���������ӱ�� - ��9 \* [ĩβ9�ĸ���]��+ 1**

��ô����������ɣ����ǾͿ���**ֻ���ĩβ��9��С��������ⶨλ���㣬������С�����ڵ�λ�ã�ֻ��Ҫ����ǰ��С��λ��+1**���ɡ���ͼ��С��ʾ��ͼ��

![](./assets/img/Solution1742_3.webp)

##### ����ʵ��

##### 1> ģ��

```dart
class Solution {
    public int countBalls(int lowLimit, int highLimit) {
        int result = 0;
        int[] resultMap = new int[46];
        for(int i = lowLimit; i <= highLimit; i++) {
            int num = i, index = 0;
            while(num > 0) {
                index += num % 10;
                num = num / 10;
            }
            resultMap[index] += 1;
        }
        for (int r : resultMap) result = Math.max(result, r);
        return result;
    }
}
```

##### 2> �ҹ���

```dart
class Solution {
    public int countBalls(int lowLimit, int highLimit) {
        int[] resultMap = new int[46];
        int firstIndex = 0, result = 0;
        for (int num = lowLimit; num > 0; num = num / 10) firstIndex += num % 10;
        resultMap[firstIndex] = 1; // ��ʼ����һ������lowLimit���ڱ�ź��ӵ�С������
        for (int i = lowLimit; i < highLimit; i++) {
            for (int prevNum = i; prevNum % 10 == 9; prevNum /= 10) // ����ǰһ������ĩλ�Ƿ�Ϊ9�������¶�λ��һ������λ��
                firstIndex -= 9; // ǰ��9λ
            resultMap[++firstIndex]++;
        }
        for (int rm : resultMap) result = Math.max(result, rm);
        return result;
    }
}
```
