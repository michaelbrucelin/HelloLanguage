package com.itheima.day12_oop_app2.d7_abstract_test;

/**
   金卡
 */
public class GoldCard extends Card{
    @Override
    public void pay(double money) {
        // 优惠后的金额算出来：
        double rs = money * 0.8;
        double lastMoney = getMoney() - rs;
        System.out.println(getName() + "当前账户总金额："
                + getMoney() +",当前消费了：" + rs +",消费后余额剩余：" +
                lastMoney);

        setMoney(lastMoney); // 更新账户对象余额
    }
}
