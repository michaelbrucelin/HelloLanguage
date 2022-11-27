#### 方法二：差分数组

利用差分数组的思想，对差分数组求前缀和，可以得到统计出 t 时刻正在做作业的人数。我们初始化差分数组 cnt 每个元素都为 0，在每个学生的起始时间处 cnt[startTime[i]] 加 1，在每个学生的结束时间处 cnt[endTime[i]+1] 减 1，因此我们可以统计出 queryTime 时刻正在做作业的人数为 ∑j\=0queryTimecnt[j]。

```Python3
class Solution:
    def busyStudent(self, startTime: List[int], endTime: List[int], queryTime: int) -> int:
        maxEndTime = max(endTime)
        if queryTime > maxEndTime:
            return 0
        cnt = [0] * (maxEndTime + 2)
        for s, e in zip(startTime, endTime):
            cnt[s] += 1
            cnt[e + 1] -= 1
        return sum(cnt[:queryTime + 1])

```

```C++
class Solution {
public:
    int busyStudent(vector<int>& startTime, vector<int>& endTime, int queryTime) {
        int n = startTime.size();
        int maxEndTime = *max_element(endTime.begin(), endTime.end());
        if (queryTime > maxEndTime) {
            return 0;
        }
        vector<int> cnt(maxEndTime + 2);
        for (int i = 0; i < n; i++) {
            cnt[startTime[i]]++;
            cnt[endTime[i] + 1]--;
        }
        int ans = 0;
        for (int i = 0; i <= queryTime; i++) {
            ans += cnt[i];
        }
        return ans;
    }
};

```

```Java
class Solution {
    public int busyStudent(int[] startTime, int[] endTime, int queryTime) {
        int n = startTime.length;
        int maxEndTime = Arrays.stream(endTime).max().getAsInt();
        if (queryTime > maxEndTime) {
            return 0;
        }
        int[] cnt = new int[maxEndTime + 2];
        for (int i = 0; i < n; i++) {
            cnt[startTime[i]]++;
            cnt[endTime[i] + 1]--;
        }
        int ans = 0;
        for (int i = 0; i <= queryTime; i++) {
            ans += cnt[i];
        }
        return ans;
    }
}

```

```C#
public class Solution {
    public int BusyStudent(int[] startTime, int[] endTime, int queryTime) {
        int n = startTime.Length;
        int maxEndTime = endTime.Max();
        if (queryTime > maxEndTime) {
            return 0;
        }
        int[] cnt = new int[maxEndTime + 2];
        for (int i = 0; i < n; i++) {
            cnt[startTime[i]]++;
            cnt[endTime[i] + 1]--;
        }
        int ans = 0;
        for (int i = 0; i <= queryTime; i++) {
            ans += cnt[i];
        }
        return ans;
    }
}

```

```C
#define MAX(a, b) ((a) > (b) ? (a) : (b))

int busyStudent(int* startTime, int startTimeSize, int* endTime, int endTimeSize, int queryTime){
    int maxEndTime = 0;
    for (int i = 0; i < endTimeSize; i++) {
        maxEndTime = MAX(maxEndTime, endTime[i]);
    }
    if (queryTime > maxEndTime) {
        return 0;
    }
    int *cnt = (int *)malloc(sizeof(int) * (maxEndTime + 2));
    memset(cnt, 0, sizeof(maxEndTime) * (maxEndTime + 2));
    for (int i = 0; i < startTimeSize; i++) {
        cnt[startTime[i]]++;
        cnt[endTime[i] + 1]--;
    }
    int ans = 0;
    for (int i = 0; i <= queryTime; i++) {
        ans += cnt[i];
    }
    free(cnt);
    return ans;
}

```

```JavaScript
var busyStudent = function(startTime, endTime, queryTime) {
    const n = startTime.length;
    const maxEndTime = _.max(endTime);
    if (queryTime > maxEndTime) {
        return 0;
    }
    const cnt = new Array(maxEndTime + 2).fill(0);
    for (let i = 0; i < n; i++) {
        cnt[startTime[i]]++;
        cnt[endTime[i] + 1]--;
    }
    let ans = 0;
    for (let i = 0; i <= queryTime; i++) {
        ans += cnt[i];
    }
    return ans;
};

```

```Golang
func busyStudent(startTime []int, endTime []int, queryTime int) (ans int) {
    maxEndTime := 0
    for _, e := range endTime {
        maxEndTime = max(maxEndTime, e)
    }
    if queryTime > maxEndTime {
        return
    }
    cnt := make([]int, maxEndTime+2)
    for i, s := range startTime {
        cnt[s]++
        cnt[endTime[i]+1]--
    }
    for _, c := range cnt[:queryTime+1] {
        ans += c
    }
    return
}

func max(a, b int) int {
    if b > a {
        return b
    }
    return a
}

```

**复杂度分析**

-   时间复杂度：O(n+queryTime)，其中 n 为数组的长度，queryTime 为给定的查找时间。首先需要遍历一遍数组，需要的时间为 O(n)，然后需要查分求和求出 queryTime 时间点正在作业的学生总数，需要的时间为 O(queryTime)，因此总的时间为 O(n+queryTime)。
    
-   空间复杂度：O(max⁡(endTime))。
