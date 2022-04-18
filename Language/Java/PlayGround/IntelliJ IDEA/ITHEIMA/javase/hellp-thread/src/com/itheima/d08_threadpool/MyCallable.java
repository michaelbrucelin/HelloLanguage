package com.itheima.d08_threadpool;

import java.util.concurrent.Callable;

/**
    1、定义一个任务类 实现Callable接口  应该申明线程任务执行完毕后的结果的数据类型
 */
public class MyCallable implements Callable<String>{
    private int n;
    public MyCallable(int n) {
        this.n = n;
    }

    /**
       2、重写call方法（任务方法）
     */
    @Override
    public String call() throws Exception {
        int sum = 0;
        for (int i = 1; i <= n ; i++) {
            sum += i;
        }
        return Thread.currentThread().getName() + "执行 1-" + n+ "的和，结果是：" + sum;
    }
}
