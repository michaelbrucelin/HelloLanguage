#include <stdio.h>

/*
用户输入年份，判断该年份是否为闰年。
*/

int main()
{
    int year;

    printf("输入年份: ");
    scanf("%d", &year);

    if (year % 4 == 0)
    {
        if (year % 100 == 0)
        {
            // 这里如果被 400 整数是闰年
            if (year % 400 == 0)
                printf("%d 是闰年", year);
            else
                printf("%d 不是闰年", year);
        }
        else
            printf("%d 是闰年", year);
    }
    else
        printf("%d 不是闰年", year);

    return 0;
}