package com.itheima.day21_thread_app.d4_thread_synchronized_code;

/**
  线程类
 */
public class DrawThread extends Thread{
    private Account acc;
    public DrawThread(Account acc, String name){
        super(name);
        this.acc = acc;
    }

    @Override
    public void run() {
        // 小明 小红  ： acc
        acc.drawMoney(100000);
    }
}
