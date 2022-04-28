package com.itheima.day11_oop_app1.d10_extends_field_method;

public class ExtendsDemo2 {
    public static void main(String[] args) {
        Student s = new Student();
        s.run(); // 子类的
        System.out.println("-----------");
        s.go();
    }
}

class People{
    public void run(){
        System.out.println("可以跑~~");
    }
}

class Student extends People{
    public void run(){
        System.out.println("学生跑的贼快~~");
    }

    public void go(){
        run(); // 子类的
        super.run(); // 父类的
    }
}

