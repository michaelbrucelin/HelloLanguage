#### [](https://leetcode.cn/problems/remove-element/solution/yi-chu-yuan-su-by-leetcode-solution-svxi//#����һ��˫ָ��)����һ��˫ָ��

**˼·���㷨**

������ĿҪ��ɾ�������е��� val ��Ԫ�أ�����������ĳ���һ��С�ڵ�����������ĳ��ȣ����ǿ��԰����������ֱ��д�����������ϡ�����ʹ��˫ָ�룺��ָ�� right ָ��ǰ��Ҫ�����Ԫ�أ���ָ�� left ָ����һ����Ҫ��ֵ��λ�á�
-   �����ָ��ָ���Ԫ�ز����� val����һ������������һ��Ԫ�أ����Ǿͽ���ָ��ָ���Ԫ�ظ��Ƶ���ָ��λ�ã�Ȼ������ָ��ͬʱ���ƣ�
-   �����ָ��ָ���Ԫ�ص��� val��������������������ʱ��ָ�벻������ָ������һλ��

�������̱��ֲ���������ǣ����� [0,left) �е�Ԫ�ض������� val��������ָ����������������Ժ�left ��ֵ�����������ĳ��ȡ�

�������㷨�������£�����������û��Ԫ�ص��� val��������ָ�������������һ�Ρ�

**����**

```C++
class Solution {
public:
    int removeElement(vector<int>& nums, int val) {
        int n = nums.size();
        int left = 0;
        for (int right = 0; right < n; right++) {
            if (nums[right] != val) {
                nums[left] = nums[right];
                left++;
            }
        }
        return left;
    }
};
```

```Java
class Solution {
    public int removeElement(int[] nums, int val) {
        int n = nums.length;
        int left = 0;
        for (int right = 0; right < n; right++) {
            if (nums[right] != val) {
                nums[left] = nums[right];
                left++;
            }
        }
        return left;
    }
}
```

```JavaScript
var removeElement = function(nums, val) {
    const n = nums.length;
    let left = 0;
    for (let right = 0; right < n; right++) {
        if (nums[right] !== val) {
            nums[left] = nums[right];
            left++;
        }
    }
    return left;
};
```

```Go
func removeElement(nums []int, val int) int {
    left := 0
    for _, v := range nums { // v �� nums[right]
        if v != val {
            nums[left] = v
            left++
        }
    }
    return left
}
```

```C
int removeElement(int* nums, int numsSize, int val) {
    int left = 0;
    for (int right = 0; right < numsSize; right++) {
        if (nums[right] != val) {
            nums[left] = nums[right];
            left++;
        }
    }
    return left;
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�O(n)������ n Ϊ���еĳ��ȡ�����ֻ��Ҫ�����������������Ρ�
-   �ռ临�Ӷȣ�O(1)������ֻ��Ҫ�����Ŀռ䱣�����ɱ�����
    

#### [](https://leetcode.cn/problems/remove-element/solution/yi-chu-yuan-su-by-leetcode-solution-svxi//#��������˫ָ���Ż�)��������˫ָ���Ż�

**˼·**

���Ҫ�Ƴ���Ԫ��ǡ��������Ŀ�ͷ���������� [1,2,3,4,5]���� val Ϊ 1 ʱ��������Ҫ��ÿһ��Ԫ�ض�����һλ��ע�⵽��Ŀ��˵����Ԫ�ص�˳����Ըı䡹��ʵ�������ǿ���ֱ�ӽ����һ��Ԫ�� 5 �ƶ������п�ͷ��ȡ��Ԫ�� 1���õ����� [5,2,3,4]��ͬ��������ĿҪ������Ż��������� val Ԫ�ص���������ʱ�ǳ���Ч��

ʵ�ַ��棬������Ȼʹ��˫ָ�룬����ָ���ʼʱ�ֱ�λ���������β�����м��ƶ����������С�

**�㷨**

�����ָ�� left ָ���Ԫ�ص��� val����ʱ����ָ�� right ָ���Ԫ�ظ��Ƶ���ָ�� left ��λ�ã�Ȼ����ָ�� right ����һλ�������ֵ������Ԫ��ǡ��Ҳ���� val�����Լ�������ָ�� right ָ���Ԫ�ص�ֵ��ֵ��������ָ�� left ָ��ĵ��� val ��Ԫ�ص�λ�ü��������ǣ���ֱ����ָ��ָ���Ԫ�ص�ֵ������ val Ϊֹ��

����ָ�� left ����ָ�� right �غϵ�ʱ������ָ����������������е�Ԫ�ء�

�����ķ�������ָ�����������º�����ֻ����������һ�Ρ��뷽��һ��ͬ���ǣ�**��������������Ҫ������Ԫ�ص��ظ���ֵ����**��

**����**

```C++
class Solution {
public:
    int removeElement(vector<int>& nums, int val) {
        int left = 0, right = nums.size();
        while (left < right) {
            if (nums[left] == val) {
                nums[left] = nums[right - 1];
                right--;
            } else {
                left++;
            }
        }
        return left;
    }
};
```

```Java
class Solution {
    public int removeElement(int[] nums, int val) {
        int left = 0;
        int right = nums.length;
        while (left < right) {
            if (nums[left] == val) {
                nums[left] = nums[right - 1];
                right--;
            } else {
                left++;
            }
        }
        return left;
    }
}
```

```JavaScript
var removeElement = function(nums, val) {
    let left = 0, right = nums.length;
    while (left < right) {
        if (nums[left] === val) {
            nums[left] = nums[right - 1];
            right--;
        } else {
            left++;
        }
    }
    return left;
};
```

```Go
func removeElement(nums []int, val int) int {
    left, right := 0, len(nums)
    for left < right {
        if nums[left] == val {
            nums[left] = nums[right-1]
            right--
        } else {
            left++
        }
    }
    return left
}
```

```C
int removeElement(int* nums, int numsSize, int val) {
    int left = 0, right = numsSize;
    while (left < right) {
        if (nums[left] == val) {
            nums[left] = nums[right - 1];
            right--;
        } else {
            left++;
        }
    }
    return left;
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�O(n)������ n Ϊ���еĳ��ȡ�����ֻ��Ҫ��������������һ�Ρ�
-   �ռ临�Ӷȣ�O(1)������ֻ��Ҫ�����Ŀռ䱣�����ɱ�����
