package com.itheima.d05_thread_synchronized_method;

/**
    账户类：余额，卡号
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

    /**
       小明 小红
       this == acc
       使用 synchronized 关键字修饰的方法是同步方法
       如果同步方法是实例方法，默认使用当前对象（this）加锁
       如果同步方法是静态方法，默认使用当前类（类名.class）加锁
     */
    public synchronized void drawMoney(double money) {
        // 1、拿到是谁来取钱
        String name = Thread.currentThread().getName();
        // 2、判断余额是否足够
        // 小明  小红
        if(this.money >= money){
            // 钱够了
            System.out.println(name+"来取钱，吐出：" + money);
            // 更新余额
            this.money -= money;
            System.out.println(name+"取钱后，余额剩余：" + this.money);
        }else{
            // 3、余额不足
            System.out.println(name+"来取钱，余额不足！");
        }
    }
}
