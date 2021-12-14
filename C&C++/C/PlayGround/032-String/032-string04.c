#include <stdio.h>

int main()
{
    char a[] = "hello, world; hello mlin.";
    char b[0];

    void copystr(char *p1, char *p2);
    copystr(a, b);

    printf("%s\n", b);
}

void copystr(char *p1, char *p2)
{
    for (; *p1 != '\0'; p1++, p2++)
    {
        *p2 = *p1;
    }
    *p2 = '\0';
}

void copystr1(char *p1, char *p2)
{
    while ((*p2 = *p1) != '\0')
    {
        p1++;
        p2++;
    }
}

void copystr2(char *p1, char *p2)
{
    while ((*p2++ = *p1++) != '\0')
    {
        ;
    }
}

void copystr3(char *p1, char *p2)
{
    while (*p1 != '0')
    {
        *p2++ = *p1++;
    }
    *p2 = '\0';
}

void copystr4(char *p1, char *p2)
{
    while (*p2++ = *p1++) //字符串结尾的'\0'，就是0，自然就是false
    {
        ;
    }
}

void copystr5(char *p1, char *p2)
{
    for (; *p2++ = *p1++;)
    {
        ;
    }
}