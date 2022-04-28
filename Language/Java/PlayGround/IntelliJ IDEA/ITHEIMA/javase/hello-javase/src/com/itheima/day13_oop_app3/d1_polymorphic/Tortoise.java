package com.itheima.day13_oop_app3.d1_polymorphic;

public class Tortoise extends Animal{
    public String name = "乌龟名称";

    @Override
    public void run() {
        System.out.println("🐢跑的非常慢~~~");
    }
}
