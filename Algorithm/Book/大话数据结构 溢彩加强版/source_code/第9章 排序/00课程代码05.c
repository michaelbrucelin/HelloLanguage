#define TRUE 1
#define FALSE 0

typedef int Status; /* Status是函数的类型,其值是函数结果状态代码，如OK等 */

#define MAXSIZE 10000 /* 用于要排序数组个数最大值，可根据需要修改 */
typedef struct
{
    int r[MAXSIZE + 1]; /* 用于存储要排序数组，r[0]用作哨兵或临时变量 */
    int length;         /* 用于记录顺序表的长度 */
} SqList;

/* 交换L中数组r的下标为i和j的值 */
void swap(SqList *L, int i, int j)
{
    int temp = L->r[i];
    L->r[i] = L->r[j];
    L->r[j] = temp;
}

void HeapSort(SqList *L) /* 对顺序表L进行堆排序 */
{
    int i;
    for (i = L->length / 2; i > 0; i--) /* 把L中的r构建成一个大顶堆 */
        HeapAdjust(L, i, L->length);
    for (i = L->length; i > 1; i--)
    {
        swap(L, 1, i);           /* 将堆顶记录和当前未经排序子序列最后一记录交换 */
        HeapAdjust(L, 1, i - 1); /* 将L->r[1..i-1]重新调整为大顶堆 */
    }
}

void HeapAdjust(SqList *L, int s, int m)
{ /* 本函数调整L->r[s]的关键字，使L->r[s..m]成为一个大顶堆 */
    int temp, j;
    temp = L->r[s];
    for (j = 2 * s; j <= m; j *= 2) /* 沿关键字较大的孩子结点向下筛选 */
    {
        if (j < m && L->r[j] < L->r[j + 1])
            ++j; /* j为关键字中较大的记录的下标 */
        if (temp >= L->r[j])
            break; /* rc应插入在位置s上 */
        L->r[s] = L->r[j];
        s = j;
    }
    L->r[s] = temp; /* 插入 */
}
