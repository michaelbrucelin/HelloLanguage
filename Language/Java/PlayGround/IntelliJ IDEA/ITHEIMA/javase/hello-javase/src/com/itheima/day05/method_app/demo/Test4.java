package com.itheima.day05.method_app.demo;

public class Test4 {
    public static void main(String[] args) {
        // 目标：理解方法的内存运行机制
        study();
    }

    public static void eat(){
        System.out.println("吃饭~");
    }

    public static void sleep(){
        System.out.println("睡觉~");
    }

    public static void study(){
        eat();
        System.out.println("学习~");
        sleep();
    }
}
