/* 顺序查找，a为数组，n为要查找的数组个数，key为要查找的关键字 */
int Sequential_Search(int *a, int n, int key)
{
    int i;
    for (i = 1; i <= n; i++)
    {
        if (a[i] == key)
            return i;
    }
    return 0;
}

/* 有哨兵顺序查找 */
int Sequential_Search2(int *a, int n, int key)
{
    int i;
    a[0] = key; /* 设置a[0]为关键字值，我们称之为“哨兵”*/
    i = n;      /* 循环从数组尾部开始 */
    while (a[i] != key)
    {
        i--;
    }
    return i; /* 返回0则说明查找失败 */
}

/* 折半查找 */
int Binary_Search(int *a, int n, int key)
{
    int low, high, mid;
    low = 1;  /* 定义最低下标为记录首位 */
    high = n; /* 定义最高下标为记录末位 */
    while (low <= high)
    {
        mid = (low + high) / 2; /* 折半 */
        if (key < a[mid])       /* 若查找值比中值小 */
            high = mid - 1;     /* 最高下标调整到中位下标小一位 */
        else if (key > a[mid])  /* 若查找值比中值大 */
            low = mid + 1;      /* 最低下标调整到中位下标大一位 */
        else
            return mid; /* 若相等则说明mid即为查找到的位置 */
    }
    return 0;
}

/* 插值查找 */
int Interpolation_Search(int *a, int n, int key)
{
    int low, high, mid;
    low = 1;  /* 定义最低下标为记录首位 */
    high = n; /* 定义最高下标为记录末位 */
    while (low <= high)
    {
        mid = low + (high - low) * (key - a[low]) / (a[high] - a[low]); /* 插值 */
        if (key < a[mid])                                               /* 若查找值比插值小 */
            high = mid - 1;                                             /* 最高下标调整到插值下标小一位 */
        else if (key > a[mid])                                          /* 若查找值比插值大 */
            low = mid + 1;                                              /* 最低下标调整到插值下标大一位 */
        else
            return mid; /* 若相等则说明mid即为查找到的位置 */
    }
    return 0;
}

int F[100];                                  /* 斐波那契数列 */
int Fibonacci_Search(int *a, int n, int key) /* 斐波那契查找 */
{
    int low, high, mid, i, k;
    low = 1;  /* 定义最低下标为记录首位 */
    high = n; /* 定义最高下标为记录末位 */
    k = 0;
    while (n > F[k] - 1) /* 计算n位于斐波那契数列的位置 */
        k++;
    for (i = n; i < F[k] - 1; i++) /* 将不满的数值补全 */
        a[i] = a[n];
    while (low <= high)
    {
        mid = low + F[k - 1] - 1; /* 计算当前分隔的下标 */
        if (key < a[mid])         /* 若查找记录小于当前分隔记录 */
        {
            high = mid - 1; /* 最高下标调整到分隔下标mid-1处 */
            k = k - 1;      /* 斐波那契数列下标减一位 */
        }
        else if (key > a[mid]) /* 若查找记录大于当前分隔记录 */
        {
            low = mid + 1; /* 最低下标调整到分隔下标mid+1处 */
            k = k - 2;     /* 斐波那契数列下标减两位 */
        }
        else
        {
            if (mid <= n)
                return mid; /* 若相等则说明mid即为查找到的位置 */
            else
                return n; /* 若mid>n说明是补全数值，返回n */
        }
    }
    return 0;
}
