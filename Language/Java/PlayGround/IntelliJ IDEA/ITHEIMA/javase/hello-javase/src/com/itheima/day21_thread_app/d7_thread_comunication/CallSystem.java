package com.itheima.day21_thread_app.d7_thread_comunication;

/**
   呼叫系统。
 */
public class CallSystem {
    // 定义一个变量记录当前呼入进来的电话。
    public static int number = 0; // 最多只接听一个。

    /* 接入电话
     */
    public synchronized static void call() {
        try {
            number++;
            System.out.println("成功接入一个用户，等待分发~~~~");

            // 唤醒别人 : 1个
            CallSystem.class.notify();
            // 让当前线程对象进入等待状态。
            CallSystem.class.wait();

        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }

    /**
       分发电话
     */
    public synchronized static void receive() {
        try {
            String name = Thread.currentThread().getName();
            if(number == 1){
                System.out.println(name + "此电话已经分发给客服并接听完毕了~~~~~");
                number--;
                // 唤醒别人 : 1个
                CallSystem.class.notify();
                CallSystem.class.wait(); // 让当前线程等待
            }else {
                // 唤醒别人 : 1个
                CallSystem.class.notify();
                CallSystem.class.wait(); // 让当前线程等待
            }
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }
}
