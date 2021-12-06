#include <stdio.h>
#include <stdlib.h>
#include <string.h>

int main()
{
    char dtm[100];

    int m, n;
    strcpy(dtm, "m=10&n=1024");
    printf("%s\n", dtm);
    sscanf(dtm, "m=%d&n=%d", &m, &n);
    printf("%d * %d = %d\n\n", m, n, m * n);

    int expire;
    char key[20];
    strcpy(dtm, "key=hello&expire=1234");
    printf("%s\n", dtm);
    sscanf(dtm, "key=%s&expire=%d", key, &expire);
    printf("key: %s, expire: %d\n\n", key, expire);

    int expire2;
    // char key2[20];
    char *key2;
    strcpy(dtm, "expire=1234&key=hello");
    printf("%s\n", dtm);
    sscanf(dtm, "expire=%d&key=%s", &expire2, key2);
    printf("key: %s, expire: %d\n", key2, expire2);

    return (0);
}
