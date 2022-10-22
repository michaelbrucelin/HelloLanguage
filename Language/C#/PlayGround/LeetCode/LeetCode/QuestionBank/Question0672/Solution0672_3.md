#### [](https://leetcode.cn/problems/bulb-switcher-ii/solution/deng-pao-kai-guan-ii-by-leetcode-solutio-he7o//#����һ�����������ռ�)����һ�����������ռ�

**˼·**

����������κ��Ż�������������Ҫ�� presses �Σ�ÿ���� 4 ��ѡ����ôһ���� 4^presses^ �ְ���ѡ��ÿ��ѡ������ O(n) ʱ�����״̬�������յ�ʱ�临�Ӷ�Ϊ O(n��4^presses^)������˼�������Դ����½ǶȽ��������ռ䡣

���ȣ�����Ҫ���ǰ�ť������˳�򣬶�ֻ��Ҫ����ÿ����ť�����˼��Σ��ڰ�ť��������һ��������£�˳��Ӱ���������״̬������һ���أ�����Ҫ����ÿ����ť���屻���˼��Σ���ֻ��Ҫ���Ǳ����������λ���ż���μ��ɣ�ĳ����ÿ�ఴ���ٰ� 2 �μ��䱶���Σ�Ҳ��Ӱ������״̬��

��Σ��۲�ÿ����ť��Ч�������Է������а�ť���Ը��ݱ�Ż���Ϊ���� 4 �飬����Ϊ 6�����б���� k��0��

-   ���Ϊ 6k+1���ܰ�ť 1,3,4 Ӱ�죻
-   ���Ϊ 6k+2,6k+6���ܰ�ť 1,2 Ӱ�죻
-   ���Ϊ 6k+3,6k+5���ܰ�ť 1,3 Ӱ�죻
-   ���Ϊ 6k+4���ܰ�ť 1,2,4 Ӱ�졣

��ˣ�ֻ��Ҫ�����ĸ����ݣ�����֪�����е�������״̬�ˡ�

��д����ʱ��������һ������Ϊ 4 ���� pressArr ��ʾ 4 ����ť�İ��������һ������ status ��ʾ������������״̬�����������������ֲ�ͬ��״̬���ɡ�

**����**

```Python
class Solution:
    def flipLights(self, n: int, presses: int) -> int:
        seen = set()
        for i in range(2**4):
            pressArr = [(i >> j) & 1 for j in range(4)]
            if sum(pressArr) % 2 == presses % 2 and sum(pressArr) <= presses:
                status = pressArr[0] ^ pressArr[1] ^ pressArr[3]
                if n >= 2:
                    status |= (pressArr[0] ^ pressArr[1]) << 1
                if n >= 3:
                    status |= (pressArr[0] ^ pressArr[2]) << 2
                if n >= 4:
                    status |= (pressArr[0] ^ pressArr[1] ^ pressArr[3]) << 3
                seen.add(status)
        return len(seen)

```

```Java
class Solution {
    public int flipLights(int n, int presses) {
        Set<Integer> seen = new HashSet<Integer>();
        for (int i = 0; i < 1 << 4; i++) {
            int[] pressArr = new int[4];
            for (int j = 0; j < 4; j++) {
                pressArr[j] = (i >> j) & 1;
            }
            int sum = Arrays.stream(pressArr).sum();
            if (sum % 2 == presses % 2 && sum <= presses) {
                int status = pressArr[0] ^ pressArr[1] ^ pressArr[3];
                if (n >= 2) {
                    status |= (pressArr[0] ^ pressArr[1]) << 1;
                }
                if (n >= 3) {
                    status |= (pressArr[0] ^ pressArr[2]) << 2;
                }
                if (n >= 4) {
                    status |= (pressArr[0] ^ pressArr[1] ^ pressArr[3]) << 3;
                }
                seen.add(status);
            }
        }
        return seen.size();
    }
}
```

```C#
public class Solution {
    public int FlipLights(int n, int presses) {
        ISet<int> seen = new HashSet<int>();
        for (int i = 0; i < 1 << 4; i++) {
            int[] pressArr = new int[4];
            for (int j = 0; j < 4; j++) {
                pressArr[j] = (i >> j) & 1;
            }
            int sum = pressArr.Sum();
            if (sum % 2 == presses % 2 && sum <= presses) {
                int status = pressArr[0] ^ pressArr[1] ^ pressArr[3];
                if (n >= 2) {
                    status |= (pressArr[0] ^ pressArr[1]) << 1;
                }
                if (n >= 3) {
                    status |= (pressArr[0] ^ pressArr[2]) << 2;
                }
                if (n >= 4) {
                    status |= (pressArr[0] ^ pressArr[1] ^ pressArr[3]) << 3;
                }
                seen.Add(status);
            }
        }
        return seen.Count;
    }
}
```

