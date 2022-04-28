package com.itheima.day07_oop_app.createobject;

/**
   目标：掌握自己设计类，并获得对象。
 */
public class Test {
    public static void main(String[] args) {
        // 如何去获取汽车的对象。
        Car c1 = new Car();
        System.out.println(c1);
        c1.name = "宝马X3";
        c1.price = 37.89;
        System.out.println(c1.name);
        System.out.println(c1.price);
        c1.start();
        c1.run();

        System.out.println("-------------------");
        Car c2 = new Car();
        c2.name = "奔驰GLC";
        c2.price = 39.89;
        System.out.println(c2.name);
        System.out.println(c2.price);
        c2.start();
        c2.run();
    }
}
