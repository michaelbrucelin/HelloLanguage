package com.itheima.day05.method_app.param;

public class MethodDemo1 {
    public static void main(String[] args) {
        // 目标：理解Java的基本类型的参数传递：值传递。
        int a = 10;
        change(a);
        System.out.println(a); // 10
    }

    public static void change(int a){
        System.out.println(a); // 10
        a = 20;
        System.out.println(a); // 20
    }
}
