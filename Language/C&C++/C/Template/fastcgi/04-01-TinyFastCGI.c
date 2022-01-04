#include "fcgi_stdio.h" /* fcgi library; put it first*/
#include <stdlib.h>

// 代码来自：http://www.chiark.greenend.org.uk/doc/libfcgi0ldbl/fastcgi-prog-guide/ch2c.htm
// 结构并不是很懂，实践中可以测试实际的性能差异

int count;

void initialize(void)
{
    count = 0;
}

void main(void)
{
    /* Initialization. */
    initialize();

    /* Response loop. */
    while (FCGI_Accept() >= 0)
    {
        printf("Content-type: text/html\r\n"
               "\r\n"
               "<title>FastCGI Hello! (C, fcgi_stdio library)</title>"
               "<h1>FastCGI Hello! (C, fcgi_stdio library)</h1>"
               "Request number %d running on host <i>%s</i>\n",
               ++count, getenv("SERVER_HOSTNAME"));
    }
}

/*
# apt-get install libfcgi-dev  # Debian10
# yum install fcgi-devel       # CentOS7

# gcc 04-01-TinyFastCGI.c -o tinyf.cgi -lfcgi

# curl http://127.0.0.1:80/cgi-bin/tinyf.cgi
<title>FastCGI Hello! (C, fcgi_stdio library)</title><h1>FastCGI Hello! (C, fcgi_stdio library)</h1>Request number 1 running on host <i>(null)</i>
*/
