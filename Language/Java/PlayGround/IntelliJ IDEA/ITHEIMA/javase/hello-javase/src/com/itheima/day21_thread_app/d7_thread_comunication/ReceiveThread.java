package com.itheima.day21_thread_app.d7_thread_comunication;

/**
   接电话线程类
 */
public class ReceiveThread extends Thread{
    @Override
    public void run() {
        // 1号  2号
        while (true){
            CallSystem.receive();
        }
    }
}
