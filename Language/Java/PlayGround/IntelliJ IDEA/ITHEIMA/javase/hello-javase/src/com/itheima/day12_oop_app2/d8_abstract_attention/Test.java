package com.itheima.day12_oop_app2.d8_abstract_attention;

public class Test {
    public static void main(String[] args) {
//        有得有失: 得到了抽象方法，失去了创建对象的能力。
       //   Animal a = new Animal();
//        抽象类为什么不能创建对象？
          // a.run();

//        类有的成员（成员变量、方法、构造器）抽象类都具备

//        抽象类中不一定有抽象方法，有抽象方法的类一定是抽象类

//        一个类继承了抽象类必须重写完抽象类的全部抽象方法，
//        否则这个类也必须定义成抽象类。

//        不能用abstract修饰变量、代码块、构造器。
    }
}

class Cat extends Animal{

    @Override
    public void run() {

    }

    @Override
    public void run2() {

    }
}