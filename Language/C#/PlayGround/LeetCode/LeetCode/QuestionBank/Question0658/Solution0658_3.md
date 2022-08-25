#### 方法二：二分查找 + 双指针

假设数组长度为 n，注意到数组 arr 已经按照升序排序，我们可以将数组 arr 分成两部分，前一部分所有元素 \[0,left\] 都小于 x，后一部分所有元素 \[right,n−1\] 都大于等于 x，left 与 right 都可以通过二分查找获得。

left 和 right 指向的元素都是各自部分最接近 x 的元素，因此我们可以通过比较 left 和 right 指向的元素获取整体最接近 x 的元素。如果 x−arr\[left\]≤arr\[right\]−x，那么将 left 减一，否则将 right 加一。相应地，如果 left 或 right 已经越界，那么不考虑对应部分的元素。

最后，区间 \[left+1,right−1\] 的元素就是我们所要获得的结果，返回答案既可。

```Python3
class Solution:
    def findClosestElements(self, arr: List[int], k: int, x: int) -> List[int]:
        right = bisect_left(arr, x)
        left = right - 1
        for _ in range(k):
            if left < 0:
                right += 1
            elif right >= len(arr) or x - arr[left] <= arr[right] - x:
                left -= 1
            else:
                right += 1
        return arr[left + 1: right]

```

```C++
class Solution {
public:
    vector<int> findClosestElements(vector<int>& arr, int k, int x) {
        int right = lower_bound(arr.begin(), arr.end(), x) - arr.begin();
        int left = right - 1;
        while (k--) {
            if (left < 0) {
                right++;
            } else if (right >= arr.size()) {
                left--;
            } else if (x - arr[left] <= arr[right] - x) {
                left--;
            } else {
                right++;
            }
        }
        return vector<int>(arr.begin() + left + 1, arr.begin() + right);
    }
};

```

```Java
class Solution {
    public List<Integer> findClosestElements(int[] arr, int k, int x) {
        int right = binarySearch(arr, x);
        int left = right - 1;
        while (k-- > 0) {
            if (left < 0) {
                right++;
            } else if (right >= arr.length) {
                left--;
            } else if (x - arr[left] <= arr[right] - x) {
                left--;
            } else {
                right++;
            }
        }
        List<Integer> ans = new ArrayList<Integer>();
        for (int i = left + 1; i < right; i++) {
            ans.add(arr[i]);
        }
        return ans;
    }

    public int binarySearch(int[] arr, int x) {
        int low = 0, high = arr.length - 1;
        while (low < high) {
            int mid = low + (high - low) / 2;
            if (arr[mid] >= x) {
                high = mid;
            } else {
                low = mid + 1;
            }
        }
        return low;
    }
}

```

```C#
public class Solution {
    public IList<int> FindClosestElements(int[] arr, int k, int x) {
        int right = BinarySearch(arr, x);
        int left = right - 1;
        while (k-- > 0) {
            if (left < 0) {
                right++;
            } else if (right >= arr.Length) {
                left--;
            } else if (x - arr[left] <= arr[right] - x) {
                left--;
            } else {
                right++;
            }
        }
        IList<int> ans = new List<int>();
        for (int i = left + 1; i < right; i++) {
            ans.Add(arr[i]);
        }
        return ans;
    }

    public int BinarySearch(int[] arr, int x) {
        int low = 0, high = arr.Length - 1;
        while (low < high) {
            int mid = low + (high - low) / 2;
            if (arr[mid] >= x) {
                high = mid;
            } else {
                low = mid + 1;
            }
        }
        return low;
    }
}

```

```C
int binarySearch(const int* arr, int arrSize, int x) {
    int low = 0, high = arrSize - 1;
    while (low < high) {
        int mid = low + (high - low) / 2;
        if (arr[mid] >= x) {
            high = mid;
        } else {
            low = mid + 1;
        }
    }
    return low;
}

int* findClosestElements(int* arr, int arrSize, int k, int x, int* returnSize) {
    int right = binarySearch(arr, arrSize, x);
    int left = right - 1;
    while (k--) {
        if (left < 0) {
            right++;
        } else if (right >= arrSize) {
            left--;
        } else if (x - arr[left] <= arr[right] - x) {
            left--;
        } else {
            right++;
        }
    }
    int *res = (int *)malloc(sizeof(int) * (right - left - 1));
    memcpy(res, arr + left + 1, sizeof(int) * (right - left - 1));
    *returnSize = right - left - 1;
    return res;
}

```

```JavaScript
var findClosestElements = function(arr, k, x) {
    let right = binarySearch(arr, x);
    let left = right - 1;
    while (k-- > 0) {
        if (left < 0) {
            right++;
        } else if (right >= arr.length) {
            left--;
        } else if (x - arr[left] <= arr[right] - x) {
            left--;
        } else {
            right++;
        }
    }
    const ans = [];
    for (let i = left + 1; i < right; i++) {
        ans.push(arr[i]);
    }
    return ans;
}

const binarySearch = (arr, x) => {
    let low = 0, high = arr.length - 1;
    while (low < high) {
        const mid = low + Math.floor((high - low) / 2);
        if (arr[mid] >= x) {
            high = mid;
        } else {
            low = mid + 1;
        }
    }
    return low;
}

```

```Golang
func findClosestElements(arr []int, k, x int) []int {
    right := sort.SearchInts(arr, x)
    left := right - 1
    for ; k > 0; k-- {
        if left < 0 {
            right++
        } else if right >= len(arr) || x-arr[left] <= arr[right]-x {
            left--
        } else {
            right++
        }
    }
    return arr[left+1 : right]
}

```

**复杂度分析**

-   时间复杂度：O(logn+k)，其中 n 是数组 arr 的长度。二分查找需要 O(logn)，双指针查找需要 O(k)。
    
-   空间复杂度：O(1)。返回值不计入空间复杂度。
