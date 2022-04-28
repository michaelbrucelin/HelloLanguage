package com.itheima.day12_oop_app2.d1_package;


import com.itheima.d1_package.demo1.Animal;
import com.itheima.d1_package.demo1.Cat;

public class Test {
    public static void main(String[] args) {
        // 导包：相同包下的类可以直接访问。
        Student s = new Student();

        // 不同包下的类必须导包才可以使用
        Animal a = new Animal();

        // 使用默认导包的类：demo1下的cat
        Cat c1 = new Cat();
        c1.run();

        // 指定使用demo2下的Cat类
        com.itheima.d1_package.demo2.Cat c2 = new  com.itheima.d1_package.demo2.Cat();
        c2.run();
    }
}
