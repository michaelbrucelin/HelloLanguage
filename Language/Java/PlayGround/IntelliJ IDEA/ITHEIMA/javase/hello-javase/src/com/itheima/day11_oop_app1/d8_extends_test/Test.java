package com.itheima.day11_oop_app1.d8_extends_test;

public class Test {
    public static void main(String[] args) {
        // 1、创建学生对象
        Student s = new Student();
        s.setName("张松松"); // 父类的
        s.setAge(25); // 父类的
        s.setClassName("Java999期"); // 子类的
        System.out.println(s.getName());
        System.out.println(s.getAge());
        System.out.println(s.getClassName());
        s.queryCourse(); // 父类的
        s.writeInfo(); // 子类的

    }
}
