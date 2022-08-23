## �������

���ݷ�Χ����һ�����Ի��ԣ����䲢����һ�������������⡣

������Ҫ���Ǻ���������޽⣬�Լ��н��������С������

�ڸ������̴�С nnn ��ǰ���£����ܹ���ĺϷ�����ֻ�����������**�׸�����Ϊ 0 ���׸�����Ϊ 1**��������ת��Ϊ�ܷ�����Ϸ����̣��Լ��������ֺϷ��������ò�����С��

ͬʱ��**�����кͽ����о�����Ӱ���е������������е���������**��������ǿ��Եõ���һ���ж��޽������������ʼ���̵���/����������Ϊ 2����Ȼ�޷�������Ϸ����̡�

������ʼ���зֱ�Ϊ `r1` �� `r2`����ʼ���зֱ�Ϊ `c1` �� `c2`�����ѷ��ֵڶ����ʣ�**���ܹ��ɺϷ����̣�`r1` �� `r2` �� 0 �� 1 ��������Ȼ��ȣ�`c1` �� `c2` �е� 0 �� 1 ��������Ȼ���**��

ͬʱ���ڽ����кͽ����о��жԳ��ԺͶ����ԣ����ǿ�����ʹ�á������С������з����������в��ᵼ�������෢���仯�����ᵼ���е���ֵ�ֲ������仯��

��˵ڶ����ʿ���չΪ��**`r1` �� `r2` �Գ�λ��Ϊ��Ȼ��ͬ��`c1` �� `c2` �Գ�λ�ñ�Ȼ��ͬ�������������Ϊ��ȻΪ (111...111)_2_����Ϊ `mask = (1 << n) - 1`�������Ȼ�޽⡣**

���������������㣬�����н⡣

���� `r1` �� `r2` �� `c1` �� `c2` �Գ�λ�ñ�Ȼ��ͬ��������ǵ����� `r1` ��`r2` Ψһȷ����`c1` �� `c2` ͬ����ͬʱ��������һ�ּ����Ϊ `t` = (...101)_2_�����ݺϷ����̶����֪Ҫô�ǽ����е���Ϊ ttt��Ҫô�ǽ����е���Ϊ ttt��

�������ú��� `int getCnt(int a, int b)` ���㽫 `a` ��Ϊ `b` ����Ҫ����Сת����������״̬ת���������Ϊ��ͬλ�������� 2��һ�ν�����ʵ������������ͬλ����

�ֱ���㡸�� `r1` �� `r2` ת��Ϊ `t` ���貽�����͡��� `c1` �� `c2` ת��Ϊ `t` ���貽����������֮�ͼ�Ϊ�𰸡�

���룺

```Java
class Solution {
    int n = 0, INF = 0x3f3f3f3f;
    int getCnt(int a, int b) {
        return Integer.bitCount(a) != Integer.bitCount(b) ? INF : Integer.bitCount(a ^ b) / 2;
    }
    public int movesToChessboard(int[][] g) {
        n = g.length;
        int r1 = -1, r2 = -1, c1 = -1, c2 = -1, mask = (1 << n) - 1;
        for (int i = 0; i < n; i++) {
            int a = 0, b = 0;
            for (int j = 0; j < n; j++) {
                if (g[i][j] == 1) a += (1 << j);
                if (g[j][i] == 1) b += (1 << j);
            }
            if (r1 == -1) r1 = a;
            else if (r2 == -1 && a != r1) r2 = a;
            if (c1 == -1) c1 = b;
            else if (c2 == -1 && b != c1) c2 = b;
            if (a != r1 && a != r2) return -1;
            if (b != c1 && b != c2) return -1;
        }
        if (Integer.bitCount(r1) + Integer.bitCount(r2) != n) return -1;
        if (Integer.bitCount(c1) + Integer.bitCount(c2) != n) return -1;
        if ((r1 ^ r2) != mask || (c1 ^ c2) != mask) return -1;
        int t = 0;
        for (int i = 0; i < n; i += 2) t += (1 << i);
        int ans = Math.min(getCnt(r1, t), getCnt(r2, t)) + Math.min(getCnt(c1, t), getCnt(c2, t));
        return ans >= INF ? -1 : ans;
    }
}

```

```TypeScript
let n: number = 0, INF = 0x3f3f3f3f
function bitCount(x: number): number {
    let ans = 0
    while (x != 0 && ++ans >= 0) x -= (x & -x)
    return ans
}
function getCnt(a: number, b: number): number {
    return bitCount(a) != bitCount(b) ? INF : bitCount(a ^ b) / 2
}
function movesToChessboard(g: number[][]): number {
    n = g.length
    let r1 = -1, r2 = -1, c1 = -1, c2 = -1, mask = (1 << n) - 1
    for (let i = 0; i < n; i++) {
        let a = 0, b = 0
        for (let j = 0; j < n; j++) {
            if (g[i][j] == 1) a += (1 << j)
            if (g[j][i] == 1) b += (1 << j)
        }
        if (r1 == -1) r1 = a
        else if (r2 == -1 && a != r1) r2 = a
        if (c1 == -1) c1 = b
        else if (c2 == -1 && b != c1) c2 = b
        if (a != r1 && a != r2) return -1
        if (b != c1 && b != c2) return -1
    }
    if (bitCount(r1) + bitCount(r2) != n) return -1
    if (bitCount(c1) + bitCount(c2) != n) return -1
    if ((r1 ^ r2) != mask || (c1 ^ c2) != mask) return -1
    let t = 0
    for (let i = 0; i < n; i += 2) t += (1 << i)
    const ans = Math.min(getCnt(r1, t), getCnt(r2, t)) + Math.min(getCnt(c1, t), getCnt(c2, t))
    return ans >= INF ? -1 : ans
};

```

-   ʱ�临�Ӷȣ�O(n^2^)
-   �ռ临�Ӷȣ�O(1)
