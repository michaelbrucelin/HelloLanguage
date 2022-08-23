#### ����һ����ϣ��

���ڸ���������һ��������Ч�Ľ⣬��˶������� groupSizes �е�ÿ��Ԫ�� x���� x �������г��� y ��ʱ��y һ���ܱ� x �������Ҵ�СΪ x ������ yx\\dfrac{y}{x}xy ����

���Ƚ�ÿ���˵ı�Ű�����Ĵ�С���֣�ʹ�ù�ϣ���¼ÿ����Ĵ�С��Ӧ�������˵ı�š�Ȼ�������ϣ�����ڴ�СΪ x ���飬�õ���Ӧ�������˱���б����б�Ĵ�С��Ϊ y���� y һ���ܱ� xxx ���������б�ֳ� yx\\dfrac{y}{x}xy ����СΪ xxx ���飬����ÿ������ӵ����С���������֮�󣬼���ɷ��顣

����ʾ�� 1 �ķ��顣

1.  �������� groupSizes �õ�ÿ����Ĵ�С��Ӧ�������˵ı�ţ���СΪ 1 �����Ӧ�ı���б��� \[5\]����СΪ 3 �����Ӧ�ı���б��� \[0,1,2,3,4,6\]��
    
2.  ��ÿ����Ĵ�С��Ӧ�ı���б�ֳ��ض���С���б�
    
    -   ��СΪ 1 �����Ӧ�ı���б�ĳ����� 1������� 1 ����СΪ 1 ���飺\[5\]��
        
    -   ��СΪ 3 �����Ӧ�ı���б�ĳ����� 6������� 2 ����СΪ 3 ���飺\[0,1,2\],\[3,4,6\]��
        
