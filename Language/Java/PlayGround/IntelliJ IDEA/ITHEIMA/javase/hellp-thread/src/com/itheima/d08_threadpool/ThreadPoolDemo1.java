package com.itheima.d08_threadpool;

import java.util.concurrent.*;

/**
    目标：自定义一个线程池对象，并测试其特性。
 */
public class ThreadPoolDemo1 {
    public static void main(String[] args) {
        // 1、创建线程池对象
        /**
         public ThreadPoolExecutor(int corePoolSize,
                                 int maximumPoolSize,
                                 long keepAliveTime,
                                 TimeUnit unit,
                                 BlockingQueue<Runnable> workQueue,
                                 ThreadFactory threadFactory,
                                 RejectedExecutionHandler handler)
         */
        ExecutorService pool = new ThreadPoolExecutor(3, 5 ,
                6, TimeUnit.SECONDS, new ArrayBlockingQueue<>(5) , Executors.defaultThreadFactory(),
               new ThreadPoolExecutor.AbortPolicy() );

        // 2、给任务线程池处理。
        Runnable target = new MyRunnable();
        pool.execute(target);
        pool.execute(target);
        pool.execute(target);

        pool.execute(target);
        pool.execute(target);
        pool.execute(target);
        pool.execute(target);
        pool.execute(target);

        // 创建临时线程
        pool.execute(target);
        pool.execute(target);
//        // 不创建，拒绝策略被触发！！！
//        pool.execute(target);

        // 关闭线程池（开发中一般不会使用）。
        // pool.shutdownNow(); // 立即关闭，即使任务没有完成，会丢失任务的！
        pool.shutdown(); // 会等待全部任务执行完毕之后再关闭（建议使用的）
    }
}
