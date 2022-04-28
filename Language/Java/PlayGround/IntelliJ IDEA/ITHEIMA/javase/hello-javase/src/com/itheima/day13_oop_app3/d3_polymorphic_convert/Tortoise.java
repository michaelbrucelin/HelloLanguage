package com.itheima.day13_oop_app3.d3_polymorphic_convert;

public class Tortoise extends Animal {
    public String name = "乌龟名称";

    @Override
    public void run() {
        System.out.println("🐢跑的非常慢~~~");
    }

    /**
     独有功能
     */
    public void layEggs(){
        System.out.println("🐢在下蛋~~~");
    }
}
