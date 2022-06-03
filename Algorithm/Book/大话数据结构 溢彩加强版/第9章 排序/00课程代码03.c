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

void InsertSort(SqList *L) /* 对顺序表L作直接插入排序 */
{
    int i, j;
    for (i = 2; i <= L->length; i++)
    {
        if (L->r[i] < L->r[i - 1]) /* 需将L->r[i]插入有序子表 */
        {
            L->r[0] = L->r[i]; /* 设置哨兵 */
            for (j = i - 1; L->r[j] > L->r[0]; j--)
                L->r[j + 1] = L->r[j]; /* 记录后移 */
            L->r[j + 1] = L->r[0];     /* 插入到正确位置 */
        }
    }
}
