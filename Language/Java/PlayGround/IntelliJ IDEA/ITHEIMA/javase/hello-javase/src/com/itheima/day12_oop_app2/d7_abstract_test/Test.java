package com.itheima.day12_oop_app2.d7_abstract_test;

public class Test {
    public static void main(String[] args) {
        GoldCard c = new GoldCard();
        c.setMoney(10000); // 父类的
        c.setName("三石");
        c.pay(300);
        System.out.println("余额：" + c.getMoney());
    }
}
