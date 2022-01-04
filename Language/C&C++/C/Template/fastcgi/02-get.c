#include <stdio.h>
#include <stdlib.h>

// 获取GET方法的传参

int main()
{
    char *data;
    int m, n;
    printf("Content-Type: text/html\n\n");
    printf("<title>Mult-Get</title>");
    data = getenv("QUERY_STRING");
    if (NULL == data)
        printf("Error: get args error.");
    if (sscanf(data, "m=%d&n=%d", &m, &n) != 2)
        printf("Error: Parameters are not right.");
    else
        printf("%d * %d = %d", m, n, m * n);

    return 0;
}

/*
# gcc 02-get.c -o get.cgi

# curl 'http://127.0.0.1:80/cgi-bin/get.cgi?m=2&n=3'
<title>Mult-Get</title>2 * 3 = 6
*/
