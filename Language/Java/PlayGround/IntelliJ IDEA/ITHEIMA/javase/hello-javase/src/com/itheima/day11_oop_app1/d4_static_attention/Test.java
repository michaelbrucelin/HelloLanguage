package com.itheima.day11_oop_app1.d4_static_attention;

public class Test {
    // 静态成员变量
    public static int onLineNumber;
    // 实例成员变量
    private String name;

    public static void getMax(){
        // 1、静态方法可以直接访问静态成员,不能访问实例成员。
        System.out.println(Test.onLineNumber);
        System.out.println(onLineNumber);
        inAddr();

        // System.out.println(name);

        // 3、静态方法中不能出现this关键字
        // System.out.println(this);
    }

    public void run(){
        // 2、实例方法可以直接访问静态成员，也可以访问实例成员
        System.out.println(Test.onLineNumber);
        System.out.println(onLineNumber);
        Test.getMax();
        getMax();

        System.out.println(name);
        sing();

        System.out.println(this);
    }

    public void sing(){
        System.out.println(this);
    }

    // 静态成员方法
    public static void inAddr(){
        System.out.println("我们在黑马程序员~~");
    }

    public static void main(String[] args) {

    }
}
