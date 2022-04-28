package com.itheima.day11_oop_app1.d6_singleinstance;

public class Test2 {
    public static void main(String[] args) {
        // 得到一个对象
        SingleInstance2 s1 = SingleInstance2.getInstance();
        SingleInstance2 s2 = SingleInstance2.getInstance();

        System.out.println(s1 == s2);
    }
}
