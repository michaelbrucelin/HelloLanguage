#### 方法三：二分查找

对于每个学生的作业时间 \[startTime\[i\],endTime\[i\]\]，一定满足 startTime\[i\]≤endTime\[i\]。如果第 i 名学生在 queryTime 时正在作业，则一定满足 startTime\[i\]≤queryTime≤endTime\[i\]。设起始时间小于等于 queryTime 的学生集合为 lessStart，设结束时间小于 queryTime 的学生集合为 lessEnd，则根据上述推理可以知道 lessEnd∈lessStart，我们从 lessStart 去除 lessEnd 的子集部分即为符合条件的学生集合。因此我们通过二分查找找到始时间小于等于 queryTime 的学生人数，然后减去结束时间小于 queryTime 的学生人数，最终结果即为符合条件要求。

```Python3
class Solution:
    def busyStudent(self, startTime: List[int], endTime: List[int], queryTime: int) -> int:
        startTime.sort()
        endTime.sort()
        return bisect_right(startTime, queryTime) - bisect_left(endTime, queryTime)

```

```C++
class Solution {
public: 
    int busyStudent(vector<int>& startTime, vector<int>& endTime, int queryTime) {
        sort(startTime.begin(), startTime.end());
        sort(endTime.begin(), endTime.end());
        int lessStart = upper_bound(startTime.begin(), startTime.end(), queryTime) - startTime.begin();
        int lessEnd = lower_bound(endTime.begin(), endTime.end(), queryTime) - endTime.begin();
        return lessStart - lessEnd;
    }
};

```

```Java
class Solution {
    public int busyStudent(int[] startTime, int[] endTime, int queryTime) {
        Arrays.sort(startTime);
        Arrays.sort(endTime);
        int lessStart = upperbound(startTime, 0, startTime.length - 1, queryTime);
        int lessEnd = lowerbound(endTime, 0, endTime.length - 1, queryTime);
        return lessStart - lessEnd;
    }

    public static int upperbound(int[] arr, int l, int r, int target) {
        int ans = r + 1;
        while (l <= r) {
            int mid = l + ((r - l) >> 1);
            if (arr[mid] > target) {
                ans = mid;
                r = mid - 1;
            } else {
                l = mid + 1;
            }
        }
        return ans;
    }

    public static int lowerbound(int[] arr, int l, int r, int target) {
        int ans = r + 1;
        while (l <= r) {
            int mid = l + ((r - l) >> 1);
            if (arr[mid] >= target) {
                ans = mid;
                r = mid - 1;
            } else {
                l = mid + 1;
            }
        }
        return ans;
    }
}

```

```C#
public class Solution {
    public int BusyStudent(int[] startTime, int[] endTime, int queryTime) {
        Array.Sort(startTime);
        Array.Sort(endTime);
        int lessStart = Upperbound(startTime, 0, startTime.Length - 1, queryTime);
        int lessEnd = Lowerbound(endTime, 0, endTime.Length - 1, queryTime);
        return lessStart - lessEnd;
    }

    public static int Upperbound(int[] arr, int l, int r, int target) {
        int ans = r + 1;
        while (l <= r) {
            int mid = l + ((r - l) >> 1);
            if (arr[mid] > target) {
                ans = mid;
                r = mid - 1;
            } else {
                l = mid + 1;
            }
        }
        return ans;
    }

    public static int Lowerbound(int[] arr, int l, int r, int target) {
        int ans = r + 1;
        while (l <= r) {
            int mid = l + ((r - l) >> 1);
            if (arr[mid] >= target) {
                ans = mid;
                r = mid - 1;
            } else {
                l = mid + 1;
            }
        }
        return ans;
    }
}

```

```C
static inline int cmp(const void *pa, const void *pb) {
    return *(int *)pa - *(int *)pb;
}

static int upperbound(const int *arr, int l, int r, int target) {
    int ans = r + 1;
    while (l <= r) {
        int mid = l + ((r - l) >> 1);
        if (arr[mid] > target) {
            ans = mid;
            r = mid - 1;
        } else {
            l = mid + 1;
        }
    }
    return ans;
}

static int lowerbound(const int *arr, int l, int r, int target) {
    int ans = r + 1;
    while (l <= r) {
        int mid = l + ((r - l) >> 1);
        if (arr[mid] >= target) {
            ans = mid;
            r = mid - 1;
        } else {
            l = mid + 1;
        }
    }
    return ans;
}

int busyStudent(int* startTime, int startTimeSize, int* endTime, int endTimeSize, int queryTime){
    qsort(startTime, startTimeSize, sizeof(int), cmp);
    qsort(endTime, endTimeSize, sizeof(int), cmp);
    int lessStart = upperbound(startTime, 0, startTimeSize - 1, queryTime);
    int lessEnd = lowerbound(endTime, 0, endTimeSize - 1, queryTime);
    return lessStart - lessEnd;
}

```

```JavaScript
var busyStudent = function(startTime, endTime, queryTime) {
    startTime.sort((a, b) => a - b);
    endTime.sort((a, b) => a - b);
    const lessStart = upperbound(startTime, 0, startTime.length - 1, queryTime);
    const lessEnd = lowerbound(endTime, 0, endTime.length - 1, queryTime);
    return lessStart - lessEnd;
}

const upperbound = (arr, l, r, target) => {
    let ans = r + 1;
    while (l <= r) {
        const mid = l + ((r - l) >> 1);
        if (arr[mid] > target) {
            ans = mid;
            r = mid - 1;
        } else {
            l = mid + 1;
        }
    }
    return ans;
}

const lowerbound = (arr, l, r, target) => {
    let ans = r + 1;
    while (l <= r) {
        let mid = l + ((r - l) >> 1);
        if (arr[mid] >= target) {
            ans = mid;
            r = mid - 1;
        } else {
            l = mid + 1;
        }
    }
    return ans;
};

```

```Golang
func busyStudent(startTime []int, endTime []int, queryTime int) (ans int) {
    sort.Ints(startTime)
    sort.Ints(endTime)
    return sort.SearchInts(startTime, queryTime+1) - sort.SearchInts(endTime, queryTime)
}

```

**复杂度分析**

-   时间复杂度：O(nlogn)，其中 n 为 数组的长度。排序需要的时间为 O(nlogn)，二分查找的时间复杂度为 O(logn)。
    
-   空间复杂度：O(logn)。排序需要的栈空间为 O(logn)。
