package com.itheima.day13_oop_app3.d2_polymorphic_advantage;

public class Test {
    public static void main(String[] args) {
        Animal d = new Dog();
        go(d);
        // d.lookDoor();

        Animal t = new Tortoise();
        go(t);
    }

    /**
       希望这个方法可以接收一切子类动物对象
     * @param a
     */
    public static void go(Animal a){
        System.out.println("预备~~~");
        a.run();
        System.out.println("结束~~~~");
    }
}
