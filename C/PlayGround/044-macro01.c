#include <stdio.h>

/*
宏定义就是替换，只是字符层面的替换，注意与全局变量和常量的区别
*/

#define PI 3.14159
#define CIRCLEAREA PI *r *r
#define INPUTR "please input radius of the circle"
#define AREA "the area of circle is"
#define F "%f"
#define LF "%lf"
#define N "\n"
#define T "\t"

int main(void)
{
    double r;
    printf(INPUTR N);
    scanf(LF, &r);

    printf("PI is" T F N, PI);
    printf("radius is" T F N, r);
    printf(AREA T F N, CIRCLEAREA);

    return (0);
}