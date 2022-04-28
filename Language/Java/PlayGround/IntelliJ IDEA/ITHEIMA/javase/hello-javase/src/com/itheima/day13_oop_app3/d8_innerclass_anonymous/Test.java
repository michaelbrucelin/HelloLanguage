package com.itheima.day13_oop_app3.d8_innerclass_anonymous;

/**
      目标：学习匿名内部类的形式和特点。
 */
public class Test {
    public static void main(String[] args) {
        Animal a = new Animal(){
            @Override
            public void run() {
                System.out.println("老虎跑的块~~~");
            }
        };
        a.run();
    }
}

//class Tiger extends Animal{
//    @Override
//    public void run() {
//        System.out.println("老虎跑的块~~~");
//    }
//}

abstract class Animal{
    public abstract void run();
}