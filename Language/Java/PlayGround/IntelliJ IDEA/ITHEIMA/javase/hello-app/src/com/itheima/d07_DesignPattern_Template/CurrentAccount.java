package com.itheima.d07_DesignPattern_Template;

/**
 * 活期账户
 */
public class CurrentAccount extends Account {

    public CurrentAccount(String cardId, double money) {
        super(cardId, money);
    }

    @Override
    public double calc() {
        // b.正式结算利息
        double result = getMoney() * 0.0175; // 结算利息了
        return result;
    }
}