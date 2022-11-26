#### [����һ�����ֲ���](https://leetcode.cn/problems/search-in-rotated-sorted-array/solutions/220083/sou-suo-xuan-zhuan-pai-xu-shu-zu-by-leetcode-solut/)

**˼·���㷨**

�����������飬����ʹ�ö��ֲ��ҵķ�������Ԫ�ء�

����������У����鱾��������ģ�������ת��ֻ��֤������ľֲ�������ģ��⻹�ܽ��ж��ֲ����𣿴��ǿ��Եġ�

���Է��ֵ��ǣ����ǽ�������м�ֿ������������ֵ�ʱ��һ����һ���ֵ�����������ġ���ʾ�����������Ǵ� `6` ���λ�÷ֿ��Ժ��������� `[4, 5, 6]` �� `[7, 0, 1, 2]` �������֣�������� `[4, 5, 6]` ������ֵ�����������ģ�����Ҳ����ˡ�

����ʾ���ǿ����ڳ�����ֲ��ҵ�ʱ��鿴��ǰ `mid` Ϊ�ָ�λ�÷ָ�������������� `[l, mid]` �� `[mid + 1, r]` �ĸ�����������ģ�������������Ǹ�����ȷ�����Ǹ���θı���ֲ��ҵ����½磬��Ϊ�����ܹ�����������ǲ����жϳ� `target` �ڲ���������֣�
-   ��� `[l, mid - 1]` ���������飬�� `target` �Ĵ�С���� `[nums[l],nums[mid])`��������Ӧ�ý�������Χ��С�� `[l, mid - 1]`�������� `[mid + 1, r]` ��Ѱ�ҡ�
-   ��� `[mid, r]` ���������飬�� `target` �Ĵ�С���� `(nums[mid+1],nums[r]]`��������Ӧ�ý�������Χ��С�� `[mid + 1, r]`�������� `[l, mid - 1]` ��Ѱ�ҡ�

![](./assets/img/Solution0033_2.png)

��Ҫע����ǣ����ֵ�д���кܶ��֣��������ж� `target` ��С�����򲿷ֵĹ�ϵ��ʱ����ܻ����ϸ���ϵĲ��

```cpp
class Solution {
public:
    int search(vector<int>& nums, int target) {
        int n = (int)nums.size();
        if (!n) {
            return -1;
        }
        if (n == 1) {
            return nums[0] == target ? 0 : -1;
        }
        int l = 0, r = n - 1;
        while (l <= r) {
            int mid = (l + r) / 2;
            if (nums[mid] == target) return mid;
            if (nums[0] <= nums[mid]) {
                if (nums[0] <= target && target < nums[mid]) {
                    r = mid - 1;
                } else {
                    l = mid + 1;
                }
            } else {
                if (nums[mid] < target && target <= nums[n - 1]) {
                    l = mid + 1;
                } else {
                    r = mid - 1;
                }
            }
        }
        return -1;
    }
};
```

```java
class Solution {
    public int search(int[] nums, int target) {
        int n = nums.length;
        if (n == 0) {
            return -1;
        }
        if (n == 1) {
            return nums[0] == target ? 0 : -1;
        }
        int l = 0, r = n - 1;
        while (l <= r) {
            int mid = (l + r) / 2;
            if (nums[mid] == target) {
                return mid;
            }
            if (nums[0] <= nums[mid]) {
                if (nums[0] <= target && target < nums[mid]) {
                    r = mid - 1;
                } else {
                    l = mid + 1;
                }
            } else {
                if (nums[mid] < target && target <= nums[n - 1]) {
                    l = mid + 1;
                } else {
                    r = mid - 1;
                }
            }
        }
        return -1;
    }
}
```

```python
class Solution:
    def search(self, nums: List[int], target: int) -> int:
        if not nums:
            return -1
        l, r = 0, len(nums) - 1
        while l <= r:
            mid = (l + r) // 2
            if nums[mid] == target:
                return mid
            if nums[0] <= nums[mid]:
                if nums[0] <= target < nums[mid]:
                    r = mid - 1
                else:
                    l = mid + 1
            else:
                if nums[mid] < target <= nums[len(nums) - 1]:
                    l = mid + 1
                else:
                    r = mid - 1
        return -1
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ� $O(\log n)$������ n Ϊ nums ����Ĵ�С�������㷨ʱ�临�Ӷȼ�Ϊ���ֲ��ҵ�ʱ�临�Ӷ� $O(\log n)$��
-   �ռ临�Ӷȣ� O(1) ������ֻ��Ҫ��������Ŀռ��ű�����
