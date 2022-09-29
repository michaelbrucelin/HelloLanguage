/* 线性表的单链表存储结构 */
typedef int ElemType;           // ElemType类型根据具体情况而定，这里为int
typedef struct Node {
	ElemType data;
	struct Node* next;
}Node;
typedef struct Node* LinkList;  // 定义LinkList

#define OK 1
#define ERROR 0

typedef int Status;          // Status是函数的类型，其值是函数结果的状态代码，如OK等


/* 获取元素操作 */
// 初始条件：链式线性表L已存在，1≤i≤ListLength(L)
// 操作结果：用e返回L中第个元素的值，注意i是指位置，第1个位置的数组是从0开始
Status GetElem(LinkList L, int i, ElemType* e)
{
	int j;
	LinkList p;         // 声明一结点p
	p = L->next;        // 让p指向链表L的第一个结点
	j = 1;              // j为计数器
	while (p && j < i)  // p不为空或者计数器j还没有等于i时，循环继续
	{
		p = p->next;    // 让p指向下一个结点
		++j;
	}

	if (!p || j > i)    // j > i 是为了防止 i<=0 吗？
		return ERROR;   // 第i个元素不存在
	*e = p->data;       // 取第i个元素的数据

	return OK;
}


/* 插入操作 */
// 初始条件：链式线性表L已存在,1≤i≤ListLength(L)
// 操作结果：在L中第i个位置之前插入新的数据元素e，L的长度加1


/* 删除操作 */
// 初始条件：链式线性表L已存在，1≤i≤ListLength(L)
// 操作结果：删除L的第i个数据元素，并用e返回其值，L的长度减1
