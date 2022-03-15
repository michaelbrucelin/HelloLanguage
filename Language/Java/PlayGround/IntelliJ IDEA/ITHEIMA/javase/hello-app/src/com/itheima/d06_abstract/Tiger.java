package com.itheima.d06_abstract;

/**
 * 子类继承抽象类，必须实现抽象类中的所有抽象方法，除非子类也是抽象类
 */
public class Tiger extends Animal {
    @Override
    public void eat() {
        System.out.println(getName() +"吃肉");
    }

    @Override
    public void sleep() {
        System.out.println(getName() +"睡觉");
    }
}
