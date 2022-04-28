package com.itheima.day10_prepare_app.encapsulation;

public class Student {
    // 私有的成员只能在奔类中被访问
    private int age;

    public int getAge() {
        return age;
    }

    public void setAge(int age) {
        this.age = age;
    }
}
