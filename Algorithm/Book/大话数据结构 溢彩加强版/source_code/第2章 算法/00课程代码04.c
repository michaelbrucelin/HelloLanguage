int main()
{
    int i, n;
    for (i = 0; i < n; i++)
    {
        /* 时间复杂度为O(1)的程序步骤序列 */
    }

    int count = 1, n;
    while (count < n)
    {
        count = count * 2;
        /* 时间复杂度为O(1)的程序步骤序列 */
    }

    int i, j, n;
    for (i = 0; i < n; i++)
    {
        for (j = 0; j < n; j++)
        {
            /* 时间复杂度为O(1)的程序步骤序列 */
        }
    }

    int i, j, m, n;
    for (i = 0; i < m; i++)
    {
        for (j = 0; j < n; j++)
        {
            /* 时间复杂度为O(1)的程序步骤序列 */
        }
    }

    int i, j, n;
    for (i = 0; i < n; i++)
    {
        for (j = i; j < n; j++) /* 注意j = i而不是0 */
        {
            /* 时间复杂度为O(1)的程序步骤序列 */
        }
    }

    int i, j, n;
    for (i = 0; i < n; i++)
    {
        function(i);
    }

    n++;         /* 执行次数为1 */
    function(n); /* 执行次数为n */
    int i, j;
    for (i = 0; i < n; i++) /* 执行次数为n×n */
    {
        function(i);
    }
    for (i = 0; i < n; i++) /* 执行次数为n(n + 1)/2 */
    {
        for (j = i; j < n; j++)
        {
            /* 时间复杂度为O(1)的程序步骤序列 */
        }
    }
}

void function(int count)
{
    print(count);
}

void function(int count)
{
    int j, n;
    for (j = count; j < n; j++)
    {
        /* 时间复杂度为O(1)的程序步骤序列 */
    }
}
