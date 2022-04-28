package com.itheima.day07_oop_app.constructor;

/**
    目标：明白构造器的作用和分类。(开发的人，理解能力好)
 */
public class ConstructorDemo {
    public static void main(String[] args) {
        Car c = new Car();
//        c.name = "";
//        c.price
        System.out.println(c.name);
        System.out.println(c.price);

        Car c2 = new Car("奔驰GLC", 39.78);
        System.out.println(c2.name);
        System.out.println(c2.price);
    }
}
