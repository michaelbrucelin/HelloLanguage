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

/* 对顺序表L作归并排序 */
void MergeSort(SqList *L)
{
    MSort(L->r, L->r, 1, L->length);
}

/* 将SR[s..t]归并排序为TR1[s..t] */
void MSort(int SR[], int TR1[], int s, int t)
{
    int m;
    int TR2[MAXSIZE + 1];
    if (s == t)
        TR1[s] = SR[s];
    else
    {
        m = (s + t) / 2;          /* 将SR[s..t]平分为SR[s..m]和SR[m+1..t] */
        MSort(SR, TR2, s, m);     /* 递归地将SR[s..m]归并为有序的TR2[s..m] */
        MSort(SR, TR2, m + 1, t); /* 递归地将SR[m+1..t]归并为有序的TR2[m+1..t] */
        Merge(TR2, TR1, s, m, t); /* 将TR2[s..m]和TR2[m+1..t]归并到TR1[s..t] */
    }
}

void Merge(int SR[], int TR[], int i, int m, int n)
{ /* 将有序的SR[i..m]和SR[m+1..n]归并为有序的TR[i..n] */
    int j, k, l;
    for (j = m + 1, k = i; i <= m && j <= n; k++) /* 将SR中记录由小到大地并入TR */
    {
        if (SR[i] < SR[j])
            TR[k] = SR[i++];
        else
            TR[k] = SR[j++];
    }
    if (i <= m)
    {
        for (l = 0; l <= m - i; l++)
            TR[k + l] = SR[i + l]; /* 将剩余的SR[i..m]复制到TR */
    }
    if (j <= n)
    {
        for (l = 0; l <= n - j; l++)
            TR[k + l] = SR[j + l]; /* 将剩余的SR[j..n]复制到TR */
    }
}

void MergeSort2(SqList *L) /* 对顺序表L作归并非递归排序 */
{
    int *TR = (int *)malloc(L->length * sizeof(int)); /* 申请额外空间 */
    int k = 1;
    while (k < L->length)
    {
        MergePass(L->r, TR, k, L->length);
        k = 2 * k; /* 子序列长度加倍 */
        MergePass(TR, L->r, k, L->length);
        k = 2 * k; /* 子序列长度加倍 */
    }
}

void MergePass(int SR[], int TR[], int s, int n)
{ /* 将SR[]中相邻长度为s的子序列两两归并到TR[] */
    int i = 1;
    int j;
    while (i <= n - 2 * s + 1) /* 两两归并 */
    {
        Merge(SR, TR, i, i + s - 1, i + 2 * s - 1);
        i = i + 2 * s;
    }
    if (i < n - s + 1) /* 归并最后两个序列 */
        Merge(SR, TR, i, i + s - 1, n);
    else /* 若最后只剩下单个子序列 */
        for (j = i; j <= n; j++)
            TR[j] = SR[j];
}
