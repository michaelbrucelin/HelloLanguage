// spinlock.c---2021

#include <stdio.h>
#include <threads.h>
#include <stdatomic.h>

atomic_llong counter = 0;
atomic_flag aflag = ATOMIC_FLAG_INIT;

int thrd_proc1(void *arg)
{
    struct timespec interv = {0, 20};

    for (size_t x = 0; x < 5000; x++)
    {
        while (atomic_flag_test_and_set(&aflag))
            ;
        counter = counter + 1;
        atomic_flag_clear(&aflag);

        thrd_sleep(&interv, 0);
    }

    return 0;
}

int thrd_proc2(void *arg)
{
    struct timespec interv = {0, 30};

    for (size_t x = 0; x < 5000; x++)
    {
        while (atomic_flag_test_and_set(&aflag))
            ;
        counter = counter - 1;
        atomic_flag_clear(&aflag);

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
