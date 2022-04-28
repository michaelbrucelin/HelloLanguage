package com.itheima.day12_oop_app2.d3_final;

/**
    目标：明白final一些基本语法知识
 */
public class Test {
    // 属于类，只加载一次，可以共享 (常量)
    public static final String schoolName = "黑马";
    public static final String schoolName2;
    static{
        schoolName2 = "传智";
        // schoolName2 = "传智"; // 第二次赋值，报错了！
    }

    // 属于对象的！ (final基本上不会用来修饰实例成员变量，没有意义！)
    private final String name = "王麻子";

    public static void main(String[] args) {
       // final修饰变量，变量有且仅能被赋值一次。
        /* 变量有几种：
           局部变量。
           成员变量。
                -- 1、静态成员变量。
                -- 2、实例成员变量。
       */
        final int age;
        age = 12;
        // age = 20; // 第二次赋值，报错了！
        System.out.println(age);

        final double rate = 3.14;

        buy(0.8);

        // schoolName = "传智"; // 第二次赋值，报错了！
        Test t = new Test();
        // t.name = "麻子"; // 第二次赋值，报错了！
        System.out.println(t.name);
    }

    public static void buy(final double z){
        // z = 0.1; // 第二次赋值，报错了！
    }
}

/**
   final修饰类 类不能被继承了
 */
//final class Animal{
//}
//class Cat extends Animal{
//}

/**
   final修饰方法，方法不能被重写
 */
class Animal{
    public final void run(){
        System.out.println("动物可以跑~~");
    }
}

class Tiger extends Animal{
//    @Override
//    public void run() {
//        System.out.println("老虎跑的贼快~~~");
//    }
}