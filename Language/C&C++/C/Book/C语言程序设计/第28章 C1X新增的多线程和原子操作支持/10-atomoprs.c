// atomoprs.c---2021

#include <stdio.h>
#include <threads.h>
#include <stdatomic.h>

_Atomic long long counter = 0;

int thrd_proc1(void *arg)
{
    struct timespec interv = {0, 20};

    for (size_t x = 0; x < 5000; x++)
    {
        long long old = atomic_load(&counter), new;

        do
        {
            new = old + 1;
        } while (!atomic_compare_exchange_weak(&counter, &old, new));

        thrd_sleep(&interv, 0);
    }

    return 0;
}

int thrd_proc2(void *arg)
{
    struct timespec interv = {0, 30};

    for (size_t x = 0; x < 5000; x++)
    {
        long long old = atomic_load(&counter), new;

        do
        {
            new = old - 1;
        } while (!atomic_compare_exchange_weak(&counter, &old, new));

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
