#include <stdio.h>

/*
使用结构体（struct）将两个复数相加
我们把形如 a+bi（a,b均为实数）的数称为复数，其中 a 称为实部，b 称为虚部，i 称为虚数单位
*/

typedef struct complex
{
    float real;
    float imag;
} complex;
complex add(complex n1, complex n2);

int main()
{
    complex n1, n2, temp;

    printf("第一个复数 \n");
    printf("输入实部和虚部:\n");
    scanf("%f %f", &n1.real, &n1.imag);

    printf("\n第二个复数 \n");
    printf("输入实部和虚部:\n");
    scanf("%f %f", &n2.real, &n2.imag);

    temp = add(n1, n2);
    printf("Sum = %.1f + %.1fi", temp.real, temp.imag);

    return 0;
}

complex add(complex n1, complex n2)
{
    complex temp;

    temp.real = n1.real + n2.real;
    temp.imag = n1.imag + n2.imag;

    return (temp);
}