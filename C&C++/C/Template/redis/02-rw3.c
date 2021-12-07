#include <hiredis/hiredis.h>
#include <string.h>

// 对02-rw2.c进行代码重构

const char *doredis(char *key, char *value, int expire)
{
    redisContext *c = redisConnect("localhost", 6379);

    if (c == NULL)
    {
        return "Error: Connect Redis failed.";
    }
    else if (c->err)
    {
        return c->errstr;
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
            char kvalue[255];

            reply = redisCommand(c, "GET %s", key);
            strcat(kvalue, reply->str);
            strcat(kvalue, ".");
            if (reply)
                freeReplyObject(reply);

            /*
            reply = redisCommand(c, "TTL %s", key);
            strcat(kvalue, reply->str);
            if (reply)
                freeReplyObject(reply);
            */

            // printf("kvalue in function: %s\n", kvalue); // 加了这一行，main中就能输出结果，注释掉这一行，main中就输出空，不确认是为什么
            result = kvalue;
        }
        else
        {
            reply = redisCommand(c, "SETEX %s %d %s", key, expire, value);
            if (reply)
                freeReplyObject(reply);
            result = "true";
        }

        redisFree(c);

        return result;
    }
}

int main(int argc, char *argv[])
{
    // const char *r = doredis("foo", "bar", 100);
    const char *r = doredis(argv[1], argv[2], atoi(argv[3]));
    printf("result: %s", r);

    return (0);
}
