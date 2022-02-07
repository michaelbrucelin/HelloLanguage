// atomic.c---2021
// 用运算符+=和-=修改原子变量的实例

#include <stdio.h>
#include <threads.h>

_Atomic long long counter = 0; // 原子变量，与02-datarace.c相比，只是这里做个修改

int thrd_proc1(void *arg)
{
    struct timespec interv = {0, 20};

    for (size_t x = 0; x < 5000; x++)
    {
        counter += 1; // 需要使用 += 操作符，如果改为 counter = counter + 1; 则会出错，并不能保证操作的原子性
        thrd_sleep(&interv, 0);
    }

    return 0;
}

int thrd_proc2(void *arg)
{
    struct timespec interv = {0, 30};

    for (size_t x = 0; x < 5000; x++)
    {
        counter -= 1; // 需要使用 -= 操作符，如果改为 counter = counter - 1; 则会出错，并不能保证操作的原子性
        thrd_sleep(&interv, 0);
    }

    return 0;
}

int main(void)
{
    thrd_t t0, t1;

    thrd_create(&t0, thrd_proc1, 0);
    thrd_create(&t1, thrd_proc2, 0);

    thrd_join(t0, &(int){0});
    thrd_join(t1, &(int){0});

    printf("%lld\n", counter);
}
