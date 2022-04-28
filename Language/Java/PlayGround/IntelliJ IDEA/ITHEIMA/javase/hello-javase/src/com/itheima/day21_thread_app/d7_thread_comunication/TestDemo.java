package com.itheima.day21_thread_app.d7_thread_comunication;

public class TestDemo {
    public static void main(String[] args) {
        // 1、生产者线程：负责不断接收打进来的电话
        CallThread call = new CallThread();
        call.start();

        // 2、消费者线程：客服，每个客服每次接听一个电话
        ReceiveThread r1 = new ReceiveThread();
        r1.start();
    }
}
