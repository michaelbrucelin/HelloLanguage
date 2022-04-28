package com.itheima.day11_oop_app1.d12_extends_constructor;

public class Cat extends Animal{
    public Cat(){
        super(); // 默认的，写不写都有，默认就是找父类无参数构造器
        System.out.println("==子类Cat无参数构造器被执行===");
    }

    public Cat(String n){
        super(); // 默认的，写不写都有，默认就是找父类无参数构造器
        System.out.println("==子类Cat有参数构造器被执行===");
    }
}
