int main()
{
    int i, sum = 0, n = 100;
    for (i = 1; i <= n; i++)
    {
        sum = sum + i;
    }
    printf("%d", sum);

    int sum = 0, n = 100;
    sum = (1 + n) * n / 2;
    printf("%d", sum);
}