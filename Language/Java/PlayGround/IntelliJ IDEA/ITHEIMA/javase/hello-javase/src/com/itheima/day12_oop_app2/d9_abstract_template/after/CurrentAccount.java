package com.itheima.day12_oop_app2.d9_abstract_template.after;

/**
  活期账户
 */
public class CurrentAccount extends Account {

    public CurrentAccount(String cardId,  double money) {
        super(cardId, money);
    }

    @Override
    public double calc() {
        // b.正式结算利息
        double result =  getMoney() * 0.0175; // 结算利息了
        return result;
    }

}
