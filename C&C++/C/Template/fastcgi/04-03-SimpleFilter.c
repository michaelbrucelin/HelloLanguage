#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <fcgi_stdio.h>

// 代码来自：https://docs.oracle.com/cd/E19146-01/820-0872/6ncj5heq7/index.html

void main(void)
{
    size_t PageSize = 1024 * 3;
    char *page;
    FCGX_Stream *in, *out, *err;
    FCGX_ParamArray envp;

    int count = 0;
    page = (char *)malloc(PageSize);

    if (page == NULL)
    {
        printf("Content-type: text/x-server-parsed-html\r\n");
        printf("<title>malloc failure</title>");
        printf("<h1>Cannot allocate memory to run filter. exiting</h1>");
        printf("\r\n\r\n");
        exit(2);
    }

    while (FCGI_Accept() >= 0)
    {
        char *tmp;
        char *execcgi;
        char *dataLenStr = NULL;
        int numchars = 0;
        int stdinDataSize = 0;
        int filterDataLen = 0;
        int dataToBeRead = 0;
        int x = 0;
        int loopCount = 0;

        count++;
        dataLenStr = getenv("FCGI_DATA_LENGTH");
        if (dataLenStr)
            filterDataLen = atoi(dataLenStr);

        /* clear out stdin */
        while (EOF != getc(stdin))
        {
            stdinDataSize++;
        }

        dataToBeRead = filterDataLen;
        FCGI_StartFilterData();
        tmp = page; /** just in case fread or fwrite moves our pointer **/

        // start responding
        printf("Content-type: text/plain\r\n");
        printf("\r\n"); /** send a new line at the beginning **/
        printf("<title>SIMPLE FILTER</title>");
        printf("<h1>This page was Filtered by SimpleFilter FastCGI filter</h1>");
        printf("file size=%d<br>", filterDatalen);
        printf("stdin size=%d<br>", stdinDataSize);

        while (dataToBeRead > 0)
        {
            x = 0;
            page = tmp;

            if (dataToBeRead > PageSize)
                x = PageSize;
            else
                x = dataToBeRead;
            numchars = fread((void *)(page), 1, x, stdin);

            if (numchars == 0)
                continue;
            /** at this point your data is in page pointer, so do whatever you want
                with it before sending it back to the server.
                In this example, no data is manipulated. Only the count of number of
                times the filter data is read and the total bytes read
                at the end of every loop is printed. **/

            dataToBeRead -= numchars;
            loopCount++;
            printf("loop count = %d ... so far read %d bytes <br>", loopCount, (filterDatalen - dataToBeRead));
        }
        printf("\r\n\r\n"); /** send a new line at the end of transfer **/

        fflush(stdout);

        page = tmp; /** restore page pointer **/
        memset(page, NULL, numchars);
    }

    free(page);
}