#include <stdio.h>

//如果程序循环100次某个函数，效率低下，由于宏是在代码中直接展开，这时可以考虑使用宏来替代函数，但是如果函数复杂，宏也有很多问题
//这时就可以使用内联函数，内联函数与宏一样，直接在使用的地方展开，这样效率就高了，也不会产生很多由宏导致的问题
//如果使用内联函数，编译的时候需要指定-O，如果没有指定，编译器就把内联函数当作普通函数处理了
//gcc -O 094-funcinline.c，NB了，测试中如果不指定inline，编译不过去，现在的编译器聪明了

#define SQUARE(x) ((x) * (x))

inline int square(int x);
inline int square(int x)
{
    return x * x;
}

int main(void)
{
    int i = 1;

    while (i <= 100)
        //printf("%d的平方为%d\n", i - 1, SQUARE(i++));  //这里使用宏的话，就错了，因为宏展开会两次i++
        printf("%d的平方为%d\n", i - 1, square(i++));

    return (0);
}