package com.itheima.d4_singleton;

public class LanHanSingletonDemo {
    public static void main(String[] args) {
        LanHanSingleton singleton1 = LanHanSingleton.getInstance();
        LanHanSingleton singleton2 = LanHanSingleton.getInstance();
        System.out.println(singleton1 == singleton2);  // 验证是否为同一个对象
    }
}
