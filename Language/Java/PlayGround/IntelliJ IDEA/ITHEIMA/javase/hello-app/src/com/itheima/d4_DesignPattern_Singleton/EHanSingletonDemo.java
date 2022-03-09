package com.itheima.d4_DesignPattern_Singleton;

public class EHanSingletonDemo {
    public static void main(String[] args) {
        EHanSingleton instance1 = EHanSingleton.getInstance();
        EHanSingleton instance2 = EHanSingleton.getInstance();
        System.out.println(instance1 == instance2);  // 验证是否为同一个对象
    }
}
