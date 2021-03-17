#include <stdio.h>

//宏定义中的一些其他用法
//#会把后边的参数当成字符串
//##会把后面的参数当成字符串并连接起来
//宏定义支持可变参数：#define SHOWLIST(...) printf(# __VA_ARGS__)

#define STR(s) #s
#define TOGETHER(x, y) x##y
#define SHOUWLIST(...) printf(#__VA_ARGS__)
#define PRINT(format, ...) printf(#format, ##__VA_ARGS__)

int main(void)
{
    printf("%s\n", STR(Hello World));
    printf(STR(Hello % s num = % d\n), STR(World), 1024);

    printf("%d\n", TOGETHER(52, 0));

    SHOUWLIST(Hello World, 520, 3.14\n);

    PRINT(num = % d % f\n, 520, 3.14);
    PRINT(Hello World\n); //可变参数为空

    return (0);
}