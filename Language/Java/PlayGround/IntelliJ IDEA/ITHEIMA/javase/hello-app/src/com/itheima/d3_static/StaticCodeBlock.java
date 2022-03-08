package com.itheima.d3_static;

public class StaticCodeBlock {
    public StaticCodeBlock(){
        System.out.println("---------------- 构造方法 ----------------");
    }

    static {
        System.out.println("---------------- 静态代码块 ----------------");
    }

    // 如果直接执行此文件，也是优先执行静态代码块，因为先加载类，才能执行main方法，而加载类时静态代码块就已经执行了
    public static void main(String[] args) {
        System.out.println("---------------- main方法 ----------------");
    }
}
