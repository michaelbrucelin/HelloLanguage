#### [](https://leetcode.cn/problems/missing-two-lcci/solution/zhuan-zhi-xiao-shi-de-shu-de-san-chong-jie-fa-by-w//#解题思路)解题思路

此处撰写解题思路

#### [](https://leetcode.cn/problems/missing-two-lcci/solution/zhuan-zhi-xiao-shi-de-shu-de-san-chong-jie-fa-by-w//#代码)代码

##### 1. 求和：
    找到缺失的一个数
    \->找到缺失的两个数

```C++
class Solution {
public:
    vector<int> missingTwo(vector<int>& nums) {
        int n = nums.size() + 2;
        long sum = 0;
        for (auto x: nums) sum += x;

        int sumTwo = n * (n + 1) / 2 - sum, limits = sumTwo / 2;
        sum = 0;
        for (auto x: nums)
            if (x <= limits) sum += x; // 两个数不相同那么一个大于，一个小于
        int one = limits * (limits + 1) / 2 - sum;
        return {one, sumTwo - one};
    }
};
```

##### 2. 异或：
    找到缺失的一个数
    \-> 找到缺失的两个数

```C++
class Solution {
public:
    vector<int> missingTwo(vector<int>& nums) {
        int ans = 0, n = nums.size();
        for (int i = 1; i <= n + 2; i ++) ans ^= i;
        for (auto x: nums) ans ^= x;

        int one = 0;
        int diff = ans & -ans; 
        for (int i = 1; i <= n + 2; i ++)
            if (diff & i) one ^= i; // ?
        for (auto x: nums)
            if (diff & x) one ^= x;
        return {one, one ^ ans};
    }
};
```

##### 3. 原地hash
    hash找到原来的位置
    找到缺失的一个数
    \-> 找到缺失的两个数

```C++
class Solution {
public:
    vector<int> missingTwo(vector<int>& nums) {
        for (int i = 0; i < 3; i ++) nums.push_back(-1);

        for (int i = 0; i < nums.size(); i ++)
            while (i != nums[i] && nums[i] != -1)
                swap(nums[i], nums[nums[i]]);
        
        vector<int> ans;
        for (int i = 1; i < nums.size(); i ++) 
            if (nums[i] == -1) ans.push_back(i);
        return ans; 
    }
};
```
