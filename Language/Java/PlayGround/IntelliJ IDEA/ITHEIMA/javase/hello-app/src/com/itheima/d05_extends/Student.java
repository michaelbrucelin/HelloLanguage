package com.itheima.d05_extends;

public class Student extends Person {
    public Student() {
        super();  // 调用父类的构造方法，这一句不写编译器也会给加进去
        System.out.println("子类的构造方法");
    }
}
