package com.itheima.day11_oop_app1.d9_extends_feature;

public class ExtendsDemo {
    public static void main(String[] args) {
        // 子类是否可以继承私有的属性和行为呢？我认为可以的
        Student s = new Student();
//        System.out.println(s.age);
//        s.run();
    }
}

class C extends A{

}

class A{

}

class B{

}

class People{
    private int age = 21;
    private void run(){
        System.out.println("人跑的很快~~");
    }
}

class Student extends People{

}