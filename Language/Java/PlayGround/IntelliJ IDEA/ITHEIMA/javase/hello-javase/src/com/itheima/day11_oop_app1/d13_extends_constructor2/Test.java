package com.itheima.day11_oop_app1.d13_extends_constructor2;

public class Test {
    public static void main(String[] args) {
        Student s = new Student("张三", 21, "99期");
        System.out.println(s.getName());
        System.out.println(s.getAge());
        System.out.println(s.getClassName());
    }
}
