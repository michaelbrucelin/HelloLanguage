package com.itheima.day11_oop_app1.d10_extends_field_method;

public class ExtendsDemo {
    public static void main(String[] args) {
        Wolf w = new Wolf();
        System.out.println(w.name); // 子类的
        w.showName();
    }
}

class Animal{
    public String name = "父类动物";
}

class Wolf extends Animal{
    public String name = "子类动物";

    public void showName(){
        String name = "局部名称";
        System.out.println(name); // 局部的
        System.out.println(this.name); // 子类name
        System.out.println(super.name); // 父类name
    }
}

