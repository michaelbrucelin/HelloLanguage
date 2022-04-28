package com.itheima.day07_oop_app.thisdemo;

public class Car {
    String name;
    double price;

    public void goWith(String name){
        System.out.println(this.name +"正在和：" + name +"比赛！");
    }

    /**
      无参数构造器(默认存在的)
     */
    public Car(){
        System.out.println("无参数构造器被触发执行~~~");
    }

    /**
       有参数构造器
     */
    public Car(String name, double price){
        System.out.println("有参数构造器被触发执行~~~");
        System.out.println(this);
        this.name = name;
        this.price = price;
    }
}
