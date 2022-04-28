package com.itheima.day07_oop_app.constructor;

public class Car {
    String name;
    double price;

    /**
      无参数构造器(默认存在的)
     */
    public Car(){
        System.out.println("无参数构造器被触发执行~~~");
    }

    /**
       有参数构造器
     */
    public Car(String n, double p){
        System.out.println("有参数构造器被触发执行~~~");
        name = n;
        price = p;
    }
}
