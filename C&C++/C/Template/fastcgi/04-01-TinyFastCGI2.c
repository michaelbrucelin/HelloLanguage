#include <stdio.h>
#include <stdlib.h>

// 取消04-01-TinyFastCGI.c中的结构，比较二者的差异。
// 比较输出结果没有差异，原以为套用模板输出的count会是1, 2, 3...，但是实际测试每次都是1。
// 注释掉main()中的initialize();，依然如此。

int count;

void initialize(void)
{
    count = 0;
}

void main(void)
{
    /* Initialization. */
    initialize();

    printf("Content-type: text/html\r\n"
           "\r\n"
           "<title>FastCGI Hello! (C, fcgi_stdio library)</title>"
           "<h1>FastCGI Hello! (C, fcgi_stdio library)</h1>"
           "Request number %d running on host <i>%s</i>\n",
           ++count, getenv("SERVER_HOSTNAME"));
}

/*
# gcc 04-01-TinyFastCGI2.c -o tinyf2.cgi -lfcgi
*/
