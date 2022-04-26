package com.itheima.d07_thread_comunication2;

/**
 * 线程类：存钱
 */
public class DepositThread extends Thread {
    private Account acc;

    public DepositThread(Account acc, String name) {
        super(name);
        this.acc = acc;
    }

    @Override
    public void run() {
        while (true) {
            acc.saveMoney(10000);
            try {
                Thread.sleep(1000);
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
    }
}
