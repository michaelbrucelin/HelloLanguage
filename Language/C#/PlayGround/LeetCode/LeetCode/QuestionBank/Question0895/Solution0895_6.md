#### [���Ƶ��ջ](https://leetcode.cn/problems/maximum-frequency-stack/solutions/1998430/mei-xiang-ming-bai-yi-ge-dong-hua-miao-d-oich/)

����˼·����Ƶ�ʣ����ִ�������ͬ��Ԫ�أ�ѹ�벻ͬ��ջ�С�ÿ�γ�ջʱ����������Ƶ�����Ԫ�ص�ջ��ջ����
ͬʱ��Ϊ��֪��ÿ��Ԫ�ص�Ƶ�ʣ�����Ҫ��һ����ϣ����ʵʱά����

����� PPT ����չʾ��ʾ�� 1 ����β����ġ�
![](./assets/img/Solution0895_6_01.png)
![](./assets/img/Solution0895_6_02.png)
![](./assets/img/Solution0895_6_03.png)
![](./assets/img/Solution0895_6_04.png)
![](./assets/img/Solution0895_6_05.png)
![](./assets/img/Solution0895_6_06.png)
![](./assets/img/Solution0895_6_07.png)
![](./assets/img/Solution0895_6_08.png)
![](./assets/img/Solution0895_6_09.png)
![](./assets/img/Solution0895_6_10.png)
![](./assets/img/Solution0895_6_11.png)

> ע������ʵ��ʱ��Ϊ�˼򵥵�ʵ�֣���Ԫ��Ƶ�ʼ�Ϊ 0 ʱ����û�дӹ�ϣ����ɾ��Ԫ�ء�

#### ����

**��**���Ƿ�����**�м�**��ĳ��ջΪ�յ������

**��**�����ᡣ��Ϊ��ջһ������Ԫ��Ƶ����ߵ�ջ�Ϸ����ģ������涯�������Ҳ�ķǿ�ջ��

**��**������ж����ͬƵ�ʵ����֣���ô��֤��������һ����ӽ�ջ�����Ǹ����֣�

**��**����Ϊ������������Ͼ���**��ԭʼջ��ֳɶ��ջ**��ÿ��ջ���洢����ͬƵ�ʵ����֣������Ƶ��ָ����������ջʱ��Ƶ�ʣ����ұ�����ԭ�е���ջ˳����˵�������һ����ӽ�ջ�����Ǹ����֡�

```py
class FreqStack:
    def __init__(self):
        self.cnt = Counter()
        self.stacks = []  # ÿ��Ԫ�ض���һ��ջ

    def push(self, val: int) -> None:
        if self.cnt[val] == len(self.stacks):  # ���Ԫ�ص�Ƶ���Ѿ���Ŀǰ���ģ������ֳ�����һ��
            self.stacks.append([val])  # ��ô���봴��һ����ջ
        else:
            self.stacks[self.cnt[val]].append(val)  # �����ѹ���Ӧ��ջ
        self.cnt[val] += 1  # ����Ƶ��

    def pop(self) -> int:
        val = self.stacks[-1].pop()  # �������Ҳ�ջ��ջ��
        if len(self.stacks[-1]) == 0:  # ջΪ��
            self.stacks.pop()  # ɾ��
        self.cnt[val] -= 1  # ����Ƶ��
        return val
```

```java
class FreqStack {
    private final Map<Integer, Integer> cnt = new HashMap<>();
    private final List<Deque<Integer>> stacks = new ArrayList<>();

    public void push(int val) {
        int c = cnt.getOrDefault(val, 0);
        if (c == stacks.size()) // ���Ԫ�ص�Ƶ���Ѿ���Ŀǰ���ģ������ֳ�����һ��
            stacks.add(new ArrayDeque<>()); // ��ô���봴��һ����ջ
        stacks.get(c).push(val);
        cnt.put(val, c + 1); // ����Ƶ��
    }

    public int pop() {
        int back = stacks.size() - 1;
        int val = stacks.get(back).pop(); // �������Ҳ�ջ��ջ��
        if (stacks.get(back).isEmpty()) // ջΪ��
            stacks.remove(back); // ɾ��
        cnt.put(val, cnt.get(val) - 1); // ����Ƶ��
        return val;
    }
}
```

```cpp
class FreqStack {
    unordered_map<int, int> cnt;
    vector<stack<int>> stacks;
public:
    void push(int val) {
        if (cnt[val] == stacks.size()) // ���Ԫ�ص�Ƶ���Ѿ���Ŀǰ���ģ������ֳ�����һ��
            stacks.push_back({}); // ��ô���봴��һ����ջ
        stacks[cnt[val]].push(val);
        ++cnt[val]; // ����Ƶ��
    }

    int pop() {
        int val = stacks.back().top(); // �������Ҳ�ջ��ջ��
        stacks.back().pop();
        if (stacks.back().empty()) // ջΪ��
            stacks.pop_back(); // ɾ��
        --cnt[val]; // ����Ƶ��
        return val;
    }
};
```

```go
type FreqStack struct {
    cnt    map[int]int
    stacks [][]int
}

func Constructor() FreqStack {
    return FreqStack{cnt: map[int]int{}}
}

func (f *FreqStack) Push(val int) {
    c := f.cnt[val]
    if c == len(f.stacks) { // ���Ԫ�ص�Ƶ���Ѿ���Ŀǰ���ģ������ֳ�����һ��
        f.stacks = append(f.stacks, []int{val}) // ��ô���봴��һ����ջ
    } else {
        f.stacks[c] = append(f.stacks[c], val) // �����ѹ���Ӧ��ջ
    }
    f.cnt[val]++ // ����Ƶ��
}

func (f *FreqStack) Pop() int {
    back := len(f.stacks) - 1
    st := f.stacks[back]
    bk := len(st) - 1
    val := st[bk] // �������Ҳ�ջ��ջ��
    if bk == 0 { // ջΪ��
        f.stacks = f.stacks[:back] // ɾ��
    } else {
        f.stacks[back] = st[:bk]
    }
    f.cnt[val]-- // ����Ƶ��
    return val
}
```

#### ���Ӷȷ���

-   ʱ�临�Ӷȣ���Ϊ $O(1)$��
-   �ռ临�Ӷȣ�$O(q)$������ $q$ Ϊ $push$ ���õĴ�����
