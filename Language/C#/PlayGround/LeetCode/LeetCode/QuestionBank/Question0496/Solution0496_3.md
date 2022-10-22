#### ������������ջ + ��ϣ��

**˼·**

���ǿ�����Ԥ���� nums2��ʹ��ѯ nums1 �е�ÿ��Ԫ���� nums2 �ж�Ӧλ�õ��ұߵĵ�һ�������Ԫ��ֵʱ����Ҫ�ٱ��� nums2�����ǣ����ǽ���Ŀ�ֽ�Ϊ���������⣺

-   �� 1 �������⣺��θ���Ч�ؼ��� nums2 ��ÿ��Ԫ���ұߵĵ�һ�������ֵ��
-   �� 2 �������⣺��δ洢�� 1 ��������Ľ����
    

**�㷨**

���ǿ���ʹ�õ���ջ������� 1 �������⡣������� nums2�����õ���ջ��ά����ǰλ���ұߵĸ����Ԫ���б���ջ�׵�ջ����Ԫ���ǵ����ݼ��ġ�

����أ�ÿ�������ƶ���������һ���µ�λ�� i���ͽ���ǰ����ջ������С�� nums2\[i\] ��Ԫ�ص�������ջ����ǰλ���ұߵĵ�һ�������Ԫ�ؼ�Ϊջ��Ԫ�أ����ջΪ����˵����ǰλ���ұ�û�и����Ԫ�ء�������ǽ�λ�� iii ��Ԫ����ջ��

���Խ��������������⡣

![](./assets/img/Solution0496_3_01.png)
![](./assets/img/Solution0496_3_02.png)
![](./assets/img/Solution0496_3_03.png)
![](./assets/img/Solution0496_3_04.png)
![](./assets/img/Solution0496_3_05.png)
![](./assets/img/Solution0496_3_06.png)
![](./assets/img/Solution0496_3_07.png)
![](./assets/img/Solution0496_3_08.png)
![](./assets/img/Solution0496_3_09.png)
![](./assets/img/Solution0496_3_10.png)
![](./assets/img/Solution0496_3_11.png)
![](./assets/img/Solution0496_3_12.png)
![](./assets/img/Solution0496_3_13.png)

��Ϊ��Ŀ�涨�� nums2 ��û���ظ�Ԫ�صģ��������ǿ���ʹ�ù�ϣ��������� 2 �������⣬��Ԫ��ֵ�����ұߵ�һ�������Ԫ��ֵ�Ķ�Ӧ��ϵ�����ϣ��

**ϸ��**

��Ϊ�������������ֻ��Ҫ�õ� nums2 ��Ԫ�ص�˳�������Ҫ�õ��±꣬����ջ��ֱ�Ӵ洢 nums2 ��Ԫ�ص�ֵ���ɡ�

**����**

```Python
class Solution:
    def nextGreaterElement(self, nums1: List[int], nums2: List[int]) -> List[int]:
        res = {}
        stack = []
        for num in reversed(nums2):
            while stack and num >= stack[-1]:
                stack.pop()
            res[num] = stack[-1] if stack else -1
            stack.append(num)
        return [res[num] for num in nums1]
```

```Java
class Solution {
    public int[] nextGreaterElement(int[] nums1, int[] nums2) {
        Map<Integer, Integer> map = new HashMap<Integer, Integer>();
        Deque<Integer> stack = new ArrayDeque<Integer>();
        for (int i = nums2.length - 1; i >= 0; --i) {
            int num = nums2[i];
            while (!stack.isEmpty() && num >= stack.peek()) {
                stack.pop();
            }
            map.put(num, stack.isEmpty() ? -1 : stack.peek());
            stack.push(num);
        }
        int[] res = new int[nums1.length];
        for (int i = 0; i < nums1.length; ++i) {
            res[i] = map.get(nums1[i]);
        }
        return res;
    }
}
```

```C#
public class Solution {
    public int[] NextGreaterElement(int[] nums1, int[] nums2) {
        Dictionary<int, int> dictionary = new Dictionary<int, int>();
        Stack<int> stack = new Stack<int>();
        for (int i = nums2.Length - 1; i >= 0; --i) {
            int num = nums2[i];
            while (stack.Count > 0 && num >= stack.Peek()) {
                stack.Pop();
            }
            dictionary.Add(num, stack.Count > 0 ? stack.Peek() : -1);
            stack.Push(num);
        }
        int[] res = new int[nums1.Length];
        for (int i = 0; i < nums1.Length; ++i) {
            res[i] = dictionary[nums1[i]];
        }
        return res;
    }
}
```

```C++
class Solution {
public:
    vector<int> nextGreaterElement(vector<int>& nums1, vector<int>& nums2) {
        unordered_map<int,int> hashmap;
        stack<int> st;
        for (int i = nums2.size() - 1; i >= 0; --i) {
            int num = nums2[i];
            while (!st.empty() && num >= st.top()) {
                st.pop();
            }
            hashmap[num] = st.empty() ? -1 : st.top();
            st.push(num);
        }
        vector<int> res(nums1.size());
        for (int i = 0; i < nums1.size(); ++i) {
            res[i] = hashmap[nums1[i]];
        }
        return res;
    }
};
```

```JavaScript
var nextGreaterElement = function(nums1, nums2) {
    const map = new Map();
    const stack = [];
    for (let i = nums2.length - 1; i >= 0; --i) {
        const num = nums2[i];
        while (stack.length && num >= stack[stack.length - 1]) {
            stack.pop();
        }
        map.set(num, stack.length ? stack[stack.length - 1] : -1);
        stack.push(num);
    }
    const res = new Array(nums1.length).fill(0).map((_, i) => map.get(nums1[i]));
    return res;
};
```

```Go
func nextGreaterElement(nums1, nums2 []int) []int {
    mp := map[int]int{}
    stack := []int{}
    for i := len(nums2) - 1; i >= 0; i-- {
        num := nums2[i]
        for len(stack) > 0 && num >= stack[len(stack)-1] {
            stack = stack[:len(stack)-1]
        }
        if len(stack) > 0 {
            mp[num] = stack[len(stack)-1]
        } else {
            mp[num] = -1
        }
        stack = append(stack, num)
    }
    res := make([]int, len(nums1))
    for i, num := range nums1 {
        res[i] = mp[num]
    }
    return res
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�O(m+n)������ m �� nums1 �ĳ��ȣ�n �� nums2 �ĳ��ȡ�������Ҫ���� nums2 �Լ��� nums2 ��ÿ��Ԫ���ұߵĵ�һ�������ֵ����Ҫ���� nums1 �����ɲ�ѯ�����
-   �ռ临�Ӷȣ�O(n)�����ڴ洢��ϣ��
