//遍历一个字符串
//https://stackoverflow.com/questions/3213827/how-to-iterate-over-a-string-in-c

#include <stdio.h>
#include <string.h>

int main(void)
{
    char source[] = "This is an example.";

    //1.
    printf("1. int len = strlen(source); for (int i = 0; i < len; i++) {\n");
    int len = strlen(source);
    for (int i = 0; i < len; i++)
    {
        printf("%s%c", i == 0 ? "" : "-", source[i]);
    }
    printf("\n");

    //2.
    printf("2. for (i = 0; source[i] != 0; i++){\n");
    for (int i = 0; source[i] != 0; i++)
    {
        printf("%s%c", i == 0 ? "" : "-", source[i]);
    }
    printf("\n");

    //3.
    printf("3. char *c = source; while (*c) putchar(*c++);\n");
    char *c = source;
    while (*c)
    {
        //putchar(*c++);
        printf("%c-", *c++);
    }
    printf("\b \n");

    return (0);
}