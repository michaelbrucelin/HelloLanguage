#### [ǰ��](https://leetcode.cn/problems/next-permutation/solutions/479151/xia-yi-ge-pai-lie-by-leetcode-solution/)

����Ҫ������ʵ��һ���㷨�����������������������г��ֵ�������һ����������С�

���������� [1,2,3] Ϊ���������а����ֵ�������Ϊ��
[1,2,3]\\ [1,3,2]\\ [2,1,3]\\ [2,3,1]\\ [3,1,2]\\ [3,2,1]

���������� [2,3,1] ����һ�����м�Ϊ [3,1,2]���ر�ģ��������� [3,2,1] ����һ������Ϊ��С������ [1,2,3]��

#### ����һ������ɨ��

**˼·���ⷨ**

ע�⵽��һ���������Ǳȵ�ǰ����Ҫ�󣬳��Ǹ������Ѿ����������С�����ϣ���ҵ�һ�ַ������ܹ��ҵ�һ�����ڵ�ǰ���е������У��ұ��ķ��Ⱦ�����С������أ�
1.  ������Ҫ��һ����ߵġ���С������һ���ұߵġ��ϴ��������������ܹ��õ�ǰ���б�󣬴Ӷ��õ���һ�����С�
2.  ͬʱ����Ҫ���������С�����������ң������ϴ�����������С����������ɺ󣬡��ϴ������ұߵ�����Ҫ���������������С����������ڱ�֤�����д���ԭ�����е�����£�ʹ���ķ��Ⱦ�����С��

������ [4,5,2,6,3,1] Ϊ����
-   �������ҵ��ķ���������һ�ԡ���С�����롸�ϴ����������Ϊ 2 �� 3�����㡸��С�����������ң������ϴ�����������С��
-   ��������ɽ��������б�Ϊ [4,5,3,6,2,1]����ʱ���ǿ������š���С�����ұߵ����У����б�Ϊ [4,5,3,1,2,6]��

����أ����������������㷨�����ڳ���Ϊ n ������ a��
1.  ���ȴӺ���ǰ���ҵ�һ��˳��� (i,i+1)������ a[i] < a[i+1]����������С������Ϊ a[i]����ʱ [i+1,n) ��Ȼ���½����С�
2.  ����ҵ���˳��ԣ���ô������ [i+1,n) �дӺ���ǰ���ҵ�һ��Ԫ�� j ���� a[i] < a[j]���������ϴ�������Ϊ a[j]��
3.  ���� a[i] �� a[j]����ʱ����֤������ [i+1,n) ��Ϊ�������ǿ���ֱ��ʹ��˫ָ�뷴ת���� [i+1,n) ʹ���Ϊ���򣬶�����Ը������������

![](./assets/img/Solution0031_2.gif)

**ע��**

����ڲ��� 1 �Ҳ���˳��ԣ�˵����ǰ�����Ѿ���һ���������У����������У�����ֱ���������� 2 ִ�в��� 3�����ɵõ���С���������С�

�÷���֧�������д����ظ�Ԫ�أ����� C++ �ı�׼�⺯�� [`next_permutation`](https://leetcode.cn/link/?target=https%3A%2F%2Fen.cppreference.com%2Fw%2Fcpp%2Falgorithm%2Fnext_permutation) �б����á�

**����**

```cpp
class Solution {
public:
    void nextPermutation(vector<int>& nums) {
        int i = nums.size() - 2;
        while (i >= 0 && nums[i] >= nums[i + 1]) {
            i--;
        }
        if (i >= 0) {
            int j = nums.size() - 1;
            while (j >= 0 && nums[i] >= nums[j]) {
                j--;
            }
            swap(nums[i], nums[j]);
        }
        reverse(nums.begin() + i + 1, nums.end());
    }
};
```

```java
class Solution {
    public void nextPermutation(int[] nums) {
        int i = nums.length - 2;
        while (i >= 0 && nums[i] >= nums[i + 1]) {
            i--;
        }
        if (i >= 0) {
            int j = nums.length - 1;
            while (j >= 0 && nums[i] >= nums[j]) {
                j--;
            }
            swap(nums, i, j);
        }
        reverse(nums, i + 1);
    }

    public void swap(int[] nums, int i, int j) {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }

    public void reverse(int[] nums, int start) {
        int left = start, right = nums.length - 1;
        while (left < right) {
            swap(nums, left, right);
            left++;
            right--;
        }
    }
}
```

```python
class Solution:
    def nextPermutation(self, nums: List[int]) -> None:
        i = len(nums) - 2
        while i >= 0 and nums[i] >= nums[i + 1]:
            i -= 1
        if i >= 0:
            j = len(nums) - 1
            while j >= 0 and nums[i] >= nums[j]:
                j -= 1
            nums[i], nums[j] = nums[j], nums[i]
        
        left, right = i + 1, len(nums) - 1
        while left < right:
            nums[left], nums[right] = nums[right], nums[left]
            left += 1
            right -= 1
```

```go
func nextPermutation(nums []int) {
    n := len(nums)
    i := n - 2
    for i >= 0 && nums[i] >= nums[i+1] {
        i--
    }
    if i >= 0 {
        j := n - 1
        for j >= 0 && nums[i] >= nums[j] {
            j--
        }
        nums[i], nums[j] = nums[j], nums[i]
    }
    reverse(nums[i+1:])
}

func reverse(a []int) {
    for i, n := 0, len(a); i < n/2; i++ {
        a[i], a[n-1-i] = a[n-1-i], a[i]
    }
}
```

```c
void swap(int *a, int *b) {
    int t = *a;
    *a = *b, *b = t;
}
void reverse(int *nums, int left, int right) {
    while (left < right) {
        swap(nums + left, nums + right);
        left++, right--;
    }
}

void nextPermutation(int *nums, int numsSize) {
    int i = numsSize - 2;
    while (i >= 0 && nums[i] >= nums[i + 1]) {
        i--;
    }
    if (i >= 0) {
        int j = numsSize - 1;
        while (j >= 0 && nums[i] >= nums[j]) {
            j--;
        }
        swap(nums + i, nums + j);
    }
    reverse(nums, i + 1, numsSize - 1);
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�O(N)������ N Ϊ�������еĳ��ȡ���������ֻ��Ҫɨ���������У��Լ�����һ�η�ת������
-   �ռ临�Ӷȣ�O(1)��ֻ��Ҫ�����Ŀռ������ɱ�����
