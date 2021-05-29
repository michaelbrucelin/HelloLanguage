#include <stdio.h>
#include <math.h>

/*
求一元二次方程：ax2+bx+c=0 的根。
输入三个实数a,b,c的值，且a不等于0。
*/

int main()
{
    float a, b, c, x1, x2, d;
    printf("输入方程的三个系数:");
    scanf("%f %f %f", &a, &b, &c);
    if (a != 0)
    {
        d = sqrt(b * b - 4 * a * c);
        x1 = (-b + d) / (2 * a);
        x2 = (-b - d) / (2 * a);
        if (x1 < x2)
            printf("%0.2f %0.2f\n", x2, x1);
        else
            printf("%0.2f %0.2f\n", x1, x2);
    }

    return 0;
}