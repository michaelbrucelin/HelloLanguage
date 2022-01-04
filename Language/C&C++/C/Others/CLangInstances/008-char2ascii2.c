#include <stdio.h>
#define MAX_STRING_LENGTH 65535 // 最大字符串长度

int main()
{
    char s[MAX_STRING_LENGTH];

    printf("请输入长度小于 %d 的任意字符：", MAX_STRING_LENGTH);
    scanf("%s", s); // 读取字符串。

    //这个模式可以用来遍历字符串
    for (int i = 0; s[i]; i++)
    {
        printf("%c的ASCII:%d\n", s[i], s[i]);
    }
}