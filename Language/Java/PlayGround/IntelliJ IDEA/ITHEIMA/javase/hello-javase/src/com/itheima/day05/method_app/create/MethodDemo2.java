package com.itheima.day05.method_app.create;

public class MethodDemo2 {
    public static void main(String[] args) {
        // 目标：学习方法的完整定义格式，并理解其调用和执行流程
        int rs = add(100, 200);
        System.out.println("和是：" + rs);

        System.out.println("-----------------");
        int rs1 = add(200, 300);
        System.out.println("和是：" + rs1);

    }

    public static int add(int a, int b){
        int c = a + b;
        return c;
    }
}
