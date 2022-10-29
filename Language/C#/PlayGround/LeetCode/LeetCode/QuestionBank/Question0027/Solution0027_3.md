#### [](https://leetcode.cn/problems/remove-element/solution/shua-chuan-lc-shuang-bai-shuang-zhi-zhen-mzt8//#˫ָ��ⷨ)˫ָ��ⷨ

���ⷨ��˼·�� [����⡿26. ɾ�����������е��ظ���](https://leetcode-cn.com/problems/remove-duplicates-from-sorted-array/solution/shua-chuan-lc-jian-ji-shuang-zhi-zhen-ji-2eg8/) �еġ�˫ָ��ⷨ�����ơ�

�������⣬���ǿ��Խ�����ֳɡ�ǰ�����Σ�

-   ǰ�������Ч���֣��洢���ǲ����� `val` ��Ԫ�ء�
-   ��������Ч���֣��洢���ǵ��� `val` ��Ԫ�ء�

���մ𰸷�����Ч���ֵĽ�β�±ꡣ

���룺

```Java
class Solution {
    public int removeElement(int[] nums, int val) {
        int j = nums.length - 1;
        for (int i = 0; i <= j; i++) {
            if (nums[i] == val) {
                swap(nums, i--, j--);
            }
        }
        return j + 1;
    }
    void swap(int[] nums, int i, int j) {
        int tmp = nums[i];
        nums[i] = nums[j];
        nums[j] = tmp;
    }
}
```

```C++
class Solution {
public:
    int removeElement(vector<int>& nums, int val) {
        int j = nums.size() - 1;
        for (int i = 0; i <= j; i++) {
            if (nums[i] == val) {
                swap(nums[i--], nums[j--]);
            }
        }
        return j + 1;
    }
};
```

-   ʱ�临�Ӷȣ�O(n)
-   �ռ临�Ӷȣ�O(1)

___

#### [](https://leetcode.cn/problems/remove-element/solution/shua-chuan-lc-shuang-bai-shuang-zhi-zhen-mzt8//#ͨ�ýⷨ)ͨ�ýⷨ

���ⷨ��˼·�� [����⡿26. ɾ�����������е��ظ���](https://leetcode-cn.com/problems/remove-duplicates-from-sorted-array/solution/shua-chuan-lc-jian-ji-shuang-zhi-zhen-ji-2eg8/) �еġ�ͨ�ýⷨ�����ơ�

���趨���� `idx`��ָ�������λ�á�`idx` ��ʼֵΪ 0

**Ȼ�����Ŀ�ġ�Ҫ��/�����߼���������������������������Ԫ�� `x` ʱ��Ӧ�������־��ߣ�**

-   �����ǰԪ�� `x` ���Ƴ�Ԫ�� `val` ��ͬ����ô������Ԫ�ء�
-   �����ǰԪ�� `x` ���Ƴ�Ԫ�� `val` ��ͬ����ô���ǽ���ŵ��±� `idx` ��λ�ã����� `idx` �������ơ�

���յõ��� `idx` ���Ǵ𰸡�

���룺

```Java
class Solution {
    public int removeElement(int[] nums, int val) {
        int idx = 0;
        for (int x : nums) {
            if (x != val) nums[idx++] = x;
        }
        return idx;
    }
}
```

```C++
class Solution {
public:
    int removeElement(vector<int>& nums, int val) {
        int idx = 0;
        for(auto x : nums)
            if(x != val)nums[idx++] = x;
        return idx;
    }
};
```

-   ʱ�临�Ӷȣ�O(n)
-   �ռ临�Ӷȣ�O(1)

___

#### [](https://leetcode.cn/problems/remove-element/solution/shua-chuan-lc-shuang-bai-shuang-zhi-zhen-mzt8//#��չ)��չ

�����һ�´ӡ���ĿҪ�������������߼���������ͬѧ�����Կ���������Ŀ��

[��ԭ�⣩26. ɾ�����������е��ظ���](https://leetcode-cn.com/problems/remove-duplicates-from-sorted-array/) : [����⣩һ��˫�� :��˫ָ�롹&��ͨ�á��ⷨ](https://leetcode-cn.com/problems/remove-duplicates-from-sorted-array/solution/shua-chuan-lc-jian-ji-shuang-zhi-zhen-ji-2eg8/)
[��ԭ�⣩80. ɾ�����������е��ظ��� II](https://leetcode-cn.com/problems/remove-duplicates-from-sorted-array-ii/) : [����⣩���ڡ�ɾ�����������ظ����ͨ��](https://leetcode-cn.com/problems/remove-duplicates-from-sorted-array-ii/solution/gong-shui-san-xie-guan-yu-shan-chu-you-x-glnq/)

___

#### [](https://leetcode.cn/problems/remove-element/solution/shua-chuan-lc-shuang-bai-shuang-zhi-zhen-mzt8//#�ܽ�)�ܽ�

**�������硸��ͬԪ����ౣ�� `k` λԪ�ء����ߡ��Ƴ��ض�Ԫ�ء������⣬���õ������Ǵ���Ŀ�������ʳ�����������Ŀ������Ҫ������������ġ������߼��������������߼���Ӧ�õ����ǵı�������ÿһ��λ�á�**
