#include <hiredis/hiredis.h>
#include <string.h>

// 对02-rw2.c进行代码重构

void doredis(char *key, char *value, int expire, char *pr, int r_len)
{
    redisContext *c = redisConnect("localhost", 6379);

    if (c == NULL)
    {
        strncpy(pr, "Error: Connect Redis failed.", r_len - 1);
    }
    else if (c->err)
    {
        strncpy(pr, c->errstr, r_len - 1);
    }
    else
    {
        char *result;
        redisReply *reply;

        reply = redisCommand(c, "SELECT 1");
        if (reply)
            freeReplyObject(reply);

        int exists; // 存放结果，释放redisCommand
        reply = redisCommand(c, "EXISTS %s", key);
        exists = reply->integer;
        if (reply)
            freeReplyObject(reply);

        if (1 == exists)
        {
            reply = redisCommand(c, "GET %s", key);
            strncpy(pr, reply->str, r_len - 1);
            if (reply)
                freeReplyObject(reply);

            /*
            reply = redisCommand(c, "TTL %s", key);
            strcat(kvalue, reply->str);
            if (reply)
                freeReplyObject(reply);
            */
        }
        else
        {
            reply = redisCommand(c, "SETEX %s %d %s", key, expire, value);
            if (reply)
                freeReplyObject(reply);
            strncpy(pr, "true", r_len - 1);
        }

        redisFree(c);
    }
    pr[r_len - 1] = '\0';
}

int main(int argc, char *argv[])
{
    if (argc != 4)
    {
        printf("Usage: %s key value expire.\n", argv[0]);
        return (1);
    }

    char result[255];
    doredis(argv[1], argv[2], atoi(argv[3]), result, sizeof(result));
    printf("result: %s", result);

    return (0);
}

/*
TODO
判断argv[3]是否为整数
TODO
结果补充ttl结果，即需要连接两个字符串
*/