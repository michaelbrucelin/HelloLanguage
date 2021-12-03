#include <stdio.h>
#include <stdlib.h>

// 自己写的获取POST方法的传参的模板
// 假定post传入的参数形式为：key=value_str&expire=value_int

int main()
{
    int len;
    char *len_, *data;
    char *key;
    int expire;

    printf("Content-Type: text/html\n\n");
    printf("<title>Hello, PostData.</title>");

    len_ = getenv("CONTENT_LENGTH"); // printf("\n%s\n", len_);
    if (NULL != len_)
    {
        len = atoi(len_); // len = strtol(len_, NULL, 10);
        data = (char *)malloc(sizeof(char) * (len + 1));
        if (NULL != data)
        {
            // fgets(data, (len + 1), stdin);
            fread(data, (len + 1), sizeof(char), stdin); // printf("\n%p\n", data); printf("\n%s\n", data);
            if (sscanf(data, "key=%s&expire=%d", key, &expire) == 2)
            {
                printf("yes");
                // printf("key: %s, expire: %d.", *key, expire);
            }

            free(data);
        }
    }

    return (0);
}

/*
# gcc 03-post2.c -o post2.cgi

网上的一些说明
https://stackoverflow.com/questions/5451913/how-to-retrieve-form-post-data-via-cgi-bin-program-written-in-c

1.
POST data is appended to the request header, after a double newline. In a CGI-BIN environment, you read it from STDIN.
Be warned that the server IS NOT REQUIRED to send you an EOF character (or some termination indicator) at the end of the POST data. Never read more than CONTENT_LENGTH bytes.

2.
If I remember right, read stdin for POST data.
Edit for untested snippet
len_ = getenv("CONTENT_LENGTH");
len = strtol(len_, NULL, 10);
postdata = malloc(len + 1);
if (!postdata) { // handle error or exit(EXIT_FAILURE); }
fgets(postdata, len + 1, stdin);
// work with postdata
free(postdata);

https://blog.petehouston.com/get-fastcgi-post-body-data-using-c/
char *get_post_body()
{
    char *content_length = getenv("CONTENT_LENGTH");
    if(!content_length) {
        return "";
    }
    int size = atoi(content_length);
    char *body = (char *) calloc(size + 1, sizeof(char));
    fread(body, size, 1, stdin);
    return body;
}
*/
