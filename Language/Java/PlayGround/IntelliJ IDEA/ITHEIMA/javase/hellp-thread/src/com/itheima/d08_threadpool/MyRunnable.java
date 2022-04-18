package com.itheima.d08_threadpool;

public class MyRunnable implements Runnable{
    @Override
    public void run() {
        for (int i = 0; i < 5; i++) {
            System.out.println(Thread.currentThread().getName() + "输出了：HelloWorld ==> "  + i);
        }
        try {
            System.out.println(Thread.currentThread().getName() + "本任务与线程绑定了，线程进入休眠了~~~");
            Thread.sleep(10000000);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
