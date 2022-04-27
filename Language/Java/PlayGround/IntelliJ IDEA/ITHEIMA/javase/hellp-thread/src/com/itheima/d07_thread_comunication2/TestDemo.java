package com.itheima.d07_thread_comunication2;

public class TestDemo {
    public static void main(String[] args) {
        // 模拟生产消费的 存取钱  整存整取（10000）
        // 消费者：小红。 取钱的。
        // 生产者：干爹。 存钱的。
        // 1、共同账户。
        Account acc = new Account("ICBC-112", 0);
        // 2、创建2个线程分别代表小红 和 干爹
        new DrawThread(acc, "小红").start();
        new DrawThread(acc, "小明").start();
        new DepositThread(acc, "干爹").start();
        new DepositThread(acc, "亲爹").start();
        new DepositThread(acc, "岳父").start();

    }
}
