#include <stdio.h>
#include <string.h>

int main()
{
    char *strs[] = {"mlin.com", "www.mlin.com", "home.mlin.com", "mlin.cn", "hello world", "hi mlin", "thank you"};

    void sortstrs(char *strs[], int);

    int len = sizeof(strs) / sizeof(strs[0]);
    sortstrs(strs, len);
    for (int i = 0; i < len; i++)
    {
        for (int j = 0; *(strs[i] + j) != '\0'; j++)
        {
            printf("%c", *(strs[i] + j));
        }
        printf("\n");
    }
}

void sortstrs(char *strs[], int len)
{
    char *ptmp;
    for (int i = 0; i < len; i++)
    {
        for (int j = 0; j < len - 1 - i; j++)
        {
            if (strcmp(strs[j], strs[j + 1]) > 0)
            {
                ptmp = strs[j + 1];
                strs[j + 1] = strs[j];
                strs[j] = ptmp;
            }
        }
    }
}