package com.itheima.day11_oop_app1.d7_extends;

public class Test {
    public static void main(String[] args) {
        // 创建子类对象，看是否可以使用父类的属性和行为
        Student s = new Student();
        s.setName("西门"); // 父类的
        s.setAge(25);// 父类的
        System.out.println(s.getName());// 父类的
        System.out.println(s.getAge());// 父类的
        s.study();
    }
}
