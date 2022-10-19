#### [](https://leetcode.cn/problems/number-of-students-unable-to-eat-lunch/solution/wu-fa-chi-wu-can-de-xue-sheng-shu-liang-fv3f5//#����һ��ģ��)����һ��ģ��

����ϲ����Բ�������ε�ѧ������Ϊ s0��ϲ���Է��������ε�ѧ������Ϊ s1���������⣬���ǿ���֪��ջ�����������ܷ�����ȡ���ڶ���ʣ���ѧ�����Ƿ���ϲ�����ģ����ѧ���ڶ��е����λ�ò�Ӱ���������̣�����ֻ��Ҫ��¼����ʣ���ѧ���� s0 �� s1 ��ֵ�����Ƕ��������̽���ģ�⣬���ջ����Ԫ��Ϊ 0 ���� s0>0�����ǽ� s0 �� 1�����ջ����Ԫ��Ϊ 1 ���� s1>0�����ǽ� s1 �� 1��������ֹ���̣������� s0+s1��

```Python
class Solution:
    def countStudents(self, students: List[int], sandwiches: List[int]) -> int:
        s1 = sum(students)
        s0 = len(students) - s1
        for x in sandwiches:
            if x == 0 and s0:
                s0 -= 1
            elif x == 1 and s1:
                s1 -= 1
            else:
                break
        return s0 + s1
```

```C++
class Solution {
public:
    int countStudents(vector<int>& students, vector<int>& sandwiches) {
        int s1 = accumulate(students.begin(), students.end(), 0);
        int s0 = students.size() - s1;
        for (int i = 0; i < sandwiches.size(); i++) {
            if (sandwiches[i] == 0 && s0 > 0) {
                s0--;
            } else if (sandwiches[i] == 1 && s1 > 0) {
                s1--;
            } else {
                break;
            }
        }
        return s0 + s1;
    }
};
```

```Java
class Solution {
    public int countStudents(int[] students, int[] sandwiches) {
        int s1 = Arrays.stream(students).sum();
        int s0 = students.length - s1;
        for (int i = 0; i < sandwiches.length; i++) {
            if (sandwiches[i] == 0 && s0 > 0) {
                s0--;
            } else if (sandwiches[i] == 1 && s1 > 0) {
                s1--;
            } else {
                break;
            }
        }
        return s0 + s1;
    }
}
```

```C#
public class Solution {
    public int CountStudents(int[] students, int[] sandwiches) {
        int s1 = students.Sum();
        int s0 = students.Length - s1;
        for (int i = 0; i < sandwiches.Length; i++) {
            if (sandwiches[i] == 0 && s0 > 0) {
                s0--;
            } else if (sandwiches[i] == 1 && s1 > 0) {
                s1--;
            } else {
                break;
            }
        }
        return s0 + s1;
    }
}
```

```C
int countStudents(int* students, int studentsSize, int* sandwiches, int sandwichesSize) {
    int s1 = 0;
    for (int i = 0; i < studentsSize; i++) {
        s1 += students[i];
    }
    int s0 = studentsSize - s1;
    for (int i = 0; i < sandwichesSize; i++) {
        if (sandwiches[i] == 0 && s0 > 0) {
            s0--;
        } else if (sandwiches[i] == 1 && s1 > 0) {
            s1--;
        } else {
            break;
        }
    }
    return s0 + s1;
}
```

```JavaScript
var countStudents = function(students, sandwiches) {
    let s1 = _.sum(students);
    let s0 = students.length - s1;
    for (let i = 0; i < sandwiches.length; i++) {
        if (sandwiches[i] === 0 && s0 > 0) {
            s0--;
        } else if (sandwiches[i] === 1 && s1 > 0) {
            s1--;
        } else {
            break;
        }
    }
    return s0 + s1;
};
```

```Go
func countStudents(students, sandwiches []int) int {
    s1 := 0
    for _, v := range students {
        s1 += v
    }
    s0 := len(students) - s1
    for _, x := range sandwiches {
        if x == 0 && s0 > 0 {
            s0--
        } else if x == 1 && s1 > 0 {
            s1--
        } else {
            break
        }
    }
    return s0 + s1
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�O(n)������ n ��ѧ����������
-   �ռ临�Ӷȣ�O(1)��
