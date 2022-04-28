package com.itheima.day11_oop_app1.d5_static_codeblock;

public class TestDemo1 {

    public static String schoolName;

    public static void main(String[] args) {
        // 目标：学习静态代码块的特点、基本作用
        System.out.println("=========main方法被执行输出===========");
        System.out.println(schoolName);
    }

    /**
     特点：与类一起加载，自动触发一次，优先执行
     作用：可以在程序加载时进行静态数据的初始化操作（准备内容）
     */
    static{
        System.out.println("==静态代码块被触发执行==");
        schoolName = "黑马程序员";
    }
}
