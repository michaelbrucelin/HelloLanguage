#### [����˼·](https://leetcode.cn/problems/maximum-frequency-stack/solutions/1998468/-by-muse-77-bzg6/)

������Ŀ������������Ҫ����������⣺

> ��**����1**����α���ĳ��**����**��**���ִ���**����������**Map<Integer, Integer> map**ά�� ��**����2**����α���**��ͬ���ִ���**����£����**���ּ���**�ġ�`��ջ`���͡�`��ջ`��˳�򣿡�������**LinkedList[] st**ά��

������`ʾ��1`Ϊ��������һ�¶���**�������**������δ���ģ�

![](./assets/img/Solution0895_4_01.png)

> �����͡�
> -   **freqStack.push(5)**�� ��`map`��{key=5, value=1}�� ��`st`��{key=1, value=[5]}��
> -   **freqStack.push(7)**�� ��`map`��{key=5, value=1},{key=7, value=1}�� ��`st`��{key=1, value=[5, 7]}��
> -   **freqStack.push(5)**�� ��`map`��{key=5, value=2},{key=7, value=1}�� ��`st`��{key=1, value=[5, 7]}, {key=2��value=[5]}��
> -   **freqStack.push(7)**�� ��`map`��{key=5, value=2},{key=7, value=2}�� ��`st`��{key=1, value=[5, 7]}, {key=2��value=[5, 7]}��
> -   **freqStack.push(4)**�� ��`map`��{key=5, value=2},{key=7, value=2},{key=4, value=1}�� ��`st`��{key=1, value=[5, 7, 4]}, {key=2��value=[5, 7]}��
> -   **freqStack.push(5)** �� ��`map`��{key=5, value=3},{key=7, value=2},{key=4, value=1}�� ��`st`��{key=1, value=[5, 7, 4]}, {key=2��value=[5, 7]}, {key=3��value=[5]}��

���ǻ�����`ʾ��1`Ϊ��������һ�¶���**��ջ����**������δ���ģ�

![](./assets/img/Solution0895_4_02.png)

> �����͡�
> -   ���ڵ�ǰ�����ִ���**max����3**�����ԣ����ǿ���ͨ��`st[3]`������ּ���Ϊ��`[5]`��
> -   **��5��ջ**֮�����ּ��ϱ�Ϊ`[]`��
> -   �������ּ���Ϊ�գ�����**max��1����2**�����ҽ�`map`��`����5`�ĳ��ִ���**��1**������`3-1=2`��

�����ٴ�ִ��**��ջ����**��������һ������δ���ģ�

![](./assets/img/Solution0895_4_03.png)

> �����͡�
> -   ���ڵ�ǰ�����ִ���**max����2**�����ԣ����ǿ���ͨ��`st[2]`������ּ���Ϊ��`[5��7]`��
> -   **��7��ջ**֮�����ּ��ϱ�Ϊ`[5]`��
> -   �������ּ��ϲ�Ϊ�գ�����**max��Ȼ����2**��Ȼ��`map`��`����7`�ĳ��ִ���**��1**������`2-1=1`��

�����ĳ�ջ�������Դ����ƣ��˴��Ͳ���׸���ˡ�

#### ����ʵ��

```java
class FreqStack {
    Map<Integer, Integer> map = new HashMap(); // key������N  value������N���ֵĴ���
    LinkedList<Integer>[] st = new LinkedList[2 * (int) 1e4]; // key������M�� value������M�ε����ּ���
    int max = 0; // ��ǰ�����ִ���

    public FreqStack() {}

    public void push(int val) {
        int times = map.getOrDefault(val, 0) + 1; // ����val�ĳ��ִ���+1
        map.put(val, times);
        if (st[times] == null) st[times] = new LinkedList();
        st[times].add(val); // ������val�ŵ���timesΪkey��value������
        max = Math.max(max, times); // ���Ը��������ִ���
    }

    public int pop() {
        int result = -1; // ����ջ����
        while (max > 0) {
            if (st[max].size() == 0) max--; // ���max������Ӧ�����ּ��϶��Ѿ���ջ�ˣ���max��1
            else {
                result = st[max].removeLast(); // �Ƴ�����times�ε����ּ����С�ĩβ��������result
                break;
            }
        }
        map.put(result, map.getOrDefault(result, 0) - 1); // ������result�ĳ��ִ���-1
        return result;
    }
}
```