3.  ���շ�������� \[\[5\],\[0,1,2\],\[3,4,6\]��
    

```Python3
class Solution:
    def groupThePeople(self, groupSizes: List[int]) -> List[List[int]]:
        groups = defaultdict(list)
        for i, size in enumerate(groupSizes):
            groups[size].append(i)
        ans = []
        for size, people in groups.items():
            ans.extend(people[i: i + size] for i in range(0, len(people), size))
        return ans

```

```Java
class Solution {
    public List<List<Integer>> groupThePeople(int[] groupSizes) {
        Map<Integer, List<Integer>> groups = new HashMap<Integer, List<Integer>>();
        int n = groupSizes.length;
        for (int i = 0; i < n; i++) {
            int size = groupSizes[i];
            groups.putIfAbsent(size, new ArrayList<Integer>());
            groups.get(size).add(i);
        }
        List<List<Integer>> groupList = new ArrayList<List<Integer>>();
        for (Map.Entry<Integer, List<Integer>> entry : groups.entrySet()) {
            int size = entry.getKey();
            List<Integer> people = entry.getValue();
            int groupCount = people.size() / size;
            for (int i = 0; i < groupCount; i++) {
                List<Integer> group = new ArrayList<Integer>();
                int start = i * size;
                for (int j = 0; j < size; j++) {
                    group.add(people.get(start + j));
                }
                groupList.add(group);
            }
        }
        return groupList;
    }
}

```

```C#
public class Solution {
    public IList<IList<int>> GroupThePeople(int[] groupSizes) {
        Dictionary<int, IList<int>> groups = new Dictionary<int, IList<int>>();
        int n = groupSizes.Length;
        for (int i = 0; i < n; i++) {
            int size = groupSizes[i];
            groups.TryAdd(size, new List<int>());
            groups[size].Add(i);
        }
        IList<IList<int>> groupList = new List<IList<int>>();
        foreach (KeyValuePair<int, IList<int>> pair in groups) {
            int size = pair.Key;
            IList<int> people = pair.Value;
            int groupCount = people.Count / size;
            for (int i = 0; i < groupCount; i++) {
                IList<int> group = new List<int>();
                int start = i * size;
                for (int j = 0; j < size; j++) {
                    group.Add(people[start + j]);
                }
                groupList.Add(group);
            }
        }
        return groupList;
    }
}

```

```C++
class Solution {
public:
    vector<vector<int>> groupThePeople(vector<int>& groupSizes) {
        unordered_map<int, vector<int>> groups;
        int n = groupSizes.size();
        for (int i = 0; i < n; i++) {
            int size = groupSizes[i];
            groups[size].emplace_back(i);
        }
        vector<vector<int>> groupList;
        for (auto &[size, people] : groups) {
            int groupCount = people.size() / size;
            for (int i = 0; i < groupCount; i++) {
                vector<int> group;
                int start = i * size;
                for (int j = 0; j < size; j++) {
                    group.emplace_back(people[start + j]);
                }
                groupList.emplace_back(group);
            }
        }
        return groupList;
    }
};

```

```C
typedef struct Array {
    int *arr;
    int pos;
    int size;
} Array;

Array* creatArray(int size) {
    Array *obj = (Array *)malloc(sizeof(Array));
    obj->arr = (int *)malloc(sizeof(int) * size);
    obj->size = size;
    obj->pos = 0;
    return obj;
}

void freeArray(Array *obj) {
    free(obj->arr);
    free(obj);
}

int** groupThePeople(int* groupSizes, int groupSizesSize, int* returnSize, int** returnColumnSizes){
    Array **groups = (Array **)malloc(sizeof(Array *) * (groupSizesSize + 1));
    for (int i = 0; i <= groupSizesSize; i++) {
        groups[i] = creatArray(groupSizesSize);
    }
    for (int i = 0; i < groupSizesSize; i++) {
        int size = groupSizes[i];
        groups[size]->arr[groups[size]->pos++] = i;
    }
    int **groupList = (int **)malloc(sizeof(int *) * groupSizesSize);
    *returnColumnSizes = (int *)malloc(sizeof(int) * groupSizesSize);
    int pos = 0;
    for (int k = 0; k <= groupSizesSize; k++) {
        if (groups[k]->pos == 0) {
            continue;
        }
        int size = k;
        int groupCount = groups[k]->pos / size;
        for (int i = 0; i < groupCount; i++) {
            int *group = (int *)malloc(sizeof(int) * size);
            int start = i * size, index = 0;
            for (int j = 0; j < size; j++) {
                group[index++] = groups[k]->arr[start + j];
            }
            (*returnColumnSizes)[pos] = size;
            groupList[pos++] = group;
        }
    }
    *returnSize = pos;
    for (int i = 0; i <= groupSizesSize; i++) {
        freeArray(groups[i]);
    }
    return groupList;
}

```

```JavaScript
var groupThePeople = function(groupSizes) {
    const groups = new Map();
    const n = groupSizes.length;
    for (let i = 0; i < n; i++) {
        const size = groupSizes[i];
        if (!groups.has(size)) {
            groups.set(size, []);
        }
        groups.get(size).push(i);
    }
    const groupList = [];
    for (const [size, people] of groups.entries()) {
        const groupCount = Math.floor(people.length / size);
        for (let i = 0; i < groupCount; i++) {
            const group = [];
            const start = i * size;
            for (let j = 0; j < size; j++) {
                group.push(people[start + j]);
            }
            groupList.push(group);
        }
    }
    return groupList;
};

```

```Golang
func groupThePeople(groupSizes []int) (ans [][]int) {
    groups := map[int][]int{}
    for i, size := range groupSizes {
        groups[size] = append(groups[size], i)
    }
    for size, people := range groups {
        for i := 0; i < len(people); i += size {
            ans = append(ans, people[i:i+size])
        }
    }
    return
}

```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�O(n)������ n ������ groupSize �ĳ��ȡ���Ҫ��������һ�εõ�ÿ����Ĵ�С��Ӧ�������˵ı�ţ�Ȼ����Ҫ��������Ԫ����ɷ��顣
    
-   �ռ临�Ӷȣ�O(n)������ n ������ groupSize �ĳ��ȡ��ռ临�Ӷ���Ҫȡ���ڹ�ϣ����ϣ����Ҫ O(n) �Ŀռ��¼ÿ����Ĵ�С��Ӧ�������˵ı�š�
