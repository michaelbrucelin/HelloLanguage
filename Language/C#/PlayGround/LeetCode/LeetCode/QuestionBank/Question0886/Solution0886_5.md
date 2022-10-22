#### [](https://leetcode.cn/problems/possible-bipartition/solution/zhua-wa-mou-si-tu-jie-leetcode-by-muse-7-ac1o//#����˼·)����˼·

���ȣ�����һ����ά���飬������¼1��n����֮��Ļ����ϵ��������n = `10`��dislikes = `[[1,2],[3,4],[5,6],[6,7],[8,9],[7,8]]`Ϊ������ô���ǾͿ��Եó����¾���ͼ������ͼ��ʾ��

![](./assets/img/Solution0886_5_1.png)

Ȼ�����Ǵӵ�1�У�row1����ʼ��������������С�**��ɫ**��������ʾ������**�ų�**����ô�����ڶ��������ȱ���������ͼ��ʾ�����Ǳ�����1�е�ʱ�򣬷���2�����ų⣬��ô������ȱ�����2�У����ڵڶ�����û����2�ų�������ˣ��������ǵó����ۣ�����`1��a��`��`2��b��`��

���Ǽ������������У�����2�Ѿ����������b�飬���Ե�2�У�row2����������

���Ǳ�����3�У����ڷ�����4�������ų⣬��ô��ȱ�������4�У�����û������������4�����ų⣬�������ǵó����ۣ�����`3��a��`��`4��b��`��

����4�Ѿ����������b�飬���Ե�4�У�row4�������������Ǳ�������5�У��������±��������

> **row5**����`����6`���������ų⣬��ȱ�����`row6`  
> **row6**����`����7`���������ų⣬��ȱ�����`row7`  
> **row7**����`����8`���������ų⣬��ȱ�����`row8`  
> **row8**����`����9`���������ų⣬��ȱ�����`row9`  
> **row9**����û�����������ų⣬���õó�������ۣ�����`5��a��`��`6��b��`��`7��a��`��`8��b��`��`9��a��`

���ս��۾��ǣ�**a������[1,3,5,7,9]**��**b������[2,4,6,8]**���������������ͼ��

![](./assets/img/Solution0886_5_2.png)

#### [](https://leetcode.cn/problems/possible-bipartition/solution/zhua-wa-mou-si-tu-jie-leetcode-by-muse-7-ac1o//#����ʵ��)����ʵ��

```
class Solution {
    public boolean possibleBipartition(int n, int[][] dislikes) {
        int[][] matrix = new int[n + 1][n + 1];
        for (int[] item : dislikes)
            matrix[item[0]][item[1]] = matrix[item[1]][item[0]] = 1;
        int[] record = new int[n + 1]; // ��¼�������
        for (int i = 1; i <= n ; i++) 
            if (record[i] == 0 && ! dfs(matrix, record, i, 1, n)) return false;
        return true;
    }

    public boolean dfs(int[][] matrix, int[] record, int index, int group, int n) {
        record[index] = group;
        for (int i = 1; i <= n ; i++) {
            if(i == index) continue;
            if (matrix[index][i] == 1 && record[i] == group) return false;
            if (matrix[index][i] == 1 && record[i] == 0 && !dfs(matrix, record, i, group * -1, n)) return false;
        }
        return true;
    }
}
```

```
class Solution {
    public boolean possibleBipartition(int n, int[][] dislikes) {
        List<Integer>[] matrix = new ArrayList[n + 1];
        for (int i = 1; i < matrix.length; i++) matrix[i] = new ArrayList(n + 1);
        for (int[] item : dislikes) {
            matrix[item[0]].add(item[1]);
            matrix[item[1]].add(item[0]);
        }
        int[] record = new int[n + 1]; // ��¼�������
        for (int i = 1; i < matrix.length ; i ++)
            if (record[i] == 0 && !dfs(matrix, record, i, 1)) return false;
        return true;
    }

    private boolean dfs(List<Integer>[] matrix, int[] record, int index, int group) {
        record[index] = group;
        for (int i = 0; i < matrix[index].size() ; i++) {
            int num = matrix[index].get(i);
            if (record[num] == group) return false;
            if (record[num] == 0 && !dfs(matrix, record, num, group * -1)) return false;
        }
        return true;
    }
}
```
