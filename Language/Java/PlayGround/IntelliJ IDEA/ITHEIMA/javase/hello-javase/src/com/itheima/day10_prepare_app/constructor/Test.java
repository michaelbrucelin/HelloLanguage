package com.itheima.day10_prepare_app.constructor;

public class Test {
    public static void main(String[] args) {
        User u = new User();
        System.out.println(u.getName());
        System.out.println(u.getPassWord());
        System.out.println(u.getAge());
        System.out.println(u.getLoginName());

        User u2 = new User("陆小凤", "lxf", "123456", 36);
        System.out.println(u2.getName());
        System.out.println(u2.getPassWord());
        System.out.println(u2.getAge());
        System.out.println(u2.getLoginName());
    }
}
