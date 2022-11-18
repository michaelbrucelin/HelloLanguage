#### [����˼·](https://leetcode.cn/problems/sum-of-subsequence-widths/solutions/1977772/by-muse-77-f6s5/)

������Ŀ�������ǿ���֪���������ȵ�ʱ��ֻ����Ҫ���������С�`���Ԫ��`���롾`��СԪ��`���Ĳ�ֵ����ô����**ֻ��Ҫ��������nums�����ֵĴ�С������Ҫ���������ڵ�λ��**�ˣ�����������`[2,4]`��������`[4,2]`��ֵ����2��

��ô����Ȼ������Ҫ��ע��������`nums`�е�ÿ��Ԫ��ֵ��С��Ϊ�˷�����㣬�������ȿ��Զ�`nums`�������������

![](./assets/img/Solution0891_4_1.webp)

����֮�����������һ���±�Ϊ`i`��Ԫ�أ������ҵ����¹��ɣ�

![](./assets/img/Solution0891_4_2.webp)

��������`nums[i]`��`���������Ԫ��`ƴװ��ϳɵ�**������**ʾ����

![](./assets/img/Solution0891_4_3.webp)

��ô�������`nums[i]`��˵������`����ܺ�`���ǣ�

> **$(2^i-2^{(nums.length-i-1)}) \times nums[i]$**

��ô���Ǳ�������nums�����е�Ԫ�أ���һ����ÿ��Ԫ�صĿ���ܺͣ���ô���ս�����Ǳ���Ĵ𰸡�

# ����ʵ��

```cpp
class Solution {
    public int sumSubseqWidths(int[] nums) {
        Arrays.sort(nums); // ����
        int mod = (int)1e9 + 7, n = nums.length;
        long result = 0;
        long[] pow = new long[n];
        pow[0] = 1;
        for (int i = 1; i < n; i++) 
            pow[i] = (pow[i - 1] << 1) % mod; // ��ʼ��2^n��ֵ

        for (int i = 0; i < n; i++)
            result = (result + (pow[i] - pow[n-i-1]) * nums[i] % mod) % mod; // �����ܺ�          
        return (int)result;
    }
}
```
