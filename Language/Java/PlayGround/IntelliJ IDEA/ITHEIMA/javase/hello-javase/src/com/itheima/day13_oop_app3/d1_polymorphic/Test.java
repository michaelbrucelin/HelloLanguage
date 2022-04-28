package com.itheima.day13_oop_app3.d1_polymorphic;

public class Test {
    public static void main(String[] args) {
        // 目标：先认识多态的形式
        // 父类  对象名称 = new 子类构造器();
        Animal a = new Dog();
        a.run(); // 方法调用：编译看左，运行看右
        System.out.println(a.name); // 方法调用：编译看左，运行也看左，动物名称

        Animal a1 = new Dog();
        a1.run();
        System.out.println(a1.name); // 动物名称
    }
}
