#### [](https://leetcode.cn/problems/distinct-subsequences-ii/solution/bu-tong-by-capital-worker-vga3//#����һ����̬�滮)����һ����̬�滮

��������������`dp[i]`Ϊǰ`i`���ַ�������ɵĲ�ͬ�������У�����

-   `dp[i] = dp[i - 1] + newCount - repeatCount`

����`newCount`Ϊ����`s[i]`�������������и�����`repeatCount`Ϊ�ظ��������и���

��������ֻ��Ҫ����`newCount`��`repeatCount`����

`newCount`��ֵ�ȽϺü��㣬����`dp[i - 1]`��  
![](./assets/img/Solution0940_3.png)
Ȼ�����Ǽ���`repeatCount`�����ǹ۲�������ĵڶ����ַ�`b`�������ظ�������Ϊ`b`��`ab`����������������������һ�����`b`��Ҳ���ǵڢڲ�����ʱ���������������С��������ǿ���ʹ������`preCount`����¼��һ�θ��ַ������ĸ������ø�������`repeatCount`��

����`dp[i]`����`dp[i-1]`�йأ����ǿ��Թ����洢��

������ǰѿմ���ȥ���ɡ�

**��������**

```Java
public int distinctSubseqII(String s) {
    int mod = (int) 1e9 + 7;
    int n = s.length();
    //֮ǰ�����ĸ���
    int[] preCount = new int[26];
    int curAns = 1;
    char[] chs = s.toCharArray();
    for (int i = 0; i < n; i++) {
        //�����ĸ���
        int newCount = curAns;
        //��ǰ���еĸ��� = ֮ǰ�� + ������ - �ظ���
        curAns = ((curAns + newCount) % mod - preCount[chs[i] - 'a'] % mod + mod) % mod;
        //��¼��ǰ�ַ��� ����ֵ
        preCount[chs[i] - 'a'] = newCount;
    }
    //��ȥ�մ�
    return curAns - 1;
}
```
