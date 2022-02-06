// mthrs.c---2021
// 多线程同时运行的实例

#include <stdio.h>
#include <threads.h>

int thread_proc(void *arg)
{
    unsigned cnt = 5;
    struct timespec interv = {1, 0}; // 1 second 0 nanoseconds

    while (cnt--)
    {
        printf("%s\t", (char *)arg);
        thrd_sleep(&interv, 0); // 将线程挂起1s，延长线程的执行时间，方便观察线程之间同时执行以及交替输出的过程
    }

    return 0;
}

int main(void)
{
    thrd_t t0, t1;

    thrd_create(&t0, thread_proc, "A"); // 创建线程，用t0保存线程的标识，线程的启动函数为thread_proc，参数为"A"
    thrd_create(&t1, thread_proc, "b");

    thrd_detach(t0); // 将线程设置为分离线程，这意味着，当线程运行结束之后，将由系统负责清理资源
    thrd_detach(t1);

    printf("+\t");                                   // main01
    thrd_sleep(&(struct timespec){1, 500000000}, 0); // main02  主线程挂起1.5s
    printf("+\t");                                   // main03

    // return 0;  // 如果使用return 0;，会隐式调用exit函数结束整个进程，所以线程t0和t1也会结束
    thrd_exit(0); // thrd_exit()函数结束当前线程，即结束主线程，但不结束整个进程，所以进程内的其他线程仍然正常执行，当进程内的所有线程全部完成后，结束进程
    // 从C99开始中允许main函数没有return语句，没有return语句时，当执行到main函数的}时，相当于执行了return 0;
}

/*
gcc 01-mthrs.c -lpthread

程序启动后，main()函数创建了主线程，主线程又创建了两个子线程，然后3个线程一起运行。
下面是连续执行10次的结果：
A       b       +       b       A       +       b       A       b       A       b       A
A       +       b       A       b       +       b       A       b       A       b       A
A       b       +       b       A       +       b       A       b       A       b       A
A       b       +       b       A       +       b       A       b       A       b       A
+       b       A       b       A       +       b       A       b       A       b       A
A       +       b       A       b       +       A       b       A       b       A       b
A       +       b       b       A       +       b       A       b       A       b       A
A       +       b       A       b       +       A       b       A       b       A       b
A       +       b       A       b       +       A       b       b       A       b       A
A       +       b       A       b       +       A       b       A       b       b       A
*/
