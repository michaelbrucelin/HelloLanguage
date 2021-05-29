//读取一个字符串
//https://stackoverflow.com/questions/7709452/how-to-read-string-from-keyboard-using-c

#include <stdio.h>

#define STR_MAX_LEN 256

int main(void)
{
    char data[STR_MAX_LEN];
    if (fgets(data, sizeof(data), stdin))
    {
        printf("your input is:\n\t%s\n", data);
    }
    else
    {
        printf("failed!\n");
    }

    return (0);
}