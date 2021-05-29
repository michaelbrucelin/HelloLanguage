//读取一个字符串
//https://stackoverflow.com/questions/7709452/how-to-read-string-from-keyboard-using-c

#include <stdio.h>
#include <stdlib.h>

int main(int argc, char *argv[])
{
    char *line = NULL; /* forces getline to allocate with malloc */
    size_t len = 0;    /* ignored when line = NULL */
    ssize_t read;

    printf("\nEnter string below [ctrl + d] to quit\n");

    while ((read = getline(&line, &len, stdin)) != -1)
    {
        if (read > 0)
            printf("\n  read %zd chars from stdin, allocated %zd bytes for line : %s\n", read, len, line);

        printf("Enter string below [ctrl + d] to quit\n");
    }

    free(line); /* free memory allocated by getline */

    return (0);
}