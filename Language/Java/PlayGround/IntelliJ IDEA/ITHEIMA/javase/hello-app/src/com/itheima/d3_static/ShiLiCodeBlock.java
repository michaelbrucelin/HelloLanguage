package com.itheima.d3_static;

public class ShiLiCodeBlock {
    public ShiLiCodeBlock(){
        System.out.println("---------------- 构造方法 ----------------");
    }

    {
        System.out.println("---------------- 实例代码块 ----------------");
    }

    // 如果直接执行此文件，不会执行实例（构造）代码块，因为实例代码块属于对象，不属于类
    public static void main(String[] args) {
        System.out.println("---------------- main方法 ----------------");
    }
}
