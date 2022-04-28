package com.itheima.day07_oop_app.encapsulation;

/**
    目标：学会面向对象的三大特征：封装的形式、作用。
 */
public class Test {
    public static void main(String[] args) {
        Student s = new Student();
        // s.age = -23;
        s.setAge(-23);
        System.out.println(s.getAge());
    }
}
