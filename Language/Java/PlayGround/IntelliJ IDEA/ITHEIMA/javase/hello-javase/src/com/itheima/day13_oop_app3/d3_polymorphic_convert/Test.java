package com.itheima.day13_oop_app3.d3_polymorphic_convert;

/**
     目标：学习多态形式下的类中转换机制。
 */
public class Test {
    public static void main(String[] args) {
        // 自动类型转换
        Animal a = new Dog();
        a.run();
//        a.lookDoor(); // 多态下无法调用子类独有功能

        // 强制类型转换:可以实现调用子类独有功能的
        Dog d = (Dog) a;
        d.lookDoor();

        // 注意：多态下直接强制类型转换，可能出现类型转换异常
        // 规定：有继承或者实现关系的2个类型就可以强制类型转换，运行时可能出现问题。
        // Tortoise t1 = (Tortoise) a;
        // 建议强制转换前，先判断变量指向对象的真实类型，再强制类型转换。
        if(a instanceof Tortoise){
            Tortoise t = (Tortoise) a;
            t.layEggs();
        }else if(a instanceof Dog){
            Dog d1 = (Dog) a;
            d1.lookDoor();
        }

        System.out.println("---------------------");
        Animal a1 = new Dog();
        go(a1);
    }

    public static void go(Animal a){
        System.out.println("预备~~~");
        a.run();
        // 独有功能
        if(a instanceof Tortoise){
            Tortoise t = (Tortoise) a;
            t.layEggs();
        }else if(a instanceof Dog){
            Dog d1 = (Dog) a;
            d1.lookDoor();
        }
        System.out.println("结束~~~~");
    }
}
