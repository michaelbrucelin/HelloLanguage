#### 排序 + 贡献值 + 数学化简

**核心：** 将数组排序后不改变结果
简单证明将数组排序后不改变结果
1. 两个数组中的元素存在一一对应的关系（废话）
2. 原数组的每一个子序列与排序后的数组的每一个子序列存在一一对应的关系
    - 一一对应的两个子序列中元素一样，但是顺序不一样
3. 一个序列的宽度与序列中的元素有关，但与元素的顺序无关

**代码逻辑**
1. 数组排序
2. 计算数组第 $i$ 项的贡献值（假定数组长度为 $len$）
    - 如果 $nums[i]$ 是序列的最大值
        - 最小值是 $nums[0]$，共 $(nums[i]-nums[0]) \times 2^{i-1}$
        - 最小值是 $nums[1]$，共 $(nums[i]-nums[1]) \times 2^{i-2}$
        - ... ...
        - 最小值是 $nums[i-2]$，共 $(nums[i]-nums[i-2]) \times 2^{1}$
        - 最小值是 $nums[i-1]$，共 $(nums[i]-nums[i-1]) \times 2^{0}$
        - 累加得：$nums[i] \times \sum\limits_{j=0}^{i-1}2^j - \sum\limits_{j=0}^{i-1}nums[j] \times 2^{i-1-j}$
    - 如果 $nums[i]$ 是序列的最小值
        - 最大值是 $nums[len-1]$，共$(nums[len-1]-nums[i]) \times 2^{len-i-2}$
        - 最大值是 $nums[len-2]$，共$(nums[len-2]-nums[i]) \times 2^{len-i-3}$
        - ... ...
        - 最大值是 $nums[i+2]$，共$(nums[i+2]-nums[i]) \times 2^{1}$
        - 最大值是 $nums[i+1]$，共$(nums[i+1]-nums[i]) \times 2^{0}$
        - 累加得：$\sum\limits_{j=i+1}^{len-1}nums[j] \times 2^{j-i-1} - nums[i] \times \sum\limits_{j=0}^{len-i-2}2^j$
    - 将上面的两个累加项加到一起化简得到 $nums[i]$ 的贡献值为：