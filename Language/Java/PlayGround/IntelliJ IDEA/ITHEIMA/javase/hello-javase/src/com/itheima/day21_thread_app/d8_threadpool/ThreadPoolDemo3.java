package com.itheima.day21_thread_app.d8_threadpool;

import java.util.concurrent.*;

/**
    目标：使用Executors的工具方法直接得到一个线程池对象。
 */
public class ThreadPoolDemo3 {
    public static void main(String[] args) throws Exception {
        // 1、创建固定线程数据的线程池
        ExecutorService pool = Executors.newFixedThreadPool(3);

        pool.execute(new MyRunnable());
        pool.execute(new MyRunnable());
        pool.execute(new MyRunnable());
        pool.execute(new MyRunnable()); // 已经没有多余线程了
    }
}
