#define MAXSIZE 20    /* 存储空间初始分配量 */
typedef int ElemType; /* ElemType类型根据实际情况而定，这里为int */
typedef struct
{
    ElemType data[MAXSIZE]; /* 数组，存储数据元素 */
    int length;             /* 线性表当前长度 */
} SqList;

#define OK 1
#define ERROR 0
/* Status是函数的类型,其值是函数结果状态代码，如OK等 */
typedef int Status;

/* 初始条件：顺序线性表L已存在，1≤i≤ListLength(L) */
/* 操作结果：用e返回L中第i个数据元素的值，注意i是指位置，第1个位置的数组是从0开始 */
Status GetElem(SqList L, int i, ElemType *e)
{
    if (L.length == 0 || i < 1 || i > L.length)
        return ERROR;
    *e = L.data[i - 1];

    return OK;
}

/* 初始条件：顺序线性表L已存在,1≤i≤ListLength(L)， */
/* 操作结果：在L中第i个位置之前插入新的数据元素e，L的长度加1 */
Status ListInsert(SqList *L, int i, ElemType e)
{
    int k;
    if (L->length == MAXSIZE) /* 顺序线性表已经满 */
        return ERROR;
    if (i < 1 || i > L->length + 1) /* 当i比第一位置小或者比最后一位置后一位置还要大时 */
        return ERROR;

    if (i <= L->length) /* 若插入数据位置不在表尾 */
    {
        for (k = L->length - 1; k >= i - 1; k--) /* 将要插入位置后的元素向后移一位 */
            L->data[k + 1] = L->data[k];
    }
    L->data[i - 1] = e; /* 将新元素插入 */
    L->length++;

    return OK;
}

/* 初始条件：顺序线性表L已存在，1≤i≤ListLength(L) */
/* 操作结果：删除L的第i个数据元素，并用e返回其值，L的长度减1 */
Status ListDelete(SqList *L, int i, ElemType *e)
{
    int k;
    if (L->length == 0) /* 线性表为空 */
        return ERROR;
    if (i < 1 || i > L->length) /* 删除位置不正确 */
        return ERROR;
    *e = L->data[i - 1];
    if (i < L->length) /* 如果删除不是最后位置 */
    {
        for (k = i; k < L->length; k++) /* 将删除位置后继元素前移 */
            L->data[k - 1] = L->data[k];
    }
    L->length--;
    return OK;
}
