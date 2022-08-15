#### 方法一：数组

可以参考循环队列：「[622\. 设计循环队列](https://leetcode.cn/problems/design-circular-queue/)」，我们利用循环队列实现双端队列。在循环队列中的基础上，我们增加 insertFront 和 deleteFront 函数实现即可。根据循环队列的定义，队列判空的条件是 front\=rear，而队列判满的条件是 front\=(rear+1) mod capacity。

对于一个固定大小的数组，只要知道队尾 rear 与队首 front，即可计算出队列当前的长度：

(rear−front+capacity) mod capacity

循环双端队列与循环队列的属性一致:

-   elements：一个固定大小的数组，用于保存循环队列的元素。
-   capacity：循环队列的容量，即队列中最多可以容纳的元素数量。
-   front：队列首元素对应的数组的索引。
-   rear：队列尾元素对应的索引的下一个索引。

循环双端队列的接口方法如下：

-   MyCircularDeque(int k)：初始化队列，同时 base 数组的空间初始化大小为 k+1。front,rear 全部初始化为 0。
-   insertFront(int value)：队列未满时，在队首插入一个元素。我们首先将队首 front 移动一个位置，更新队首索引为 front 更新为 (front−1+capacity) mod capacity。
-   insertLast(int value)：队列未满时，在队列的尾部插入一个元素，并同时将队尾的索引 rear 更新为 (rear+1) mod capacity。
-   deleteFront()：队列不为空时，从队首删除一个元素，并同时将队首的索引 front 更新为 (front+1) mod capacity。
-   deleteLast()：队列不为空时，从队尾删除一个元素。并同时将队尾的索引 rear 更新为 (rear−1+capacity) mod capacity。
-   getFront()：返回队首的元素，需要检测队列是否为空。
-   getRear()：返回队尾的元素，需要检测队列是否为空。
-   isEmpty()：检测队列是否为空，根据之前的定义只需判断 rear 是否等于 front。
-   isFull()：检测队列是否已满，根据之前的定义只需判断 front 是否等于 (rear+1) mod capacity。

```Python3
class MyCircularDeque:
    def __init__(self, k: int):
        self.front = self.rear = 0
        self.elements = [0] * (k + 1)

    def insertFront(self, value: int) -> bool:
        if self.isFull():
            return False
        self.front = (self.front - 1) % len(self.elements)
        self.elements[self.front] = value
        return True

    def insertLast(self, value: int) -> bool:
        if self.isFull():
            return False
        self.elements[self.rear] = value
        self.rear = (self.rear + 1) % len(self.elements)
        return True

    def deleteFront(self) -> bool:
        if self.isEmpty():
            return False
        self.front = (self.front + 1) % len(self.elements)
        return True

    def deleteLast(self) -> bool:
        if self.isEmpty():
            return False
        self.rear = (self.rear - 1) % len(self.elements)
        return True

    def getFront(self) -> int:
        return -1 if self.isEmpty() else self.elements[self.front]

    def getRear(self) -> int:
        return -1 if self.isEmpty() else self.elements[(self.rear - 1) % len(self.elements)]

    def isEmpty(self) -> bool:
        return self.rear == self.front

    def isFull(self) -> bool:
        return (self.rear + 1) % len(self.elements) == self.front

```

```C++
class MyCircularDeque {
private:
    vector<int> elements;
    int rear, front;
    int capacity;

public:
    MyCircularDeque(int k) {
        capacity = k + 1;
        rear = front = 0;
        elements = vector<int>(k + 1);
    }

    bool insertFront(int value) {
        if (isFull()) {
            return false;
        }
        front = (front - 1 + capacity) % capacity;
        elements[front] = value;
        return true;
    }

    bool insertLast(int value) {
        if (isFull()) {
            return false;
        }
        elements[rear] = value;
        rear = (rear + 1) % capacity;
        return true;
    }

    bool deleteFront() {
        if (isEmpty()) {
            return false;
        }
        front = (front + 1) % capacity;
        return true;
    }

    bool deleteLast() {
        if (isEmpty()) {
            return false;
        }
        rear = (rear - 1 + capacity) % capacity;
        return true;
    }

    int getFront() {
        if (isEmpty()) {
            return -1;
        }
        return elements[front];
    }

    int getRear() {
        if (isEmpty()) {
            return -1;
        }
        return elements[(rear - 1 + capacity) % capacity];
    }   

    bool isEmpty() {
        return rear == front;
    }

    bool isFull() {
        return (rear + 1) % capacity == front;
    }
};

```

```Java
class MyCircularDeque {
    private int[] elements;
    private int rear, front;
    private int capacity;

    public MyCircularDeque(int k) {
        capacity = k + 1;
        rear = front = 0;
        elements = new int[k + 1];
    }

    public boolean insertFront(int value) {
        if (isFull()) {
            return false;
        }
        front = (front - 1 + capacity) % capacity;
        elements[front] = value;
        return true;
    }

    public boolean insertLast(int value) {
        if (isFull()) {
            return false;
        }
        elements[rear] = value;
        rear = (rear + 1) % capacity;
        return true;
    }

    public boolean deleteFront() {
        if (isEmpty()) {
            return false;
        }
        front = (front + 1) % capacity;
        return true;
    }

    public boolean deleteLast() {
        if (isEmpty()) {
            return false;
        }
        rear = (rear - 1 + capacity) % capacity;
        return true;
    }

    public int getFront() {
        if (isEmpty()) {
            return -1;
        }
        return elements[front];
    }

    public int getRear() {
        if (isEmpty()) {
            return -1;
        }
        return elements[(rear - 1 + capacity) % capacity];
    }

    public boolean isEmpty() {
        return rear == front;
    }

    public boolean isFull() {
        return (rear + 1) % capacity == front;
    }
}

```

```C#
public class MyCircularDeque {
    private int[] elements;
    private int rear, front;
    private int capacity;

    public MyCircularDeque(int k) {
        capacity = k + 1;
        rear = front = 0;
        elements = new int[k + 1];
    }

    public bool InsertFront(int value) {
        if (IsFull()) {
            return false;
        }
        front = (front - 1 + capacity) % capacity;
        elements[front] = value;
        return true;
    }

    public bool InsertLast(int value) {
        if (IsFull()) {
            return false;
        }
        elements[rear] = value;
        rear = (rear + 1) % capacity;
        return true;
    }

    public bool DeleteFront() {
        if (IsEmpty()) {
            return false;
        }
        front = (front + 1) % capacity;
        return true;
    }

    public bool DeleteLast() {
        if (IsEmpty()) {
            return false;
        }
        rear = (rear - 1 + capacity) % capacity;
        return true;
    }

    public int GetFront() {
        if (IsEmpty()) {
            return -1;
        }
        return elements[front];
    }

    public int GetRear() {
        if (IsEmpty()) {
            return -1;
        }
        return elements[(rear - 1 + capacity) % capacity];
    }

    public bool IsEmpty() {
        return rear == front;
    }

    public bool IsFull() {
        return (rear + 1) % capacity == front;
    }
}

```

```C
typedef struct {
    int *elements;
    int rear, front;
    int capacity;
} MyCircularDeque;

MyCircularDeque* myCircularDequeCreate(int k) {
    MyCircularDeque *obj = (MyCircularDeque *)malloc(sizeof(MyCircularDeque));
    obj->capacity = k + 1;
    obj->rear = obj->front = 0;
    obj->elements = (int *)malloc(sizeof(int) * obj->capacity);
    return obj;
}

bool myCircularDequeInsertFront(MyCircularDeque* obj, int value) {
    if ((obj->rear + 1) % obj->capacity == obj->front) {
        return false;
    }
    obj->front = (obj->front - 1 + obj->capacity) % obj->capacity;
    obj->elements[obj->front] = value;
    return true;
}

bool myCircularDequeInsertLast(MyCircularDeque* obj, int value) {
    if ((obj->rear + 1) % obj->capacity == obj->front) {
        return false;
    }
    obj->elements[obj->rear] = value;
    obj->rear = (obj->rear + 1) % obj->capacity;
    return true;
}

bool myCircularDequeDeleteFront(MyCircularDeque* obj) {
    if (obj->rear == obj->front) {
        return false;
    }
    obj->front = (obj->front + 1) % obj->capacity;
    return true;
}

bool myCircularDequeDeleteLast(MyCircularDeque* obj) {
    if (obj->rear == obj->front) {
        return false;
    }
    obj->rear = (obj->rear - 1 + obj->capacity) % obj->capacity;
    return true;
}

int myCircularDequeGetFront(MyCircularDeque* obj) {
    if (obj->rear == obj->front) {
        return -1;
    }
    return obj->elements[obj->front];
}

int myCircularDequeGetRear(MyCircularDeque* obj) {
    if (obj->rear == obj->front) {
        return -1;
    }
    return obj->elements[(obj->rear - 1 + obj->capacity) % obj->capacity];
}

bool myCircularDequeIsEmpty(MyCircularDeque* obj) {
    return obj->rear == obj->front;
}

bool myCircularDequeIsFull(MyCircularDeque* obj) {
    return (obj->rear + 1) % obj->capacity == obj->front;
}

void myCircularDequeFree(MyCircularDeque* obj) {
    free(obj->elements);
    free(obj);
}

```

```JavaScript
var MyCircularDeque = function(k) {
    this.capacity = k + 1;
    this.rear = this.front = 0;
    this.elements = new Array(k + 1).fill(0);
};

MyCircularDeque.prototype.insertFront = function(value) {
    if (this.isFull()) {
        return false;
    }
    this.front = (this.front - 1 + this.capacity) % this.capacity;
    this.elements[this.front] = value;
    return true;
};

MyCircularDeque.prototype.insertLast = function(value) {
    if (this.isFull()) {
        return false;
    }
    this.elements[this.rear] = value;
    this.rear = (this.rear + 1) % this.capacity;
    return true;
};

MyCircularDeque.prototype.deleteFront = function() {
    if (this.isEmpty()) {
        return false;
    }
    this.front = (this.front + 1) % this.capacity;
    return true;
};

MyCircularDeque.prototype.deleteLast = function() {
    if (this.isEmpty()) {
        return false;
    }
    this.rear = (this.rear - 1 + this.capacity) % this.capacity;
    return true;
};

MyCircularDeque.prototype.getFront = function() {
    if (this.isEmpty()) {
        return -1;
    }
    return this.elements[this.front];
};

MyCircularDeque.prototype.getRear = function() {
    if (this.isEmpty()) {
        return -1;
    }
    return this.elements[(this.rear - 1 + this.capacity) % this.capacity];
};

MyCircularDeque.prototype.isEmpty = function() {
    return this.rear == this.front;
};

MyCircularDeque.prototype.isFull = function() {
    return (this.rear + 1) % this.capacity == this.front;
};

```

```Golang
type MyCircularDeque struct {
    front, rear int
    elements    []int
}

func Constructor(k int) MyCircularDeque {
    return MyCircularDeque{elements: make([]int, k+1)}
}

func (q *MyCircularDeque) InsertFront(value int) bool {
    if q.IsFull() {
        return false
    }
    q.front = (q.front - 1 + len(q.elements)) % len(q.elements)
    q.elements[q.front] = value
    return true
}

func (q *MyCircularDeque) InsertLast(value int) bool {
    if q.IsFull() {
        return false
    }
    q.elements[q.rear] = value
    q.rear = (q.rear + 1) % len(q.elements)
    return true
}

func (q *MyCircularDeque) DeleteFront() bool {
    if q.IsEmpty() {
        return false
    }
    q.front = (q.front + 1) % len(q.elements)
    return true
}

func (q *MyCircularDeque) DeleteLast() bool {
    if q.IsEmpty() {
        return false
    }
    q.rear = (q.rear - 1 + len(q.elements)) % len(q.elements)
    return true
}

func (q MyCircularDeque) GetFront() int {
    if q.IsEmpty() {
        return -1
    }
    return q.elements[q.front]
}

func (q MyCircularDeque) GetRear() int {
    if q.IsEmpty() {
        return -1
    }
    return q.elements[(q.rear-1+len(q.elements))%len(q.elements)]
}

func (q MyCircularDeque) IsEmpty() bool {
    return q.rear == q.front
}

func (q MyCircularDeque) IsFull() bool {
    return (q.rear+1)%len(q.elements) == q.front
}

```

**复杂度分析**

-   时间复杂度：初始化和每项操作的时间复杂度均为 O(1)。
    
-   空间复杂度：O(k)，其中 k 为给定的队列元素数目。
