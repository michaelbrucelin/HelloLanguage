package com.itheima.day11_oop_app1.d1_static_field;

public class User {
    // 在线人数信息：静态成员变量
    public static int onLineNumber = 161;
    // 实例成员变量
    private String name;
    private int age;

    public static void main(String[] args) {
        // 1、类名.静态成员变量
        User.onLineNumber++;
        // 注意：同一个类中访问静态成员变量，类名可以省略不写
        System.out.println(onLineNumber);

        // 2、对象.实例成员变量
        // System.out.println(name);
        User u1 = new User();
        u1.name = "猪八戒";
        u1.age = 36;
        System.out.println(u1.name);
        System.out.println(u1.age);
        // 对象.静态成员变量(不推荐这样访问)
        u1.onLineNumber++;

        User u2 = new User();
        u2.name = "孙悟空";
        u2.age = 38;
        System.out.println(u2.name);
        System.out.println(u2.age);
        // 对象.静态成员变量(不推荐这样访问)
        u2.onLineNumber++;

        System.out.println(onLineNumber);

    }
}
