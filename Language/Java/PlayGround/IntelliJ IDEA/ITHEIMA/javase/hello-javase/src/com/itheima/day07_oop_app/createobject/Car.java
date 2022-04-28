package com.itheima.day07_oop_app.createobject;

public class Car {
    // 属性（成员变量）
    String name; // 名称
    double price; // 价格

    // 行为（方法）
    public void start(){
        System.out.println(name + " 价格是：" + price +", 启动成功！");
    }

    public void run(){
        System.out.println(name + " 价格是：" + price +", 跑的很快！");
    }
}
