#### ��˫ָ�롿ɾ���ظ���-���Ż�˼·

##### [](https://leetcode.cn/problems/remove-duplicates-from-sorted-array/solution/shuang-zhi-zhen-shan-chu-zhong-fu-xiang-dai-you-hu//#����˼·��)����˼·��

**�ⷨ�� ˫ָ��**

����ע������������ģ���ô�ظ���Ԫ��һ�������ڡ�

Ҫ��ɾ���ظ�Ԫ�أ�ʵ���Ͼ��ǽ����ظ���Ԫ���Ƶ��������ࡣ

������ 2 ��ָ�룬һ����ǰ���� `p`��һ���ں���� `q`���㷨�������£�

1.�Ƚ� `p` �� `q` λ�õ�Ԫ���Ƿ���ȡ�

�����ȣ�`q` ���� 1 λ  
�������ȣ��� `q` λ�õ�Ԫ�ظ��Ƶ� `p+1` λ���ϣ�`p` ����һλ��`q` ���� 1 λ  
�ظ��������̣�ֱ�� `q` �������鳤�ȡ�

���� `p + 1`����Ϊ�����鳤�ȡ�

**����ͼ���һ��**

![](./assets/img/Solution0026_3_01.png)

**���룺**

```Java
 public int removeDuplicates(int[] nums) {
    if(nums == null || nums.length == 0) return 0;
    int p = 0;
    int q = 1;
    while(q < nums.length){
        if(nums[p] != nums[q]){
            nums[p + 1] = nums[q];
            p++;
        }
        q++;
    }
    return p + 1;
}
```

**���Ӷȷ�����**

ʱ�临�Ӷȣ�O(n)��
�ռ临�Ӷȣ�O(1)��

**�Ż���**

���Ǵ󲿷���ⶼû������ģ���������һ�¡�

�����������飺

![](./assets/img/Solution0026_3_02.png)

��ʱ������û���ظ�Ԫ�أ���������ķ�����ÿ�αȽ�ʱ `nums[p]` �������� `nums[q]`����˾ͻὫ `q` ָ���Ԫ��ԭ�ظ���һ�飬���������ʵ�ǲ���Ҫ�ġ�

������ǿ������һ��С�жϣ��� `q - p > 1` ʱ���Ž��и��ơ�

**���룺**

```Java
public int removeDuplicates(int[] nums) {
    if(nums == null || nums.length == 0) return 0;
    int p = 0;
    int q = 1;
    while(q < nums.length){
        if(nums[p] != nums[q]){
            if(q - p > 1){
                nums[p + 1] = nums[q];
            }
            p++;
        }
        q++;
    }
    return p + 1;
}
```

**���Ӷȷ�����**

ʱ�临�Ӷȣ�O(n)��
�ռ临�Ӷȣ�O(1)��
