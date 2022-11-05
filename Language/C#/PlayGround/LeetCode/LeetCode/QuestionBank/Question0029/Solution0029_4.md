#### [���ص��뷨��û��λ���㣬û����λ����](https://leetcode.cn/problems/divide-two-integers/solutions/50605/po-su-de-xiang-fa-mei-you-wei-yun-suan-mei-you-yi-/)

**Խ������ֻҪ�Գ�����1��-1�������۾������˰�**  
**����������Ч�ʿ��ٱƽ����**

�ٸ����ӣ�11 ���� 3 �� ����11��3�󣬽��������1�� Ȼ������3����������6������11��3������Ҫ����ô�����������2�ˣ����������6�ٷ�������12��11����12���������ˣ�����þ��øղŵ���С��2Ҳ�����õ�4�ˡ�������֪�����ս���϶���2��4֮�䡣Ҳ����˵2�ټ���ĳ������������Ƕ����أ�����11��ȥ�ղ����һ�εĽ��6��ʣ��5�����Ǽ���5��3�ļ�����Ҳ���ǳ����������ݹ�����ˡ�˵�ú��ң����Ͻ�����ҿ�����ţ�Ȼ���Լ���ֽ�ϻ�һ��������ֱ�ӿ��Ҵ���ͺ�����

```cpp
class Solution {
public:
    int divide(int dividend, int divisor) {
        if(dividend == 0) return 0;
        if(divisor == 1) return dividend;
        if(divisor == -1){
            if(dividend>INT_MIN) return -dividend;// ֻҪ������С���Ǹ�����������ֱ�ӷ����෴���ͺ���
            return INT_MAX;// ����С���Ǹ����Ǿͷ�������������
        }
        long a = dividend;
        long b = divisor;
        int sign = 1; 
        if((a>0&&b<0) || (a<0&&b>0)){
            sign = -1;
        }
        a = a>0?a:-a;
        b = b>0?b:-b;
        long res = div(a,b);
        if(sign>0)return res>INT_MAX?INT_MAX:res;
        return -res;
    }
    int div(long a, long b){  // �ƺ�������ѵ�����������⼸��
        if(a<b) return 0;
        long count = 1;
        long tb = b; // �ں���Ĵ����в�����b
        while((tb+tb)<=a){
            count = count + count; // ��С�ⷭ��
            tb = tb+tb; // ��ǰ���Ե�ֵҲ����
        }
        return count + div(a-tb,b);
    }
};
```