```C++
class Solution {
public:
    int flipLights(int n, int presses) {
        unordered_set<int> seen;
        for (int i = 0; i < 1 << 4; i++) {
            vector<int> pressArr(4);
            for (int j = 0; j < 4; j++) {
                pressArr[j] = (i >> j) & 1;
            }
            int sum = accumulate(pressArr.begin(), pressArr.end(), 0);
            if (sum % 2 == presses % 2 && sum <= presses) {
                int status = pressArr[0] ^ pressArr[1] ^ pressArr[3];
                if (n >= 2) {
                    status |= (pressArr[0] ^ pressArr[1]) << 1;
                }
                if (n >= 3) {
                    status |= (pressArr[0] ^ pressArr[2]) << 2;
                }
                if (n >= 4) {
                    status |= (pressArr[0] ^ pressArr[1] ^ pressArr[3]) << 3;
                }
                seen.emplace(status);
            }
        }
        return seen.size();
    }
};
```

```C
typedef struct {
    int key;
    UT_hash_handle hh;
} HashItem; 

HashItem *hashFindItem(HashItem **obj, int key) {
    HashItem *pEntry = NULL;
    HASH_FIND_INT(*obj, &key, pEntry);
    return pEntry;
}

bool hashAddItem(HashItem **obj, int key) {
    if (hashFindItem(obj, key)) {
        return false;
    }
    HashItem *pEntry = (HashItem *)malloc(sizeof(HashItem));
    pEntry->key = key;
    HASH_ADD_INT(*obj, key, pEntry);
    return true;
}

void hashFree(HashItem **obj) {
    HashItem *curr = NULL, *tmp = NULL;
    HASH_ITER(hh, *obj, curr, tmp) {
        HASH_DEL(*obj, curr);  
        free(curr);             
    }
}

int flipLights(int n, int presses){
    HashItem *seen = NULL;
    for (int i = 0; i < 1 << 4; i++) {
        int pressArr[4], sum = 0;
        for (int j = 0; j < 4; j++) {
            pressArr[j] = (i >> j) & 1;
            sum += pressArr[j];
        }
        if (sum % 2 == presses % 2 && sum <= presses) {
            int status = pressArr[0] ^ pressArr[1] ^ pressArr[3];
            if (n >= 2) {
                status |= (pressArr[0] ^ pressArr[1]) << 1;
            }
            if (n >= 3) {
                status |= (pressArr[0] ^ pressArr[2]) << 2;
            }
            if (n >= 4) {
                status |= (pressArr[0] ^ pressArr[1] ^ pressArr[3]) << 3;
            }
            hashAddItem(&seen, status);
        }
    }
    int ret = HASH_COUNT(seen);
    hashFree(&seen);
    return ret;
}
```

```JavaScript
var flipLights = function(n, presses) {
    const seen = new Set();
    for (let i = 0; i < 1 << 4; i++) {
        const pressArr = new Array(4).fill(0);
        for (let j = 0; j < 4; j++) {
            pressArr[j] = (i >> j) & 1;
        }
        const sum = _.sum(pressArr);
        if (sum % 2 === presses % 2 && sum <= presses) {
            let status = pressArr[0] ^ pressArr[1] ^ pressArr[3];
            if (n >= 2) {
                status |= (pressArr[0] ^ pressArr[1]) << 1;
            }
            if (n >= 3) {
                status |= (pressArr[0] ^ pressArr[2]) << 2;
            }
            if (n >= 4) {
                status |= (pressArr[0] ^ pressArr[1] ^ pressArr[3]) << 3;
            }
            seen.add(status);
        }
    }
    return seen.size;
};
```

```Go
func flipLights(n, presses int) int {
    seen := map[int]struct{}{}
    for i := 0; i < 1<<4; i++ {
        pressArr := [4]int{}
        sum := 0
        for j := 0; j < 4; j++ {
            pressArr[j] = i >> j & 1
            sum += pressArr[j]
        }
        if sum%2 == presses%2 && sum <= presses {
            status := pressArr[0] ^ pressArr[1] ^ pressArr[3]
            if n >= 2 {
                status |= (pressArr[0] ^ pressArr[1]) << 1
            }
            if n >= 3 {
                status |= (pressArr[0] ^ pressArr[2]) << 2
            }
            if n >= 4 {
                status |= (pressArr[0] ^ pressArr[1] ^ pressArr[3]) << 3
            }
            seen[status] = struct{}{}
        }
    }
    return len(seen)
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�O(1)��ֻ��Ҫʹ�ó���ʱ�伴����ɼ��㡣
-   �ռ临�Ӷȣ�O(1)��ֻ��Ҫʹ�ó����ռ伴����ɼ��㡣
