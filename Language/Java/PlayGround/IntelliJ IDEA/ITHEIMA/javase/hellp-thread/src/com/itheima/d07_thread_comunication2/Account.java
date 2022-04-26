package com.itheima.d07_thread_comunication2;

/**
 * 账户类：余额，卡号
 */
public class Account {
    private String cardId;
    private double money; // 余额 关键信息

    public Account() {
    }

    public Account(String cardId, double money) {
        this.cardId = cardId;
        this.money = money;
    }

    public String getCardId() {
        return cardId;
    }

    public void setCardId(String cardId) {
        this.cardId = cardId;
    }

    public double getMoney() {
        return money;
    }

    public void setMoney(double money) {
        this.money = money;
    }


    // 小红 小明
    public synchronized void drawMoney(double money) {
        try {
            String name = Thread.currentThread().getName();
            if (this.money >= money) {
                // 有钱，取钱
                this.money -= money;
                System.out.println(name + "来取钱" + money + "成功，取钱后余额剩余：" + this.money);
                // 取钱后  唤醒别人等待自己
                this.notify(); // 唤醒别人：干爹
                this.wait(); // 等待了当前取钱线程：小红
            } else {
                // 没钱，唤醒别人等待自己
                this.notify();
                this.wait();
            }
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }

    // 干爹
    public synchronized void saveMoney(double money) {
        try {
            String name = Thread.currentThread().getName();
            if (this.money > 0) {
                // 有钱，不存钱
                // 唤醒别人等待自己
                this.notify(); // 唤醒别人：小红
                this.wait(); // 等待了当前取钱线程：干爹
            } else {
                // 没钱，存钱
                this.money += money;
                System.out.println(name + "来存钱，存钱后余额是：" + this.money);
                // 存钱后有钱：唤醒别人等待自己
                this.notify();
                this.wait();
            }
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
    }
}
