package com.itheima.day02.type;

public class TypeDemo1 {
    public static void main(String[] args) {
        // 目标：理解自动类型转换
        byte a = 20;
        int b = a; // 发生了自动类型转换
        System.out.println(a);
        System.out.println(b);

        int age = 23;
        double db = age; // 自动类型转换
        System.out.println(db);

        char ch = 'a'; // 00000000 01100001
        int code = ch; // 00000000 00000000 00000000 01100001
        System.out.println(code);
    }
}
