int main()
{
    int i;
    int a[40];
    a[0] = 0;
    a[1] = 1;
    printf("%d ", a[0]);
    printf("%d ", a[1]);
    for (i = 2; i < 40; i++)
    {
        a[i] = a[i - 1] + a[i - 2];
        printf("%d ", a[i]);
    }
    return 0;
}
