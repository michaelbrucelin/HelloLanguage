package com.itheima.day07_oop_app.thisdemo;

/**
    目标：说出this关键字的作用，并学会其使用。
 */
public class ThisDemo {
    public static void main(String[] args) {
        Car c = new Car("宝马X3", 37.89);
        System.out.println(c);
        System.out.println(c.name);
        System.out.println(c.price);

        c.goWith("奔驰GLC");
    }
}
