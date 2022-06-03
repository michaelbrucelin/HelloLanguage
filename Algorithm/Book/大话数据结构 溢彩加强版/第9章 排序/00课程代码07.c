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

/* 对顺序表L作快速排序 */
void QuickSort(SqList *L)
{
    QSort(L, 1, L->length);
}

/* 对顺序表L中的子序列L->r[low..high]作快速排序 */
void QSort(SqList *L, int low, int high)
{
    int pivot;
    if (low < high)
    {
        /* 将L->r[low..high]一分为二，算出枢轴值pivot */
        pivot = Partition(L, low, high);
        QSort(L, low, pivot - 1);  /*  对低子表递归排序 */
        QSort(L, pivot + 1, high); /*  对高子表递归排序 */
    }
}

int Partition(SqList *L, int low, int high)
{ /* 交换顺序表L中子表的记录，使枢轴记录到位，并返回其所在位置，此时在它之前(后)均不大(小)于它。*/
    int pivotkey;

    pivotkey = L->r[low]; /* 用子表的第一个记录作枢轴记录 */
    while (low < high)    /* 从表的两端交替地向中间扫描 */
    {
        while (low < high && L->r[high] >= pivotkey)
            high--;
        swap(L, low, high); /* 将比枢轴记录小的记录交换到低端 */
        while (low < high && L->r[low] <= pivotkey)
            low++;
        swap(L, low, high); /* 将比枢轴记录大的记录交换到高端 */
    }
    return low; /* 返回枢轴所在位置 */
}

// int pivotkey;
//
// int m = low + (high - low) / 2; /* 计算数组中间的元素的下标 */
// if (L->r[low] > L->r[high])
//     swap(L, low, high); /* 交换左端与右端数据，保证左端较小 */
// if (L->r[m] > L->r[high])
//     swap(L, high, m); /* 交换中间与右端数据，保证中间较小 */
// if (L->r[m] > L->r[low])
//     swap(L, m, low); /* 交换中间与左端数据，保证左端较小 */
//
// /* 此时L.r[low]已经为整个序列左中右三个关键字的中间值。*/
//
// pivotkey = L->r[low]; /* 用子表的第一个记录作枢轴记录 */

/* 快速排序优化算法 */
int Partition1(SqList *L, int low, int high)
{
    int pivotkey;

    int m = low + (high - low) / 2; /* 计算数组中间的元素的下标 */
    if (L->r[low] > L->r[high])
        swap(L, low, high); /* 交换左端与右端数据，保证左端较小 */
    if (L->r[m] > L->r[high])
        swap(L, high, m); /* 交换中间与右端数据，保证中间较小 */
    if (L->r[m] > L->r[low])
        swap(L, m, low); /* 交换中间与左端数据，保证左端较小 */

    pivotkey = L->r[low]; /* 用子表的第一个记录作枢轴记录 */
    L->r[0] = pivotkey;   /* 将枢轴关键字备份到L->r[0] */
    while (low < high)    /*  从表的两端交替地向中间扫描 */
    {
        while (low < high && L->r[high] >= pivotkey)
            high--;
        L->r[low] = L->r[high]; /* 采用替换而不是交换的方式进行操作 */
        while (low < high && L->r[low] <= pivotkey)
            low++;
        L->r[high] = L->r[low]; /* 采用替换而不是交换的方式进行操作 */
    }
    L->r[low] = L->r[0]; /* 将枢轴数值替换回L.r[low] */
    return low;          /* 返回枢轴所在位置 */
}

#define MAX_LENGTH_INSERT_SORT 7 /* 用于快速排序时判断是否选用插入排序阙值 */
/* 对顺序表L中的子序列L.r[low..high]作快速排序 */
void QSort1(SqList *L, int low, int high)
{
    int pivot;
    if ((high - low) > MAX_LENGTH_INSERT_SORT)
    {
        pivot = Partition1(L, low, high); /* 将L->r[low..high]一分为二，算出枢轴值pivot */
        QSort1(L, low, pivot - 1);        /* 对低子表递归排序 */
        QSort1(L, pivot + 1, high);       /* 对高子表递归排序 */
    }
    else
        InsertSort(L); /* 当high-low小于等于常数时用直接插入排序 */
}

/* 尾递归 */
void QSort2(SqList *L, int low, int high)
{
    int pivot;
    if ((high - low) > MAX_LENGTH_INSERT_SORT)
    {
        while (low < high)
        {
            pivot = Partition1(L, low, high); /* 将L->r[low..high]一分为二，算出枢轴值pivot */
            QSort2(L, low, pivot - 1);        /* 对低子表递归排序 */
            low = pivot + 1;                  /* 尾递归 */
        }
    }
    else
        InsertSort(L); /* 当high-low小于等于常数时用直接插入排序 */
}
