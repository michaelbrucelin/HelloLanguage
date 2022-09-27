int main()
{
    int i, sum = 0, n = 100; /* 执行1次 */
    for (i = 1; i <= n; i++) /* 执行了n+1次 */
    {
        sum = sum + i; /* 执行n次 */
    }
    printf("%d", sum); /* 执行1次 */

    int sum = 0, n = 100;  /* 执行一次 */
    sum = (1 + n) * n / 2; /* 执行一次 */
    printf("%d", sum);     /* 执行一次 */

    int i, j, x = 0, sum = 0, n = 100; /* 执行一次 */
    for (i = 1; i <= n; i++)
    {
        for (j = 1; j <= n; j++)
        {
            x++; /* 执行n×n次 */
            sum = sum + x;
        }
    }
    printf("%d", sum); /* 执行一次 */
}